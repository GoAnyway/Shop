using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
    public class Order : BaseEntity
    {
        public int OrderNumber { get; set; }
        public string CounterpartyName { get; set; }
        public DateTime OrderDate { get; set; }

        [ForeignKey(nameof(Author))] public Guid? AuthorId { get; set; }
        public Employee Author { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}