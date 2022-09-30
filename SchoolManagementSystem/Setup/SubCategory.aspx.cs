using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace SchoolManagementSystem.Setup
{
    public partial class SubCategory : System.Web.UI.Page
    {
        SetupBLL objSetup = new SetupBLL();
        CommonDAL objc = new CommonDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
                CommonDAL.Fillddl(ddlCategory, "SELECT CategoryId, Category FROM Site_Category ORDER BY Category", "Category", "CategoryId");
            }
        }
        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = objSetup.LoadSubCategory();
            if (dt.Rows.Count > 0)
            {
                gvCategory.DataSource = dt;
                gvCategory.DataBind();
            }
            else
            {
                gvCategory.DataSource = null;
                gvCategory.DataBind();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int save = 0;
            if (ddlCategory.SelectedValue !="0" && txtSubCategory.Text !="")
            {

                if (btnSave.Text == "Save")
                {
                    save = objSetup.SetupSubcategory_InsertUpdateDelete(1, int.Parse(ddlCategory.SelectedValue), txtSubCategory.Text, int.Parse(Session["UserId"].ToString()), 0);
                    if (save > 0)
                    {
                        rmMsg.SuccessMessage = "Save done";
                        LoadGrid();
                        txtSubCategory.Text = "";
                        ddlCategory.SelectedValue = "0";
                    }
                }
                else if (btnSave.Text == "Update")
                {
                    save = objSetup.SetupSubcategory_InsertUpdateDelete(2, int.Parse(ddlCategory.SelectedValue), txtSubCategory.Text, int.Parse(Session["UserId"].ToString()),int.Parse(hdnUpdateSubCId.Value));
                    if (save > 0)
                    {
                        rmMsg.SuccessMessage = "Update done";
                        LoadGrid();
                        txtSubCategory.Text = "";
                        ddlCategory.SelectedValue = "0";
                        btnSave.Text = "Save";
                    }
                }
            }
            else
            {
                rmMsg.FailureMessage = "Give Correct infomation";
            }
        }

        protected void gvCategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowindex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnCategoryId = (HiddenField)gvCategory.Rows[rowindex].FindControl("hdnCategoryId");
            HiddenField hdnSubCategoryId = (HiddenField)gvCategory.Rows[rowindex].FindControl("hdnSubCategoryId");
            Label lblSubCategory = (Label)gvCategory.Rows[rowindex].FindControl("lblSubCategory");

            if (e.CommandName=="editc")
            {
                hdnUpdateSubCId.Value = hdnSubCategoryId.Value;
                ddlCategory.SelectedValue = hdnCategoryId.Value;
                txtSubCategory.Text = lblSubCategory.Text;
                btnSave.Text = "Update";

            }
            else if (e.CommandName=="deletec")
            {
               int save1 = objSetup.SetupSubcategory_InsertUpdateDelete(3, int.Parse(hdnCategoryId.Value), lblSubCategory.Text, int.Parse(Session["UserId"].ToString()), int.Parse(hdnSubCategoryId.Value));
                if (save1 > 0)
                {
                    rmMsg.SuccessMessage = "Delete done";
                    LoadGrid();
                    txtSubCategory.Text = "";
                }
            }
        }
    }
}