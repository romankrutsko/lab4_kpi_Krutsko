using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoSklad.Core.GlobalSklad;

namespace AutoSklad.Orchestrators.GlobalSklad
{
    public class GlobalSkladService : ISkladService
    {
        private readonly ISkladRepository _repository;

        public GlobalSkladService(ISkladRepository repository)
        {
            _repository = repository;
        }

        public async Task<Core.GlobalSklad.GlobalSklad> AddAsync(Core.GlobalSklad.GlobalSklad globalSklad)
        {
            return await _repository.AddAsync(globalSklad);
        }

        public async Task<List<Core.GlobalSklad.GlobalSklad>> GetAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<Core.GlobalSklad.GlobalSklad> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task RemoveById(int id)
        {
            var sklad = await _repository.GetByIdAsync(id);
            if (sklad == null)
                throw new ArgumentNullException();
            await _repository.RemoveById(id);
        }

        public async Task<Core.GlobalSklad.GlobalSklad> Update(int id, int count)
        {
            var sklad = await _repository.GetByIdAsync(id);
            await _repository.Update(id, count);
            return sklad;
        }
    }
}