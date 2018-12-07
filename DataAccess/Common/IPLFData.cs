using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Common
{ 
   public  interface IPLFData<T>
    {
        IList<T> GetListItems(string sp, object parameter);
    }
}
