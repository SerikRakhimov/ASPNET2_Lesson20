using SaveTimeCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTimeCore.Models
{
    public class Branch : IEntity
    {
        public int Id { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public DateTime StartWork { get; set; }
        public DateTime EndWork { get; set; }
        public int StepWork { get; set; }

        [ForeignKey("Company")]
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }

        // "IList<Employee> Employees"
        // нужно чтобы при каскадном удалении 
        // записей из Branch 
        // связанные Branches.Id = Employees.BranchId
        // данные из Employee не удалялись,
        // Employees.BranchId присваиваося null
        public IList<Employee> Employees { get; set; }

        public Branch()
        {
            StartWork = new DateTime(2020, 1, 1, 9, 0, 0);
            EndWork = new DateTime(2020, 1, 1, 18, 0, 0);
            StepWork = 0;
            Employees = new List<Employee>();
        }

    }
}
