using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyApi.Data.Entities
{
    [Table("User")]
    public class UserEntity: Entity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }


        public int? CompanyId { get; set; }
        public CompanyEntity Company { get; set; }
    }
}
