using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;
using A2SPA.Data.Models;

namespace A2SPA.Data
{
    public partial class A2SPAContext : DbContext
    {
        //public A2SPAContext(DbContextOptions<A2SPAContext> options) : base(options) { }
        public A2SPAContext(IOptions<AppSettings> appSettings)
        {
            ConnectionString = appSettings.Value.ConnectionString;
        }

        public string ConnectionString { get; }

        public virtual DbSet<TestData> TestData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=A2SPA;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer(ConnectionString);
            base.OnConfiguring(optionsBuilder);
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestData>(entity =>
            {
                entity.Property(e => e.CreateDtm).HasColumnType("datetime");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Currency).HasColumnType("numeric");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.UpdateDtm).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20);
            });
        }
    }
}