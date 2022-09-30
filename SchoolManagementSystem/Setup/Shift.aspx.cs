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
    public partial class Shift : System.Web.UI.Page
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
            dt = objSetup.LoadShiftBLL();
            if (dt.Rows.Count > 0)
            {
                gvShift.DataSource = dt;
                gvShift.DataBind();
            }
            else
            {
                gvShift.DataSource = null;
                gvShift.DataBind();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int save = 0;

            if (btnSave.Text == "Save")
            {
                save = objSetup.SetupShiftBLL_InsertUpdateDelete(1, txtShift.Text, int.Parse(Session["UserId"].ToString()), 0);
                if (save > 0)
                {
                    rmMsg.SuccessMessage = "Save done";
                    LoadGrid();
                    txtShift.Text = "";
                }
            }
            else if (btnSave.Text == "Update")
            {
                save = objSetup.SetupShiftBLL_InsertUpdateDelete(2, txtShift.Text, int.Parse(Session["UserId"].ToString()),int.Parse(hdnUpdateDesgId.Value));
                if (save > 0)
                {
                    rmMsg.SuccessMessage = "Update done";
                    LoadGrid();
                    txtShift.Text = "";
                    btnSave.Text = "Save";
                }
            }
        }

        protected void gvShift_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowindex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnShiftId = (HiddenField)gvShift.Rows[rowindex].FindControl("hdnShiftId");
            Label lblShift = (Label)gvShift.Rows[rowindex].FindControl("lblShift");

            if (e.CommandName == "editc")
            {
                hdnUpdateDesgId.Value = hdnShiftId.Value;
                txtShift.Text = lblShift.Text;
                btnSave.Text = "Update";

            }
            else if (e.CommandName == "deletec")
            {
                int save1 = objSetup.SetupShiftBLL_InsertUpdateDelete(3, txtShift.Text, int.Parse(Session["UserId"].ToString()), int.Parse(hdnShiftId.Value));
                if (save1 > 0)
                {
                    rmMsg.SuccessMessage = "Delete done";
                    LoadGrid();
                    txtShift.Text = "";
                }
            }
        }
    }
}