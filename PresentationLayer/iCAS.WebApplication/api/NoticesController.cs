using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Micro.Objects.Administration;
using Micro.BusinessLayer.Administration;
using Newtonsoft.Json.Linq;
using System.Text;

namespace TCon.iCAS.WebApplication.api
{
	public class NoticesController : ApiController
	{
		// GET api/<controller>
		//public IEnumerable<string> Get()
		//{
		//	return new string[] { "value1", "value2" };
		//}

		public HttpResponseMessage Get()
		{
			//return new string[] { "value1", "value2" };
			List<WebMenu> theParentWebMenuList = WebMenuManagement.GetInstance.GetParentWebMenuAll();

			return new HttpResponseMessage(HttpStatusCode.OK)
			{
				Content = new StringContent(JArray.FromObject(theParentWebMenuList).ToString(), Encoding.UTF8, "application/json")
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

		// DELETE api/<controller>/5
		public void Delete(int id)
		{
		}
	}
}