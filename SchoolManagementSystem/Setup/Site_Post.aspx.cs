using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace SchoolManagementSystem.Setup
{
    public partial class Site_Post : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonDAL.Fillddl(ddlCategory, "SELECT CategoryId, Category FROM Site_Category ORDER BY Category", "Category", "CategoryId");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = "SELECT SubCategoryId, SubCategory FROM dbo.Site_SubCategory WHERE (CategoryId = " + ddlCategory.SelectedValue + ")";
            CommonDAL.Fillddl(ddlSubCategory, str, "SubCategory", "SubCategoryId");
        }
    }
}