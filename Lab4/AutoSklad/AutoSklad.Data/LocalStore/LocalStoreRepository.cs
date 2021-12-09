using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoSklad.Core.LocalStore;
using Microsoft.EntityFrameworkCore;

namespace AutoSklad.Data.LocalStore
{
    public class LocalStoreRepository : ILocalStoreRepository
    {
        private readonly AutoSkladContext _context;
        private readonly IMapper _mapper;

        public LocalStoreRepository(IMapper mapper, AutoSkladContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Core.LocalStore.LocalStore> AddAsync(Core.LocalStore.LocalStore localStore)
        {
            var entity = _mapper.Map<LocalStoreDto>(localStore);
            var result = await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<Core.LocalStore.LocalStore>(result.Entity);
        }

        public async Task<List<Core.LocalStore.LocalStore>> GetAsync()
        {
            var entities = await _context.LocalStores.ToListAsync();
            return _mapper.Map<List<Core.LocalStore.LocalStore>>(entities);
        }

        public async Task<Core.LocalStore.LocalStore> GetByIdAsync(int id)
        {
            var entity = await _context.LocalStores.FirstAsync(x => x.Id == id);
            return _mapper.Map<Core.LocalStore.LocalStore>(entity);
        }

        public async Task RemoveById(int id)
        {
            var entity = await _context.LocalStores.FirstOrDefaultAsync(x => x.Id == id);
            _context.LocalStores.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Core.LocalStore.LocalStore> UpdateCount(int id, int count)
        {
            var entity = await _context.LocalStores.FirstAsync(x => x.Id == id);
            entity.Count = count;
            var result = _context.Update(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<Core.LocalStore.LocalStore>(result.Entity);
        }
    }
}