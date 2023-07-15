using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iCAS.APIWeb.Models
{
    public class Response
    {
        public string message;
        public object data;
    }

    public class ListResponse
    {
        public string message;
        public object data;
        public int pageNo;
        public int pageSize;
        public int totalRecordFetched;
    }
}