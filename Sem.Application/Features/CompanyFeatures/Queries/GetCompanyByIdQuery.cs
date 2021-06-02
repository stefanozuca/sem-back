using MediatR;
using Sem.Application.Interfaces;
using Sem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sem.Application.Features.CompanyFeatures.Queries
{
    public class GetCompanyByIdQuery : IRequest<Company>
    {
        public int Id { get; set; }

        public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, Company>
        {
            private readonly IApplicationDbContext _context;
            public GetCompanyByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Company> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
            {
                var company = _context.Companies.Where(x => x.CompanyId == request.Id).FirstOrDefault();

                return company == null ? null : company;
            }
        }
    }
}
