using SaveTimeCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTimeCore.Models
{
    public class Account : IEntity
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        // "IList<Employee> Employees"
        // нужно чтобы при чтобы при каскадном удалении
        // записей из Account 
        // связанные Accounts.Id = Employees.AccountId
        // данные из Employee не удалялись,
        // Employees.AccountId присваиваося null
        public IList<Employee> Employees { get; set; }

        public Account()
        {
            Employees = new List<Employee>();
        }

    }
}
