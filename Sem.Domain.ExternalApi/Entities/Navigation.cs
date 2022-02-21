
using Sem.Domain.ExternalApi.Common;

namespace Sem.Domain.ExternalApi.Entities
{
    public class Navigation : BaseEntity
    {
        public string Name { get; set; }
        public string Href { get; set; }
        public bool Current { get; set; }
    }
}
