using SpendingTracker.Model.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendingTracker.Server.Repository
{
    public interface IUserRepository : IBaseRepository<SystemUser>
    {
    }
}
