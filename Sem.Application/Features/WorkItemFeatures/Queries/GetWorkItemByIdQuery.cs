using MediatR;
using Sem.Application.Interfaces;
using Sem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sem.Application.Features.WorkItemFeatures.Queries
{
    public class GetWorkItemByIdQuery : IRequest<WorkItem>
    {
        public int Id { get; set; }
        public class GetWorkItemByIdQueryHandler : IRequestHandler<GetWorkItemByIdQuery, WorkItem>
        {
            private readonly IApplicationDbContext _context;
            public GetWorkItemByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<WorkItem> Handle(GetWorkItemByIdQuery request, CancellationToken cancellationToken)
            {
                var workItem = _context.WorkItems.Where(x => x.Id == request.Id).FirstOrDefault();
                if (workItem == null) return null;
                return workItem;
            }
        }

    }
}
