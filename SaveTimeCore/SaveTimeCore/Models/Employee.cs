using SaveTimeCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTimeCore.Models
{
    public class Employee : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Account")]
        public int? AccountId { get; set; }  // "int?"
                                             // нужно чтобы при чтобы при каскадном удалении 
                                             // записей из Account 
                                             // связанные Accounts.Id = Employees.AccountId
                                             // данные из Employee не удалялись,
                                             // Employees.AccountId присваиваося null
        public virtual Account Account { get; set; }
        [ForeignKey("Branch")]
        public int? BranchId { get; set; } // "int?"
                                           // нужно чтобы при чтобы при каскадном удалении 
                                           // записей из Branch 
                                           // связанные Branches.Id = Employees.BranchId
                                           // данные из Employee не удалялись,
                                           // Employees.BranchId присваиваося null
        public virtual Branch Branch { get; set; }
        public virtual IList<Service> Services { get; set; } = new List<Service>();
        public Employee()
        {
            Services = new List<Service>();
        }

    }
}