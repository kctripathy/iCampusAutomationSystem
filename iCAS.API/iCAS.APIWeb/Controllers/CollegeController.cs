using iCAS.APIWeb.Models;
using Micro.BusinessLayer.Administration;
using Micro.BusinessLayer.HumanResource;
using Micro.BusinessLayer.ICAS.ESTBLMT;
using Micro.BusinessLayer.ICAS.STAFFS;
using Micro.BusinessLayer.ICAS.STUDENT;
using Micro.Commons;
using Micro.Objects.HumanResource;
using Micro.Objects.ICAS.ESTBLMT;
using Micro.Objects.ICAS.STAFFS;
using Micro.Objects.ICAS.STUDENT;
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
using System.Web;
using System.Web.Http;

namespace iCAS.APIWeb.Controllers
{
    public class CollegeController : ApiController
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

        public Byte[] ToByteArray(Stream stream)
        {
            Int32 length = stream.Length > Int32.MaxValue ? Int32.MaxValue : Convert.ToInt32(stream.Length);
            Byte[] buffer = new Byte[length];
            stream.Read(buffer, 0, length);
            return buffer;
        }

        #region @@@@@@@@@@@@@@ College @@@@@@@@@@@@@@@@@@@@@
        /// <summary>
        /// Get all departments of the college
        /// </summary>
        /// <returns></returns>
        [Route("api/College/Departments")]
        public HttpResponseMessage GetDepartments()
        {
            List<Micro.Objects.ICAS.STAFFS.Department> theList = Micro.BusinessLayer.ICAS.STAFFS.DepartmentManagement.GetInstance.GetDepartments();

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JArray.FromObject(theList).ToString(), Encoding.UTF8, "application/json")
            };
        }

        [Route("api/College/Designations")]
        public HttpResponseMessage GetDesignations()
        {
            List<Micro.Objects.ICAS.STAFFS.Designation> theList = Micro.BusinessLayer.ICAS.STAFFS.DesignationManagement.GetInstance.GetDesignationsList();

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JArray.FromObject(theList).ToString(), Encoding.UTF8, "application/json")
            };
        }

        #endregion

        #region @@@@@@@@@@@@@@@@ Staffs @@@@@@@@@@@@@@@@@@@@@@@@@

        /// <summary>
        /// Get all staffs of the college
        /// </summary>
        /// <returns></returns>
        [Route("api/College/Staffs")]
        public HttpResponseMessage GetStaffs()
        {
            List<Staff> theList = StaffMasterManagement.GetInstance.GetStaffs();

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JArray.FromObject(theList).ToString(), Encoding.UTF8, "application/json")
            };
        }

        [HttpPost]
        [Route("api/College/Staff")]
        public HttpResponseMessage SaveStaff([FromBody]Staff2Save staff)
        {
            Response response = new Response();
            StaffMaster s = new StaffMaster();
            string token = GetRequestToken();
            if (token.Length > 0 && UserManagement.GetInstance.ValidateToken(staff.SavedByUserId, token))
            {
                int staffId = StaffMasterManagement.GetInstance.InsertUpdateEmployee(staff);
                if (staffId > 0)
                {
                    s = StaffMasterManagement.GetInstance.GetEmployeeByID(staffId);
                    response.message = "Success";
                    response.data = s;
                }
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
        [Route("api/College/Staff/Delete/{loggedOnUserId}")]
        public HttpResponseMessage DeleteStaff([FromBody] int id, int loggedOnUserId)
        {
            Response response = new Response();
            StaffMaster s = new StaffMaster();
            string token = GetRequestToken();

            if (token.Length > 0 && UserManagement.GetInstance.ValidateToken(loggedOnUserId, token))
            {
                long returnValue = StaffMasterManagement.GetInstance.DeleteStaff(id, loggedOnUserId);
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

        [Route("api/College/StaffDetails/{userId}/{staffId}")]
        public HttpResponseMessage GetStaffDetails(int userId, int staffId)
        {
            Response response = new Response();
            StaffMaster staffMaster = new StaffMaster();
            string token = GetRequestToken();
            if (token.Length > 0 && UserManagement.GetInstance.ValidateToken(userId, token))
            {
                staffMaster = StaffMasterManagement.GetInstance.GetEmployeeByID(staffId);
                response.message = "Success";
                response.data = staffMaster;
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

        /// <summary>
        /// Get staffs of given department
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>
        [Route("api/College/Staffs/Department/{name}")]
        public HttpResponseMessage GetStaffsByDepartment([FromUri]string name)
        {
            List<Staff> theList = StaffMasterManagement.GetInstance.GetStaffsByDepartment(name.ToUpper());

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JArray.FromObject(theList).ToString(), Encoding.UTF8, "application/json")
            };
        }

        /// <summary>
        /// Get the photo of the college staff
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/College/Staff/{id}/Photo")]
        public HttpResponseMessage GetStaffPhoto([FromUri] int id)
        {
            List<EmployeeProfile> theList = EmployeeProfileManagement.GetInstance.GetEmployeeProfileByEmployeeID(id); // StaffMasterManagement.GetInstance.GetStaffs();

            if (theList == null || theList.Count == 0)
            {
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JArray.FromObject(theList).ToString(), Encoding.UTF8, "application/json")
                };
            }

            byte[] imgData = theList[0].SettingKeyValue;
            MemoryStream ms = new MemoryStream(imgData);
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(ms);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
            return response;
        }

        [HttpPost]
        [Route("api/College/Staff/{loggedOnUserId}/{id}/UploadPhoto")]
        public HttpResponseMessage UploadStaffPhoto( int loggedOnUserId, int id)
        {
            Response response = new Response();
            string token = GetRequestToken();
            if (token.Length > 0 && UserManagement.GetInstance.ValidateToken(loggedOnUserId, token))
            {
                byte[] StaffImage = null;
                response.message = "Success";
                var base64String = Uri.UnescapeDataString(HttpContext.Current.Request.Form.ToString()).Split(',')[1];
                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(base64String)))
                {
                    StaffImage = ToByteArray(ms);
                }

                EmployeeProfile TheEmployeeProfile = new EmployeeProfile();
                TheEmployeeProfile.EmployeeID = id;
                TheEmployeeProfile.SettingKeyName = MicroEnums.CommonKeyNames.EmployeeProfile.GetStringValue();
                TheEmployeeProfile.SettingKeyID = 81;
                TheEmployeeProfile.SettingKeyReference = "Photo";
                TheEmployeeProfile.SettingKeyValue = StaffImage;

                int ProcReturnValue = EmployeeProfileManagement.GetInstance.InsertEmployeeProfile(TheEmployeeProfile);
                response.data = ProcReturnValue;
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
                };
                //return GetStaffPhoto(id);
            }
            else
            {
                response.message = "Access denied";
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
                };
            }
            
        }

        #endregion

        #region @@@@@@@@@ Students @@@@@@@@@@@@@@@@@@@@@@
        [HttpPost]
        [Route("api/College/Students")]
        public HttpResponseMessage GetStudents([FromBody] StudentSearchPayload payload)
        {
            List<StudentViewModel> theList = StudentManagement.GetInstance.GetStudents(payload);

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JArray.FromObject(theList).ToString(), Encoding.UTF8, "application/json")
            };
        }
        #endregion

        #region @@@@@@@@@@@@@@@ Establishments @@@@@@@@@@@@@@@@@@@@@@@

        /// <summary>
        /// Get all establishments of the office
        /// </summary>
        /// <returns></returns>
        [Route("api/College/Establishments")]
        public HttpResponseMessage GetEstablishments()
        {
            List<Establishment> TheEstablishmentList = EstablishmentManagement.GetInstance.GetEstablishmentList();
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JArray.FromObject(TheEstablishmentList).ToString(), Encoding.UTF8, "application/json")
            };
        }

        [HttpPost]
        [Route("api/College/Establishment/Save/{loggedOnUserId}/{employeeId}")]
        public HttpResponseMessage SaveEstablishment([FromBody] Establishment2Save estb, int loggedOnUserId, int employeeId)
        {
            
            Response response = new Response();
            string token = GetRequestToken();
            if (token.Length > 0 && UserManagement.GetInstance.ValidateToken(loggedOnUserId, token))
            {
                int id;
                Establishment e = new Establishment
                {
                    EstbID = estb.EstbID,
                    EstbTitle = estb.EstbTitle,
                    EstbTypeCode = estb.EstbTypeCode,
                    EstbDate = estb.EstbDate,
                    EstbViewStartDate = estb.EstbDate,
                    EstbViewEndDate = estb.EstbDate.AddYears(1),
                    EstbDescription = estb.EstbDesc,
                    EstbDescription1 = estb.EstbDesc1,
                    EstbDescription2 = estb.EstbDesc2,
                    FileNameWithPath = estb.FileName,
                    AuthorOrContributorName = estb.Author,
                    EstbStatusFlag = "A",
                    AddedBy = employeeId
                };
                
                if (estb.EstbID == 0)
                {
                    id = EstablishmentManagement.GetInstance.InsertEstablishment(e);
                }
                else
                {
                    id = EstablishmentManagement.GetInstance.UpdateEstablishment(e);
                }
                 
                response.message = "Success";
                response.data = id;
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
        [Route("api/College/Establishment/Delete/{loggedOnUserId}")]
        public HttpResponseMessage DeleteEstablishment([FromBody] int id, int loggedOnUserId)
        {
            Response response = new Response();
            string token = GetRequestToken();

            if (token.Length > 0 && UserManagement.GetInstance.ValidateToken(loggedOnUserId, token))
            {
                Establishment establishment = new Establishment();
                establishment.EstbID = id;

                long returnValue = EstablishmentManagement.GetInstance.DeleteEstablishment(establishment);
                response.message = "Success";
                response.data = returnValue;
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
                };
            }
            else
            {
                response.message = "Access denied";
                return new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
                };
            }
        }

        [HttpPost]
        [Route("api/College/Establishment/ChangeStatus/{loggedOnUserId}/{newStatus}")]
        public HttpResponseMessage ChangeEstablishmentStatus([FromBody] int id, int loggedOnUserId, string newStatus)
        {
            Response response = new Response();
            string token = GetRequestToken();

            if (token.Length > 0 && UserManagement.GetInstance.ValidateToken(loggedOnUserId, token))
            {
                long returnValue = EstablishmentManagement.GetInstance.UpdateStatusFlag(id, newStatus);
                response.message = "Success";
                response.data = returnValue;
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
                };
            }
            else
            {
                response.data = -420;
                response.message = "Unauthorized request";
                return new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent(JObject.FromObject(response).ToString(), Encoding.UTF8, "application/json")
                };
            }
        }


        [HttpPost]
        [Route("api/College/Establishment/{loggedOnUserId}/{estbId}/UploadPhoto")]
        public HttpResponseMessage UploadEstablishmentPhoto(int loggedOnUserId, long estbId)
        {
            Response response = new Response();
            string token = GetRequestToken();
            if (token.Length > 0 && UserManagement.GetInstance.ValidateToken(loggedOnUserId, token))
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
                string path = ConfigurationManager.AppSettings["uploadPathForEstablishments"].ToString();
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string fileName = string.Concat(estbId.ToString(), ".jpg");
                string filePath = String.Concat(path, "/", fileName);
                var base64String = Uri.UnescapeDataString(HttpContext.Current.Request.Form.ToString()).Split(',')[1];

                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(base64String)))
                {
                    using (Bitmap bm2 = new Bitmap(ms))
                    {
                        bm2.Save(filePath);
                    }
                }
                long returnValue = EstablishmentManagement.GetInstance.UpdateFileName(estbId, fileName);
                response.message = returnValue > 0 ?  "Success": "Failure";
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
        [Route("api/College/Establishment/{loggedOnUserId}/{estbId}/UploadPDF")]
        public HttpResponseMessage UploadEstablishmentPDF(int loggedOnUserId, long estbId)
        {
            Response response = new Response();
            string token = GetRequestToken();
            if (token.Length > 0 && UserManagement.GetInstance.ValidateToken(loggedOnUserId, token))
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
                string path = ConfigurationManager.AppSettings["uploadPathForEstablishments"].ToString();
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string fileName = $"{estbId}.pdf";
                string filePath = String.Concat(path, "/", fileName);
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
                long returnValue = EstablishmentManagement.GetInstance.UpdateFileName(estbId, fileName);
                response.message = returnValue > 0 ? "Success" : "Failure";
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
        #endregion
    }

}
