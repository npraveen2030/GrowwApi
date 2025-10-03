using GrowwBLL.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrowwApi.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class StockController : ControllerBase
    //{
    //}
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockPriceService _service;

        public StockController(IStockPriceService service)
        {
            _service = service;
        }

        //[HttpGet("GetByRange")]
        //public async Task<IActionResult> GetByRange([FromQuery] string range, [FromQuery] int stockId)
        //{
        //    var data = await _service.GetStockPriceByRangeAsync(range, stockId);
        //    return Ok(data);
        //}

        [HttpGet("{range}/{stockId}")]
        public async Task<IActionResult> GetByRange(string range, int stockId)
        {
            try
            {
                if (string.IsNullOrEmpty(range))
                    return BadRequest("Range parameter is required.");

                if (stockId <= 0)
                    return BadRequest("Invalid StockId.");

                var data = await _service.GetStockPriceByRangeAsync(range, stockId);

                if (data == null || !data.Any())
                    return NotFound($"No stock data found for StockId={stockId} in range={range}.");

                return Ok(data);
            }
            catch (Exception ex)
            {
                // Log exception here (optional)
                return StatusCode(500, new { message = "An error occurred while fetching data.", details = ex.Message });
            }
        }
    }

}
