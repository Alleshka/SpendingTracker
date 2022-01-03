using System;
using System.Collections.Generic;

namespace SpendingTracker.Model
{
    /// <summary>
    /// Группа трат
    /// </summary>
    public class SpendingGroup : BaseModel
    {
        /// <summary>
        /// Дата создания группы
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Дата обновления группы
        /// </summary>
        public DateTime UpdatedDate { get; set; }

        /// <summary>
        /// Наименование группы
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Связь с владельцем группы
        /// </summary>
        public Guid UserId { get; set; }
        public SystemUser User { get; set; }

        /// <summary>
        /// Затраты внутри группы
        /// </summary>
        public IEnumerable<Spending> Spendings { get; set; }
    }
}
