using iCAS.APIWeb.Models;
using Micro.BusinessLayer.ICAS.ADMIN;
using Micro.Objects.ICAS.ADMIN;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace iCAS.APIWeb.Controllers
{
    public class FeedbackController : ApiController
    {
        // GET: api/Feedback
        public List<UserFeedbackViewModel> Get()
        {
            List<UserFeedbackViewModel> theList = Micro.BusinessLayer.ICAS.ADMIN.UserManagement.GetInstance.SelectUserFeedback();
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

        #region STUDENT FEEDBACK
        [Route("api/Student/Feedback/Questions")]
        public List<Feedback> GetFeedbackQuestion()
        {
            List<Feedback> theList = FeedbackMasterManagement.GetInstance.GetFeedbackQuestions();
            return theList;
        }

        [HttpPost]
        [Route("api/Student/Feedback/Submit")]
        public HttpResponseMessage SubmitFeedback(object answers)
        {
            Response response = new Response();
            var feedback = JsonConvert.DeserializeObject<Dictionary<string, string>>(answers.ToString());
            
            Debug.Print(answers.ToString());
            Debug.Print(feedback.ToString());

            foreach (var f in feedback)
            {
                Debug.Print($"{f.Key}: {f.Value}");
            }

            int ret_value = FeedbackMasterManagement.GetInstance.SubmitFeedback(feedback);
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

        #endregion
    }
}
