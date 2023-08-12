using iCAS.APIWeb.Models;
using Micro.BusinessLayer.Administration;
using Micro.BusinessLayer.HumanResource;
using Micro.BusinessLayer.ICAS.ESTBLMT;
using Micro.BusinessLayer.ICAS.STAFFS;
using Micro.BusinessLayer.ICAS.STUDENT;
using Micro.Objects.HumanResource;
using Micro.Objects.ICAS.ESTBLMT;
using Micro.Objects.ICAS.STAFFS;
using Micro.Objects.ICAS.STUDENT;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace iCAS.APIWeb.Controllers
{
    public class CollegeController : ApiController
    {

        public string GetRequestToken()
        {
            var re = Request;
            var headers = re.Headers;
            string token = string.Empty;

            if (headers.Contains("Token"))
            {
                token = headers.GetValues("Token").First();
            }

            return token;
        }

        /// <summary>
        /// Get all establishments of the office
        /// </summary>
        /// <returns></returns>
        [Route("api/College/Establishments")]
        public HttpResponseMessage GetEstablishments()
        {
            List<Establishment> TheEstablishmentList = EstablishmentManagement.GetInstance.GetEstablishmentList();
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JArray.FromObject(TheEstablishmentList).ToString(), Encoding.UTF8, "application/json")
            };
        }

        /// <summary>
        /// Get all departments of the college
        /// </summary>
        /// <returns></returns>
        [Route("api/College/Departments")]
        public HttpResponseMessage GetDepartments()
        {
            List<Micro.Objects.ICAS.STAFFS.Department> theList = Micro.BusinessLayer.ICAS.STAFFS.DepartmentManagement.GetInstance.GetDepartments();

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JArray.FromObject(theList).ToString(), Encoding.UTF8, "application/json")
            };
        }
        

        /// <summary>
        /// Get all staffs of the college
        /// </summary>
        /// <returns></returns>
        [Route("api/College/Staffs")]
        public HttpResponseMessage GetStaffs()
        {
            List<Staff> theList = StaffMasterManagement.GetInstance.GetStaffs();

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JArray.FromObject(theList).ToString(), Encoding.UTF8, "application/json")
            };
        }

        [Route("api/College/StaffDetails/{userId}/{staffId}")]
        public HttpResponseMessage GetStaffDetails(int userId, int staffId)
        {
            Response response = new Response();
            StaffMaster staffMaster = new StaffMaster();
            string token = GetRequestToken();
            if (token.Length > 0 && UserManagement.GetInstance.ValidateToken(userId, token))
            {
                staffMaster = StaffMasterManagement.GetInstance.GetEmployeeByID(staffId);
                response.message = "Success";
                response.data = staffMaster;
            }
            else
            {
                response.message = "Access denied";
            }
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
            };
        }

        /// <summary>
        /// Get staffs of given department
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>
        [Route("api/College/Staffs/Department/{name}")]
        public HttpResponseMessage GetStaffsByDepartment([FromUri]string name)
        {
            List<Staff> theList = StaffMasterManagement.GetInstance.GetStaffsByDepartment(name.ToUpper());

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JArray.FromObject(theList).ToString(), Encoding.UTF8, "application/json")
            };
        }

        /// <summary>
        /// Get the photo of the college staff
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/College/Staff/{id}/Photo")]
        public HttpResponseMessage GetStaffPhoto([FromUri] int id)
        {
            List<EmployeeProfile> theList = EmployeeProfileManagement.GetInstance.GetEmployeeProfileByEmployeeID(id); // StaffMasterManagement.GetInstance.GetStaffs();

            if (theList == null || theList.Count == 0)
            {
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JArray.FromObject(theList).ToString(), Encoding.UTF8, "application/json")
                };
            }

            byte[] imgData = theList[0].SettingKeyValue;
            MemoryStream ms = new MemoryStream(imgData);
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(ms);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
            return response;
        }

        // GET: api/College
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/College/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/College
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/College/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/College/5
        public void Delete(int id)
        {
        }

        #region students
        [HttpPost]
        [Route("api/College/Students")]
        public HttpResponseMessage GetStudents([FromBody] StudentSearchPayload payload)
        {
            List<StudentViewModel> theList = StudentManagement.GetInstance.GetStudents(payload);

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JArray.FromObject(theList).ToString(), Encoding.UTF8, "application/json")
            };
        }
        #endregion
    }
}
