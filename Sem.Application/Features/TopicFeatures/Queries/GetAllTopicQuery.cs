using MediatR;
using Microsoft.EntityFrameworkCore;
using Sem.Application.Interfaces;
using Sem.Domain.External.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sem.Application.Features.TopicFeatures.Queries
{
    public class GetAllTopicQuery : IRequest<IEnumerable<Topic>>
    {
        public class GetAllTopicQueryHandler : IRequestHandler<GetAllTopicQuery, IEnumerable<Topic>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllTopicQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
           
            public async Task<IEnumerable<Topic>> Handle(GetAllTopicQuery request, CancellationToken cancellationToken)
            {
                var listIds = new List<int> { 2, 3, 4 };

                var list = await _context.Topics.Where(x=>listIds.Contains(x.Id)).ToListAsync();

                if (list == null) return null;

                return list.AsReadOnly();
            }
        }
    }
}
