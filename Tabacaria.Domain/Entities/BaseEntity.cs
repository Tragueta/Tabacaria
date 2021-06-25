using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tabacaria.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("CreationDate")]
        public DateTime CreationDate { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
        }
    }
}
