using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Orgnzr.Models;
using Microsoft.EntityFrameworkCore;

namespace Orgnzr.Data
{
    public class contactContext : DbContext
    {
        public contactContext(DbContextOptions<contactContext> options) : base(options)
        {

        }

        public DbSet<ClientContact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientContact>().ToTable("Contact");
        }
    }
}
