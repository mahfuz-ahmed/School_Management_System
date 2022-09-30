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

namespace SchoolManagementSystem.PIMS
{
    public partial class EmployeeInfo : System.Web.UI.Page
    {
        EmployeeInfoBll objEmpBll = new EmployeeInfoBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonDAL.Fillddl(ddlDistrict, "SELECT DistrictId,DistrictName FROM Conf_District Order By DistrictName", "DistrictName", "DistrictId");
                CommonDAL.Fillddl(ddlReligion, "SELECT ReligionId,ReligionName FROM Conf_Religion Order By ReligionName", "ReligionName", "ReligionId");
                CommonDAL.Fillddl(ddlDesignation, "SELECT DesignationId,DesignationName FROM Conf_Designation Order By DesignationName", "DesignationName", "DesignationId");
                LoadGrid();
            }
        }
        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonDAL.Fillddl(ddlUpazila, "SELECT UpazilaId,UpazilaName FROM Conf_Upazila  Where (DistrictId=" + ddlDistrict.SelectedValue + ") Order By UpazilaName", "UpazilaName", "UpazilaId");
        }

        private void Save()
        {
            int save = 0;

            EEmployeeInfo objEEmp = new EEmployeeInfo();

            objEEmp.FirstName = txtFirstName.Text;
            objEEmp.LastName = txtLastName.Text;
            objEEmp.EmployeeType = ddlEmployeeType.SelectedValue;
            objEEmp.DesignationId = int.Parse(ddlDesignation.SelectedValue);
            objEEmp.StartingSalary = float.Parse(txtStartingSalary.Text);
            objEEmp.Nationality = txtNationality.Text;
            objEEmp.NID = txtNID.Text;
            objEEmp.DateofBirth = DateTime.Parse(txtDateOfBirth.Text);
            objEEmp.JoiningDate = DateTime.Parse(txtDateOfJoining.Text);
            objEEmp.ReligionId = int.Parse(ddlReligion.SelectedValue);
            objEEmp.DistrictId = int.Parse(ddlDistrict.SelectedValue);
            objEEmp.UpazilaId = int.Parse(ddlUpazila.SelectedValue);
            objEEmp.Address = txtAddress.Text;
            objEEmp.Email = txtEmail.Text;
            objEEmp.ContactNo = txtContactNumber.Text;
            objEEmp.Gender = ddlGender.SelectedValue;
            objEEmp.BloodGroup = ddlBloodGroup.SelectedValue;
            objEEmp.EmpImg = imgSave();
            objEEmp.EntryBy = int.Parse(Session["UserId"].ToString());

            if (btnSave.Text == "Save")
            {
                objEEmp.Action = 1;
                objEEmp.EmployeeId = 0;
            }
            else if (btnSave.Text == "Update")
            {
                objEEmp.Action = 2;
                objEEmp.EmployeeId = int.Parse(hdnUpdateEmployeeId.Value);

            }

            save = objEmpBll.InsertUpdateDelete_EmployeeInfoBLL(objEEmp);
            if (save > 0)
            {
                rmMsg.SuccessMessage = "Save Done";
            }
        }

        private string imgSave()
        {
            string imageName = "";
            if (fuEmployeeImage.FileContent.Length > 0)
            {
                imageName = fuEmployeeImage.FileName.ToString();
                fuEmployeeImage.SaveAs(Server.MapPath("~/assets/img/Users/ " + fuEmployeeImage.FileName));
            }
            return imageName;
        }

        private void ClearFields()
        {

            ddlEmployeeType.SelectedValue = "0";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            ddlDesignation.SelectedValue = "0";
            ddlReligion.SelectedValue = "0";
            txtAddress.Text = "";
            ddlDistrict.SelectedValue = "0";
            ddlUpazila.SelectedValue = "0";
            txtStartingSalary.Text = "";
            txtNationality.Text = "";
            txtNID.Text = "";
            ddlGender.SelectedValue = "0";
            ddlBloodGroup.SelectedValue = "0";
            txtEmail.Text = "";
            txtContactNumber.Text = "";
        }

        private bool CheckFieldValue()
        {
            bool IsReq = false;

            if (txtFirstName.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "First Name can't be empty";
            }
            else if (txtLastName.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Last Name can't be empty";
            }
            else if (ddlEmployeeType.SelectedValue == "0")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Select Employee Type";
            }
            else if (ddlDesignation.SelectedValue == "0")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Select Designation";
            }
            else if (txtStartingSalary.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Starting Salary can't be empty";
            }
            else if (txtNationality.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Nationality can't be empty";
            }
            else if (txtNID.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "NID can't be empty";
            }
            else if (txtDateOfBirth.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Enter Date of Birth";
            }
            else if (txtDateOfJoining.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Enter your Joining Date";
            }
            else if (ddlReligion.SelectedValue == "0")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Select Religion";
            }
            else if (ddlDistrict.SelectedValue == "0")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Select District";
            }
            else if (ddlUpazila.SelectedValue == "0" || ddlUpazila.SelectedIndex == -1)
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Select Upazila";
            }
            else if (txtAddress.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Address can't be empty";
            }
            else if (txtEmail.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Email can't be empty";
            }
            
            else if (txtContactNumber.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Contact No can't be empty";
            }


            else if (ddlGender.SelectedValue == "0")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Select Gender";
            }
            else if (ddlBloodGroup.SelectedValue == "0")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Select Blood Group";
            }
            return IsReq;
        }

        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = objEmpBll.SetupSp_GetInstituteBLL();

            if (dt.Rows.Count > 0)
            {
                gvEmployeeInfo.DataSource = dt;
                gvEmployeeInfo.DataBind();
            }
            else
            {
                gvEmployeeInfo.DataSource = null;
                gvEmployeeInfo.DataBind();
            }
        }

        private void DeleteIns(int EmployeeId)
        {
            int save = 0;
            EEmployeeInfo objEEmp = new EEmployeeInfo();

            objEEmp.FirstName = "";
            objEEmp.LastName = "";
            objEEmp.EmployeeType = "";
            objEEmp.DesignationId = 0;
            objEEmp.StartingSalary = 0;
            objEEmp.Nationality = "";
            objEEmp.NID = "";
            objEEmp.DateofBirth = DateTime.Now;
            objEEmp.JoiningDate = DateTime.Now;
            objEEmp.ReligionId = 0;
            objEEmp.DistrictId = 0;
            objEEmp.UpazilaId = 0;
            objEEmp.Address = "";
            objEEmp.Email = "";
            objEEmp.ContactNo = "";
            objEEmp.Gender = "";
            objEEmp.BloodGroup = "";
            objEEmp.EmpImg = imgSave();
            objEEmp.EntryBy = 0;
            objEEmp.Action = 3;
            objEEmp.EmployeeId = EmployeeId;


            save = objEmpBll.InsertUpdateDelete_EmployeeInfoBLL(objEEmp);
            if (save > 0)
            {
                rmMsg.SuccessMessage = "Delete Successfull.";
                LoadGrid();
            }

        }

        protected void gvEmployeeInfo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowindex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnEmployeeId = (HiddenField)gvEmployeeInfo.Rows[rowindex].FindControl("hdnEmployeeId");

            if (e.CommandName == "editc")
            {
                FillControl(int.Parse(hdnEmployeeId.Value));
                btnSave.Text = "Update";

            }
            else if (e.CommandName == "deletec")
            {
                DeleteIns(int.Parse(hdnEmployeeId.Value));
            }
        }

        private void FillControl(int EmployeeId)
        {
            DataTable dt = new DataTable();
            dt = objEmpBll.SetupSp_GetInstituteBLL(EmployeeId);
            if (dt.Rows.Count > 0)
            {
                hdnUpdateEmployeeId.Value = EmployeeId.ToString();
                txtFirstName.Text = dt.Rows[0]["FirstName"].ToString();
                txtLastName.Text = dt.Rows[0]["LastName"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                ddlEmployeeType.Text = dt.Rows[0]["EmployeeType"].ToString();
                ddlDesignation.SelectedValue = dt.Rows[0]["DesignationId"].ToString();
                txtStartingSalary.Text = dt.Rows[0]["StartingSalary"].ToString();
                txtNationality.Text = dt.Rows[0]["Nationality"].ToString();
                txtNID.Text = dt.Rows[0]["NID"].ToString();
                txtDateOfBirth.Text = (string)DateTime.Parse(dt.Rows[0]["DOB"].ToString()).ToString("yyyy-MM-dd");
                txtDateOfJoining.Text = (string)DateTime.Parse(dt.Rows[0]["JoiningDate"].ToString()).ToString("yyyy-MM-dd");
                ddlReligion.SelectedValue = dt.Rows[0]["ReligionId"].ToString();
                ddlDistrict.SelectedValue = dt.Rows[0]["DistrictId"].ToString();

                CommonDAL.Fillddl(ddlUpazila, @"SELECT UpazilaId, UpazilaName FROM Conf_Upazila
                WHERE (DistrictId = " + ddlDistrict.SelectedValue + ") ORDER BY UpazilaName", "UpazilaName", "UpazilaId");

                ddlUpazila.SelectedValue = dt.Rows[0]["UpazilaId"].ToString();
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtContactNumber.Text = dt.Rows[0]["ContactNo"].ToString();
                ddlGender.Text = dt.Rows[0]["Gender"].ToString();
                ddlBloodGroup.Text = dt.Rows[0]["BloodGroup"].ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckFieldValue() == false)
            {
                Save();
                LoadGrid();
                ClearFields();
            }
        }
    }
}