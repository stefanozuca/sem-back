using MediatR;
using Sem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sem.Application.Features.WorkItemFeatures.Commands
{
    public class DeleteWorkItemByIdCommand : IRequest<int>
    {
        public int WorkItemId { get; set; }

        public class DeleteWorkItemByIdCommandHandler : IRequestHandler<DeleteWorkItemByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteWorkItemByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(DeleteWorkItemByIdCommand request, CancellationToken cancellationToken)
            {
                var workItem = _context.WorkItems.Where(x => x.WorkItemId == request.WorkItemId).FirstOrDefault();
                if (workItem == null) return default;
                _context.WorkItems.Remove(workItem);
                await _context.SaveChangesAsync();
                return workItem.WorkItemId;
            }
        }
    }
}
