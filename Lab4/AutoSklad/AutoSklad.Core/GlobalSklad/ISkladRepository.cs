using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoSklad.Core.GlobalSklad
{
    public interface ISkladRepository
    {
        Task<List<GlobalSklad>> GetAsync();
        Task<GlobalSklad> GetByIdAsync(int id);
        Task<GlobalSklad> Update(int id, int count);
        Task RemoveById(int id);
        Task<GlobalSklad> AddAsync(GlobalSklad globalSklad);
    }
}