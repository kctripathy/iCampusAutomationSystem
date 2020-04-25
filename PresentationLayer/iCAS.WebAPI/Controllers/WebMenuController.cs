using Micro.BusinessLayer.Administration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace iCAS.WebAPI.Controllers
{
    public class WebMenuController : ApiController
    {
        // GET: api/MenuItems
        public HttpResponseMessage Get()
        {
            //return new string[] { "value1", "value2" };
            List<Micro.Objects.Administration.WebMenu> allMenuItems =WebMenuManagement.GetInstance.SelectAllMenuItemsByRoleId(7);

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JArray.FromObject(allMenuItems).ToString(), Encoding.UTF8, "application/json")
            };
        }


        public HttpResponseMessage GetByRoleId(int roleId)
        {
            //return new string[] { "value1", "value2" };
            List<Micro.Objects.Administration.WebMenu> allMenuItems = WebMenuManagement.GetInstance.SelectAllMenuItemsByRoleId(roleId);

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JArray.FromObject(allMenuItems).ToString(), Encoding.UTF8, "application/json")
            };
        }
    }
}
