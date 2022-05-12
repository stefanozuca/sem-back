using MediatR;
using Sem.Application.Interfaces;
using Sem.Domain.External.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sem.Application.Features.HistoricalFeatures.Command
{
    public class CreateHistoricalCounterCommand : IRequest<int>
    {
        public int Felices { get; set; }
        public int Proyectos { get; set; }
        public int Horas { get; set; }
        public int Trabajadores { get; set; }

        public class CreateHistoricalFeatureCommandHandler : IRequestHandler<CreateHistoricalCounterCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateHistoricalFeatureCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateHistoricalCounterCommand request, CancellationToken cancellationToken)
            {
                var counter = new HistoricalCounter();
                counter.Felices = request.Felices;
                counter.Proyectos = request.Proyectos;
                counter.Horas = request.Horas;
                counter.Trabajadores = request.Trabajadores;

                _context.Counters.Add(counter);
                await _context.SaveChangesAsync();
                return counter.Id;
            }
        }
    }
}
