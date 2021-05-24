using MediatR;
using Microsoft.EntityFrameworkCore;
using Sem.Application.Interfaces;
using Sem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sem.Application.Features.WorkItemFeatures.Queries
{
    public class GetAllWorkItemsQuery : IRequest<IEnumerable<WorkItem>>
    {
        public class GetAllWorkItemsQueryHandler : IRequestHandler<GetAllWorkItemsQuery, IEnumerable<WorkItem>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllWorkItemsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<WorkItem>> Handle(GetAllWorkItemsQuery query, CancellationToken cancellationToken)
            { 
                var workItemList = await _context.WorkItems.ToListAsync();
                if (workItemList == null)
                {
                    return null;
                }
                return workItemList.AsReadOnly();
            }
        }
    }
}
