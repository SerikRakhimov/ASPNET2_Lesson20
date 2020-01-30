using System;
using System.Collections.Generic;

namespace SaveTimeCore.Models.ViewModels
{
    public class BranchDetailsViewModel
    {
        public int Id { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public DateTime StartWork { get; set; }
        public DateTime EndWork { get; set; }
        public int StepWork { get; set; }
        public IList<EmployeeDetailsViewModel> Employees { get; set; }
    }
}


