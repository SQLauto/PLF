using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLF.Generic.LIB
{
    public class EmployeeList : IListRepository<Employee2, string>
    {
        public IEnumerable<Employee2> GetItems()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee2> GetItems(int employeeID)
        {
            throw new NotImplementedException();
        }

        public IList<Employee2> GetListItems(int employeeID)
        {
            throw new NotImplementedException();
        }

        public IList<Employee2> GetListItems(string userRole, string userID, string schoolyear, string schoolcode)
        {
            throw new NotImplementedException();
        }

        public IList<Employee2> GetListItems(string userRole, string userID, string schoolyear, string schoolcode, string searchby, string searchValue)
        {
  
            var mylist = new List<Employee2>();
    
            return mylist;
        }

        public IList<Employee2> GetListItems(string userRole, string userID, string schoolyear, string schoolcode, string serachby, string searchValue, string type, string area)
        {
            throw new NotImplementedException();
        }
    }

}
