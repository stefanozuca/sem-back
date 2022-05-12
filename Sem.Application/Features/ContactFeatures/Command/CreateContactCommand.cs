using MediatR;
using Sem.Application.Interfaces;
using Sem.Domain.External.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sem.Application.Features.ContactFeatures.Command
{
    public class CreateContactCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Href { get; set; }
        public string Target { get; set; }

        public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateContactCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateContactCommand request, CancellationToken cancellationToken)
            {
                var blog = new Contact();
                blog.Title = request.Title;
                blog.Content = request.Content;
                blog.Href = request.Href;
                blog.Target = request.Target;

                _context.Contacts.Add(blog);
                await _context.SaveChangesAsync();
                return blog.Id;
            }
        }
    }
}
