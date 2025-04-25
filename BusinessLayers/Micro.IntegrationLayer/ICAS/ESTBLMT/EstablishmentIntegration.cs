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

            Establishment estb = new Establishment();

                estb.EstbID = int.Parse(dr["EstbID"].ToString());
                estb.EstbCode = dr["EstbCode"].ToString();
                estb.EstbTypeCode = dr["EstbTypeCode"].ToString();
                estb.EstbTitle = dr["EstbTitle"].ToString();
                estb.EstbDescription = dr["EstbDescription"].ToString();
                estb.EstbDescription1 = dr["EstbDescription1"].ToString();
                estb.EstbDescription2 = dr["EstbDescription2"].ToString();
                estb.EstbMessage = dr["EstbMessage"].ToString();
                if (dr["EstbDate"] != null)
                {
                    estb.EstbDate = DateTime.Parse(DateTime.Parse(dr["EstbDate"].ToString()).ToString(MicroConstants.DateFormat));
                }
                estb.EstbViewStartDate = DateTime.Parse(dr["EstbViewStartDate"].ToString()); //.ToString(MicroConstants.DateFormat);
                estb.EstbViewEndDate = DateTime.Parse(dr["EstbViewEndDate"].ToString()); //.ToString(MicroConstants.DateFormat);
                estb.EstbStatusFlag = dr["ESTBSTATUSFLAG"].ToString();
                estb.IsActive = bool.Parse(dr["IsActive"].ToString());
                estb.IsDeleted = bool.Parse(dr["IsDeleted"].ToString());
                estb.AddedBy = int.Parse(dr["AddedBy"].ToString());
                estb.AddedByEmployeeID = int.Parse(dr["AddedBy"].ToString());
            
                estb.ModifiedBy =int.Parse(MicroGlobals.ReturnZeroIfNull(dr["ModifiedBy"].ToString()));
                if (estb.DateAdded != null)
                {
                    estb.DateAdded = DateTime.Parse(dr["DateAdded"].ToString()).ToString(MicroConstants.DateFormat);
                }
                if (estb.DateModified != null)
                {
                    estb.DateModified = DateTime.Parse(dr["DateModified"].ToString()).ToString(MicroConstants.DateFormat);
                }
                estb.OfficeID =int.Parse( dr["OfficeID"].ToString());
                estb.CompanyID =int.Parse(dr["CompanyID"].ToString());
                estb.FileNameWithPath = dr["VC_FIELD2"].ToString();
                estb.AuthorOrContributorName = dr["EmployeeName"].ToString();

          return estb;
        
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

        #region API 
        public static long UpdateFileName(long id, string fileName)
        {
            return EstablishmentDataAccess.GetInstance.UpdateFileName(id, fileName);
        }

        public static int InsertEmailSentLog(EmailRequest email, int loggedOnUserId)
        {
            return EstablishmentDataAccess.GetInstance.InsertEmailSentLog(email, loggedOnUserId);
        }

        public static dynamic GetEmailSentLog(EmailGet email)
        {
            return EstablishmentDataAccess.GetInstance.GetEmailSentLog(email);
        }

        public static long UpdateStatusFlag(long id, string status)
        {
            return EstablishmentDataAccess.GetInstance.UpdateStatusFlag(id, status);
        }
        #endregion


    }
}
