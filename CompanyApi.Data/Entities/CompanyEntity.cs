using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyApi.Data.Entities
{
    [Table("Company")]
    public class CompanyEntity : Entity
    {
        public string Name { get; set; }

        public IList<UserEntity> Users { get; set; }
    }
}
