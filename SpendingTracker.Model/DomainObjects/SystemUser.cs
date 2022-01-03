using System.Collections.Generic;

namespace SpendingTracker.Model
{
    /// <summary>
    /// Пользователь системы
    /// </summary>
    public class SystemUser : BaseModel
    {    
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
        public IEnumerable<SpendingGroup> Spendings { get; set; }
    }
}
