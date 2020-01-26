using ShortLinkSpaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortLinkSpaService.Services
{
    public interface IShortLinkService
    {
        Link CreateShortLink(Link link);
        string GetLongLink(string shortLink);
    }
}
