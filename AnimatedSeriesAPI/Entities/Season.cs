using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimatedSeriesAPI.Entities
{
    public class Season
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SeasonNumber { get; set; }

        [ForeignKey("Serie")]
        public int SerieId { get; set; }
        public virtual Serie Serie { get; set; }
        public IEnumerable<Episode> Episodes { get; set; }
        public virtual Cast Cast { get; set; }
        public int CastId { get; set; }
        public virtual Director Director { get; set; }
        public int DirectorId { get; set; }

    }
}