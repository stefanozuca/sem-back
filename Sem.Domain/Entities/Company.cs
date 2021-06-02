using Sem.Domain.Common;
using System.Collections.Generic;

namespace Sem.Domain.Entities
{
    public class Company //: BaseEntity
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        //public ICollection<WorkItem> WorkItems { get; set; }
    }
}