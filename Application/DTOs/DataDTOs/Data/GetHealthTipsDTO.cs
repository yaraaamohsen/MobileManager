using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.DataDTOs.Data
{
    public class GetHealthTipsDTO : BaseDataDTO
    {
        [Url(ErrorMessage = "Not Valid UrlAttachment")]
        public string? ContentAttachment { get; set; }
        public string? ArabicContentText { get; set; }
        public string? EnglishContentText { get; set; }
    }
}
