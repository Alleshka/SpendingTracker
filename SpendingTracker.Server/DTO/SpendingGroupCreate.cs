using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendingTracker.Server.DTO
{
    public class SpendingGroupCreate
    {
        public string Name { get; set; }
        public Guid UserID { get; set; }
        public ICollection<SpendingCreate> Spendings { get; set; } = new List<SpendingCreate>();
    }
}
