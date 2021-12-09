using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoSklad.Core.GlobalSklad;
using Microsoft.EntityFrameworkCore;

namespace AutoSklad.Data.GlobalSklad
{
    public class GlobalSkladRepository : ISkladRepository
    {
        private readonly AutoSkladContext _context;
        private readonly IMapper _mapper;

        public GlobalSkladRepository(IMapper mapper, AutoSkladContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Core.GlobalSklad.GlobalSklad> AddAsync(Core.GlobalSklad.GlobalSklad globalSklad)
        {
            var entity = _mapper.Map<GlobalSkladDto>(globalSklad);
            var result = await _context.Sklads.AddAsync(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<Core.GlobalSklad.GlobalSklad>(result.Entity);
        }

        public async Task<List<Core.GlobalSklad.GlobalSklad>> GetAsync()
        {
            var entities = await _context.Sklads.ToListAsync();
            return _mapper.Map<List<Core.GlobalSklad.GlobalSklad>>(entities);
        }

        public async Task<Core.GlobalSklad.GlobalSklad> GetByIdAsync(int id)
        {
            var entity = await _context.Sklads.FirstAsync(x => x.Id == id);
            return _mapper.Map<Core.GlobalSklad.GlobalSklad>(entity);
        }

        public async Task RemoveById(int id)
        {
            var entety = await _context.Sklads.FirstAsync(x => x.Id == id);
            _context.Sklads.Remove(entety);
            await _context.SaveChangesAsync();
        }

        public async Task<Core.GlobalSklad.GlobalSklad> Update(int id, int count)
        {
            var entity = await _context.Sklads.FirstAsync(x => x.Id == id);
            entity.Count = count;
            var result = _context.Update(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<Core.GlobalSklad.GlobalSklad>(result.Entity);
        }
    }
}