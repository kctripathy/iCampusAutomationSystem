using iCAS.APIWeb.Models;
using Micro.BusinessLayer.ICAS.LIBRARY;
using Micro.Objects.ICAS;
using Micro.Objects.ICAS.LIBRARY;
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
    public class LibraryController : ApiController
    {
        /// <summary>
        /// Get Library Books
        /// </summary>
        /// <returns></returns>
        [Route("api/Library/Books")]
        public HttpResponseMessage GetBooks()
        {
            List<Book> TheBooksList = LibraryManagement.GetInstance.GetBooksList_DistinctRecords();
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JArray.FromObject(TheBooksList).ToString(), Encoding.UTF8, "application/json")
            };
        }

        [Route("api/Library/BooksList")]
        public HttpResponseMessage GetBooks([FromUri] PagingParameterModel pageRequest)
        {
            string ReturnMessage = WebConstants.SUCCESS;
            List<BookViewModel> TheBooksList = LibraryManagement.GetInstance.GetBooksListPage(pageRequest);
            if (TheBooksList.Count == 0) ReturnMessage = WebConstants.FAILURE;
            Response response = new Response { message = ReturnMessage,data = TheBooksList };
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
            };
        }


        #region for library module

        [Route("api/Library/Book/Categories")]
        public HttpResponseMessage GetCategories()
        {
            List<BookCategory> list = LibraryManagement.GetInstance.GetBook_Categories(true); //get categories those have books available
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JArray.FromObject(list).ToString(), Encoding.UTF8, "application/json")
            };
        }

        [Route("api/Library/Book/Segments")]
        public HttpResponseMessage GetSegments()
        {
            List<BookSegment> list = LibraryManagement.GetInstance.GetBook_BookSegments(true); //get categories those have books available
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JArray.FromObject(list).ToString(), Encoding.UTF8, "application/json")
            };
        }


        [HttpPost]
        [Route("api/Library/Book/List")]
        public HttpResponseMessage GetLibraryBookList([FromBody] payload payload)
        {
            string ReturnMessage = WebConstants.SUCCESS;
            List<BookViewModel> TheBooksList = LibraryManagement.GetInstance.GetLibraryBooksList(payload);

            if (TheBooksList.Count == 0) ReturnMessage = WebConstants.FAILURE;

            ListResponse response = new ListResponse { 
                message = ReturnMessage, 
                data = TheBooksList, 
                pageNo = payload.pageNo,
                pageSize = payload.pageSize,
                totalRecordFetched = TheBooksList.Count
            };
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
            };
        }


        [HttpGet]
        [Route("api/Library/Summary")]
        public HttpResponseMessage GetSummary()
        {
            LibrarySummary library = LibraryManagement.GetInstance.GetLibrarySummary();
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JObject.FromObject(library).ToString(), Encoding.UTF8, "application/json")
            };
        }


        [HttpGet]
        [Route("api/Library/Admin/GetSegments")]
        public HttpResponseMessage AdminGetSegments()
        {
            List<BookSegment> list = LibraryManagement.GetInstance.GetBook_BookSegments(false); //get all segments
            Response response = new Response { message = "Success", data = list };
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
            };
        }

        [HttpPost]
        [Route("api/Library/Admin/SaveSegment/{userId}")]
        public HttpResponseMessage AdminSaveSegments([FromBody] dynamic payload, int userId)
        {
            Response response = new Response();
            if (ValidateToken(userId))
            {
                int returnValue = LibraryManagement.GetInstance.SaveSegment(payload); //get all segments
                response.message = "Success";
                response.data = returnValue;
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
                };
            }
            else
            {
                response.message = "Invalid request";
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
                };
            }
        }

        [HttpPost]
        [Route("api/Library/Admin/DeleteSegment/{userId}")]
        public HttpResponseMessage AdminDeleteSegments([FromBody] int id, int userId)
        {
            Response response = new Response();
            if (ValidateToken(userId))
            {
                int returnValue = LibraryManagement.GetInstance.DeleteSegment(id);
                response.message = "Success";
                response.data = returnValue;
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
                };
            }
            else
            {
                response.message = "Invalid request";
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
                };
            }
        }

        //
        // CATEGORIES
        //
        [HttpGet]
        [Route("api/Library/Admin/GetCategories")]
        public HttpResponseMessage AdminGetCategories()
        {
            List<BookCategory> list = LibraryManagement.GetInstance.GetBook_Categories(false); //get all segments
            Response response = new Response { message = "Success", data = list };
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
            };
        }

        [HttpPost]
        [Route("api/Library/Admin/SaveCategory/{userId}")]
        public HttpResponseMessage AdminSaveCategory([FromBody] dynamic payload, int userId)
        {
            Response response = new Response();
            if (ValidateToken(userId))
            {
                int returnValue = LibraryManagement.GetInstance.SaveCategory(payload); //get all segments
                response.message = "Success";
                response.data = returnValue;
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
                };
            }
            else
            {
                response.message = "Invalid request";
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
                };
            }
        }

        [HttpPost]
        [Route("api/Library/Admin/DeleteCategory/{userId}")]
        public HttpResponseMessage AdminDeleteCategory([FromBody] int id, int userId)
        {
            Response response = new Response();
            if (ValidateToken(userId))
            {
                int returnValue = LibraryManagement.GetInstance.DeleteCategory(id);
                response.message = "Success";
                response.data = returnValue;
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
                };
            }
            else
            {
                response.message = "Invalid request";
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
                };
            }
        }
        #endregion

        #region Authentication
        private bool ValidateToken(int userId)
        {
            Response response = new Response();
            string token = GetRequestToken();
            if (token.Length > 0 && Micro.BusinessLayer.Administration.UserManagement.GetInstance.ValidateToken(userId, token))
            {
                return true;
            }
            else
            {
                return false;
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
        #endregion

    }
}
