using System;

namespace CompanyApi.Services.Models
{
    public class User : Models
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public int CompanyId { get; set; }
    }
}
