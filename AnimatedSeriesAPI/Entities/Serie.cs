using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimatedSeriesAPI.Entities
{
    public class Serie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public IEnumerable<Season> Seasons { get; set; }

        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }

    }
}