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
    public partial class Downloads : System.Web.UI.Page
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
            StringBuilder sbContent = new StringBuilder("<ul class='downloadableUL'>");


            
            //Notice
            sbContent.AppendLine("<li class='PageSubtitle'>Notices:</li>");
            List<Establishment> theList4Notice = EstablishmentManagement.GetInstance.GetEstablishmentListByTypeCodes("N");
            foreach (Establishment estb in theList4Notice)
            {
                
                string theLine = string.Format(
                                                @"
                                                <li><span class='titleText'>{0}</span>
                                                    <a href='Documents/{1}' title='{0} style='border: none;' target='_blank'>
                                                        <img alt='{1}' src='Images/pdf.gif' style='border: none;' class='RowImageClass' />
                                                    </a>
                                                </li>
                                                ", estb.EstbTitle
                                                 , estb.FileNameWithPath
                                                , ConfigurationManager.AppSettings["WebServerIP"].ToString()
                                                , estb.EstbTypeCodeDesc
                                                );
                sbContent.AppendLine(theLine);
            }
            
            //Syllabus
            sbContent.AppendLine("<li class='PageSubtitle'>Syllabus:</li>");
            List<Establishment> theList1 = EstablishmentManagement.GetInstance.GetEstablishmentListByTypeCodes("S");
            foreach (Establishment estb in theList1)
            {
                string theLine = string.Format(
                                                @"
                                                <li><span class='titleText'>{0}</span>
                                                    <a href='Documents/{1}' title='{0} style='border: none;' target='_blank'>
                                                        <img alt='{1}' src='Images/pdf.gif' style='border: none;' class='RowImageClass' />
                                                    </a>
                                                </li>
                                                ", estb.EstbTitle
                                                 , estb.FileNameWithPath
                                                , ConfigurationManager.AppSettings["WebServerIP"].ToString()
                                                );
                sbContent.AppendLine(theLine);
            }

            
            

            //Publications
            sbContent.AppendLine("<li class='PageSubtitle'>Books/Study Materials:</li>");
            List<Establishment> theList3 = EstablishmentManagement.GetInstance.GetEstablishmentListByTypeCodes("1,2,3,4,5,6,7,8,9");
            foreach (Establishment estb in theList3)
            {
                string theLine = string.Format(
                                                @"
                                                <li><span class='titleText'>{0}</span>
                                                    <a href='Documents/{1}' title='{0} style='border: none;' target='_blank'>
                                                        <img alt='{1}' src='Images/pdf.gif' style='border: none;' class='RowImageClass' />
                                                    </a>
                                                </li>
                                                ", estb.EstbTitle
                                                 , estb.FileNameWithPath
                                                , ConfigurationManager.AppSettings["WebServerIP"].ToString()
                                                , estb.EstbTypeCodeDesc
                                                );
                sbContent.AppendLine(theLine);
            }
            
            //Circulars
            sbContent.AppendLine("<li class='PageSubtitle'>Circulars:</li>");
            List<Establishment> theList4Circulars = EstablishmentManagement.GetInstance.GetEstablishmentListByTypeCodes("C");
            foreach (Establishment estb in theList4Circulars)
            {
                string theLine = string.Format(
                                                @"
                                                <li><span class='titleText'>{0}</span>
                                                    <a href='Documents/{1}' title='{0} style='border: none;' target='_blank'>
                                                        <img alt='{1}' src='Images/pdf.gif' style='border: none;' />
                                                    </a>
                                                </li>
                                                ", estb.EstbTitle
                                                 , estb.FileNameWithPath
                                                , ConfigurationManager.AppSettings["WebServerIP"].ToString()
                                                , estb.EstbTypeCodeDesc
                                                );
                sbContent.AppendLine(theLine);
            }
            //Minutes
            sbContent.AppendLine("<li class='PageSubtitle'>Minutes of Meetings:</li>");
            List<Establishment> theList2 = EstablishmentManagement.GetInstance.GetEstablishmentListByTypeCodes("M");
            foreach (Establishment estb in theList2)
            {
                string theLine = string.Format(
                                                @"
                                                <li><span class='titleText'>{0}</span>
                                                    <a href='Documents/{1}' title='{0} style='border: none;' target='_blank'>
                                                        <img alt='{1}' src='Images/pdf.gif' style='border: none;' class='RowImageClass' />
                                                    </a>
                                                </li>
                                                ", estb.EstbTitle
                                                 , estb.FileNameWithPath
                                                , ConfigurationManager.AppSettings["WebServerIP"].ToString()
                                                );
                sbContent.AppendLine(theLine);
            }

            //Tender 
            sbContent.AppendLine("<li class='PageSubtitle'>Tenders:</li>");
            List<Establishment> theList4 = EstablishmentManagement.GetInstance.GetEstablishmentListByTypeCodes("T");
            foreach (Establishment estb in theList4)
            {
                string theLine = string.Format(
                                                @"
                                                <li><span class='titleText'>{0}</span>
                                                    <a href='Documents/{1}' title='{0} style='border: none;' target='_blank'>
                                                        <img alt='{1}' src='Images/pdf.gif' style='border: none;' class='RowImageClass' />
                                                    </a>
                                                </li>
                                                ", estb.EstbTitle
                                                 , estb.FileNameWithPath
                                                , ConfigurationManager.AppSettings["WebServerIP"].ToString()
                                                , estb.EstbTypeCodeDesc
                                                );
                sbContent.AppendLine(theLine);
            }
            sbContent.AppendLine("</ul>");
            return sbContent.ToString();
        }
    }
}