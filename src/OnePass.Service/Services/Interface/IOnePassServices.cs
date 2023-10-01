using OnePass.Domain.Data;
using OnePass.Domain.Request;

namespace OnePass.Core.Services.Interface
{
    public interface IOnePassServices
    {
        Task<string> connectDB();

        Task<EstoqueItem> GetItemById(int idItem);

        Task<bool> CreateLoginMasterServiceAsync(MasterLoginRequest masterLoginRequest);

    }
}
