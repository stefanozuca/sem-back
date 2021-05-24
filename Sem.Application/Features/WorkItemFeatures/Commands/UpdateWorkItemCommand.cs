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
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int IdEmpresa { get; set; }

        public class UpdateWorkItemCommandHandler : IRequestHandler<UpdateWorkItemCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateWorkItemCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateWorkItemCommand request, CancellationToken cancellationToken)
            {
                var workItem = _context.WorkItems.Where(x => x.Id == request.Id).FirstOrDefault();

                if (workItem == null)
                {
                    return default;
                }
                else
                {
                    workItem.Titulo = request.Titulo;
                    workItem.Descripcion = request.Descripcion;
                    workItem.Empresa = _context.Companies.Where(c => c.Id == request.IdEmpresa).FirstOrDefault();
                    await _context.SaveChangesAsync();
                    return workItem.Id;
                }
            }
        }
    }
}
