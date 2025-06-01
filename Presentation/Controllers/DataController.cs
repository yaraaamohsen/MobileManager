using Application.DTOs.DataDTOs.Data;
using Application.DTOs.DataDTOs.Version;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("NT/[controller]")]
    [Authorize]
    public class DataController(IDataService _dataService) : ControllerBase
    {
        [HttpGet("GetClientDataVersion")]
        public ActionResult<ClientDataDto> GetClientDataVersion()
        {
            var result = _dataService.getClienDataVersion();
            return Ok(result);
        }


        [HttpGet("getNewsData")]
        public ActionResult<GetNewsDataDTO> getNewsData()
        {
            var result = _dataService.getNewsData();
            return Ok(result);
        }


        [HttpGet("getHealthTips")]
        public ActionResult<GetHealthTipsDTO> getHealthTips()
        {
            var result = _dataService.getHealthTips();
            return Ok(result);
        }


        [HttpGet("getPromotion")]
        public ActionResult<GetPromotionDTO> getPromotion()
        {
            var result = _dataService.getPromotion();
            return Ok(result);
        }
    }
}
