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

        #endregion

        // GET: api/Library
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Library/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Library
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Library/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Library/5
        public void Delete(int id)
        {
        }
    }
}
