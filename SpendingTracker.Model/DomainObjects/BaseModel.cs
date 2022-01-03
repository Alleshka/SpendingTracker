using System;
using System.ComponentModel.DataAnnotations;

namespace SpendingTracker.Model
{
    public abstract class BaseModel
    {
        [Key]
        public Guid ObjectID { get; set; }
    }
}
