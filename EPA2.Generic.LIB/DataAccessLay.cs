using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace PLF.Generic.LIB
{
    public class DataAccessLay
    {
        string   conSTR = Helper.ConnectionSTR(); /// "dbconnection STR";
        public List<School> GetSchools(string operate, string userID, string schoolYear, string schoolCode,string schoolArea)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                // connection.Query is a Dapper function
                //var output = connection.Query<Person>($"select * from People where LastName = '{lastName }'").ToList();
                string SP = "dbo.tcdsb_PLF_AreaSchoolList @Operate,@UserID,@SchoolYear,@SchoolCode,@SchoolArea";
                Parameter2 parameter =  new Parameter2 { Operate = operate, UserID = userID, SchoolYear = schoolYear, SchoolCode = schoolCode, SchoolArea = schoolArea };

                var schoollist = connection.Query<School>(SP, parameter).ToList();
                  //  new { Operate = operate, UserID = userID, SchoolYear = schoolYear, SchoolCode = schoolCode,SchoolArea = schoolArea }).ToList();
                return schoollist;
            }
        }
        public   List<MyListItem> GetLists(string operate, string userID)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                // connection.Query is a Dapper function
                //var output = connection.Query<Person>($"select * from People where LastName = '{lastName }'").ToList();
                string SP = "dbo.tcdsb_PLF_ListDDL2 @Operate,@UserID";
                Parameter parameter = new Parameter { Operate = operate, UserID = userID};

                var mylist = connection.Query<MyListItem>(SP, parameter).ToList();
                //  new { Operate = operate, UserID = userID, SchoolYear = schoolYear, SchoolCode = schoolCode,SchoolArea = schoolArea }).ToList();
                return mylist;
            }
        }
        public List<MyListItem> GetLists(string operate, string userID, string schoolYear, string schoolCode, string userRole)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                // connection.Query is a Dapper function
                //var output = connection.Query<Person>($"select * from People where LastName = '{lastName }'").ToList();
                string SP = "dbo.tcdsb_PLF_ListSchoolsNew @Operate,@UserID,@SchoolYear,@SchoolCode,@UserRole";
                Parameter2 parameter = new Parameter2 { Operate = operate, UserID = userID, SchoolYear = schoolYear, SchoolCode = schoolCode, UserRole = userRole };

                var mylist = connection.Query<MyListItem>(SP, parameter).ToList();
                //  new { Operate = operate, UserID = userID, SchoolYear = schoolYear, SchoolCode = schoolCode,SchoolArea = schoolArea }).ToList();
                return mylist;
            }
        }
        public List<Person> GetPeople(string lastName)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                // connection.Query is a Dapper function
                //var output = connection.Query<Person>($"select * from People where LastName = '{lastName }'").ToList();
                var output = connection.Query<Person>("dbo.peope_GetLastName @LastName", new { LastName = lastName }).ToList();
                return output;
            }
        }
        public void InsertPerson(string firstName, string lastName, string emailAddress, string phoneNumber)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                List<Person> people = new List<Person>();
                //Person newPerson = new Person { FirstName = firstName, LastName = lastName, EmailAddress = emailAddress, PhoneNumber = phoneNumber };
                //people.Add(newPerson);
                people.Add(new Person { FirstName = firstName, LastName = lastName, EmailAddress = emailAddress, PhoneNumber = phoneNumber });
                //connection.Execute is a Dapper function
                connection.Execute("dbo.peope_Insert @FirstName @LastName,@EmailAddress,@PhoneNumber", people);
            }
        }
        public string InsertPersonResult(string firstName, string lastName, string emailAddress, string phoneNumber)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                List<Person> people = new List<Person>();
                //Person newPerson = new Person { FirstName = firstName, LastName = lastName, EmailAddress = emailAddress, PhoneNumber = phoneNumber };
                //people.Add(newPerson);
                people.Add(new Person { FirstName = firstName, LastName = lastName, EmailAddress = emailAddress, PhoneNumber = phoneNumber });
                //connection.Execute is a Dapper function
                var result = connection.Query<string>("dbo.peope_Insert @FirstName @LastName,@EmailAddress,@PhoneNumber", people);
                // result will be a retunr value [Successfully or Failed]
                return result.ToString();
            }
        }
    }
}
