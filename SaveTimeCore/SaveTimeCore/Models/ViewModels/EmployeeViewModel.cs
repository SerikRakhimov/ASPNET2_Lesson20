using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaveTimeCore.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AccountPhone { get; set; }
        public string AccountEmail { get; set; }
        public string CompanyName { get; set; }
        public string BranchAdress { get; set; }

    }
}