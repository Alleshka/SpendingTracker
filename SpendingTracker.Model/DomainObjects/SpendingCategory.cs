using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SpendingTracker.Model.DomainObjects
{
    /// <summary>
    /// Категории пользователя
    /// </summary>
    public class SpendingCategory : BaseModel
    {
        public SpendingCategory() : base()
        {

        }

        public SpendingCategory(Guid id) : base(id)
        {
        }

        /// <summary>
        /// Наименование категории
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Связь с владельцем категории
        /// </summary>
        public Guid UserID { get; set; }

        [JsonIgnore]
        public SystemUser User { get; set; }

        [JsonIgnore]
        public ICollection<SpendingGroup> Spendings { get; set; } = new List<SpendingGroup>();
    }
}
