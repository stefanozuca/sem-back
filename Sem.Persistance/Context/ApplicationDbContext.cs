using Microsoft.EntityFrameworkCore;
using Sem.Application.Interfaces;
using Sem.Domain.Entities;
using Sem.Domain.External.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sem.Persistance.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Navigation> Navigations { get; set; }
        public DbSet<HistoricalCounter> Counters { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Blog> Blogs { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
