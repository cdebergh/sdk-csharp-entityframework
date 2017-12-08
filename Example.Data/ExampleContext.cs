using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Example.Model;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Example.Data
{
    public class ExampleContext : DbContext
    {
        public DbSet<ExampleEntity> ExampleEntitys { get; set; }

        public ExampleContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<ExampleEntity>()
              .ToTable("ExampleEntity");

            modelBuilder.Entity<ExampleEntity>()
                .Property(u => u.Name)
                .HasMaxLength(100)
                .IsRequired();

        }
    }
}
