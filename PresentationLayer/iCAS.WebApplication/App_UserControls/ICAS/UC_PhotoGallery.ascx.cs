using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.BusinessLayer.ICAS.ESTBLMT;
using Micro.Objects.ICAS.ESTBLMT;
using Micro.Commons;
using System.Text;
using System.Configuration;

namespace LTPL.ICAS.WebApplication.App_UserControls.ICAS
{
    public partial class UC_PhotoGallery : System.Web.UI.UserControl
    {

        #region Declaration
        public static class PageVariables
        {

            public static Establishment TheEstablishment
            {
                get
                {
                    Establishment TheEstablishment = HttpContext.Current.Session["theestablishment"] as Establishment;
                    return TheEstablishment;
                }
                set
                {
                    HttpContext.Current.Session.Add("TheEstablishment", value);
                }
            }

            public static List<Establishment> TheEstablishmentList
            {
                get
                {
                    List<Establishment> TheEstablishmentList = HttpContext.Current.Session["TheEstablishmentList"] as List<Establishment>;
                    return TheEstablishmentList;
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
                BindPhotoGalleryDiv("Y");
            }
        }
        public void BindPhotoGalleryDiv(string estbTypeCode)
        {
            //PageVariables.TheEstablishmentList = EstablishmentManagement.GetInstance.GetEstablishmentListByTypeCode(estbTypeCode); //.Find(a=> a.EstbViewEndDate < DateTime.Today).ToList();
            PageVariables.TheEstablishmentList = EstablishmentManagement.GetInstance.GetEstablishmentPhotoGallery();
            StringBuilder theImageLink = new StringBuilder(); //@"<li><a href='Documents/{0}' title='{1}'><img src='Documents/{0}_thumbnail.jpg' alt='{1}' /></a></li>");


            StringBuilder sbDivContent = new StringBuilder(@"<div id='thumbnails'>
                                                                <ul class='clearfix'>");

            foreach (Establishment estb in PageVariables.TheEstablishmentList)
            {
                string theContentLi = string.Format(@"<li>
                                                        <a href='http://{2}/Documents/{0}' title='{1}' class='photoThumbnailLink' >
                                                            <img src='http://{2}/Documents/{0}' alt='{1}' class='photoThumbnailImg' />
                                                        </a>
                                                     </li>", estb.FileNameWithPath
                                                           , estb.EstbTitle
                                                           , ConfigurationManager.AppSettings["WebServerIP"].ToString());
                theImageLink.AppendLine(theContentLi);
            }

            sbDivContent.AppendLine(theImageLink.ToString());
            sbDivContent.Append(@"                            </ul>
                                                              </div>");

            lit_ThumbnailDivContent.Text = sbDivContent.ToString();
        }



    }
}