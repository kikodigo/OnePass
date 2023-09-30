using Microsoft.Extensions.Logging;
using OnePass.Core.Services.Interface;
using OnePass.Domain.Data;
using OnePass.Domain.Request;
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

        public async Task<EstoqueItem> GetItemById(int idItem)
        {
            var item = await _onePassRepository.GetItem(idItem);

            return item;
        }

        public async Task<bool> CreateLoginMasterServiceAsync(MasterLoginRequest masterLoginRequest)
        {
            var result = await _onePassRepository.CreateLoginMasterAsync(masterLoginRequest);

            return result;
        }
    }
}
