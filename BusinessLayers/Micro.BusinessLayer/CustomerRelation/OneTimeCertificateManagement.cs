using System.Collections.Generic;
using Micro.Objects.CustomerRelation;
using Micro.IntegrationLayer.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
   public partial  class OneTimeCertificateManagement
   {
       #region Declaration
       public string DefaultColumns = "OneTimeCertificateCode,CustomerAccountCode,OfficeName,ReceivedOnDate";
       public string DisplayMember = "OneTimeCertificateCode";
       public string ValueMember = "OneTimeCertificateID";
       #endregion

       #region Code to make this as Singleton Class
       /// <summary>
        /// Declare a private static variable
        /// </summary>
       private static OneTimeCertificateManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
       public static OneTimeCertificateManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new OneTimeCertificateManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

       #region Methods & Implementation

       public  List<OneTimeCertificate> GetOneTimeCertificateList(bool allOffices = false, bool showDeleted = false)
       {
           return OneTimeCertificateIntegration.GetOneTimeCertificateList(allOffices,showDeleted);
       }

       public  List<OneTimeCertificate> GetOneTimeCertificatesByDate(string FromDate, string ToDate)
       {
           return OneTimeCertificateIntegration.GetOneTimeCertificatesByDate(FromDate, ToDate);
       }
	   public OneTimeCertificate GetOneTimeCertificatesByOneTimeCertificateID(int OneTimeCertificateID)
	   {
		   return OneTimeCertificateIntegration.GetOneTimeCertificatesByOneTimeCertificateID(OneTimeCertificateID);
	   }
       public  List<OneTimeCertificate> GetOneTimeCertificatesByFieldForceID(int FieldForceID)
       {
           return OneTimeCertificateIntegration.GetOneTimeCertificatesByFieldForceID(FieldForceID);
       }

       public int InsertOneTimeCertificate(OneTimeCertificate theCertificate)
       {
           return OneTimeCertificateIntegration.InsertOneTimeCertificate(theCertificate);
       }

       public int IssueOneTimeCertificate(OneTimeCertificate theCertificate, string OneTimeCertificateIDs)
       {
           return OneTimeCertificateIntegration.IssueOneTimeCertificate(theCertificate, OneTimeCertificateIDs);
       }

       public int PrintDuplicateOneTimeCertificate(OneTimeCertificate theCertificate)
       {
           return OneTimeCertificateIntegration.PrintDuplicateOneTimeCertificate(theCertificate);
       }
       #endregion
   }
}
