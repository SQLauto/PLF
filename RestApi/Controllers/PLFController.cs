using BusinessOperation;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RestApi.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PLFController : ApiController
    {
        /// <summary>
        ///  http://localhost:9517/Api/PLF
        ///  will return PLF form all Title and content items by school anf year.
        /// </summary>
       
        /// <returns>PLF Form content list  </returns>
        public IEnumerable<FormContent> Get()
        {

            List<FormContent> list = FormData.ListofContent("20182019", "0290");

            return list;
        }
        // GET: api/PLF
        public IEnumerable<FormContent> Get(string schoolYear, string schoolCode)
        {

            List<FormContent> list = FormData.ListofContent(schoolYear, schoolCode);

            return list;
        }
        /// <summary>
        ///  http://localhost:9517/api/PLF/?schoolYear=20182019schoolCode=0290itemCode=PLP11 
        ///  by provide the itemCode, Web API will return one string value of itemCode  
        /// </summary>
        /// <param name="schoolYear"></param>
        /// <param name="schoolCode"></param>
        /// <param name="itemCode"></param>
        /// <returns>PLF Form content by item code</returns>
        // GET: api/PLF/itemCode
        public string Get(string schoolYear, string schoolCode, string itemCode)
        {
            return FormData.Content("Content", "", "", schoolYear, schoolCode, itemCode);
        }

        /// <summary>
        ///  http://localhost:9517/api/PLF/?schoolYear=20182019schoolCode=0290itemCode=PLP11value=myinputtext
        ///  by provide the value the Web API will save the value to database and return save or update action result.
        /// </summary>
        /// <param name="schoolYear"></param>
        /// <param name="schoolCode"></param>
        /// <param name="itemCode"></param>
        /// <param name="value"></param>
        /// <returns>PLF Form save content and get save result back</returns>
        // GET: api/PLF/itemCode/value
        public string Get(string schoolYear, string schoolCode, string itemCode, string value)
        {
            return FormData.Content("Content", "", "", schoolYear, schoolCode, itemCode, value);
        }

        /// <summary>
        /// This is save the content to Database
        /// </summary>
        /// <param name="userID"> user ID </param>
        /// <param name="schoolYear"> PLF School Year </param>
        /// <param name="schoolCode">PLF School Code </param>
        /// <param name="itemCode">PLF item Code BDA01 to BDA26, PLP11 to PLP20 </param>
        /// <param name="value"> actual item content </param>
        ///  http://localhost:9517/api/PLF/?userID=mif&schoolYear=20182019schoolCode=0290itemCode=PLP11 
        // POST: api/PLF
        public void Post(string userID, string schoolYear, string schoolCode, string itemCode, string value)
        {
            FormData.Content("Content", userID,"", schoolYear, schoolCode, itemCode, value);
        }

        // PUT: api/PLF/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PLF/5
        public void Delete(int id)
        {
        }
    }
}
