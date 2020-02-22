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
    public class StudentPreQualiIntegration
    {
        public static List<StudentPreviousQual> GetPreQualList(int StudentID)
        {
            try
            {
                List<StudentPreviousQual> TheQualList = ConvertDatarowToObject(StudentPreQualsDataAccess.GetInstance.GetPreQualsList(StudentID));
                return TheQualList;
            }
            catch (Exception ex)
            {
                throw (new Exception(String.Format("{0}.{1}", MethodBase.GetCurrentMethod().DeclaringType, (new System.Diagnostics.StackFrame()).GetMethod().Name), ex));
            }
        }

        public static List<StudentPreviousQual> ConvertDatarowToObject(DataTable QualListTable)
        {
            List<StudentPreviousQual> PreQualList = new List<StudentPreviousQual>();

            foreach (DataRow dr in QualListTable.Rows)
            {

                StudentPreviousQual ThePreQual = new StudentPreviousQual();
                ThePreQual.QualName = dr["QualName"].ToString();
                ThePreQual.QualCode = dr["QualCode"].ToString();
                ThePreQual.PreQualID = int.Parse(dr["PreQualID"].ToString());
                ThePreQual.QualID = int.Parse(dr["QualID"].ToString());
                ThePreQual.StudentID = int.Parse(dr["StudentID"].ToString());
                ThePreQual.Board = dr["Board"].ToString();
                ThePreQual.Division = dr["Division"].ToString();
                ThePreQual.Percentage = dr["Percentage"].ToString();
                ThePreQual.PassingYear = dr["PassingYear"].ToString();
                ThePreQual.OfficeID = int.Parse(dr["OfficeID"].ToString());
                PreQualList.Add(ThePreQual);
            }
            return PreQualList;
        }
    }
}
