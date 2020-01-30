using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaveTimeCore.Models.ViewModels
{
    public class CompanyDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string EMail { get; set; }
        public IList<BranchDetailsViewModel> Branches { get; set; }
    }
}


