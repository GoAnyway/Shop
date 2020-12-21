using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
    public class Product : BaseEntity
    {
        public int ProductNumber { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }

        [ForeignKey(nameof(Order))] public Guid? OrderId { get; set; }
        public Order Order { get; set; }
    }
}