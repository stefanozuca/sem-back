using Sem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sem.Domain.Entities
{
    public class WorkItem //: BaseEntity
    {
        public int WorkItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Company Company { get; set; }
    }
}
