using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SpendingTracker.Model.DomainObjects
{
    /// <summary>
    /// Группа трат
    /// </summary>
    public class SpendingGroup : BaseModel
    {
        public SpendingGroup() : base ()
        {

        }

        public SpendingGroup(Guid objectID) : base (objectID)
        {

        }

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
        /// Владелец группы
        /// </summary>
        public Guid UserID { get; set; }

        [JsonIgnore]
        public SystemUser User { get; set; }

        /// <summary>
        /// Затраты внутри группы
        /// </summary>
        public ICollection<Spending> Spendings { get; set; } = new List<Spending>();

        [JsonIgnore]
        /// <summary>
        /// Категории
        /// </summary>
        public ICollection<SpendingCategory> Categories { get; set; } = new List<SpendingCategory>();
    }
}
