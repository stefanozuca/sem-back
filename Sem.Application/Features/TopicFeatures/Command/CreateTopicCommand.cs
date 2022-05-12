using MediatR;
using Sem.Application.Interfaces;
using Sem.Domain.External.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sem.Application.Features.TopicFeatures.Command
{
    public class CreateTopicCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public class CreateTopicCommandHandler : IRequestHandler<CreateTopicCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateTopicCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
            {
                var topic = new Topic();
                topic.Title = request.Title;
                topic.Content = request.Content;

                _context.Topics.Add(topic);
                await _context.SaveChangesAsync();
                return topic.Id;
            }
        }
    }
}
