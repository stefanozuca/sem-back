using MediatR;
using Microsoft.EntityFrameworkCore;
using Sem.Application.Interfaces;
using Sem.Domain.External.Entities;
using System.Collections.Generic;
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
                var list = await _context.Topics.ToListAsync();

                if (list == null) return null;

                return list.AsReadOnly();
            }
        }
    }
}
