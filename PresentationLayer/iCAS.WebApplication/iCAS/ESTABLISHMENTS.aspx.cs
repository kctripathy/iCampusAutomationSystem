using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Commons;
using Micro.Objects.Administration;
using Micro.Objects.ICAS.ESTBLMT;
using Micro.BusinessLayer.ICAS.ESTBLMT;

namespace LTPL.ICAS.WebApplication.iCAS
{
    public partial class ESTABLISHMENTS : BasePage
    {
        #region Declaration

        protected static class PageVariables
        {
            public static string TheOfficeId
            {
                get
                {
                    string ThisOfficeID = HttpContext.Current.Session["TheOfficeId"].ToString();
                    return ThisOfficeID;
                }
                set
                {
                    HttpContext.Current.Session.Add("TheOfficeId", value);
                }
            }
            
            public static List<Office> TheOfficeList
            {
                get
                {
                    List<Office> TheOffice = HttpContext.Current.Session["TheOfficeList"] as List<Office>;
                    return TheOffice;
                }
                set
                {
                    HttpContext.Current.Session.Add("TheOfficeList", value);
                }
            }

            public static List<Establishment> TheEstbList
            {
                get
                {
                    List<Establishment> TheEstablishment = HttpContext.Current.Session["TheEstablishmentList"] as List<Establishment>;
                    return TheEstablishment;
                }
                set
                {
                    HttpContext.Current.Session.Add("TheEstablishmentList", value);
                }
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //
                gview_Estb.DataSource = EstablishmentManagement.GetInstance.GetEstablishmentList();
                gview_Estb.DataBind();

            }
        }


    }
}