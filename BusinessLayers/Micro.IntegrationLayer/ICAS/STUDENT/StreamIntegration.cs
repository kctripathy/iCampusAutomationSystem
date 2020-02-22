using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using Micro.Commons;
using System.Reflection;
using Micro.Objects.ICAS.STUDENT;
using Micro.DataAccessLayer.ICAS.STUDENT;

namespace Micro.IntegrationLayer.ICAS.STUDENT
{
    public class StreamIntegration
    {
        public static List<Streams> GetStreamList()
        {
            try
            {
                List<Streams> TheStreamList = ConvertDatarowToObject(StreamDataAccess.GetInstance.GetStreamAll());
                return TheStreamList;
            }
            catch (Exception ex)
            {
                throw (new Exception(String.Format("{0}.{1}", MethodBase.GetCurrentMethod().DeclaringType, (new System.Diagnostics.StackFrame()).GetMethod().Name), ex));
            }
        }
     
        public static List<Streams> ConvertDatarowToObject(DataTable StreamListTable)
        {
            List<Streams> StreamList = new List<Streams>();

            foreach (DataRow dr in StreamListTable.Rows)
            {

                Streams TheStream = new Streams();
                TheStream.StreamID = int.Parse(dr["StreamID"].ToString());
                TheStream.StreamName = dr["StreamName"].ToString();               
                StreamList.Add(TheStream);
            }
            return StreamList;
        }
        
    }
}
