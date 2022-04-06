using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendingTracker.Server.DTO
{
    public class SpendingCreate
    {
        public string Description { get; set; }
        public double Sum { get; set; }
        public DateTime? Date { get; set; }
    }
}
