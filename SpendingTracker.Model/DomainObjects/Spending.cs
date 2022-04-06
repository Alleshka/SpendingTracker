using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SpendingTracker.Model.DomainObjects
{
    /// <summary>
    /// Класс затрат
    /// </summary>
    public class Spending : BaseModel
    {

        public Spending() : base()
        {

        }

        public Spending(Guid guid) : base (guid)
        {

        }

        /// <summary>
        /// Сумма траты
        /// </summary>
        public double Sum { get; set; }

        /// <summary>
        /// Описание траты
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дата траты
        /// </summary>
        public DateTime Date { get; set; }

        public Guid GroupID { get; set; }

        [JsonIgnore]
        public SpendingGroup Group { get; set; }
    }
}
