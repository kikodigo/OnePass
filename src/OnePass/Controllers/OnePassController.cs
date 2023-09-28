using Microsoft.AspNetCore.Mvc;
using OnePass.Core.Services.Interface;
using OnePass.Repository.Interfaces;

namespace OnePass.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OnePassController : ControllerBase
    {      

        private readonly ILogger<OnePassController> _logger;
        private readonly IOnePassServices _onePassServices;
        public OnePassController(ILogger<OnePassController> logger, IOnePassServices onePassServices)
        {
            _logger = logger; 
            _onePassServices = onePassServices;
        }

        [HttpGet("GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {

            await _onePassServices.connectDB();


            return Ok(true);
        }

        [HttpGet ("GetItemByID")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var item = await _onePassServices.GetItemById(id);

                return Ok(item);
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}