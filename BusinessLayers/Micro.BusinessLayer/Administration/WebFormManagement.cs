using System;
using System.Collections.Generic;
using Micro.Objects.Administration;
using Micro.IntegrationLayer.Administration;
using System.Reflection;

namespace Micro.BusinessLayer.Administration
{
public partial	class WebFormManagement
	{
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>

    private static WebFormManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
    public static WebFormManagement GetInstance
    {
        get 
        {
            if (_Instance == null)
            {
                _Instance = new WebFormManagement();
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

    public List<WebForm> GetWebFormsAll()
    {
        try
        {
            return WebFormIntegration.GetWebFormsAll();
        }
        catch (Exception ex)
        {
            throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        }
    }
    } 

}
