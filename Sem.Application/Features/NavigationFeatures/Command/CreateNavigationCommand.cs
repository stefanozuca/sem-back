using MediatR;
using Sem.Application.Interfaces;
using Sem.Domain.External.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sem.Application.Features.NavigationFeatures.Command
{
    public class CreateNavigationCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Href { get; set; }
        public bool Current { get; set; }

        public class CreateNavigationCommandHandler : IRequestHandler<CreateNavigationCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateNavigationCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateNavigationCommand request, CancellationToken cancellationToken)
            {
                var navigation = new Navigation();
                navigation.Name = request.Name;
                navigation.Href = request.Href;
                navigation.Current = request.Current;

                _context.Navigations.Add(navigation);
                await _context.SaveChangesAsync();
                return navigation.Id;
            }
        }
    }
}
