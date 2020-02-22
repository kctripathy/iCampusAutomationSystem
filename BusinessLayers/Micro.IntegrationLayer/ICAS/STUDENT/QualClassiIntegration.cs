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
    public class QualClassiIntegration
    {
        public static List<QualClass> GetClassListByQualID(int QualID)
        {
            try
            {
                List<QualClass> TheQualClassList = ConvertDatarowToObject(QualClassDataAccess.GetInstance.GetClassListByQualID(QualID));
                return TheQualClassList;
            }
            catch (Exception ex)
            {
                throw (new Exception(String.Format("{0}.{1}", MethodBase.GetCurrentMethod().DeclaringType, (new System.Diagnostics.StackFrame()).GetMethod().Name), ex));
            }
        }
        public static List<QualClass> GetClassListByStreamAndQual(int QualID,int StreamID)
        {
            try
            {
                List<QualClass> TheQualClassList = ConvertDatarowToObject(QualClassDataAccess.GetInstance.GetClassListByStreamAndQual(QualID,StreamID));
                return TheQualClassList;
            }
            catch (Exception ex)
            {
                throw (new Exception(String.Format("{0}.{1}", MethodBase.GetCurrentMethod().DeclaringType, (new System.Diagnostics.StackFrame()).GetMethod().Name), ex));
            }
        }
        public static List<QualClass> ConvertDatarowToObject(DataTable QualClassListTable)
        {
            List<QualClass> QualClassList = new List<QualClass>();

            foreach (DataRow dr in QualClassListTable.Rows)
            {
                QualClass TheQualClass = new QualClass();
                TheQualClass.QualID = int.Parse(dr["QualID"].ToString());
                TheQualClass.ClassID = int.Parse(dr["ClassID"].ToString());
                TheQualClass.ClassName = dr["ClassName"].ToString();
                TheQualClass.StreamID =int.Parse(dr["StreamID"].ToString());
                TheQualClass.StreamYearNo = dr["StreamYearNo"].ToString();               
                QualClassList.Add(TheQualClass);
            }
            return QualClassList;
        }
        //public static int InsertQuals(Qualification theQualification)
        //{
        //    return QualsDataAccess.GetInstance.InsertQuals(theQualification);
        //}
    }
}
