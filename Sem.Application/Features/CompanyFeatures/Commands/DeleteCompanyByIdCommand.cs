using MediatR;
using Sem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sem.Application.Features.CompanyFeatures.Commands
{
    public class DeleteCompanyByIdCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteCompanyByIdCommandHandler : IRequestHandler<DeleteCompanyByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteCompanyByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(DeleteCompanyByIdCommand request, CancellationToken cancellationToken)
            {
                var company = _context.Companies.Where(x => x.CompanyId == request.Id).FirstOrDefault();
                if (company == null) return default;
                _context.Companies.Remove(company);
                await _context.SaveChangesAsync();
                return company.CompanyId;
            }
        }
    }
}
