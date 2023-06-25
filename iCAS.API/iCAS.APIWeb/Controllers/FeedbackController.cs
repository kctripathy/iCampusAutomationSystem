﻿using iCAS.APIWeb.Models;
using Micro.Objects.ICAS.ADMIN;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace iCAS.APIWeb.Controllers
{
    public class FeedbackController : ApiController
    {
        // GET: api/Feedback
        public List<UserFeedback> Get()
        {
            List<UserFeedback> theList = Micro.BusinessLayer.ICAS.ADMIN.UserManagement.GetInstance.SelectUserFeedback();
            return theList;
        }

        [Route("api/Feedback/Categories")]
        public List<UserFeedbackCategory> GetUserFeedbackCategory()
        {
            List<UserFeedbackCategory> theList = Micro.BusinessLayer.ICAS.ADMIN.UserManagement.GetInstance.SelectUserFeedbackCategory();
            return theList;
        }

        // GET: api/Feedback/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Feedback
        public HttpResponseMessage Post([FromBody]UserFeedback userFeedback)
        {
            Response response = new Response();
            int ret_value = Micro.BusinessLayer.ICAS.ADMIN.UserManagement.GetInstance.InsertUserFeedback(userFeedback);
            if (ret_value <= 0)
            {
                response.message = "Failed";
                response.data = 0;
            }
            else
            {
                response.message = "Success";
                response.data = ret_value;
            }
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
            };
        }

        // PUT: api/Feedback/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Feedback/5
        public void Delete(int id)
        {
        }
    }
}
