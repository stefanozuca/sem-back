using Microsoft.EntityFrameworkCore;
using Sem.Domain.Entities;
using Sem.Domain.External.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sem.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Topic> Topics { get; set; }
        DbSet<Service> Services { get; set; }
        DbSet<Navigation> Navigations { get; set; }
        DbSet<HistoricalCounter> Counters { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<Blog> Blogs { get; set; }
        DbSet<Company> Companies { get; set; }
        Task<int> SaveChangesAsync();
    }
}
