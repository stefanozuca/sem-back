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
    public class GetAllHistoricalCounterQuery : IRequest<HistoricalCounter>
    {
        public class GetAllHistoricalCounterQueryHandler : IRequestHandler<GetAllHistoricalCounterQuery, HistoricalCounter>
        {
            private readonly IApplicationDbContext _context;
            public GetAllHistoricalCounterQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<HistoricalCounter> Handle(GetAllHistoricalCounterQuery request, CancellationToken cancellationToken)
            {
                return await _context.Counters.FirstAsync();
            }
        }
    }
}
