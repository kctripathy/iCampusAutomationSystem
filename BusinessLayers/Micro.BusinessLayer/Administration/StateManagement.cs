using System;
using System.Collections.Generic;
using Micro.Objects.Administration;
using Micro.IntegrationLayer.Administration;

namespace Micro.BusinessLayer.Administration
{
    public class StateManagement
    {

        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static StateManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static StateManagement GetInstance
        {
            get
            {
                if(_Instance == null)
                {
                    _Instance = new StateManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion


        #region Methods & Implementations

        public int InsertState(State theState)
        {
            string Context = this.GetType().FullName.ToString();
            try
            {
                return StateIntegration.InsertState(theState);
            }
            catch (Exception ex)
            {
                throw (new Exception(Context, ex));
            }          
        }

        public List<State> GetAllStatesByCountryId(int countryId)
        {
            //The below piece of code is working fine and should be un commented before after adding the states to the table
            //string UniqueKey = "GetAllStatesByCountryId_" + countryId.ToString();
            //if(HttpRuntime.Cache[UniqueKey] == null)
            //{
            //   List<State> StateList = StateIntegration.GetAllStatesByCountryId(countryId);
            //    HttpRuntime.Cache[UniqueKey] = StateList;
            //}
            //return (List<State>)(HttpRuntime.Cache[UniqueKey]);

            string Context = this.GetType().FullName.ToString();
            try
            {
                return StateIntegration.GetAllStatesByCountryId(countryId);
            }
            catch (Exception ex)
            {
                throw (new Exception(Context, ex));
            }
            
        }
        #endregion
    }
}
