using Microsoft.EntityFrameworkCore;
using SpendingTracker.Model.DomainObjects;
using SpendingTracker.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendingTracker.Server.Repository.SqlEFRepository
{
    public class UserRepository : IUserRepository
    {
        private SqlApplicationContext db;
        public UserRepository(SqlApplicationContext context)
        {
            db = context;
        }

        public Task<SystemUser> Create(SystemUser obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(SystemUser obj)
        {
            throw new NotImplementedException();
        }

        public async Task<SystemUser> GetObjectByIDAsync(Guid objectID)
        {
            return await db.Users.FirstOrDefaultAsync(x => x.ObjectID == objectID);
        }

        public async Task<List<SystemUser>> GetObjectsAsync()
        {
            return await db.Users.ToListAsync();
        }

        public async Task<SystemUser> Update(SystemUser obj)
        {
            throw new NotImplementedException();
        }
    }
}
