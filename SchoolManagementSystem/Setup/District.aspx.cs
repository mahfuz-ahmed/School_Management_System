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
    public partial class District : System.Web.UI.Page
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
            dt = objSetup.LoadDistrictBLL();
            if (dt.Rows.Count > 0)
            {
                gvDistrict.DataSource = dt;
                gvDistrict.DataBind();
            }
            else
            {
                gvDistrict.DataSource = null;
                gvDistrict.DataBind();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int save = 0;

            if (btnSave.Text == "Save")
            {
                save = objSetup.SetupDistrictBLL_InsertUpdateDelete(1, txtDistrict.Text, int.Parse(Session["UserId"].ToString()), 0);
                if (save > 0)
                {
                    rmMsg.SuccessMessage = "Save done";
                    LoadGrid();
                    txtDistrict.Text = "";
                }
            }
            else if (btnSave.Text == "Update")
            {
                save = objSetup.SetupDistrictBLL_InsertUpdateDelete(2, txtDistrict.Text, int.Parse(Session["UserId"].ToString()),int.Parse(hdnUpdateDistId.Value));
                if (save > 0)
                {
                    rmMsg.SuccessMessage = "Update done";
                    LoadGrid();
                    txtDistrict.Text = "";
                    btnSave.Text = "Save";
                }
            }
        }

        protected void gvDistrict_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowindex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnDistrictId = (HiddenField)gvDistrict.Rows[rowindex].FindControl("hdnDistrictId");
            Label lblDistrict = (Label)gvDistrict.Rows[rowindex].FindControl("lblDistrict");

            if (e.CommandName == "editc")
            {
                hdnUpdateDistId.Value = hdnDistrictId.Value;
                txtDistrict.Text = lblDistrict.Text;
                btnSave.Text = "Update";

            }
            else if (e.CommandName == "deletec")
            {
                int save1 = objSetup.SetupDistrictBLL_InsertUpdateDelete(3, txtDistrict.Text, int.Parse(Session["UserId"].ToString()), int.Parse(hdnDistrictId.Value));
                if (save1 > 0)
                {
                    rmMsg.SuccessMessage = "Delete done";
                    LoadGrid();
                    txtDistrict.Text = "";
                }
            }
        }
    }
}