using BusinessOperation;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPI.Controllers
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class PLFController : ApiController
    {
        /// <summary>
        ///  http://localhost:9517/Api/PLF 
        ///  will return PLF form all Title and content items by school anf year.
        /// </summary>
        
        /// <returns>PLF Form content list  </returns>
        // GET: api/PLF
        public IEnumerable<FormContent> Get()
        {

            List<FormContent> list = FormData.ListofContent("20182019", "0290");

            return list;
        }
        /// <summary>
        ///  http://localhost:9517/Api/PLF/?schoolYear=20182019schoolCode=0290
        ///  will return PLF form all Title and content items by school anf year.
        /// </summary>
        /// <param name="schoolYear"></param>
        /// <param name="schoolCode"></param>
        /// <returns>PLF Form content list  </returns>
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
            return FormData.Content("Content", "", "", schoolYear, schoolCode, itemCode,value);
        }

        // POST: api/PLF
        public void Post([FromBody]string value)
        {
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
