using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimatedSeriesAPI.Entities
{
    public class Episode
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public int EpisodeNumber { get; set; }
        public int SeasonId { get; set; }
        public virtual Season Season { get; set; }
    }
}
