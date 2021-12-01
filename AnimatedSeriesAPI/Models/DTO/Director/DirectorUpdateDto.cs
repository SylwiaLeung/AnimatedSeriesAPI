using System.ComponentModel.DataAnnotations;

namespace AnimatedSeriesAPI.Models.DTO.Director
{
    public class DirectorUpdateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
