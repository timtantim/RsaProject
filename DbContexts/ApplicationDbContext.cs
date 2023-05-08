using Microsoft.EntityFrameworkCore;
using RsaProject.Model;
using System;

namespace RsaProject.DbContexts
{
    public class ApplicationDbContext:DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
        }

        public DbSet<Bom> Bom { get; set; }

        public DbSet<BomHead> BomHead { get; set; }

        public DbSet<BomDetail> BomDetail { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BomHead>()
                .HasIndex(p => new { p.BomCode })
                .IsUnique(true);
        }
    }
}
