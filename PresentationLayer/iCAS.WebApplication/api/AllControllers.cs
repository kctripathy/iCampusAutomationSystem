using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Micro.Objects.Administration;
using Micro.BusinessLayer.Administration;
using Micro.Objects.ICAS.STAFFS;
using Micro.BusinessLayer.ICAS.STAFFS;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Web.Mvc;
using Micro.Commons;

namespace TCon.iCAS.WebApplication.api
{

	public class DepartmentsController : ApiController
	{

		public HttpResponseMessage GetDepartments()
		{
			List<Department> theList = DepartmentManagement.GetInstance.GetDepartmentsList();

			return new HttpResponseMessage(HttpStatusCode.OK)
			{
				Content = new StringContent(JArray.FromObject(theList).ToString(), Encoding.UTF8, "application/json")
			};
		}
	}

	public class StaffsController : ApiController
	{

		public HttpResponseMessage Get()
		{
			List<StaffMaster> theList = StaffMasterManagement.GetInstance.GetOfficeEmployeeList();

			return new HttpResponseMessage(HttpStatusCode.OK)
			{
				Content = new StringContent(JArray.FromObject(theList).ToString(), Encoding.UTF8, "application/json")
			};
		}
	}

	public class LoginController : ApiController
	{

		public HttpResponseMessage Post([FromBody] UserLogin user)
		{
			User CurrentUser = UserManagement.GetInstance.GetUserByLoginName(user.UserName);
			Response response = new Response();

			if (CurrentUser.UserID.Equals(0) || CurrentUser == null)
            {
				response.message = "Invalid credential";
				return new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
				};
			}
			else if (!CurrentUser.Password.Equals(MicroSecurity.Encrypt(user.Password)))
			{
				response.message = "Invalid credential!";
				return new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JArray.FromObject(response).ToString(), Encoding.UTF8, "application/json")
				};
			}
			else
            {
				response.message = "Valid user";
				response.user = CurrentUser;
				return new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
				};
			}
		}
	}

	public class Response
    {
		public string message { get; set; }
		public User user { get; set; }
    }

}