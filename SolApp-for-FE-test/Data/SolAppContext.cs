using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BaseWebApi.Models;

namespace BaseWebApi.Data
{
    public class SolAppContext : DbContext
    {
        public SolAppContext (DbContextOptions<SolAppContext> options)
            : base(options)
        {
        }

        public DbSet<BaseWebApi.Models.Cow>? Cow { get; set; }
    }
}
