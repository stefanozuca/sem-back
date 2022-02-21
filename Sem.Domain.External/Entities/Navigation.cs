
using Sem.Domain.External.Common;

namespace Sem.Domain.External.Entities
{
    public class Navigation : BaseEntity
    {
        public string Name { get; set; }
        public string Href { get; set; }
        public bool Current { get; set; }
    }
}
