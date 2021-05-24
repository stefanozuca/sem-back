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
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int IdEmpresa { get; set; }

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
                workItem.Titulo = request.Titulo;
                workItem.Descripcion = request.Descripcion;
                workItem.Empresa = _context.Companies.Where(c => c.Id == request.IdEmpresa).FirstOrDefault();

                _context.WorkItems.Add(workItem);
                await _context.SaveChangesAsync();
                return workItem.Id;
            }
        }
    }
}
