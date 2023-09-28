using Microsoft.Extensions.Logging;
using OnePass.Core.Services.Interface;
using OnePass.Repository.Interfaces;

namespace OnePass.Core.Services
{
    public class OnePassServices : IOnePassServices
    {
        private readonly ILogger<OnePassServices> _logger;
        private readonly IOnePassRepository _onePassRepository;

        public OnePassServices(ILogger<OnePassServices> logger,
                               IOnePassRepository onePassRepository)
        {
            _logger = logger;
            _onePassRepository = onePassRepository;
        }


        public async Task connectDB()
        {
            _onePassRepository.conectDb();
        }
    }
}
