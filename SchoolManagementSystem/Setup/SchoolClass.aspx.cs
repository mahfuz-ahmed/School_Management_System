using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.Setup
{
    public partial class SchoolClass : System.Web.UI.Page
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
            dt = objSetup.LoadSchoolClassBLL();
            if (dt.Rows.Count > 0)
            {
                gvClass.DataSource = dt;
                gvClass.DataBind();
            }
            else
            {
                gvClass.DataSource = null;
                gvClass.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int save = 0;

            if (btnSave.Text == "Save")
            {
                save = objSetup.SetupSchoolClassBLL_InsertUpdateDelete(1, txtClassName.Text, int.Parse(Session["UserId"].ToString()), 0);
                if (save > 0)
                {
                    rmMsg.SuccessMessage = "Save done";
                    LoadGrid();
                    txtClassName.Text = "";
                }
            }
            else if (btnSave.Text == "Update")
            {
                save = objSetup.SetupSchoolClassBLL_InsertUpdateDelete(2, txtClassName.Text, int.Parse(Session["UserId"].ToString()), int.Parse(hdnUpdateSCId.Value));
                if (save > 0)
                {
                    rmMsg.SuccessMessage = "Update done";
                    LoadGrid();
                    txtClassName.Text = "";
                    btnSave.Text = "Save";
                }
            }
        }

        protected void gvClass_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowindex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnClassId = (HiddenField)gvClass.Rows[rowindex].FindControl("hdnClassId");
            Label lblSchoolClass = (Label)gvClass.Rows[rowindex].FindControl("lblSchoolClass");

            if (e.CommandName == "editc")
            {
                hdnUpdateSCId.Value = hdnClassId.Value;
                txtClassName.Text = lblSchoolClass.Text;
                btnSave.Text = "Update";

            }
            else if (e.CommandName == "deletec")
            {
                int save1 = objSetup.SetupSchoolClassBLL_InsertUpdateDelete(3, txtClassName.Text, int.Parse(Session["UserId"].ToString()), int.Parse(hdnClassId.Value));
                if (save1 > 0)
                {
                    rmMsg.SuccessMessage = "Delete done";
                    LoadGrid();
                    txtClassName.Text = "";
                }
            }
        }
    }
}