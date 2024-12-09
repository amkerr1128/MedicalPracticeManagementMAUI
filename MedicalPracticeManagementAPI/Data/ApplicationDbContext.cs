using Microsoft.EntityFrameworkCore;
using MedicalPracticeManagementMAUI.Models;

namespace MedicalPracticeManagementAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Treatment> Treatments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Correct column type for SQLite compatibility
            modelBuilder.Entity<Treatment>()
                .Property(t => t.Name)
                .HasColumnType("TEXT");

            modelBuilder.Entity<Treatment>()
                .Property(t => t.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}