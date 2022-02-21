using MediatR;
using Sem.Application.Interfaces;
using Sem.Domain.External.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sem.Application.Features.BlogFeatures.Command
{
    public class CreateBlogCommand : IRequest<int>
    {
        public DateTime Date { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public bool IsFavorite { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateBlogCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
            {
                var blog = new Blog();
                blog.Date = request.Date;
                blog.ImagePath = request.ImagePath;
                blog.IsFavorite = request.IsFavorite;
                blog.Title = request.Title;
                blog.Description = request.Description;
                blog.Content = request.Content;

                _context.Blogs.Add(blog);
                await _context.SaveChangesAsync();
                return blog.Id;
            }
        }
    }
}
