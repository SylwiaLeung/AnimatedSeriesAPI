using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimatedSeriesAPI.Entities
{
    public class Season
    {
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }
        public int SerieId { get; set; }
        public virtual Serie Serie { get; set; }
        public IEnumerable<Episode> Episodes { get; set; }
        public virtual Cast Cast { get; set; }
        public int CastId { get; set; }
        public virtual Director Director { get; set; }
        public int DirectorId { get; set; }

    }
}