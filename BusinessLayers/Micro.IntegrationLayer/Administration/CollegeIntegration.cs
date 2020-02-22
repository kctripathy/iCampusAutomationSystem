using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.Administration;
using System.Data;
using Micro.DataAccessLayer.Administration;

namespace Micro.IntegrationLayer.Administration
{
    public partial class CollegeIntegration
    {

        //public static List<College> GetCollgeList()
        //{
        //    List<College> TheList = new List<College>();

        //    DataTable TheCollgeDataTable = CollegeDataAccess.GetInstance.GetCollegeList();

        //    foreach (DataRow dr in TheCollgeDataTable.Rows)
        //    {
        //        College objCollege = new College();
                
        //        objCollege.CollegeCode = dr["COLLEGECODE"].ToString();
        //        objCollege.CollegeName = dr["COLLEGENAME"].ToString();

        //        TheList.Add(objCollege);
        //    }
        //    return TheList;
        //}
    }
}
