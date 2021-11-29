using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimatedSeriesAPI.Entities
{
    public class Lector
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public IEnumerable<CastLector> CastLectors { get; set; }
    }
}
