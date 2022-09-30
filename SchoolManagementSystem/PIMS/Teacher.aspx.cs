using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.PIMS
{
    public partial class Teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                CommonDAL.Fillddl(ddlDistrict, "SELECT DistrictId,DistrictName FROM Conf_District Order By DistrictName", "DistrictName", "DistrictId");
                CommonDAL.Fillddl(ddlBloodGroup, "SELECT BloodGroupId,BloodGroupName FROM BloodGroup Order By BloodGroupName", "BloodGroupName", "BloodGroupId");
                CommonDAL.Fillddl(ddlReligion, "SELECT ReligionId,ReligionName FROM Conf_Religion Order By ReligionName", "ReligionName", "ReligionId");
                CommonDAL.Fillddl(ddlGender, "SELECT GenderId,GenderName FROM Conf_Gender Order By GenderName", "GenderName", "GenderId");
                CommonDAL.Fillddl(ddlDesignation, "SELECT DesignationId,DesignationName FROM Conf_Designation Order By DesignationName", "DesignationName", "DesignationId");
                //LoadGrid();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void gvTeacherProfile_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonDAL.Fillddl(ddlUpazila, "SELECT UpazilaId,UpazilaName FROM Conf_Upazila  Where (DistrictId=" + ddlDistrict.SelectedValue + ") Order By UpazilaName", "UpazilaName", "UpazilaId");
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
            else if (ddlDesignation.SelectedValue == "0")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Select Designation";
            }
            else if (txtDateOfBirth.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Enter Date of Birth";
            }
            else if (ddlGender.SelectedValue == "0")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Select Gender";
            }
            else if (ddlReligion.SelectedValue == "0")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Select Religion";
            }
            else if (ddlBloodGroup.SelectedValue == "0")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Select Blood Group";
            }
            else if (txtContactNumber.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Contact Number can't be empty";
            }
            else if (txtEmail.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Email can't be empty";
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

            else if (txtJoiningDate.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Enter your Joining Date";
            }
            
            return IsReq;
        }

        private void ClearFields()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            ddlDesignation.SelectedValue = "0";
            txtDateOfBirth.Text = "";
            ddlGender.SelectedValue = "0";
            ddlReligion.SelectedValue = "0";
            ddlBloodGroup.SelectedValue = "0";
            txtContactNumber.Text = "";
            txtEmail.Text = "";
            txtNationality.Text = "";
            txtNID.Text = "";
            ddlDistrict.SelectedValue = "0";
            ddlUpazila.SelectedValue = "0";
            txtAddress.Text = "";
            txtJoiningDate.Text = "";
        }
    }
}