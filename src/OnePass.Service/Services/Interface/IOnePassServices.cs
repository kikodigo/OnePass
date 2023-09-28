using OnePass.Domain.Data;

namespace OnePass.Core.Services.Interface
{
    public interface IOnePassServices
    {
        Task connectDB();

        Task<EstoqueItem> GetItemById(int idItem);
    }
}
