using Sem.Domain.ExternalApi.Common;

namespace Sem.Domain.ExternalApi.Entities
{
    public class HistoricalCounter : BaseEntity
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
