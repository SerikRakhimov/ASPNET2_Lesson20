using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaveTimeCore.Models.ViewModels
{
    public class EmployeeEditModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AccountId { get; set; }
        public int BranchId { get; set; }
        public IList<Account> Accounts { get; set; } 
        public IList<Branch> Branches { get; set; }

        public EmployeeEditModel()
        {
            Accounts = new List<Account>();
            Branches = new List<Branch>();
        }
    }

}
