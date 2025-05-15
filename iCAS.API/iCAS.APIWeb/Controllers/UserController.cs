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
			Micro.Objects.Administration.User CurrentUser = UserManagement.GetInstance.Login(user.UserName,"YES");
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
				response.message = "Invalid password!";

				return new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
				};
			}
			else
			{
				response.message = "Valid user";
				response.data = new UserLoginRespsonse
				{
					UserID = CurrentUser.UserID,
					RoleID = CurrentUser.RoleID,
					UserReferenceID = CurrentUser.UserReferenceID,
					UserType = CurrentUser.UserType,
					UserName = CurrentUser.UserName,
					UserReferenceName = CurrentUser.UserReferenceName,
					RoleDescription = CurrentUser.RoleDescription,
					EmailAddress = CurrentUser.EmailAddress,
					PhoneNumber = CurrentUser.PhoneNumber,
					IsPasswordChangeDue = CurrentUser.IsPasswordChangeDue,
					Designation = CurrentUser.Designation,
					token = CurrentUser.token
				};
				return new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
				};
			}
		}

		[Route("api/User/{id}")]
		public HttpResponseMessage GetUserById([FromUri] int id)
		{

			Response response = new Response();
			string token = GetRequestToken();
			if (UserManagement.GetInstance.ValidateToken(id, token))
            {
				response.message = "Success";
				
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

		//api/User/495/ChangePassword
		[Route("api/User/ChangePassword")]
		public HttpResponseMessage ChangePassword([FromBody] UserChangePassword user)
		{
			Response response = new Response();

			//Validate the token first
			string token = GetRequestToken();
			//if (!UserManagement.GetInstance.ValidateToken(user.UserId, token))
			//{
			//	response.message = "Invalid token!";
			//	return new HttpResponseMessage(HttpStatusCode.OK)
			//	{
			//		Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
			//	};
			//}

			//Check if old password is okayy
			Micro.Objects.Administration.User CurrentUser = UserManagement.GetInstance.Login(user.UserName, "NO");
			if (!CurrentUser.Password.Equals(MicroSecurity.Encrypt(user.OldPassword)))
			{
				response.message = "Invalid old password!";
				return new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
				};
			}
			if (!token.ToUpper().Contains(CurrentUser.token.ToUpper()))
			{
				response.message = "Invalid token!";
				return new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
				};
			}
			else
			{
				User ThisUser = new User
                {
					UserID = user.UserId,
					Password = MicroSecurity.Encrypt(user.NewPassword)
                };
				int result = ChangePasswordManagement.GetInstance.UpdateChangePassword(ThisUser);
				response.message = result>0? "Success": "Failure";

				return new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
				};
			}
		}

		[HttpPost]
		[Route("api/User/UpdatePassword/{loggedOnUserId}")]
		public HttpResponseMessage UpdateUserPassword([FromBody] UpdatePasswordModel payload, int loggedOnUserId)
		{
			Response response = new Response();
			string token = GetRequestToken();

			if (token.Length > 0 && UserManagement.GetInstance.ValidateToken(loggedOnUserId, token))
			{
				long returnValue = UserManagement.GetInstance.UpdatePassword(payload);

				response.message = "Success";
				response.data = returnValue;
				return new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
				};
			}
			else
			{
				response.message = "Unauthorized request";
				return new HttpResponseMessage(HttpStatusCode.Unauthorized)
				{
					Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
				};
			}
		}

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
	}
}
