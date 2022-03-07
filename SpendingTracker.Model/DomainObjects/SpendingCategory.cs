using System.Collections.Generic;

namespace SpendingTracker.Model.DomainObjects
{
    public class SpendingCategory : BaseModel
    {
        public string Name { get; set; }

        public IEnumerable<SpendingGroup> Spendings { get; set; } = new List<SpendingGroup>();
    }
}
