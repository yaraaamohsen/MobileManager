using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.DataDTOs.Data
{
    public class GetPromotionDTO : BaseDataDTO
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime promotionStartDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime promotionEndDate { get; set; }

        [Required]
        public bool addPromotiontoHome { get; set; }

        [Url(ErrorMessage = "Not Valid UrlAttachment")]
        public Uri? ContentAttachment { get; set; }
        public string? ArabicContentText { get; set; }
        public string? EnglishContentText { get; set; }
    }
}
