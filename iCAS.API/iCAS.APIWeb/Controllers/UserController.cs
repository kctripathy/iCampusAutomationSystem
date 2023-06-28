using iCAS.APIWeb.Models;
using Micro.BusinessLayer.Administration;
using Micro.Commons;
using Micro.Objects.Administration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace iCAS.APIWeb.Controllers
{
    public class UserController : ApiController
    {

		[Route("api/User/Login")]
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
				response.data = CurrentUser;
				return new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
				};
			}
		}
	}
}
