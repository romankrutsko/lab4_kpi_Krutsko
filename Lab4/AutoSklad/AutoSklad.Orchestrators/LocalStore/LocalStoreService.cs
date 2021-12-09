using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoSklad.Core.LocalStore;

namespace AutoSklad.Orchestrators.LocalStore
{
    public class LocalStoreService : ILocalStoreService
    {
        private readonly ILocalStoreRepository _repository;

        public LocalStoreService(ILocalStoreRepository repository)
        {
            _repository = repository;
        }

        public async Task<Core.LocalStore.LocalStore> AddAsync(Core.LocalStore.LocalStore localStore)
        {
            return await _repository.AddAsync(localStore);
        }

        public async Task<List<Core.LocalStore.LocalStore>> GetAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<Core.LocalStore.LocalStore> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task RemoveById(int id)
        {
            var store = await _repository.GetByIdAsync(id);
            if (store == null)
                throw new ArgumentNullException();
            await _repository.RemoveById(id);
        }

        public async Task<Core.LocalStore.LocalStore> UpdateCount(int id, int count)
        {
            var store = await _repository.GetByIdAsync(id);
            if (store == null)
                throw new ArgumentNullException();
            if (count < 0)
                throw new ArgumentOutOfRangeException();
            store.Count = count;
            await _repository.UpdateCount(id, count);
            return store;
        }
    }
}