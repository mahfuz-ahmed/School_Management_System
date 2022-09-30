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
    public partial class Subject : System.Web.UI.Page
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
            dt = objSetup.LoadSubjectBLL();
            if (dt.Rows.Count > 0)
            {
                gvSubject.DataSource = dt;
                gvSubject.DataBind();
            }
            else
            {
                gvSubject.DataSource = null;
                gvSubject.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int save = 0;

            if (btnSave.Text == "Save")
            {
                save = objSetup.SetupSubjectBLL_InsertUpdateDelete(1, txtSubject.Text, int.Parse(Session["UserId"].ToString()), 0);
                if (save > 0)
                {
                    rmMsg.SuccessMessage = "Save done";
                    LoadGrid();
                    txtSubject.Text = "";
                }
            }
            else if (btnSave.Text == "Update")
            {
                save = objSetup.SetupSubjectBLL_InsertUpdateDelete(2, txtSubject.Text, int.Parse(Session["UserId"].ToString()), int.Parse(hdnUpdateSubjectId.Value));
                if (save > 0)
                {
                    rmMsg.SuccessMessage = "Update done";
                    LoadGrid();
                    txtSubject.Text = "";
                    btnSave.Text = "Save";
                }
            }
        }

        protected void gvSubject_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowindex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnSubjectId = (HiddenField)gvSubject.Rows[rowindex].FindControl("hdnSubjectId");
            Label lblSubjectName = (Label)gvSubject.Rows[rowindex].FindControl("lblSubjectName");

            if (e.CommandName == "editc")
            {
                hdnUpdateSubjectId.Value = hdnSubjectId.Value;
                txtSubject.Text = lblSubjectName.Text;
                btnSave.Text = "Update";

            }
            else if (e.CommandName == "deletec")
            {
                int save1 = objSetup.SetupSubjectBLL_InsertUpdateDelete(3, txtSubject.Text, int.Parse(Session["UserId"].ToString()), int.Parse(hdnSubjectId.Value));
                if (save1 > 0)
                {
                    rmMsg.SuccessMessage = "Delete done";
                    LoadGrid();
                    txtSubject.Text = "";
                }
            }
        }
    }
}