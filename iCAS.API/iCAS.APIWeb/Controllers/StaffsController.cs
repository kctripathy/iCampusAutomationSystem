﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Micro.Objects.ICAS.STAFFS;
using Micro.BusinessLayer.ICAS.STAFFS;

namespace iCAS.APIWeb.Controllers
{
    public class StaffsController : ApiController
    {
        // GET: api/Staffs
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Staffs/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Staffs
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Staffs/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Staffs/5
        public void Delete(int id)
        {
        }
    }
}