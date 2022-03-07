using System;
using System.ComponentModel.DataAnnotations;

namespace SpendingTracker.Model.DomainObjects
{
    public abstract class BaseModel
    {
        [Key]
        public Guid ObjectID { get; protected set; }

        public BaseModel() : this(Guid.NewGuid())
        {

        }

        public BaseModel(Guid id)
        {
            ObjectID = id;
        }
    }
}
