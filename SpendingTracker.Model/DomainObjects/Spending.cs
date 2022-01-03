using System;

namespace SpendingTracker.Model
{
    /// <summary>
    /// Класс затрат
    /// </summary>
    public class Spending : BaseModel
    {
        /// <summary>
        /// Сумма траты
        /// </summary>
        public int Sum { get; set; }

        /// <summary>
        /// Описание траты
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дата траты
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Все траты входят в группу трат
        /// Если трата одна, то для неё создаётся отдельная группа
        /// </summary>
        public Guid GroupKey { get; set; }
        public SpendingGroup Group { get; set; }
    }
}
