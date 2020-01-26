using ShortLinkSpaService.Context;
using ShortLinkSpaService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ShortLinkSpaService.Services
{
    public class ShortLinkService : IShortLinkService
    {
        private readonly ShortLinkContext _shortLinkContext;
        public ShortLinkService(ShortLinkContext shortLinkContext)
        {
            _shortLinkContext = shortLinkContext;
        }
        public Link CreateShortLink(Link link)
        {
            try
            {
                link.ShortLink = SerializeLink(link.LongLink);
                this._shortLinkContext.Links.Add(link);
                this._shortLinkContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return link;
        }

        public string GetLongLink(string shortLink)
        {
            string longLink = string.Empty;
            try
            {
                longLink = this._shortLinkContext.Links.FirstOrDefault(l => l.ShortLink == shortLink)?.LongLink;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return longLink;
        }

        private string SerializeLink(string longLink)
        {
            string serializeLink = string.Empty;
            BinaryFormatter binF = new BinaryFormatter();
            MemoryStream memStr = new MemoryStream();
            binF.Serialize(memStr, longLink);
            byte[] objBytes = memStr.ToArray();

            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(objBytes);
                serializeLink = Convert.ToBase64String(hash).Replace("/", "").Replace("=", "");
            }

            return serializeLink;
        }
    }
}
