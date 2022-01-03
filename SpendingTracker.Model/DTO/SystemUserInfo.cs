using System;

namespace SpendingTracker.Model.DTO
{
    public class SystemUserInfo
    {
        private SystemUser _user;

        public SystemUserInfo(SystemUser user)
        {
            _user = user;
        }

        public string Login => _user.Login;
        public Guid ObjectID => _user.ObjectID;
    }
}
