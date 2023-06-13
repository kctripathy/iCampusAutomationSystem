using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Micro.Commons;
using Micro.BusinessLayer.Administration;
using Micro.Objects.Administration;
using System.Text;
using Newtonsoft.Json.Linq;

namespace iCAS.APIWeb.Controllers
{
    public class LoginController : ApiController
    {
        // GET: api/Login
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Login/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Login
        public HttpResponseMessage Post([FromBody] UserLogin user)
        {
            UserLogin userLogin = new UserLogin();
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JArray.FromObject(userLogin).ToString(), Encoding.UTF8, "application/json")
            };
        }

        // PUT: api/Login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }
    }
}
