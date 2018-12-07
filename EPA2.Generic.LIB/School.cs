using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLF.Generic.LIB
{
    public class School
    {
        public string SchoolYear { get; set; }
        public string SchoolCode { get; set; }
        public string SchoolName { get; set; }
        public string SchoolArea { get; set; }
        public string Principal { get; set; }
        public string SchoolSignOffDate { get; set; }
        public string SOSignOffDate { get; set; }
        public string PublishDate { get; set; }
        public string Comments { get; set; }
        public string GoAction { get; set; }
        public string ActionClick 
        {
            get {
                return $"javascript:OpenPLF('{SchoolYear}','{SchoolCode}','{PublishDate}','{SchoolSignOffDate}')";
            }
        }
        private string myVar;

        public string FullName
        {
            get { return myVar; }
            set { myVar = value; }
        }

    }
}
