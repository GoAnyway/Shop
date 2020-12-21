using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Entities.Enums;

namespace Database.Entities
{
    public class Employee : BaseEntity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }

        [NotMapped] public Gender Gender { get; set; }

        [Column(nameof(Gender))]
        public int GenderValue
        {
            get => (int) Gender;
            set => Gender = (Gender) value;
        }

        [ForeignKey(nameof(Subdivision))] public Guid? SubdivisionId { get; set; }
        public virtual Subdivision Subdivision { get; set; }
        public virtual ICollection<Subdivision> Subdivisions { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}