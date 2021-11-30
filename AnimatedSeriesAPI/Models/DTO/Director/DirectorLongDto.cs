using System.Collections.Generic;

namespace AnimatedSeriesAPI.Models
{
    public class DirectorLongDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<SeasonShortDto> Seasons { get; set; }
    }
}
