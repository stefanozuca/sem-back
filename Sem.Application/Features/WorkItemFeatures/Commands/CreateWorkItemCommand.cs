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
    public class CreateWorkItemCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }

        public class CreateWorkItemCommandHandler : IRequestHandler<CreateWorkItemCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateWorkItemCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateWorkItemCommand request, CancellationToken cancellationToken)
            {
                var workItem = new WorkItem();
                workItem.Title = request.Title;
                workItem.Description = request.Description;
                workItem.Company = _context.Companies.Where(c => c.CompanyId == request.CompanyId).FirstOrDefault();

                _context.WorkItems.Add(workItem);
                await _context.SaveChangesAsync();
                var a = _context.Companies;
                return workItem.WorkItemId;
            }
        }
    }
}
