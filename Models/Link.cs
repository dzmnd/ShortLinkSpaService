using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortLinkSpaService.Models
{
    public class Link
    {
        public long LinkId { get; set; }
        public string ShortLink { get; set; }
        public string LongLink { get; set; }
    }
}
