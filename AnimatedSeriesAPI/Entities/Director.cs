using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimatedSeriesAPI.Entities
{
    public class Director
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public IEnumerable<Season> Seasons { get; set; }
    }
}