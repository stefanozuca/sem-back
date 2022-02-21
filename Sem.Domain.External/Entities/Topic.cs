using Sem.Domain.External.Common;

namespace Sem.Domain.External.Entities
{
    public class Topic : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
