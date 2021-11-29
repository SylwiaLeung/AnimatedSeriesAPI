using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimatedSeriesAPI.Entities
{
    public class Cast 
    {
        public int Id { get; set; }
        public IEnumerable<CastLector> CastLectors { get; set; }
    }
}
