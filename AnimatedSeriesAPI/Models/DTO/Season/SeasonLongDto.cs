using System.Collections.Generic;

namespace AnimatedSeriesAPI.Models
{
    public class SeasonLongDto
    {
        public int Id { get; set; }
        public int SeasonNumber { get; set; }
        public string SerieTitle { get; set; }
        public string DirectorName { get; set; }
        public List<CastLectorDto> Lectors { get; set; }
        public List<EpisodeShortDto> Episodes { get; set; }
    }
}
