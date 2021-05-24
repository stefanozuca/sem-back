using MediatR;
using Sem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sem.Application.Features.CompanyFeatures.Commands
{
    public class UpdateCompanyCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateCompanyCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
            {
                var company = _context.Companies.Where(x => x.Id == request.Id).FirstOrDefault();

                if (company == null) return default;

                company.Name = request.Name;
                await _context.SaveChangesAsync();
                return company.Id;
            }
        }
    }
}
