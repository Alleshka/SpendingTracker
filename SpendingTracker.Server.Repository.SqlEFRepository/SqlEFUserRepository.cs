using Microsoft.EntityFrameworkCore;
using SpendingTracker.Model.DomainObjects;
using SpendingTracker.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendingTracker.Server.Repository.SqlEFRepository
{
    public class SqlEFUserRepository : IUserRepository
    {
        private SqlApplicationContext db;
        public SqlEFUserRepository(SqlApplicationContext context)
        {
            db = context;
        }

        public SystemUser Create(SystemUser obj)
        {
            var user = db.Users.Add(obj);
            db.SaveChanges();
            return user.Entity;
        }

        public async Task<SystemUser> CreateAsync(SystemUser obj)
        {
            var user = await db.Users.AddAsync(obj);
            await db.SaveChangesAsync();
            return user.Entity;
        }

        public bool Delete(SystemUser obj)
        {
            db.Users.Remove(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(Guid objectID)
        {
            var user = GetObjectByID(objectID);
            return Delete(user);
        }

        public Task<bool> DeleteAsync(SystemUser obj)
        {
            db.Users.Remove(obj);
            return db.SaveChangesAsync().ContinueWith(x => x.Result > 0);
        }

        public async Task<bool> DeleteAsync(Guid objectID)
        {
            // TODO: Is this right?
            var user = await GetObjectByIDAsync(objectID);
            return Delete(user);
        }

        public SystemUser GetObjectByID(Guid objectID)
        {
            return GetAll().FirstOrDefault(x => x.ObjectID == objectID);
        }

        public async Task<SystemUser> GetObjectByIDAsync(Guid objectID)
        {
            return await db.Users.FirstOrDefaultAsync(x => x.ObjectID == objectID);
        }

        public IQueryable<SystemUser> GetAll()
        {
            return db.Users.AsQueryable();
        }

        public async Task<List<SystemUser>> GetAllAsync()
        {
            return await db.Users.ToListAsync();
        }

        public SystemUser Update(SystemUser obj)
        {
            var user = GetObjectByID(obj.ObjectID);
            if (user != null)
            {
                db.Entry(user).CurrentValues.SetValues(obj);
            }
            db.SaveChanges();
            return user;
        }

        public async Task<SystemUser> UpdateAsync(SystemUser obj)
        {
            var user = await GetObjectByIDAsync(obj.ObjectID);
            
            if (user != null)
            {
                db.Entry(user).CurrentValues.SetValues(obj);
            }

            await db.SaveChangesAsync();
            return user;
        }
    }
}
