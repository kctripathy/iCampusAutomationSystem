using Micro.BusinessLayer.ICAS.LIBRARY;
using Micro.Objects.ICAS.LIBRARY;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using TCon.iCAS.WebApplication.Database;

namespace TCon.iCAS.WebApplication.api
{
    public class BooksController : ApiController
    {

        iCAS_LibraryEntity objLibrary = new iCAS_LibraryEntity();
        public HttpResponseMessage Get()
        {
            List<Book> TheBooksList = LibraryManagement.GetInstance.GetBooksList_DistinctRecords();
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JArray.FromObject(TheBooksList).ToString(), Encoding.UTF8, "application/json")
            };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // To Insert new Student Details
        //[HttpGet]
        //public IEnumerable<string> insertStudent(Book objBook)
        //{
        //    //return objapi.USP_Student_Insert(StudentName, StudentEmail, Phone, Address).AsEnumerable();
        //    //objLibrary.LIB_Book_Insert(
        //    //    objBook.AccessionNo,
        //    //    objBook.BookType
        //    //    )
        //}

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}