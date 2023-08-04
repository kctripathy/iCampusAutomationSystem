using iCAS.APIWeb.Models;
using Micro.BusinessLayer.ICAS.LIBRARY;
using Micro.Objects.ICAS;
using Micro.Objects.ICAS.LIBRARY;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;

namespace iCAS.APIWeb.Controllers
{
    public class LibraryController : ApiController
    {

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

        [HttpPost]
        [Route("api/Library/Book/List")]
        public HttpResponseMessage GetLibraryBookList([FromBody] payload payload)
        {
            string ReturnMessage = WebConstants.SUCCESS;
            List<BookViewModel> TheBooksList = LibraryManagement.GetInstance.GetLibraryBooksList(payload);

            if (TheBooksList.Count == 0) ReturnMessage = WebConstants.FAILURE;

            ListResponse response = new ListResponse
            {
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
        [Route("api/Library/Book/{id}")]
        public HttpResponseMessage GetBookById([FromUri] long id)
        {
            LibraryBook book = LibraryManagement.GetInstance.GetBookByID(id);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JObject.FromObject(book).ToString(), Encoding.UTF8, "application/json")
            };
        }

        [HttpGet]
        [Route("api/Library/Book/Image/{id}")]
        public HttpResponseMessage GetBookImageById([FromUri] long id)
        {
            string path = string.Concat(ConfigurationManager.AppSettings["uploadPath"].ToString(), "PHOTO/", id.ToString(), ".jpg");

            //string path = String.Concat(HttpContext.Current.Server.MapPath("~/LibraryBook/Images"), "\\", id.ToString(), ".jpg");
            //if (!File.Exists(path))
            //{
            //    path = String.Concat(HttpContext.Current.Server.MapPath("~/LibraryBook/Images"), "\\0.jpg");
            //}

            Byte[] imgData = System.IO.File.ReadAllBytes(path);   
            MemoryStream ms = new MemoryStream(imgData);
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(ms);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
            return response;
        }

        [HttpGet]
        [Route("api/Library/Book/AccessionNo/{acno}")]
        public HttpResponseMessage GetBookById([FromUri] int acno)
        {
            BookViewModel book = LibraryManagement.GetInstance.GetBookByAccessionNo(acno);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JObject.FromObject(book).ToString(), Encoding.UTF8, "application/json")
            };
        }


        [HttpPost]
        [Route("api/Library/Admin/SaveBook/{userId}")]
        public HttpResponseMessage AdminSaveBook([FromBody] LibraryBook payload, int userId)
        {
            Response response = new Response();
            if (ValidateToken(userId))
            {
                long returnValue = LibraryManagement.GetInstance.SaveBook(payload, userId); //get all segments
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
                response.data = -4;
                return new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
                };
            }
        }


        [HttpPost]
        [Route("api/Library/Admin/DeleteBook/{userId}")]
        public HttpResponseMessage AdminDeleteBook([FromBody] long id, int userId)
        {
            Response response = new Response();
            if (ValidateToken(userId))
            {
                long returnValue = LibraryManagement.GetInstance.DeleteBook(id);
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

       
        [HttpPost]
        [Route("api/Library/Admin/UploadBookImage/{userId}/{id}")]
        public HttpResponseMessage AdminUploadBookImage(int userId, long id)
        {
            Response response = new Response();
            if (ValidateToken(userId))
            {
                if (HttpContext.Current.Request.Form.ToString().Equals(""))
                {
                    response.message = "No file to upload";
                    return new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
                    };
                }
                //Create the Directory.
                //string path = HttpContext.Current.Server.MapPath("~/LibraryBook/Images");
                string path = string.Concat(ConfigurationManager.AppSettings["uploadPath"].ToString(), "PHOTO");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string filePath = String.Concat(path, "/", id.ToString(), ".jpg");
                var base64String = Uri.UnescapeDataString(HttpContext.Current.Request.Form.ToString()).Split(',')[1];

                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(base64String)))
                {
                    using (Bitmap bm2 = new Bitmap(ms))
                    {
                        bm2.Save(filePath);
                    }
                }
                long returnValue = LibraryManagement.GetInstance.UpdateImageOrPDF(id,"image");
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
                response.data = -4;
                return new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
                };
            }
        }



        [HttpPost]
        [Route("api/Library/Admin/UploadBookPDF/{userId}/{id}")]
        public HttpResponseMessage AdminUploadBookPDF(int userId, long id)
        {
            Response response = new Response();
            if (ValidateToken(userId))
            {
                if (HttpContext.Current.Request.Form.ToString().Equals(""))
                {
                    response.message = "No file to upload";
                    return new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
                    };
                }
                //Create the Directory.
                //string path = HttpContext.Current.Server.MapPath("~/LibraryBook/PDF");
                //string path = @"P:\tsdc\docs\backoffice.tsdcollege.in\Documents\LibraryBook\PDF";
                string path = string.Concat(ConfigurationManager.AppSettings["uploadPath"].ToString(), "PDF");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string filePath = String.Concat(path, "/", id.ToString(), ".pdf");
                var base64String = Uri.UnescapeDataString(HttpContext.Current.Request.Form.ToString()).Split(',')[1];

                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(base64String)))
                {
                    using (FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        byte[] bytes = new byte[ms.Length];
                        ms.Read(bytes, 0, (int)ms.Length);
                        file.Write(bytes, 0, bytes.Length);
                        ms.Close();
                    }
                }

                //
                long returnValue = LibraryManagement.GetInstance.UpdateImageOrPDF(id);
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
                response.data = -4;
                return new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
                };
            }
        }





        [Obsolete]
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


        #region Categories and Segments

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
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
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

        #region Author
        [HttpGet]
        [Route("api/Library/Author/List")]
        public HttpResponseMessage GetAuthors()
        {
            Response response = new Response();
            try
            {
                List<Author> list = LibraryManagement.GetInstance.GetBook_Authors();
                response.message = "Success";
                response.data = list;
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception)
            {
                response.message = "Failure";
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
                };
            }
        }


        [HttpPost]
        [Route("api/Library/Author/Save/{userId}")]
        public HttpResponseMessage SaveAuthor([FromBody] dynamic payload, int userId)
        {
            Response response = new Response();
            if (ValidateToken(userId))
            {
                int returnValue = LibraryManagement.GetInstance.SaveAuthor(payload);
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
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
                };
            }
        }

        [HttpPost]
        [Route("api/Library/Author/Delete/{userId}")]
        public HttpResponseMessage DeleteAuthor([FromBody] int id, int userId)
        {
            Response response = new Response();
            if (ValidateToken(userId))
            {
                int returnValue = LibraryManagement.GetInstance.DeleteAuthor(id);
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

        #region Publisher
        [HttpGet]
        [Route("api/Library/Publisher/List")]
        public HttpResponseMessage GetPublishers()
        {
            Response response = new Response();
            try
            {
                List<Publisher> list = LibraryManagement.GetInstance.GetBook_Publishers();
                response.message = "Success";
                response.data = list;
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception)
            {
                response.message = "Failure";
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
                };
            }
        }


        [HttpPost]
        [Route("api/Library/Publisher/Save/{userId}")]
        public HttpResponseMessage SavePublisher([FromBody] dynamic payload, int userId)
        {
            Response response = new Response();
            if (ValidateToken(userId))
            {
                int returnValue = LibraryManagement.GetInstance.SavePublisher(payload);
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
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
                };
            }
        }

        [HttpPost]
        [Route("api/Library/Publisher/Delete/{userId}")]
        public HttpResponseMessage DeletePublisher([FromBody] int id, int userId)
        {
            Response response = new Response();
            if (ValidateToken(userId))
            {
                int returnValue = LibraryManagement.GetInstance.DeletePublisher(id);
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


        #region Supplier
        [HttpGet]
        [Route("api/Library/Supplier/List")]
        public HttpResponseMessage GetSuppliers()
        {
            Response response = new Response();
            try
            {
                List<Supplier> list = LibraryManagement.GetInstance.GetBook_Suppliers();
                response.message = "Success";
                response.data = list;
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception)
            {
                response.message = "Failure";
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
                };
            }
        }


        [HttpPost]
        [Route("api/Library/Supplier/Save/{userId}")]
        public HttpResponseMessage SaveSupplier([FromBody] dynamic payload, int userId)
        {
            Response response = new Response();
            if (ValidateToken(userId))
            {
                int returnValue = LibraryManagement.GetInstance.SaveSupplier(payload);
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
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
                };
            }
        }

        [HttpPost]
        [Route("api/Library/Supplier/Delete/{userId}")]
        public HttpResponseMessage DeleteSupplier([FromBody] int id, int userId)
        {
            Response response = new Response();
            if (ValidateToken(userId))
            {
                int returnValue = LibraryManagement.GetInstance.DeleteSupplier(id);
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
