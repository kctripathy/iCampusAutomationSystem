using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;
using System.Data;
using Micro.Commons;

namespace Micro.IntegrationLayer.CustomerRelation
{
    public partial class DUMMYIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation
        public static DUMMY DataRowToObject(DataRow dr)
        {
            DUMMY Thedummy = new DUMMY();
            {
                Thedummy.STUDID = int.Parse(dr["@STUDID"].ToString());
                Thedummy.NAME = dr["@NAME"].ToString();
                Thedummy.DOB = DateTime.Parse(dr["@DOB"].ToString()).ToString(MicroConstants.DateFormat);
                Thedummy.GENDER = dr["@GENDER"].ToString();
                Thedummy.DOJ = DateTime.Parse(dr["@Doj"].ToString()).ToString(MicroConstants.DateFormat);
                Thedummy.DOL = DateTime.Parse(dr["@DOL"].ToString()).ToString(MicroConstants.DateFormat);
 
            }
            return Thedummy;

        }
        #endregion


        public static DUMMY getstudentbyId(int studID)
        {
            DataRow ThestudentRow = DUMMYDataAccess.GetInstance.getstudentbyId(studID);
         

            DUMMY Thestudent = DataRowToObject(ThestudentRow);

            return Thestudent;
        }
    
    
    }
    
}
