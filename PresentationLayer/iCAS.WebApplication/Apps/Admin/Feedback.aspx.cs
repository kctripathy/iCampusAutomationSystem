using Micro.Objects.ICAS.ADMIN;
using Micro.BusinessLayer.ICAS.ADMIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TCon.iCAS.WebApplication.Apps.Admin
{
    public partial class Feedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridview(0);
                BindDropdown();
            }
        }

        private void BindGridview(int id)
        {
            List<UserFeedbackViewModel> theList;
            if (id==0)
                theList = UserManagement.GetInstance.SelectUserFeedback().OrderByDescending((rec)=>rec.id).ToList();
            else
                theList = UserManagement.GetInstance.SelectUserFeedback().Where((record)=>record.id == id).OrderByDescending((rec) => rec.id).ToList();

            gview_Feedbacks.DataSource = theList;
            gview_Feedbacks.DataBind();
        }

        private void BindDropdown()
        {
            List<UserFeedbackCategory> list = UserManagement.GetInstance.SelectUserFeedbackCategory();
            ddl_Category.DataSource = list;
            ddl_Category.DataValueField = "id";
            ddl_Category.DataTextField = "name";
            ddl_Category.DataBind();

            ddl_Category.Items.Insert(0,new ListItem("-- SELECT ALL--","0"));
        }

        protected void ddl_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridview(int.Parse(ddl_Category.SelectedValue.ToString()));
        }
    }
}