using System;

namespace OnlineScheduling.Domain.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }

        public long Id { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? DeletionDate { get; set; }

        public DateTime? UpdateDate { get; set; }
    }    
}