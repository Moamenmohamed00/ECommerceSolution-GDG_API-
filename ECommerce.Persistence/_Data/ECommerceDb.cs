using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Entities;
namespace ECommerce.Persistence._Data
{
    public class ECommerceDb : DbContext
    {
        public ECommerceDb(DbContextOptions<ECommerceDb> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // modelBuilder.ApplyConfigurationsFromAssembly(typeof(ECommerceDb).Assembly);
            modelBuilder.Entity<Product>()
    .Property(p => p.Price)
    .HasPrecision(18, 2);

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ECommerce.Domain.Entities.Type> Types { get; set; } 
    }
}

