using System;
using System.Collections.Generic;
using Micro.Objects.CustomerRelation;
using Micro.DataAccessLayer.CustomerRelation;
using System.Data;
using Micro.Commons;

namespace Micro.IntegrationLayer.CustomerRelation
{
   public partial  class OneTimeCertificateIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation

       public static OneTimeCertificate DataRowToObject(DataRow dr)
       {
           OneTimeCertificate TheOneTimeCertificate = new OneTimeCertificate();

           TheOneTimeCertificate.OneTimeCertificateID = int.Parse(dr["OneTimeCertificateID"].ToString());
           TheOneTimeCertificate.OneTimeCertificateCode = dr["OneTimeCertificateCode"].ToString();
           TheOneTimeCertificate.CustomerAccountID = int.Parse(dr["CustomerAccountID"].ToString());
           if (!string.IsNullOrEmpty(dr["DatePrinted"].ToString()))
           {
               TheOneTimeCertificate.DatePrinted = DateTime.Parse(dr["DatePrinted"].ToString()).ToString(MicroConstants.DateFormat);
           }
           TheOneTimeCertificate.ReceivedBy = dr["ReceivedBy"].ToString();
           if (!string.IsNullOrEmpty(dr["ReceivedOnDate"].ToString()))
           {
               TheOneTimeCertificate.ReceivedOnDate = DateTime.Parse(dr["ReceivedOnDate"].ToString()).ToString(MicroConstants.DateFormat);
           }

           //TheOneTimeCertificate.Remarks = dr["Remarks"].ToString();
           TheOneTimeCertificate.OfficeID = int.Parse(dr["OfficeID"].ToString());
           TheOneTimeCertificate.OfficeName = dr["OfficeName"].ToString();
           TheOneTimeCertificate.OfficeCode = dr["OfficeCode"].ToString();
           TheOneTimeCertificate.CustomerAccountCode = dr["CustomerAccountCode"].ToString();

           return TheOneTimeCertificate;
       }

       public static List<OneTimeCertificate> GetOneTimeCertificateList(bool allOffices = false, bool showDeleted = false)
       {
           List<OneTimeCertificate> OneTimeCertificateList = new List<OneTimeCertificate>();
           DataTable OneTimeCertificateTable = OneTimeCertificateDataAccess.GetInstance.GetOneTimeCertificateList(allOffices, showDeleted);

           foreach (DataRow dr in OneTimeCertificateTable.Rows)
           {
               OneTimeCertificate TheOneTimeCertificate = DataRowToObject(dr);

               OneTimeCertificateList.Add(TheOneTimeCertificate);
           }

           return OneTimeCertificateList;
       }

       public static List<OneTimeCertificate> GetOneTimeCertificatesByDate(string FromDate, string ToDate)
       {
           List<OneTimeCertificate> OneTimeCertificateList = new List<OneTimeCertificate>();

           DataTable OneTimeCertificateTableType = OneTimeCertificateDataAccess.GetInstance.GetOneTimeCertificatesByDate(FromDate, ToDate);

           foreach (DataRow dr in OneTimeCertificateTableType.Rows)
           {
               OneTimeCertificate TheOneTimeCertificate = DataRowToObject(dr);

               OneTimeCertificateList.Add(TheOneTimeCertificate);
           }

           return OneTimeCertificateList;
       }
	   public static OneTimeCertificate GetOneTimeCertificatesByOneTimeCertificateID(int OneTimeCertificateID)
	   {
		   OneTimeCertificate OneTimeCertificateList = new OneTimeCertificate();

		   DataRow OneTimeCertificateTableType = OneTimeCertificateDataAccess.GetInstance.GetOneTimeCertificatesByOneTimeCertificateID(OneTimeCertificateID);

		   OneTimeCertificate TheOneTimeCertificate = DataRowToObject(OneTimeCertificateTableType);

		   return TheOneTimeCertificate;
	   }
       public static List<OneTimeCertificate> GetOneTimeCertificatesByFieldForceID(int FieldForceID)
       {
           List<OneTimeCertificate> OneTimeCertificateList = new List<OneTimeCertificate>();

           DataTable OneTimeCertificateTableType = OneTimeCertificateDataAccess.GetInstance.GetOneTimeCertificatesByFieldForceID(FieldForceID);

           foreach (DataRow dr in OneTimeCertificateTableType.Rows)
           {
               OneTimeCertificate TheOneTimeCertificate = DataRowToObject(dr);

               OneTimeCertificateList.Add(TheOneTimeCertificate);
           }

           return OneTimeCertificateList;
       }

       public static int InsertOneTimeCertificate(OneTimeCertificate theCertificate)
       {
           return OneTimeCertificateDataAccess.GetInstance.InsertOneTimeCertificate(theCertificate);
       }

       public static int IssueOneTimeCertificate(OneTimeCertificate theCertificate, string OneTimeCertificateIDs)
       {
           return OneTimeCertificateDataAccess.GetInstance.IssueOneTimeCertificate(theCertificate,OneTimeCertificateIDs);
       }

       public static int PrintDuplicateOneTimeCertificate(OneTimeCertificate theCertificate)
       {
           return OneTimeCertificateDataAccess.GetInstance.PrintDuplicateOneTimeCertificate(theCertificate);
       }
        #endregion
    }
}
