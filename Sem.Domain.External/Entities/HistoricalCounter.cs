using Sem.Domain.External.Common;

namespace Sem.Domain.External.Entities
{
    public class HistoricalCounter : BaseEntity
    {
        public int Felices { get; set; }
        public int Proyectos { get; set; }
        public int Horas { get; set; }
        public int Trabajadores { get; set; }
    }
}
