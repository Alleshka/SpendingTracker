using System;
using System.Collections.Generic;

namespace SpendingTracker.Model.DomainObjects
{
    /// <summary>
    /// Пользователь системы
    /// </summary>
    public class SystemUser : BaseModel
    {    

        public SystemUser() : base()
        {

        }

        public SystemUser(Guid guid) : base(guid)
        {

        }

        /// <summary>
        /// Логин пользователя для входа в систему
        /// </summary>
        public string Login { get; set; }
        
        /// <summary>
        /// Пароль пользователя для входа в систему
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Все траты пользователя
        /// </summary>
        public IEnumerable<SpendingGroup> Spendings { get; protected set; } = new List<SpendingGroup>();
    }
}
