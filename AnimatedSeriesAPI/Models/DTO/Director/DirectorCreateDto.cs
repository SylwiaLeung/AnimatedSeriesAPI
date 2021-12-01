using System.ComponentModel.DataAnnotations;

namespace AnimatedSeriesAPI.Models.DTO.Director
{
    public class DirectorCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
