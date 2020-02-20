using System.Collections.Generic;

namespace CompanyApi.Services.Models
{
    public class Company : Models
    {
        public string Name { get; set; }

        public List<User> Users { get; set; }
    }
}
