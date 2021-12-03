using System.Collections.Generic;

namespace AnimatedSeriesAPI.Entities
{
    public class Cast
    {
        public int Id { get; set; }
        public IEnumerable<CastLector> CastLectors { get; set; }
    }
}
