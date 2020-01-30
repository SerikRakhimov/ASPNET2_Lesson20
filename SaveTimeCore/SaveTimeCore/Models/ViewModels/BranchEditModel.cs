using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaveTimeCore.Models.ViewModels
{
    public class BranchEditModel
    {
        public int Id { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public DateTime StartWork { get; set; }
        public DateTime EndWork { get; set; }
        public int StepWork { get; set; }

        public int CompanyId { get; set; }

        public IList<Company> Companies { get; set; }

        public BranchEditModel()
        {
            StartWork = new DateTime(2020, 1, 1, 9, 0, 0);
            EndWork = new DateTime(2020, 1, 1, 18, 0, 0);
            StepWork = 0;
            Companies = new List<Company>();
        }

    }
}