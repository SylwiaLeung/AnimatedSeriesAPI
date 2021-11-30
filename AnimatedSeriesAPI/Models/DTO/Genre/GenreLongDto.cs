using System.Collections.Generic;

namespace AnimatedSeriesAPI.Models
{
    public class GenreLongDto
    {
        int Id { get; set; }
        string Name { get; set; }
        IEnumerable<SerieShortDto> Series { get; set; }
    }
}
