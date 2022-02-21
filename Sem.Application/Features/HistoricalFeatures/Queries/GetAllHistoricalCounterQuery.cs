using MediatR;
using Sem.Application.Interfaces;
using Sem.Domain.External.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace Sem.Application.Features.HistoricalFeatures.Queries
{
    public class GetAllHistoricalCounterQuery : IRequest<IEnumerable<HistoricalCounter>>
    {
        public class GetAllHistoricalCounterQueryHandler : IRequestHandler<GetAllHistoricalCounterQuery, IEnumerable<HistoricalCounter>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllHistoricalCounterQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<HistoricalCounter>> Handle(GetAllHistoricalCounterQuery request, CancellationToken cancellationToken)
            {
                var list = await _context.Counters.ToListAsync();

                if (list == null) return null;

                return list.AsReadOnly();
            }
        }
    }
}
