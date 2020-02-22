using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.ICAS.LIBRARY
{
    public class Transaction
    {
        public Int64 ID { get; set; }
        public DateTime Date{ get; set; }
        public string Type { get; set; } // I - ISSUE R - RETURN
        public int UserID { get; set; } // 
        public string UserType { get; set; } // S- STUDENT, E-EMPLOYEE
        public float FineAmount { get; set; }

    }
}
