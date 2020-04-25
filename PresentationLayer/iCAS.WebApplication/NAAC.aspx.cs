using Micro.BusinessLayer.ICAS.ESTBLMT;
using Micro.Objects.ICAS.ESTBLMT;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LTPL.ICAS.WebApplication
{
    public partial class NAAC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lit_Content.Text = BindDownlodables();
            }

        }

        public string BindDownlodables()
        {
            StringBuilder sbContent = new StringBuilder("<div class='row m-0 p-0'>");


            
            //sbContent.AppendLine("<li class='PageSubtitle'>Downloables</li>");
            List<Establishment> theList4Notice = EstablishmentManagement.GetInstance.GetEstablishmentListByTypeCodes("Z");
            foreach (Establishment estb in theList4Notice)
            {
                
                string theLine = string.Format(
												@"
                                                <div class='col-lg-6 col-sm-12' style='margin: 4px 0px'>
                                                    <a href='Documents/{1}' title='{0} style='border: none;' target='_blank'>
                                                        <img alt='{1}' src='./images/pdf.gif' style='border: none;' class='RowImageClass' />
														&nbsp;
														<span class='titleText'>{0}</span>                                                        
                                                    </a>
                                                </div>
                                                ", estb.EstbTitle
                                                 , estb.FileNameWithPath
                                                , ConfigurationManager.AppSettings["WebServerIP"].ToString()
                                                , estb.EstbTypeCodeDesc
                                                );
                sbContent.AppendLine(theLine);
            }
            sbContent.AppendLine("</div>");
            return sbContent.ToString();
        }
    }
}