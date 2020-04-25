using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.ESTBLMT;
using Micro.IntegrationLayer.ICAS.ESTBLMT;
using System.Web;

namespace Micro.BusinessLayer.ICAS.ESTBLMT
{
    public partial class EstablishmentManagement
    {
        #region code to Make this as Singleton class


        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static EstablishmentManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static EstablishmentManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new EstablishmentManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region Declaration
        #endregion


        #region Methods & Implementation


        public List<Establishment> GetEstablishmentList()
        {
            return EstablishmentIntegration.GetEstablishmentList();
            //string UniqueKey = "GetEstablishmentList";
            //if (HttpRuntime.Cache[UniqueKey] == null)
            //{
            //    List<Establishment> EstablishmentList = EstablishmentIntegration.GetEstablishmentList();
            //    HttpRuntime.Cache[UniqueKey] = EstablishmentList;
            //}
            //return (List<Establishment>)(HttpRuntime.Cache[UniqueKey]);

        }

        public List<Establishment> GetEstablishmentListFreshRecords()
        {
            return EstablishmentIntegration.GetEstablishmentList();
            //string UniqueKey = "GetEstablishmentList";
            //if (HttpRuntime.Cache[UniqueKey] == null)
            //{
            //    List<Establishment> EstablishmentList = EstablishmentIntegration.GetEstablishmentList();
            //    HttpRuntime.Cache[UniqueKey] = EstablishmentList;
            //}
            //return (List<Establishment>)(HttpRuntime.Cache[UniqueKey]);

        }
        public List<Establishment> GetEstablishment_Publications(string typeCode="P")
        {
            return EstablishmentIntegration.GetEstablishmentListByTypeCode(typeCode);
        }
        public List<Establishment> GetEstablishment_MinutesOfMeetings(string typeCode = "M")
        {
            return EstablishmentIntegration.GetEstablishmentListByTypeCode(typeCode);
        }
        public List<Establishment> GetEstablishmentListByTypeCodes(string typeCodes)
        {
            return EstablishmentIntegration.GetEstablishmentListByTypeCodes(typeCodes);
			//string UniqueKey = string.Format("GetEstablishmentListByTypeCodes___{0}", typeCodes.Replace(",", "_").ToString());
			//if (HttpRuntime.Cache[UniqueKey] == null)
			//{
			//	List<Establishment> EstablishmentList = EstablishmentIntegration.GetEstablishmentListByTypeCodes(typeCodes);
			//	HttpRuntime.Cache[UniqueKey] = EstablishmentList;

			//}
			//return (List<Establishment>)(HttpRuntime.Cache[UniqueKey]);
        }
        public List<Establishment> GetEstablishmentListByTypeCode(string typeCode)
        {
            return EstablishmentIntegration.GetEstablishmentListByTypeCode(typeCode);
            //string UniqueKey = string.Format("GetEstablishmentListByTypeCode_{0}",typeCode);
            //if (HttpRuntime.Cache[UniqueKey] == null)
            //{
            //    List<Establishment> EstablishmentList = EstablishmentIntegration.GetEstablishmentListByTypeCode(typeCode);
            //    HttpRuntime.Cache[UniqueKey] = EstablishmentList;
               
            //}
            //return (List<Establishment>)(HttpRuntime.Cache[UniqueKey]);
        }

        public List<Establishment> GetEstablishmentPhotoGallery()
        {
            return EstablishmentIntegration.GetEstablishmentListByTypeCode("Y");
            //string UniqueKey = string.Format("GetEstablishmentListByTypeCode_{0}", typeCode);
            //if (HttpRuntime.Cache[UniqueKey] == null)
            //{
            //    List<Establishment> EstablishmentList = EstablishmentIntegration.GetEstablishmentListByTypeCode(typeCode);
            //    HttpRuntime.Cache[UniqueKey] = EstablishmentList;

            //}
            //return (List<Establishment>)(HttpRuntime.Cache[UniqueKey]);
        }
        public int InsertEstablishment(Establishment theestablishment)
        {
            return EstablishmentIntegration.InsertEstablishment(theestablishment);
        }


        public int UpdateEstablishment(Establishment theestablishment)
        {
            return EstablishmentIntegration.UpdateEstablishment(theestablishment);
        }

        public int DeleteEstablishment(Establishment theestablishment)
        {
            return EstablishmentIntegration.DeleteEstablishment(theestablishment);
        }

        public int ApprovalEstablishment(string EstbIDS,string status)
        {
            return EstablishmentIntegration.ApproveEstablishment(EstbIDS,status);
          //  return EstablishmentIntegration.ApproveEstablishment(EstbIDS,status);
        }
        public int UpdateEstablishmentStatus(int estbId, string estbStatus)
        {
            return EstablishmentIntegration.UpdateEstablishmentStatus(estbId, estbStatus);
        }
        //public int RejectEstablishment(string EstbIDS)
        //{
        //    return EstablishmentIntegration.RejectEstablishment(EstbIDS);
        //}
        #endregion
    }
}
