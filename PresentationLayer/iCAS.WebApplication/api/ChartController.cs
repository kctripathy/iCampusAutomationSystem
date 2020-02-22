using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Micro.BusinessLayer;
using Newtonsoft.Json.Linq;
using System.Text;
namespace TCon.iCAS.WebApplication.api
{
	public class ChartController : ApiController
	{
		// GET api/<controller>
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
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

		public HttpResponseMessage Get(string chart_name)
		{
			DataTable dtData = ChartManagement.GetStudentStrengthYearWise();

			return new HttpResponseMessage(HttpStatusCode.OK)
			{
				Content = new StringContent(JArray.FromObject(dtData).ToString(), Encoding.UTF8, "application/json")
			};

			//return new string[] { "value1", "value2" };
			//List<WebMenu> theParentWebMenuList = WebMenuManagement.GetInstance.GetParentWebMenuAll();

			//return new HttpResponseMessage(HttpStatusCode.OK)
			//{
			//	Content = new StringContent(JArray.FromObject(theParentWebMenuList).ToString(), Encoding.UTF8, "application/json")
			//};
		}
	}
}