using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lotionApp.Models;

namespace lotion_app.Data
{
    public class lotion_appContext : DbContext
    {
        public lotion_appContext (DbContextOptions<lotion_appContext> options)
            : base(options)
        {
        }

        //public DbSet<lotionApp.Models.Lotion> Lotion { get; set; } = default!;
        public DbSet<Lotion> Lotions { get; set; }
    }
}
