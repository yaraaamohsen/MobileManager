using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.DataDTOs.Data
{
    public class GetNewsDataDTO : BaseDataDTO
    {
        [Required]
        public new string ContentUrl { get; set; } = "http://example.com";
    }
}
