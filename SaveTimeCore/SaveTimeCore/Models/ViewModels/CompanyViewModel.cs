using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaveTimeCore.Models.ViewModels
{
    public class CompanyViewModel
    {
        public IList<CompanyDetailsViewModel> Companies { get; set; }
        public CreateCompanyViewModel CreateCompany { get; set; }
        public CompanyViewModel()
        {
            Companies = new List<CompanyDetailsViewModel>();
            CreateCompany = new CreateCompanyViewModel();
        }
    }
}