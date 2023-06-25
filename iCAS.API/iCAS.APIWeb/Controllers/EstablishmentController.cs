using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace iCAS.APIWeb.Controllers
{
    public class EstablishmentController : ApiController
    {
        // GET: api/Establishment
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Establishment/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Establishment
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Establishment/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Establishment/5
        public void Delete(int id)
        {
        }
    }
}
