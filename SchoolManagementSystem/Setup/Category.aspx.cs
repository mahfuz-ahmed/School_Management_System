using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace SchoolManagementSystem.Setup
{
    public partial class Category : System.Web.UI.Page
    {
        SetupBLL objSetup = new SetupBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }
        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = objSetup.LoadCategory();
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

            if (btnSave.Text == "Save")
            {
                save = objSetup.Setup_InsertUpdateDelete(1, txtCategory.Text, int.Parse(Session["UserId"].ToString()), 0);
                if (save > 0)
                {
                    rmMsg.SuccessMessage = "Save done";
                    LoadGrid();
                    txtCategory.Text = "";
                }
            }
            else if (btnSave.Text == "Update")
            {
                save = objSetup.Setup_InsertUpdateDelete(2, txtCategory.Text, int.Parse(Session["UserId"].ToString()),int.Parse(hdnUpdateCId.Value));
                if (save > 0)
                {
                    rmMsg.SuccessMessage = "Update done";
                    LoadGrid();
                    txtCategory.Text = "";
                    btnSave.Text = "Save";
                }
            }
        }

        protected void gvCategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowindex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnCategoryId = (HiddenField)gvCategory.Rows[rowindex].FindControl("hdnCategoryId");
            Label lblCategory = (Label)gvCategory.Rows[rowindex].FindControl("lblCategory");

            if (e.CommandName=="editc")
            {
                hdnUpdateCId.Value = hdnCategoryId.Value;
                txtCategory.Text = lblCategory.Text;
                btnSave.Text = "Update";

            }
            else if (e.CommandName=="deletec")
            {
               int save1 = objSetup.Setup_InsertUpdateDelete(3, txtCategory.Text, int.Parse(Session["UserId"].ToString()), int.Parse(hdnCategoryId.Value));
                if (save1 > 0)
                {
                    rmMsg.SuccessMessage = "Delete done";
                    LoadGrid();
                    txtCategory.Text = "";
                }
            }
        }
    }
}