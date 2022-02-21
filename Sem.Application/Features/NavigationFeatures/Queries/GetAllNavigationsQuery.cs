using MediatR;
using Sem.Application.Interfaces;
using Sem.Domain.External.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace Sem.Application.Features.NavigationFeatures.Queries
{
    public class GetAllNavigationsQuery : IRequest<IEnumerable<Navigation>>
    {
        public class GetAllNavigationsQueryHandler : IRequestHandler<GetAllNavigationsQuery, IEnumerable<Navigation>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllNavigationsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Navigation>> Handle(GetAllNavigationsQuery request, CancellationToken cancellationToken)
            {
                var list = await _context.Navigations.ToListAsync();

                if (list == null) return null;

                return list.AsReadOnly();
            }
        }
    }
}
