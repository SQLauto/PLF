using ClassLibrary;
using BusinessOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class TitleController : ApiController
    {

        /// <summary>
        /// http://localhost:9517/api/Title 
        /// </summary>
        /// <returns> PLF Form title list</returns>
        // GET: api/Title
        public IEnumerable<FormTitle> Get()
        {

            List<FormTitle> list = FormData.ListofTitle();

            return list;
        }

        /// <summary>
        /// http://localhost:9517/api/Title/?itemCode=PLP11
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns> a PLF Title by code</returns>
        // GET: api/Title/itemCode
        public IEnumerable<string> Get(string itemCode)
        {
            yield return FormData.Title(itemCode);
        }


        // PUT: api/TitleList/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TitleList/5
        public void Delete(int id)
        {
        }
    }
}
