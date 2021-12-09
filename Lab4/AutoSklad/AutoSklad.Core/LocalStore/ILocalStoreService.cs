using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoSklad.Core.LocalStore
{
    public interface ILocalStoreService
    {
        Task<List<LocalStore>> GetAsync();
        Task<LocalStore> GetByIdAsync(int id);
        Task<LocalStore> UpdateCount(int id, int count);
        Task RemoveById(int id);
        Task<LocalStore> AddAsync(LocalStore localStore);
    }
}