using SpendingTracker.Model.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendingTracker.Server.Repository
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        public IQueryable<T> GetAll();
        public T GetObjectByID(Guid objectID);
        public T Create(T obj);
        public T Update(T obj);
        public bool Delete(T obj);
        public bool Delete(Guid objectID);

        public Task<List<T>> GetAllAsync();
        public Task<T> GetObjectByIDAsync(Guid objectID);
        public Task<T> CreateAsync(T obj);
        public Task<T> UpdateAsync(T obj);
        public Task<bool> DeleteAsync(T obj);
        public Task<bool> DeleteAsync(Guid objectID);
    }
}
