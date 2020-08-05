using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AW.Sca.Data.Domain
{
    public class BaseEntity<T> : IEntity<T> where T : IComparable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }       
        public long CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public long? ModifiedById { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
