using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
    public class Subdivision : BaseEntity
    {
        public string Name { get; set; }

        [ForeignKey(nameof(Manager))] public Guid? ManagerId { get; set; }
        public virtual Employee Manager { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}