using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.MasterPages
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null && Session["UserId"] != null)
            {
                lblUserName.Text = Session["UserName"].ToString();
                string userid = Session["UserId"].ToString();
                string userimage = Session["UserImage"].ToString();
                imgUser.ImageUrl = "~/assets/img/Users/" + userimage;

            }
            else
            {
                Response.Redirect("~/login.aspx");
            }

        }
    }
}