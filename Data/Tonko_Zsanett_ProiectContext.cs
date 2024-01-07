using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tonko_Zsanett_Proiect.Models;

namespace Tonko_Zsanett_Proiect.Data
{
    public class Tonko_Zsanett_ProiectContext : DbContext
    {
        public Tonko_Zsanett_ProiectContext(DbContextOptions<Tonko_Zsanett_ProiectContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produs>().HasOne(e => e.Cumparat).WithOne(e => e.Produs).HasForeignKey<Cumparat>("ProdusID");
        }

        public DbSet<Tonko_Zsanett_Proiect.Models.Produs> Produs { get; set; } = default!;
        public DbSet<Tonko_Zsanett_Proiect.Models.Furnizor> Furnizor { get; set; } = default!;
        public DbSet<Tonko_Zsanett_Proiect.Models.Category> Category { get; set; } = default!;
        public DbSet<Tonko_Zsanett_Proiect.Models.Cumparat> Cumparat { get; set; } = default!;
        public DbSet<Tonko_Zsanett_Proiect.Models.User> User { get; set; } = default!;
    }
}
