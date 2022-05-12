using MediatR;
using Sem.Application.Interfaces;
using Sem.Domain.External.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sem.Application.Features.ServicesFeatures.Command
{
    public class CreateServiceCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }

        public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateServiceCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
            {
                var service = new Service();
                service.ImagePath = request.ImagePath;
                service.Title = request.Title;
                service.Content = request.Content;

                _context.Services.Add(service);
                await _context.SaveChangesAsync();
                return service.Id;
            }
        }
    }
}
