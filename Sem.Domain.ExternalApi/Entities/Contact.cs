using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem.Domain.ExternalApi.Entities
{
    public class Contact : Topic
    {
        public string Href { get; set; }
        public string Target { get; set; }
    }
}
