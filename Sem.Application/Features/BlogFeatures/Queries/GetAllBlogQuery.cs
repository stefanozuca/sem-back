using MediatR;
using Sem.Application.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using Sem.Domain.External.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Sem.Application.Features.BlogFeatures.Queries
{
    public class GetAllBlogQuery : IRequest<IEnumerable<Blog>>
    {
        public class GetAllBlogQueryHandler : IRequestHandler<GetAllBlogQuery, IEnumerable<Blog>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllBlogQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Blog>> Handle(GetAllBlogQuery request, CancellationToken cancellationToken)
            {
                var list = await _context.Blogs.ToListAsync();

                if (list == null) return null;

                return list.AsReadOnly();
            }
        }
    }
}
