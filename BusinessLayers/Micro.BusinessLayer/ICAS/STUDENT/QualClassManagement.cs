using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.STUDENT;
using Micro.IntegrationLayer.ICAS.STUDENT;

namespace Micro.BusinessLayer.ICAS.STUDENT
{
    public class QualClassManagement
    {
         #region code to Make this as Singleton class


        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static QualClassManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static QualClassManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new QualClassManagement();
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
        public string DisplayMember = "ClassName";
        public string ValueMember = "ClassID";
        #region Methods & Implementation
        #endregion
        //public List<Streams> GetStreamList()
        //{
        //    return StreamIntegration.GetStreamList();
        //}

        public List<QualClass> GetClassListByQualID(int QualID)
        {
            string Context = this.GetType().FullName.ToString();
            try
            {
                return QualClassiIntegration.GetClassListByQualID(QualID);
            }
            catch (Exception ex)
            {
                throw (new Exception(Context, ex));
            }
        }
        public List<QualClass> GetClassListByStreamAndQual(int QualID,int StreamID)
        {
            string Context = this.GetType().FullName.ToString();
            try
            {
                return QualClassiIntegration.GetClassListByStreamAndQual(QualID,StreamID);
            }
            catch (Exception ex)
            {
                throw (new Exception(Context, ex));
            }
        }
        //public int InsertQuals(Qualification theQualification)
        //{
        //    return QualiIntegration.InsertQuals(theQualification);
        //}

    }  
}
