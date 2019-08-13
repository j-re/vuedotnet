using ECommerce.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using vue.Data.Entities;

namespace vue.Data
{
    public class VueContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public VueContext(DbContextOptions<VueContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
            .HasIndex(b => b.Slug)
            .IsUnique();
        }
    }
}