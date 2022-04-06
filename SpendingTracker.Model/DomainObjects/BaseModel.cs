using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpendingTracker.Model.DomainObjects
{
    public abstract class BaseModel 
    {
        [Key]
        [Required]
        public Guid ObjectID { get; protected set; }

        protected BaseModel() : this(Guid.NewGuid())
        {

        }

        public BaseModel(Guid id)
        {
            ObjectID = id;
        }
    }
}
