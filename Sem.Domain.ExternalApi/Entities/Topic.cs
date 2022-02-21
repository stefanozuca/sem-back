using Sem.Domain.ExternalApi.Common;

namespace Sem.Domain.ExternalApi.Entities
{
    public class Topic : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
