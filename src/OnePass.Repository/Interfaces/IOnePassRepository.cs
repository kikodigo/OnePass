using OnePass.Domain.Data;
using OnePass.Domain.Request;

namespace OnePass.Repository.Interfaces
{
    public interface IOnePassRepository
    {
        Task conectDb();

        Task<EstoqueItem> GetItem(int itemId);

        Task<bool> CreateLoginMasterAsync(MasterLoginRequest masterLoginRequest);
    }
}
