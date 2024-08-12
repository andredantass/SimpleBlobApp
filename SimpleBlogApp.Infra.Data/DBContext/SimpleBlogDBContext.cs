using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SimpleBlogApp.Domain.Entities;

namespace SimpleBlogApp.Infra.Data.DBContext
{
    public class SimpleBlogDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Post> Post { get; set; }
        public SimpleBlogDbContext(DbContextOptions<SimpleBlogDbContext> options) 
            : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            modelBuilder.Entity<User>().Property(x => x.Id).HasDefaultValue("NEWID()");
            modelBuilder.Entity<Post>().Property(x => x.Id).HasDefaultValue("NEWID()");

            modelBuilder.Ignore<Notification>();
            base.OnModelCreating(modelBuilder);
        }
        public class IntegrationContextFactory : IDesignTimeDbContextFactory<SimpleBlogDbContext>
        {
            public SimpleBlogDbContext CreateDbContext(string[] args)
            {
                var optionBuilder = new DbContextOptionsBuilder<SimpleBlogDbContext>();

                optionBuilder.UseSqlServer("Data Source=localhost;Database=SimpleBlogDb;Trusted_Connection=True;Trust Server Certificate = true;");

                return new SimpleBlogDbContext(optionBuilder.Options);
            }
        }
    }
}
