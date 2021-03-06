using System.Collections.Generic;

namespace AnimatedSeriesAPI.Models
{
    public class SerieLongDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string GenreName { get; set; }
        public List<SeasonShortDto> Seasons { get; set; }
    }
}
