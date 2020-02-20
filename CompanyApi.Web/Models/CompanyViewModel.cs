using System.Collections.Generic;

namespace CompanyApi.Web.Models
{
    public class CompanyViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<UserViewModel> Users { get; set; }
    }
}
