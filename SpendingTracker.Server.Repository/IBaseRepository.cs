using SpendingTracker.Model.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpendingTracker.Server.Repository
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        public Task<List<T>> GetObjectsAsync();
        public Task<T> GetObjectByIDAsync(Guid objectID);

        public Task<T> Create(T obj);
        public Task<T> Update(T obj);
        public Task<bool> Delete(T obj);
    }
}
