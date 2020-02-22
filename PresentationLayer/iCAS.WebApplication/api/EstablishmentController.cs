using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Micro.Objects.Administration;
using Micro.BusinessLayer.Administration;
using LTPL.ICAS.WebApplication.App_UserControls.ICAS;
using Micro.Objects.ICAS.ESTBLMT;
using Micro.BusinessLayer.ICAS.ESTBLMT;
using Newtonsoft.Json.Linq;
using System.Text;

namespace TCon.iCAS.WebApplication.api
{
	public class EstablishmentController : ApiController
	{
		// GET api/<controller>
		//public IEnumerable<string> Get()
		//{
		//	return new string[] { "value1", "value2" };
		//}
		public HttpResponseMessage Get()
		{
			//return new string[] { "value1", "value2" };
			List<Establishment> TheEstablishmentList = EstablishmentManagement.GetInstance.GetEstablishmentList();
			//UC_EstablishmentZone.PageVariables.TheEstablishmentList = TheEstablishmentList;

			return new HttpResponseMessage(HttpStatusCode.OK)
			{
				Content = new StringContent(JArray.FromObject(TheEstablishmentList).ToString(), Encoding.UTF8, "application/json")
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