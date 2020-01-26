using Microsoft.AspNetCore.Mvc;
using ShortLinkSpaService.Models;
using ShortLinkSpaService.Services;
using System.Threading.Tasks;

namespace ShortLinkSpaService.Controllers
{
    [Produces("application/json")]
    public class ShortLinkController : Controller
    {
        private readonly IShortLinkService _shortLinkService;
        public ShortLinkController(IShortLinkService shortLinkService)
        {
            _shortLinkService = shortLinkService;
        }

        [HttpPost]
        public Link CreateShortLink([FromBody]Link link) 
        {
            return this._shortLinkService.CreateShortLink(link);
        }

        public string GetLongLink(string shortLink)
        {
            return this._shortLinkService.GetLongLink(shortLink);
        }
    }
}
