using Isen.DotNet.Library.Models.Implementation;
using Microsoft.EntityFrameworkCore;

namespace Isen.DotNet.Library.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Departement> DepartementCollection { get; set; }
        public DbSet<Commune> CommuneCollection { get; set; }
        public DbSet<Adresse> AdresseCollection { get; set; }
        public DbSet<Categorie> CategorieCollection { get; set; }
        public DbSet<PointInteret> PointInteretCollection { get; set; }

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(
            ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Departement>()
                .ToTable("Departement");
            builder.Entity<Commune>()
                .ToTable("Commune")
                .HasMany(commune => commune.Adresses)
                .WithOne(adresse => adresse.Commune)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Adresse>()
                .ToTable("Adresse")
                .HasOne(adresse => adresse.Commune)
                .WithMany(commune => commune.Adresses)
                .HasForeignKey(adresse => adresse.CommuneId)
                .OnDelete(DeleteBehavior.SetNull);
            builder.Entity<Categorie>()
                .ToTable("Categorie");
            builder.Entity<PointInteret>()
                .ToTable("PointInteret")
                .HasOne(point => point.Adresse)
                .WithMany(adresse => adresse.Points)
                .HasForeignKey(point => point.AdresseId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}