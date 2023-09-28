using OnePass.Domain.Data;

namespace OnePass.Repository.Interfaces
{
    public interface IOnePassRepository
    {
        Task conectDb();

        Task<EstoqueItem> GetItem(int itemId);
    }
}
