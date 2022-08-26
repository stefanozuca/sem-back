using MediatR;
using Microsoft.EntityFrameworkCore;
using Sem.Application.Interfaces;
using Sem.Domain.External.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sem.Application.Features.BlogFeatures.Queries
{
    public class GetAllBlogFavsQuery : IRequest<IEnumerable<Blog>>
    {
        public class GetAllBlogQueryHandler : IRequestHandler<GetAllBlogFavsQuery, IEnumerable<Blog>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllBlogQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Blog>> Handle(GetAllBlogFavsQuery request, CancellationToken cancellationToken)
            {
                var list = await _context.Blogs.Where(x=>x.IsFavorite).ToListAsync();

                if (list == null) return null;

                return list.AsReadOnly();
            }
        }
    }
}
