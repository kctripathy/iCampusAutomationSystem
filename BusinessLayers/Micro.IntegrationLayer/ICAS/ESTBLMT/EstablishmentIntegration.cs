using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.ESTBLMT;
using System.Data;
using Micro.DataAccessLayer.ICAS.ESTBLMT;
using System.Data.SqlClient;
using Micro.Commons;
 


namespace Micro.IntegrationLayer.ICAS.ESTBLMT
{
    public partial class EstablishmentIntegration
    {
        #region Declaration 
        #endregion

        #region Methods & Implementation

        public static Establishment DataRowToObject(DataRow dr)
        {

            Establishment theestablishment = new Establishment();

                theestablishment.EstbID = int.Parse(dr["EstbID"].ToString());
                theestablishment.EstbCode = dr["EstbCode"].ToString();
                theestablishment.EstbTypeCode = dr["EstbTypeCode"].ToString();
                theestablishment.EstbTitle = dr["EstbTitle"].ToString();
                theestablishment.EstbDescription = dr["EstbDescription"].ToString();
                theestablishment.EstbMessage = dr["EstbMessage"].ToString();
                if (dr["EstbDate"] != null)
                {
                    theestablishment.EstbDate = DateTime.Parse(DateTime.Parse(dr["EstbDate"].ToString()).ToString(MicroConstants.DateFormat));
                }
				//if (dr["EstbUploadFile"] != null)
				//{
				//    theestablishment.EstbUploadFile = ((byte[])(dr["EstbUploadFile"])); // dr["EstbUploadFile"].ToString();
				//}

                theestablishment.EstbViewStartDate = DateTime.Parse(dr["EstbViewStartDate"].ToString()); //.ToString(MicroConstants.DateFormat);
                theestablishment.EstbViewEndDate = DateTime.Parse(dr["EstbViewEndDate"].ToString()); //.ToString(MicroConstants.DateFormat);
                theestablishment.EstbStatusFlag = dr["ESTBSTATUSFLAG"].ToString();
                theestablishment.IsActive = bool.Parse(dr["IsActive"].ToString());
                theestablishment.IsDeleted = bool.Parse(dr["IsDeleted"].ToString());
                theestablishment.AddedBy = int.Parse(dr["AddedBy"].ToString());
                theestablishment.ModifiedBy =int.Parse(MicroGlobals.ReturnZeroIfNull(dr["ModifiedBy"].ToString()));
                //theestablishment. = DateTime.Parse(dr["DateAdded"].ToString()).ToString(MicroConstants.DateFormat);
                if (theestablishment.DateAdded != null)
                {
                    theestablishment.DateAdded = DateTime.Parse(dr["DateAdded"].ToString()).ToString(MicroConstants.DateFormat);
                }
                if (theestablishment.DateModified != null)
                {
                    theestablishment.DateModified = DateTime.Parse(dr["DateModified"].ToString()).ToString(MicroConstants.DateFormat);
                }
                theestablishment.OfficeID =int.Parse( dr["OfficeID"].ToString());
                theestablishment.CompanyID =int.Parse(dr["CompanyID"].ToString());
                theestablishment.FileNameWithPath = dr["VC_FIELD2"].ToString();
                theestablishment.AuthorOrContributorName = dr["EmployeeName"].ToString();
          return theestablishment;
        
        }
      
        public static List<Establishment> GetEstablishmentList()
        {
            List<Establishment> EstablishmentList = new List<Establishment>();
            DataTable EstablishmentTable = EstablishmentDataAccess.GetInstance.GetEstablishmentList();
            foreach (DataRow dr in EstablishmentTable.Rows)
            {
                Establishment theestablishment = DataRowToObject(dr);
                EstablishmentList.Add(theestablishment);
                
            
            }
            return EstablishmentList;
            
        }
        public static List<Establishment> GetEstablishmentListByTypeCodes(string typeCodes)
        {
            List<Establishment> EstablishmentList = new List<Establishment>();
            DataTable EstablishmentTable = EstablishmentDataAccess.GetInstance.GetEstablishmentListByTypeCodes(typeCodes);
            foreach (DataRow dr in EstablishmentTable.Rows)
            {
                Establishment theestablishment = DataRowToObject(dr);
                EstablishmentList.Add(theestablishment);


            }
            return EstablishmentList;

        }
        public static List<Establishment> GetEstablishmentListByTypeCode(string typeCode)
        {
            List<Establishment> EstablishmentList = new List<Establishment>();
            DataTable EstablishmentTable = EstablishmentDataAccess.GetInstance.GetEstablishmentListByTypeCode(typeCode);
            foreach (DataRow dr in EstablishmentTable.Rows)
            {
                Establishment theestablishment = DataRowToObject(dr);
                EstablishmentList.Add(theestablishment);


            }
            return EstablishmentList;

        }
        public static int InsertEstablishment(Establishment theestablishment)
        {
            return EstablishmentDataAccess.GetInstance.InsertEstablishment(theestablishment);
        }

        public static int UpdateEstablishment(Establishment theestablishment)
        {
            return EstablishmentDataAccess.GetInstance.UpdateEstablishment(theestablishment);
        
        }


        public static int DeleteEstablishment(Establishment theestablishment)
        {
            return EstablishmentDataAccess.GetInstance.DeleteEstablishment(theestablishment);
        
        }

        

        public static int ApproveEstablishment(string EstbIDS,string status)
        {
            return EstablishmentDataAccess.GetInstance.ApproveEstablishment(EstbIDS,status);
        }

        public static int UpdateEstablishmentStatus(int estbId, string estbStatus)
        {
            return EstablishmentDataAccess.GetInstance.UpdateEstablishmentStatus(estbId, estbStatus);
        }
        //public static int RejectEstablishment(string EstbIDS)
        //{
        //    return EstablishmentDataAccess.GetInstance.ApproveEstablishment(EstbIDS);
        
        //}
        #endregion




        //public static int InsertEstablishment(Establishment theestablishment)
        //{
        //    throw new NotImplementedException();
        //}



        //public static List<Establishment> GetEstablishmentList()
        //{
        //    throw new NotImplementedException();
        //}

 
    }
}
