using MediatR;
using Sem.Application.Interfaces;
using Sem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sem.Application.Features.WorkItemFeatures.Commands
{
    public class UpdateWorkItemCommand : IRequest<int>
    {
        public int WorkItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }

        public class UpdateWorkItemCommandHandler : IRequestHandler<UpdateWorkItemCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateWorkItemCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateWorkItemCommand request, CancellationToken cancellationToken)
            {
                var workItem = _context.WorkItems.Where(x => x.WorkItemId == request.WorkItemId).FirstOrDefault();

                if (workItem == null)
                {
                    return default;
                }
                else
                {
                    workItem.Title = request.Title;
                    workItem.Description = request.Description;
                    workItem.Company = _context.Companies.Where(c => c.CompanyId == request.CompanyId).FirstOrDefault();
                    await _context.SaveChangesAsync();
                    return workItem.WorkItemId;
                }
            }
        }
    }
}
