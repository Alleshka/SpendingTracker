using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        public SystemUser(Guid objectID) : base(objectID)
        {

        }

        /// <summary>
        /// Логин пользователя для входа в систему
        /// </summary>
        [Required]
        public string Login { get; set; }

        /// <summary>
        /// Пароль пользователя для входа в систему
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Все траты пользователя
        /// </summary>
        public ICollection<SpendingGroup> Spendings { get; protected set; } = new List<SpendingGroup>();

        /// <summary>
        /// Категории пользователя
        /// </summary>
        public ICollection<SpendingCategory> Categories { get; protected set; } = new List<SpendingCategory>();
    }
}
