using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradeActivitiesController : ControllerBase
    {
        private ITradeActivityService _tradeActivityService;

        public TradeActivitiesController(ITradeActivityService tradeActivityService)
        {
            _tradeActivityService = tradeActivityService;
        }



        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _tradeActivityService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }




        [HttpGet("get")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _tradeActivityService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);

        }




        [HttpPost]
        public async Task<IActionResult> Add(TradeActivityAddDto tradeActivityAddDto)
        {
            var result = await _tradeActivityService.AddAsync(tradeActivityAddDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }



        [HttpPut]
        public async Task<IActionResult> Update(TradeActivityUpdateDto tradeActivityUpdateDto)
        {
            var result = await _tradeActivityService.UpdateAsync(tradeActivityUpdateDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }



        [HttpDelete]
        public async Task<IActionResult> Delete(int tradeActivityId)
        {
            var result = await _tradeActivityService.DeleteAsync(tradeActivityId);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);

        }

    }
}
