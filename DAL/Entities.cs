using System.Data.Entity;
using BO;
using DAL.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<CategorieCourse> CategorieCourse { get; set; }
        public virtual DbSet<CategoriePoint> CategoriePoint { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Departement> Departement { get; set; }
        public virtual DbSet<Evenement> Evenement { get; set; }
        public virtual DbSet<Participation> Participation { get; set; }
        public virtual DbSet<Point> Point { get; set; }
        public virtual DbSet<TypeManifestation> TypeManifestation { get; set; }
        public virtual DbSet<TypeDePaiement> TypeDePaiement { get; set; }
        public virtual DbSet<Ville> Ville { get; set; }

        public ApplicationDbContext()
            : base("2QXRunning", throwIfV1Schema: false)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //one-to-many 
            modelBuilder.Entity<Course>()
                        .HasRequired(c => c.Evenement) // Student entity requires Standard 
                        .WithMany(s => s.Courses); // Standard entity includes many Students entities


           // modelBuilder.Entity<EvenementTypeDePaiement>()
           //.HasKey(t => new { t.EvenementId, t.TypeDePaiementId });

            modelBuilder.Entity<Evenement>()
                .HasMany(e => e.TypesDePaiement)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("EvenementId");
                    m.MapRightKey("TypeDePaiementId");
                    m.ToTable("EvemenentTypeDePaiement");
                });

            base.OnModelCreating(modelBuilder);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }
    }
}
