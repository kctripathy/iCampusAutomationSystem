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
using Micro.Objects.HumanResource;
using Micro.BusinessLayer.HumanResource;
using System.Drawing;
using System.IO;
using Micro.Objects.ICAS.ADMIN;

namespace TCon.iCAS.WebApplication.api
{

	public class DepartmentsController : ApiController
	{

		public HttpResponseMessage GetDepartments()
		{
			List<Micro.Objects.ICAS.STAFFS.Department> theList = Micro.BusinessLayer.ICAS.STAFFS.DepartmentManagement.GetInstance.GetDepartments();

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
			List<Staff> theList = StaffMasterManagement.GetInstance.GetStaffs();

			return new HttpResponseMessage(HttpStatusCode.OK)
			{
				Content = new StringContent(JArray.FromObject(theList).ToString(), Encoding.UTF8, "application/json")
			};
		}

		public HttpResponseMessage GetByDepartment(string dept)
		{
			List<Staff> theList = StaffMasterManagement.GetInstance.GetStaffsByDepartment(dept);

			return new HttpResponseMessage(HttpStatusCode.OK)
			{
				Content = new StringContent(JArray.FromObject(theList).ToString(), Encoding.UTF8, "application/json")
			};
		}
	}

	public class StaffPhotoController : ApiController
	{

		public HttpResponseMessage Get(int id)
		{
			List<EmployeeProfile> theList = EmployeeProfileManagement.GetInstance.GetEmployeeProfileByEmployeeID(id); // StaffMasterManagement.GetInstance.GetStaffs();

			if (theList == null || theList.Count == 0)
            {
				return new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JArray.FromObject(theList).ToString(), Encoding.UTF8, "application/json")
				};
			}

			//Image img = (Image)theList[0].SettingKeyValue;
			byte[] imgData = theList[0].SettingKeyValue;
			MemoryStream ms = new MemoryStream(imgData);
			HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
			response.Content = new StreamContent(ms);
			response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
			return response;

			//return new HttpResponseMessage(HttpStatusCode.OK)
			//{
			//	Content = new StringContent(JArray.FromObject(theList).ToString(), Encoding.UTF8, "application/json")
			//};
		}

	
	}



	public class LoginController : ApiController
	{

		public HttpResponseMessage Post([FromBody] UserLogin user)
		{
			Micro.Objects.Administration.User CurrentUser = UserManagement.GetInstance.GetUserByLoginName(user.UserName);
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

	public class FeedbackController : ApiController
	{

		public HttpResponseMessage Get()
		{
			List<UserFeedback> theList = Micro.BusinessLayer.ICAS.ADMIN.UserManagement.GetInstance.SelectUserFeedback();

			return new HttpResponseMessage(HttpStatusCode.OK)
			{
				Content = new StringContent(JArray.FromObject(theList).ToString(), Encoding.UTF8, "application/json")
			};
		}

		public HttpResponseMessage Post([FromBody] UserFeedback userFeedback)
		{
			int ret_value = Micro.BusinessLayer.ICAS.ADMIN.UserManagement.GetInstance.InsertUserFeedback(userFeedback);

			APIResponse response = new APIResponse();
			if (ret_value <= 0)
			{
				response.message = "Failed";
				return new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
				};
			}
			else
			{
				response.message = "Success";
				return new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
				};
			}
		}
	}

	public class APIResponse
    {
		public string message { get; set; }
    }

	public class Response
	{
		public string message { get; set; }
		public Micro.Objects.Administration.User user { get; set; }
	}

}