using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Micro.Objects.ICAS.STAFFS;
using Micro.BusinessLayer.ICAS.STAFFS;
using System.Text;
using Newtonsoft.Json.Linq;

namespace iCAS.APIWeb.Controllers
{
    public class StaffsController : ApiController
    {
        // GET: api/Staffs
        public HttpResponseMessage Get()
        {
            List<Staff> list = StaffMasterManagement.GetInstance.GetStaffs();
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JArray.FromObject(list).ToString(), Encoding.UTF8, "application/json")
            };
        }

        [Route("api/Staff/Photo/{id}")]
        public IEnumerable<string> GetPhoto(int id)
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Staffs/5
        public Staff Get(int id)
        {
            return StaffMasterManagement.GetInstance.GetStaffs().Where((record) => record.EmployeeID == id).SingleOrDefault();
        }

        // POST: api/Staffs
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Staffs/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Staffs/5
        public void Delete(int id)
        {
        }
    }
}
