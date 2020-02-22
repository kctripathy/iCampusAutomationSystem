using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.STUDENT;
using Micro.DataAccessLayer.ICAS.STUDENT;
using System.Data;
using Micro.DataAccessLayer.ICAS.EXAM;

namespace Micro.IntegrationLayer.ICAS.STUDENT
{
  public partial  class StudentClassIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation

        //public static Classes DataRowToObject(DataRow dr)
        //{
        //    Classes TheClasses = new Classes();
        //    TheClasses.ClassID = int.Parse(dr["ClassID"].ToString());
        //    TheClasses.ClassName = dr["ClassName"].ToString();


        //    return TheClasses;
        //}

        //public static List<StudentClass> GetClassListByOfficeID(int officeID)
        //{
        //    List<StudentClass> ClassesList = new List<StudentClass>();
        //    DataTable ClassTable = ClassDataAccess.GetInstance.GetClassListByOfficeID(officeID);

        //    foreach (DataRow dr in ClassTable.Rows)
        //    {
        //        Classes TheClasses = DataRowToObject(dr);

        //        ClassesList.Add(TheClasses);
        //    }

        //    return ClassesList;
        //}
        
        #endregion
    }
}
