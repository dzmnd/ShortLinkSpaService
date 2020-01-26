using Microsoft.EntityFrameworkCore;
using ShortLinkSpaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortLinkSpaService.Context
{
    public class ShortLinkContext : DbContext
    {
        public ShortLinkContext(DbContextOptions options) : base(options) { }
        public DbSet<Link> Links { get; set; }
    }
}
