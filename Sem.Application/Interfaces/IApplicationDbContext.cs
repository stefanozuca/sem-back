using Microsoft.EntityFrameworkCore;
using Sem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sem.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<WorkItem> WorkItems { get; set; }
        DbSet<Company> Companies { get; set; }
        Task<int> SaveChangesAsync();
    }
}
