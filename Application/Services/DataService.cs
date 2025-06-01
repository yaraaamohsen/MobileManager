using Application.DTOs;
using Application.DTOs.DataDTOs.Data;
using Application.DTOs.DataDTOs.Version;
using Application.Interfaces;

namespace Application.Services
{
    public class DataService : IDataService
    {
        public BaseResponse<List<ClientDataDto>> getClienDataVersion()
        {
            var data = new List<ClientDataDto>
            {
                new ClientDataDto()
                {
                    Name = "Health Tips",
                    Version = 2,
                    ModifiedAt = DateTime.Parse("2024-08-24T14:15:22Z")
                }
            };
            return new BaseResponse<List<ClientDataDto>>(data);
        }

        public BaseResponse<List<GetNewsDataDTO>> getNewsData()
        {
            var data = new List<GetNewsDataDTO>()
            {
                new GetNewsDataDTO()
            };
            return new BaseResponse<List<GetNewsDataDTO>>(data);
        }

        public BaseResponse<List<GetHealthTipsDTO>> getHealthTips()
        {
            var data = new List<GetHealthTipsDTO>
            {
                new GetHealthTipsDTO()
                {
                    ContentAttachment = "http://example.com",
                    ArabicContentText = "Arabic Content Text",
                    EnglishContentText = "English Content Text"
                }
            };

            return new BaseResponse<List<GetHealthTipsDTO>>(data);
        }

        public BaseResponse<List<GetPromotionDTO>> getPromotion()
        {
            var data = new List<GetPromotionDTO>
            {
                new GetPromotionDTO()
                {
                    promotionStartDate = DateTime.Parse("2025-01-01"),
                    promotionEndDate = DateTime.Parse("2025-05-10"),
                    addPromotiontoHome = true,
                    ContentAttachment = "http://example.com",
                    ArabicContentText = "Arabic Content Text",
                    EnglishContentText = "English Content Text",
                }
            };
            return new BaseResponse<List<GetPromotionDTO>>(data);
        }
    }
}
