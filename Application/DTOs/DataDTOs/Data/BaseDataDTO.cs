using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.DataDTOs.Data
{
    public class BaseDataDTO
    {
        [Required]
        public string ArabicTitle { get; set; } = "Arabic Title Details";

        [Required]
        public string EnglishTitle { get; set; } = "English Title Details";

        [Url(ErrorMessage = "Not Valid Url")]
        public string? ContentUrl { get; set; } = "http://example.com";
    }
}
