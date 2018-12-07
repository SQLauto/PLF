using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLF.Generic.LIB
{
    public class Parameter
    {
        public string Operate { get; set; }
        public string UserID { get; set; }
        public string UserRole { get; set; }

    }
    public class Parameter1 : Parameter
    {
        public string SchoolYear { get; set; }
        public string SchoolCode { get; set; }

    }
    public class Parameter2 : Parameter1
    {
        public string SchoolArea { get; set; }

    }

}
