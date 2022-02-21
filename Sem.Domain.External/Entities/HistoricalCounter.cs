using Sem.Domain.External.Common;

namespace Sem.Domain.External.Entities
{
    public class HistoricalCounter : BaseEntity
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
