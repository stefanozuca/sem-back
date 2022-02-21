using MediatR;
using Sem.Application.Interfaces;
using Sem.Domain.External.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace Sem.Application.Features.ContactFeatures.Queries
{
    public class GetAllContactQuery : IRequest<IEnumerable<Contact>>
    {
        public class GetAllContactQueryHandler : IRequestHandler<GetAllContactQuery, IEnumerable<Contact>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllContactQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Contact>> Handle(GetAllContactQuery request, CancellationToken cancellationToken)
            {
                var list = await _context.Contacts.ToListAsync();

                if (list == null) return null;

                return list.AsReadOnly();
            }
        }
    }
}
