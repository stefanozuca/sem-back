using MediatR;
using Sem.Application.Interfaces;
using Sem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sem.Application.Features.CompanyFeatures.Commands
{
    public class CreateCompanyCommand : IRequest<int>
    {
        public string Name { get; set; }

        public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateCompanyCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
            {
                var company = new Company();
                company.Name = request.Name;
                _context.Companies.Add(company);
                await _context.SaveChangesAsync();
                return company.Id;
            }
        }
    }
}
