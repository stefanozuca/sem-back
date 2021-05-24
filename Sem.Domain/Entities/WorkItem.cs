using Sem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sem.Domain.Entities
{
    public class WorkItem : BaseEntity
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public Company Empresa { get; set; }
    }
}
