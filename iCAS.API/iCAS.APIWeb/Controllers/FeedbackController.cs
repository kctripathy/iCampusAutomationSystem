using iCAS.APIWeb.Models;
using Micro.BusinessLayer.ICAS.ADMIN;
using Micro.BusinessLayer.Administration;
using Micro.Objects.ICAS.ADMIN;
using Micro.Objects.ICAS.STAFFS;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Micro.BusinessLayer.ICAS.STAFFS;

namespace iCAS.APIWeb.Controllers
{
    public class FeedbackController : ApiController
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

        [Route("api/Student/Feedback/Master")]
        public List<Feedback> GetFeedbackMaster()
        {
            List<Feedback> theList = FeedbackMasterManagement.GetInstance.GetFeedbackMaster();
            return theList;
        }

        [Route("api/Student/Feedback/StudentsWhoSubmittedFeedback")]
        public List<StudentWhoSubmittedFeedback> GetStudentsWhoSubmittedFeedback(int feedbackId)
        {
            List<StudentWhoSubmittedFeedback> theList = FeedbackMasterManagement.GetInstance.GetStudentWhoSubmittedFeedback(feedbackId);
            return theList;
        }

        [Route("api/Student/Feedback/Answers/{staffId}")]
        public HttpResponseMessage GetStudentFeedbackAnswers(int staffId, int feedbackId, int userId)
        {

            Response response = new Response();
            string token = GetRequestToken();
            if (token.Length > 0 && Micro.BusinessLayer.Administration.UserManagement.GetInstance.ValidateToken(staffId, token))
            {
                List<StudentFeedbackAnswer> theList = FeedbackMasterManagement.GetInstance.GetStudentsFeedbacksAnswers(feedbackId, userId);
                response.message = "Success";
                response.data = theList;
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

        [HttpPost]
        [Route("api/Student/Feedback/Questions/{staffId}")]
        public HttpResponseMessage InsertStudentFeedbackQuestions(int staffId, FeedbackQuestionInput fq)
        {

            Response response = new Response();
            string token = GetRequestToken();
            if (token.Length > 0 && Micro.BusinessLayer.Administration.UserManagement.GetInstance.ValidateToken(staffId, token))
            {
                int returnValue = FeedbackMasterManagement.GetInstance.InsertFeedbackQuestion(fq);
                response.message = "Success";
                response.data = returnValue;
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

        [HttpPost]
        [Route("api/Student/Feedback/Questions/{staffId}/{questionId}")]
        public HttpResponseMessage DeleteStudentFeedbackQuestions(int staffId, int questionId)
        {

            Response response = new Response();
            string token = GetRequestToken();
            if (token.Length > 0 && Micro.BusinessLayer.Administration.UserManagement.GetInstance.ValidateToken(staffId, token))
            {
                int returnValue = FeedbackMasterManagement.GetInstance.DeleteFeedbackQuestion(questionId);
                response.message = "Success";
                response.data = returnValue;
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

        #endregion
    }
}
