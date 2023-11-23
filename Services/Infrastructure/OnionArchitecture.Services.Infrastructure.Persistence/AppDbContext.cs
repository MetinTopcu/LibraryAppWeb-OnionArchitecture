using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Services.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace OnionArchitecture.Services.Infrastructure.Persistence
{
    public class AppDbContext : DbContext //DbContext ile EF den yararlanıyoruz.
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; } //DB de Books sütunu

        public DbSet<Category> Categories { get; set; } //DB de Categories sütunu

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // tüm configuration dosyalarını buluyor işliyor
            base.OnModelCreating(modelBuilder);
        }
    }
}
