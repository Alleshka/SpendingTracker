using SpendingTracker.Model.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendingTracker.Server.DTO
{
    public class SystemUserShortInfo
    {
        protected SystemUser _user;
        public SystemUserShortInfo(SystemUser user)
        {
            _user = user;
        }

        public string Login => _user.Login;
        public Guid ObjectID => _user.ObjectID;
    }

    public class SystemUserFullInfo : SystemUserShortInfo
    {
        public SystemUserFullInfo(SystemUser user) : base(user)
        {

        }

        public IEnumerable<SpendingCategory> Categories => _user.Categories;
        public IEnumerable<SpendingGroup> Spendings => _user.Spendings;
    }

    public class SystemUserCreate
    {
        public Guid? ObjectID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
