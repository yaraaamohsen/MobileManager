using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.DataDTOs.Data
{
    public class GetNewsDataDTO : BaseDataDTO
    {
        [Required]
        public new Uri ContentUrl { get; set; } = new Uri("http://example.com");
    }
}
