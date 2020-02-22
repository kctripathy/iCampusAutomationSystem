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
    public class QualiIntegration
    {
        public static List<Qualification> GetQualList()
        {
            try
            {
                List<Qualification> TheQualList = ConvertDatarowToObject(QualsDataAccess.GetInstance.GetQualsList());
                return TheQualList;
            }
            catch (Exception ex)
            {
                throw (new Exception(String.Format("{0}.{1}", MethodBase.GetCurrentMethod().DeclaringType, (new System.Diagnostics.StackFrame()).GetMethod().Name), ex));
            }
        }

        public static List<Qualification> ConvertDatarowToObject(DataTable QualListTable)
        {
            List<Qualification> QualList = new List<Qualification>();

            foreach (DataRow dr in QualListTable.Rows)
            {

                Qualification TheQual = new Qualification();
                TheQual.QualID = int.Parse(dr["QualID"].ToString());
                TheQual.QualCode = dr["QualCode"].ToString();
                TheQual.QualType = dr["QualType"].ToString();
                TheQual.ClassType = dr["ClassType"].ToString();
                TheQual.QualName = dr["QualName"].ToString();
                QualList.Add(TheQual);
            }
            return QualList;
        }
        public static int InsertQuals(Qualification theQualification)
        {
            return QualsDataAccess.GetInstance.InsertQuals(theQualification);
        }
    }
}
