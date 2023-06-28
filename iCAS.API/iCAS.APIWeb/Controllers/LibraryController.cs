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

        //[Route("api/Library/Book/{id}")]
        //public HttpResponseMessage GetBook([FromUri] int id)
        //{
        //    List<BookDetail> TheBooksList = LibraryManagement.GetInstance.GetBooksByID(id);
        //    return new HttpResponseMessage(HttpStatusCode.OK)
        //    {
        //        Content = new StringContent(JArray.FromObject(TheBooksList).ToString(), Encoding.UTF8, "application/json")
        //    };
        //}

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
