using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLF.Generic.LIB
{
    public class EducatorsList : IListRepository<Educator2, string>
    {
        public IEnumerable<Educator2> GetItems()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Educator2> GetItems(int employeeID)
        {
            throw new NotImplementedException();
        }

        public IList<Educator2> GetListItems(int employeeID)
        {
            throw new NotImplementedException();
        }

        public IList<Educator2> GetListItems(string userRole, string userID, string schoolyear, string schoolcode)
        {
            throw new NotImplementedException();
        }

        public IList<Educator2> GetListItems(string userRole, string userID, string schoolyear, string schoolcode, string searchby, string searchValue)
        {

 
            var mylist = new List<Educator2>();
  
            return mylist;
        }
        public IList<Educator2> GetListItems(string userRole, string userID, string schoolyear, string schoolcode, string searchby, string searchValue, string type, string area)
        {
            throw new NotImplementedException();
        }
    }
}
