using System;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        // initializers for the tables in the Orgnzr database
        public DbSet<ClientContact> Contacts { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Services> Services { get; set; }


      /*  protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=OrgnzrDB;Integrated Security=True");
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientContact>().ToTable("Contact");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Services>().ToTable("Services");
        }
        
    }
}
