
using System;

namespace Sem.Domain.External.Entities
{
    public class Blog : Topic
    {
        public DateTime Date { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public bool IsFavorite { get; set; }
    }
}
