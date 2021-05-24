using MediatR;
using Microsoft.EntityFrameworkCore;
using Sem.Application.Interfaces;
using Sem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sem.Application.Features.CompanyFeatures.Queries
{
    public class GetAllCompaniesQuery : IRequest<IEnumerable<Company>>
    {
        public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, IEnumerable<Company>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllCompaniesQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Company>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
            {
                var companies = await _context.Companies.ToListAsync();

                return companies == null ? null : companies.AsReadOnly();
            }
        }
    }
}
