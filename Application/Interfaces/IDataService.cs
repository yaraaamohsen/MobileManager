using Application.DTOs;
using Application.DTOs.DataDTOs.Data;
using Application.DTOs.DataDTOs.Version;

namespace Application.Interfaces
{
    public interface IDataService
    {
        public BaseResponse<List<ClientDataDto>> getClienDataVersion();

        public BaseResponse<List<GetNewsDataDTO>> getNewsData();
        public BaseResponse<List<GetHealthTipsDTO>> getHealthTips();
        public BaseResponse<List<GetPromotionDTO>> getPromotion();
    }
}
