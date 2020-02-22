using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.STUDENT;
using System.Data;
using System.Reflection;
using Micro.DataAccessLayer.ICAS.STUDENT;

namespace Micro.IntegrationLayer.ICAS.STUDENT
{
    public class SubjectPaperIntegration
    {
        public static List<SubjectPapers> GetPaperListBySubjectID(int PaperID, string searchText = null, bool showDeleted = false)
        {
            try
            {
                DataTable GetPaperListBySubjectTable = SubjectPaperDataAccess.GetInstance.GetPaperListBySubjectID(PaperID, searchText, showDeleted);
                List<SubjectPapers> PaperList = new List<SubjectPapers>();
                foreach (DataRow dr in GetPaperListBySubjectTable.Rows)
                {
                    SubjectPapers ObjSubjectPapers = new SubjectPapers();
                    ObjSubjectPapers.SubjectPaperID = int.Parse(dr["SubjectPaperID"].ToString());
                    ObjSubjectPapers.SubjectPaperName = dr["SubjectPaperName"].ToString();
                    PaperList.Add(ObjSubjectPapers);
                }
                return PaperList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
    }
}
