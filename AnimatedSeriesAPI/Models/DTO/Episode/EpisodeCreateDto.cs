namespace AnimatedSeriesAPI.Models.DTO.Episode
{
    public class EpisodeCreateDto
    {
        public string Title { get; set; }
        public int EpisodeNumber { get; set; }
        public int SeasonId { get; set; }
    }
}
