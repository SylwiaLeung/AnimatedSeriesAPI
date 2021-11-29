using System.ComponentModel.DataAnnotations;

namespace AnimatedSeriesAPI.Entities
{
    public class CastLector
    {
        public int Id { get; set; }
        public virtual Cast Cast { get; set; }
        public int CastId { get; set; }
        public virtual Lector Lector { get; set; }
        public int LectorId { get; set; }
    }
}