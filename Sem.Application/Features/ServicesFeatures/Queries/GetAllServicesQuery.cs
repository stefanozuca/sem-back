using MediatR;
using Sem.Domain.External.Entities;
using Sem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sem.Application.Features.ServicesFeatures.Queries
{
    public class GetAllServicesQuery : IRequest<IEnumerable<Service>>
    {
        public class GetAllServicesQueryHandler : IRequestHandler<GetAllServicesQuery, IEnumerable<Service>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllServicesQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Service>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
            {
                var list = await _context.Services.ToListAsync();

                if (list == null) return null;

                return list.AsReadOnly();
            }
        }
    }
}
