using BLL;
using DAL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.Setup
{
    public partial class Institute : System.Web.UI.Page
    {
        InstituteBll objInsBll = new InstituteBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonDAL.Fillddl(ddlDistrict, "SELECT DistrictId,DistrictName FROM Conf_District Order By DistrictName", "DistrictName", "DistrictId");
                LoadGrid();
            }
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonDAL.Fillddl(ddlUpazila, "SELECT UpazilaId,UpazilaName FROM Conf_Upazila  Where (DistrictId=" + ddlDistrict.SelectedValue + ") Order By UpazilaName", "UpazilaName", "UpazilaId");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckFieldValue()==false)
            {
                Save();
                LoadGrid();
            }
        }

        private void Save()
        {
            int save = 0;

            EInstitute objEIns = new EInstitute();

            
            objEIns.EIIN_RegistrationNo = txtEIINRegiNo.Text;
            objEIns.InstituteName = txtInstitute.Text;
            objEIns.Email = txtEmail.Text;
            objEIns.Phone = txtPhone.Text;
            objEIns.Fax = txtFax.Text;
            objEIns.DistrictId = int.Parse(ddlDistrict.SelectedValue);
            objEIns.UpazilaId = int.Parse(ddlUpazila.SelectedValue);
            objEIns.Address = txtAddress.Text;
            objEIns.InstituteType = ddlInstituteType.SelectedValue;
            objEIns.InstituteLogo = imgSave();
            objEIns.EntryBy = int.Parse(Session["UserId"].ToString());

            if (btnSave.Text=="Save")
            {
                objEIns.Action = 1;
                objEIns.InstituteId = 0;
            }
            else if (btnSave.Text == "Update")
            {
                objEIns.Action = 2;
                objEIns.InstituteId = int.Parse(hdnUpdateInstituteId.Value);

            }

             save = objInsBll.InsertUpdateDelete_InstituteBLL(objEIns);
            if (save>0)
            {
                rmMsg.SuccessMessage = "Save Done";
            }
        }

        private string imgSave()
        {
            string imageName = "";
            if (fuInstituteLogo.FileContent.Length>0)
            {
                imageName = fuInstituteLogo.FileName.ToString();
                fuInstituteLogo.SaveAs(Server.MapPath("~/assets/img/Users/ " + fuInstituteLogo.FileName));
            }
            return imageName;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

        }

        private bool CheckFieldValue()
        {
            bool IsReq = false;

            if (txtInstitute.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Institute Name can't be empty";
            }
            else if (txtEIINRegiNo.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "EIIN/Registration No can't be empty";
            }
            else if (txtEmail.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Email can't be empty";
            }
            else if (txtPhone.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Phone can't be empty";
            }
            else if (txtFax.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Fax can't be empty";
            }
            else if (ddlDistrict.SelectedValue == "0")
            {
                IsReq = true;
                rmMsg.FailureMessage= "Please Select District";
            }
            else if (ddlUpazila.SelectedValue == "0"||ddlUpazila.SelectedIndex==-1)
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Select Upazila";
            }
            else if (txtAddress.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Address can't be empty";
            }
            else if (ddlInstituteType.SelectedValue == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Select Institute Type";
            }
            //else if (fuInstituteLogo. == "")
            //{
            //    IsReq = true;
            //    rmMsg.FailureMessage = "Please Select an Institute Logo";
            //}
            return IsReq;
        }

        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = objInsBll.SetupSp_GetInstituteBLL();

            if (dt.Rows.Count>0)
            {
                gvInstitute.DataSource = dt;
                gvInstitute.DataBind();
            }
            else
            {
                gvInstitute.DataSource = null;
                gvInstitute.DataBind();
            }
        }

        private void DeleteIns(int InstituteId)
        {
            int save = 0;
            EInstitute objEIns = new EInstitute();



            objEIns.EIIN_RegistrationNo = "";
            objEIns.InstituteName = "";
            objEIns.Email = "";
            objEIns.Phone = "";
            objEIns.Fax = "";
            objEIns.DistrictId = 0;
            objEIns.UpazilaId = 0;
            objEIns.Address = "";
            objEIns.InstituteType = "";
            objEIns.EntryBy = 0;
            objEIns.Action = 3;
            objEIns.InstituteId = InstituteId;


            save = objInsBll.InsertUpdateDelete_InstituteBLL(objEIns);
            if (save > 0)
            {
                rmMsg.SuccessMessage = "Delete Successfull.";
                LoadGrid();
            }

        }

        protected void gvInstitute_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowindex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnInstituteId = (HiddenField)gvInstitute.Rows[rowindex].FindControl("hdnInstituteId");

            if (e.CommandName == "editc")
            {
                FillControl(int.Parse(hdnInstituteId.Value));
                btnSave.Text = "Update";

            }
            else if (e.CommandName == "deletec")
            {
                DeleteIns(int.Parse(hdnInstituteId.Value));
            }
        }

        private void FillControl(int InstituteId)
        {
            DataTable dt = new DataTable();
            dt = objInsBll.SetupSp_GetInstituteBLL(InstituteId);
            if (dt.Rows.Count > 0)
            {
                hdnUpdateInstituteId.Value = InstituteId.ToString();
                txtEIINRegiNo.Text = dt.Rows[0]["EIIN_RegistrationNo"].ToString();
                txtInstitute.Text = dt.Rows[0]["InstituteName"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtPhone.Text = dt.Rows[0]["Phone"].ToString();
                txtFax.Text = dt.Rows[0]["Fax"].ToString();
                ddlDistrict.SelectedValue = dt.Rows[0]["DistrictId"].ToString();

                CommonDAL.Fillddl(ddlUpazila, @"SELECT UpazilaId, UpazilaName FROM Conf_Upazila
                WHERE (DistrictId = " + ddlDistrict.SelectedValue + ") ORDER BY UpazilaName", "UpazilaName", "UpazilaId");

                ddlUpazila.SelectedValue = dt.Rows[0]["UpazilaId"].ToString();
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                ddlInstituteType.SelectedValue = dt.Rows[0]["InstituteType"].ToString();
            }
        }
    }
}