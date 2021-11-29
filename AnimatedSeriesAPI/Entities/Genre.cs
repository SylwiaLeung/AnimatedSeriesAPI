using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimatedSeriesAPI.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}