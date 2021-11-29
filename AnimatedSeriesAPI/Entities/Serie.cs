using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimatedSeriesAPI.Entities
{
    public class Serie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public IEnumerable<Season> Seasons { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }

    }
}