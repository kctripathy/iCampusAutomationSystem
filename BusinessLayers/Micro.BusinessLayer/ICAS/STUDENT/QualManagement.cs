using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.STUDENT;
using Micro.IntegrationLayer.ICAS.STUDENT;
using System.Web;

namespace Micro.BusinessLayer.ICAS.STUDENT
{
    public class QualManagement
    {
         #region code to Make this as Singleton class


        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static QualManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static QualManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new QualManagement();
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
        public string DisplayMember = "QualCode";
        public string ValueMember = "QualID";
        #region Methods & Implementation
        #endregion
        //public List<Streams> GetStreamList()
        //{
        //    return StreamIntegration.GetStreamList();
        //}

        public List<Qualification> GetQualsList()
        {
            string Context = this.GetType().FullName.ToString();
            try
            {

                string UniqueKey = "GetQualsList";
                if (HttpRuntime.Cache[UniqueKey] == null)
                {
                    List<Qualification> QualificationList = QualiIntegration.GetQualList();
                    HttpRuntime.Cache[UniqueKey] = QualificationList;
                }
                return (List<Qualification>)(HttpRuntime.Cache[UniqueKey]);



                //return QualiIntegration.GetQualList();
            }
            catch (Exception ex)
            {
                throw (new Exception(Context, ex));
            }
        }
        public int InsertQuals(Qualification theQualification)
        {
            return QualiIntegration.InsertQuals(theQualification);
        }

    }  
}
