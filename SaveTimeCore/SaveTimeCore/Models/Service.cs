using SaveTimeCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTimeCore.Models
{
    public class Service : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
