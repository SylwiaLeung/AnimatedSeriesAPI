using System.Collections.Generic;

namespace AnimatedSeriesAPI.Models
{
    public class GenreLongDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SerieShortDto> Series { get; set; }
    }
}
