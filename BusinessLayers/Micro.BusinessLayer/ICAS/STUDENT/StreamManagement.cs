using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.STUDENT;
using Micro.IntegrationLayer.ICAS.STUDENT;
using System.Web;

namespace Micro.BusinessLayer.ICAS.STUDENT
{
    public class StreamManagement
    {
         #region code to Make this as Singleton class


        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static StreamManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static StreamManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new StreamManagement();
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
        public string DisplayMember = "StreamName";
        public string ValueMember = "StreamID";
        #region Methods & Implementation
        #endregion
        //public List<Streams> GetStreamList()
        //{
        //    return StreamIntegration.GetStreamList();
        //}

        public List<Streams> GetStreamList()
        {
            string Context = this.GetType().FullName.ToString();
            try
            {
                //return StreamIntegration.GetStreamList();
                string UniqueKey = "GetStreamList";
                if (HttpRuntime.Cache[UniqueKey] == null)
                {
                    List<Streams> StreamsList = StreamIntegration.GetStreamList();
                    HttpRuntime.Cache[UniqueKey] = StreamsList;
                }
                return (List<Streams>)(HttpRuntime.Cache[UniqueKey]);
            }
            catch (Exception ex)
            {
                throw (new Exception(Context, ex));
            }
        }


        public string GetStreamNameById(int id)
        {
            string theStreamName = string.Empty;
            List<Streams> StreamsList = StreamIntegration.GetStreamList();

            List<Streams> strm = (from m in StreamsList
                       where m.StreamID == id
                       select m).ToList();
            foreach(Streams s in strm)
            {
                theStreamName = s.StreamName;
            }             
            return theStreamName;
        }

    }  
}
