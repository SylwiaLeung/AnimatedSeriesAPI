namespace AnimatedSeriesAPI.Models
{
    public class SeriesQuery
    {
        public string SearchPhrase { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
