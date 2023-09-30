using Microsoft.AspNetCore.Mvc;
using OnePass.Core.Services.Interface;
using OnePass.Domain.Request;
using System.Linq.Expressions;

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

        [HttpGet("Ready")]
        public async Task<IActionResult> Get()
        {
            try
            {
                await _onePassServices.connectDB();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Não foi possivel conectar no banco {ex.Message}");

                throw;
            }

            return Ok(true);
        }

        [HttpGet("GetItemByID")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                //https://github.com/NetDevPack/Security.Identity

                var item = await _onePassServices.GetItemById(id);

                return Ok(item);
            }
            catch (Exception ex)
            {

                return StatusCode(500);
            }
            finally
            {
                GC.Collect();
            }
        }

        [HttpPost("CreateMasterLogin")]
        public async Task<IActionResult> CreateMasterLogin(MasterLoginRequest request)
        {
            try
            {
                var result = await _onePassServices.CreateLoginMasterServiceAsync(request);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(500);
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}