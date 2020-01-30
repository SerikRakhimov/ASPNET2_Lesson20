using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTimeCore.Interfaces
{
    public interface IRepository<T> where T:class
    {
        void Create(T item);
        IEnumerable<T> GetAll();
        T GetById(int? id);
        T GetByIdInclude(int? id, string fieldName);
        void Edit(T item);
        void Remove(T item);

    }
}
