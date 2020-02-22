using System;
using System.Collections.Generic;
using Micro.Objects.Administration;
using System.Data;
using Micro.DataAccessLayer.Administration;

namespace Micro.IntegrationLayer.Administration
{
    public class StateIntegration
    {
        public static int InsertState(State theState)
        {
            string Context = "Micro.IntegrationLayer.Administration.StateIntegration.InsertState";
            try
            {
                return StateDataAccess.GetInstance.InsertState(theState);
            }
            catch (Exception ex)
            {
                throw (new Exception(Context, ex));
            }
        }

        public static List<State> GetAllStatesByCountryId(int countryId)
        {
            string Context = "Micro.IntegrationLayer.Administration.StateIntegration.GetAllStatesByCountryId";
            try
            {
                List<State> StateList = new List<State>();
                DataTable StateDataTable = StateDataAccess.GetInstance.GetAllStatesByCountryId(countryId);
                foreach(DataRow dRow in StateDataTable.Rows)
                {
                    State s = new State();
                    s.CountryId = int.Parse(dRow["CountryId"].ToString());
					s.StateID = int.Parse(dRow["StateId"].ToString());
                    s.StateName = dRow["StateName"].ToString();
                    StateList.Add(s);
                }
                return StateList;
            }
            catch (Exception ex)
            {
                throw (new Exception(Context, ex));
            }
        }
    }
}
