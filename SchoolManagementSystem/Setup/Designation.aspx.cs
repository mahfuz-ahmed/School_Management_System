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
    public partial class Designation : System.Web.UI.Page
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
            dt = objSetup.LoadDesignationBLL();
            if (dt.Rows.Count > 0)
            {
                gvDesignation.DataSource = dt;
                gvDesignation.DataBind();
            }
            else
            {
                gvDesignation.DataSource = null;
                gvDesignation.DataBind();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int save = 0;

            if (btnSave.Text == "Save")
            {
                save = objSetup.SetupDesignationBLL_InsertUpdateDelete(1, txtDesignation.Text, int.Parse(txtPosition.Text), int.Parse(Session["UserId"].ToString()), 0);
                if (save > 0)
                {
                    rmMsg.SuccessMessage = "Save done";
                    LoadGrid();
                    txtDesignation.Text = "";
                    txtPosition.Text = "";
                }
            }
            else if (btnSave.Text == "Update")
            {
                save = objSetup.SetupDesignationBLL_InsertUpdateDelete(2, txtDesignation.Text, int.Parse(txtPosition.Text), int.Parse(Session["UserId"].ToString()),int.Parse(hdnUpdateDesgId.Value));
                if (save > 0)
                {
                    rmMsg.SuccessMessage = "Update done";
                    LoadGrid();
                    txtDesignation.Text = "";
                    txtPosition.Text = "";
                    btnSave.Text = "Save";
                }
            }
        }

        protected void gvDesignation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowindex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnDesignationId = (HiddenField)gvDesignation.Rows[rowindex].FindControl("hdnDesignationId");
            Label lblDesignation = (Label)gvDesignation.Rows[rowindex].FindControl("lblDesignation");
            Label lblPosition = (Label)gvDesignation.Rows[rowindex].FindControl("lblPosition");

            if (e.CommandName == "editc")
            {
                hdnUpdateDesgId.Value = hdnDesignationId.Value;
                txtDesignation.Text = lblDesignation.Text;
                txtPosition.Text = lblPosition.Text;
                btnSave.Text = "Update";

            }
            else if (e.CommandName == "deletec")
            {
                int save1 = objSetup.SetupDesignationBLL_InsertUpdateDelete(3, txtDesignation.Text, int.Parse(txtPosition.Text==""?"0": txtPosition.Text), int.Parse(Session["UserId"].ToString()), int.Parse(hdnDesignationId.Value));
                if (save1 > 0)
                {
                    rmMsg.SuccessMessage = "Delete done";
                    LoadGrid();
                    txtDesignation.Text = "";
                    txtPosition.Text = "";
                }
            }
        }
    }
}