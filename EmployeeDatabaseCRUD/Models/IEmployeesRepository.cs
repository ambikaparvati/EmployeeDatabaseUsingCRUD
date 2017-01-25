using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDatabaseCRUD.Models
{
    public interface IEmployeesRepository
    {
        IEnumerable<Employees> GetAll();
        Employees Get(int ID);
        bool Add(Employees employee);
        void Remove(int ID);
        bool Update(Employees employee);
    }
}
