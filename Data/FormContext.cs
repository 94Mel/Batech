using Batech.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Batech.Data
{
    public class FormContext : DbContext
    {

        public FormContext(DbContextOptions<FormContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Form> Forms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=45.84.189.34\\MSSQLSERVER2022;Database=batechco_DB;User Id=batechco_DB;Password=FrSsKBKw0Nk3sf34;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Visitor>()
            // .HasOne(v => v.User)
            // .WithOne()
            // .HasForeignKey<Visitor>(v => v.Userid);


            base.OnModelCreating(builder);

            builder.HasDefaultSchema("batechco_DB");
            builder.Entity<Form>(entity =>
            {
                entity.ToTable(name: "Form");
            });
        }
    }
}
