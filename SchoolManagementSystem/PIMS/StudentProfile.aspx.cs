using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using DAL.Entity;

namespace SchoolManagementSystem.PIMS
{
    public partial class StudentProfile : System.Web.UI.Page
    {
        StudentProfileBll objStuBll = new StudentProfileBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                CommonDAL.Fillddl(ddlDistrict, "SELECT DistrictId,DistrictName FROM Conf_District Order By DistrictName", "DistrictName", "DistrictId");
                CommonDAL.Fillddl(ddlBloodGroup, "SELECT BloodGroupId,BloodGroupName FROM BloodGroup Order By BloodGroupName", "BloodGroupName", "BloodGroupId");
                CommonDAL.Fillddl(ddlReligion, "SELECT ReligionId,ReligionName FROM Conf_Religion Order By ReligionName", "ReligionName", "ReligionId");
                CommonDAL.Fillddl(ddlGender, "SELECT GenderId,GenderName FROM Conf_Gender Order By GenderName", "GenderName", "GenderId");
                LoadGrid();
            }
        }

        

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonDAL.Fillddl(ddlUpazila, "SELECT UpazilaId,UpazilaName FROM Conf_Upazila  Where (DistrictId=" + ddlDistrict.SelectedValue + ") Order By UpazilaName", "UpazilaName", "UpazilaId");
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

        protected void btnReset_Click(object sender, EventArgs e)
        {

        }


        private void Save()
        {
            int save = 0;

            EStudentProfile objEStuPro = new EStudentProfile();

            objEStuPro.RegistrationNo = txtRegistrationNo.Text;
            objEStuPro.FirstName = txtFirstName.Text;
            objEStuPro.LastName = txtLastName.Text;
            objEStuPro.ContactNo = txtContactNumber.Text;
            objEStuPro.FatherName = txtFatherName.Text;
            objEStuPro.FatherContactNo = txtFatherContactNo.Text;
            objEStuPro.FatherOccupation = txtFatherOccupation.Text;
            objEStuPro.MotherName = txtMotherName.Text;
            objEStuPro.MotherContactNo = txtMotherContactNo.Text;
            objEStuPro.MotherOcupation = txtMotherOccupation.Text;
            objEStuPro.GurdianName = txtGurdianName.Text;
            objEStuPro.Relation = txtGurdianRelation.Text;
            objEStuPro.DistrictId = int.Parse(ddlDistrict.SelectedValue);
            objEStuPro.UpazilaId = int.Parse(ddlUpazila.SelectedValue);
            objEStuPro.Address = txtAddress.Text;
            objEStuPro.BloodGroupId = int.Parse(ddlBloodGroup.SelectedValue);
            objEStuPro.ReligionId = int.Parse(ddlReligion.SelectedValue);
            objEStuPro.GenderId = int.Parse(ddlGender.SelectedValue);
            objEStuPro.DOB = DateTime.Parse(txtDateOfBirth.Text);
            objEStuPro.StuPic = imgSave();
            objEStuPro.EntryBy = int.Parse(Session["UserId"].ToString());

            if (btnSave.Text == "Save")
            {
                objEStuPro.Action = 1;
                objEStuPro.StudentId = 0;
            }
            else if (btnSave.Text == "Update")
            {
                objEStuPro.Action = 2;
                objEStuPro.StudentId = int.Parse(hdnUpdateStudentId.Value);
            }

            save = objStuBll.InsertUpdateDelete_StudentProfileBLL(objEStuPro);
            if (save > 0)
            {
                rmMsg.SuccessMessage = "Save Done";
            }
        }

        private string imgSave()
        {
            string imageName = "";
            if (fuStudentPic.FileContent.Length > 0)
            {
                imageName = fuStudentPic.FileName.ToString();
                fuStudentPic.SaveAs(Server.MapPath("~/assets/img/Users/ " + fuStudentPic.FileName));
            }

            return imageName;
        }

        private void ClearFields()
        {

            txtRegistrationNo.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtContactNumber.Text = "";
            txtFatherName.Text = "";
            txtFatherContactNo.Text = "";
            txtFatherOccupation.Text = "";
            txtMotherName.Text = "";
            txtMotherContactNo.Text = "";
            txtMotherOccupation.Text = "";
            txtGurdianName.Text = "";
            txtGurdianRelation.Text = "";
            ddlDistrict.SelectedValue = "0";
            ddlUpazila.SelectedValue = "0";
            txtAddress.Text = "";
            ddlBloodGroup.SelectedValue = "0";
            ddlReligion.SelectedValue = "0";
            ddlGender.SelectedValue = "0";
            txtDateOfBirth.Text = "";
        }

        private bool CheckFieldValue()
        {
            bool IsReq = false;

            if (txtRegistrationNo.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Registration No can't be empty";
            }
            else if (txtFirstName.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "First Name can't be empty";
            }
            else if (txtLastName.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Last Name can't be empty";
            }
            else if (txtContactNumber.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Contact Number can't be empty";
            }
            else if (txtFatherName.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Father's Name can't be empty";
            }
            else if (txtFatherContactNo.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Father's Contact No can't be empty";
            }
            else if (txtFatherOccupation.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Father's Occupation can't be empty";
            }
            else if (txtMotherName.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Mother's Name can't be empty";
            }
            else if (txtMotherContactNo.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Mother's Contact No can't be empty";
            }
            else if (txtMotherOccupation.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Mother's Occupation can't be empty";
            }
            else if (txtGurdianName.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Gurdian's Name can't be empty";
            }
            else if (txtGurdianRelation.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Relation can't be empty";
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
            else if (ddlBloodGroup.SelectedValue == "0")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Select Blood Group";
            }
            else if (ddlReligion.SelectedValue == "0")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Select Religion";
            }
            else if (ddlGender.SelectedValue == "0")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Select Gender";
            }
            else if (txtDateOfBirth.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage = "Please Enter Date of Birth";
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
            dt = objStuBll.SetupSp_GetStudentProfileBLL();

            if (dt.Rows.Count > 0)
            {
                gvStudentProfile.DataSource = dt;
                gvStudentProfile.DataBind();
            }
            else
            {
                gvStudentProfile.DataSource = null;
                gvStudentProfile.DataBind();
            }
        }

        private void DeleteIns(int StudentId)
        {
            int save = 0;
            EStudentProfile objEStuPro = new EStudentProfile();

            objEStuPro.RegistrationNo = "";
            objEStuPro.FirstName = "";
            objEStuPro.LastName = "";
            objEStuPro.ContactNo = "";
            objEStuPro.FatherName = "";
            objEStuPro.FatherContactNo = "";
            objEStuPro.FatherOccupation = "";
            objEStuPro.MotherName = "";
            objEStuPro.MotherContactNo = "";
            objEStuPro.MotherOcupation = "";
            objEStuPro.GurdianName = "";
            objEStuPro.Relation = "";
            objEStuPro.DistrictId = 0;
            objEStuPro.UpazilaId = 0;
            objEStuPro.Address = "";
            objEStuPro.BloodGroupId = 0;
            objEStuPro.ReligionId = 0;
            objEStuPro.GenderId = 0;
            objEStuPro.DOB = DateTime.Now;
            objEStuPro.StuPic = imgSave();
            objEStuPro.StudentId = StudentId;


            save = objStuBll.InsertUpdateDelete_StudentProfileBLL(objEStuPro);
            if (save > 0)
            {
                rmMsg.SuccessMessage = "Delete Successfull.";
                LoadGrid();
            }

        }

        protected void gvStudentProfile_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowindex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnStudentId = (HiddenField)gvStudentProfile.Rows[rowindex].FindControl("hdnStudentId");

            if (e.CommandName == "editc")
            {
                FillControl(int.Parse(hdnStudentId.Value));
                btnSave.Text = "Update";

            }
            else if (e.CommandName == "deletec")
            {
                DeleteIns(int.Parse(hdnStudentId.Value));
            }
        }

        private void FillControl(int StudentId)
        {
            DataTable dt = new DataTable();
            dt = objStuBll.SetupSp_GetStudentProfileBLL(StudentId);
            if (dt.Rows.Count > 0)
            {
                hdnUpdateStudentId.Value = StudentId.ToString();
                txtRegistrationNo.Text = dt.Rows[0]["RegistrationNo"].ToString();
                txtFirstName.Text = dt.Rows[0]["FirstName"].ToString();
                txtLastName.Text = dt.Rows[0]["LastName"].ToString();
                
                txtFatherName.Text = dt.Rows[0]["FatherName"].ToString();
                txtFatherContactNo.Text = dt.Rows[0]["FatherContactNo"].ToString();
                txtFatherOccupation.Text = dt.Rows[0]["FatherOccupation"].ToString();
                txtMotherName.Text = dt.Rows[0]["MotherName"].ToString();
                txtMotherContactNo.Text = dt.Rows[0]["MotherContactNo"].ToString();
                txtMotherOccupation.Text = dt.Rows[0]["MotherOcupation"].ToString();
                txtGurdianName.Text = dt.Rows[0]["GurdianName"].ToString();
                txtGurdianRelation.Text = dt.Rows[0]["Relation"].ToString();
                ddlDistrict.SelectedValue = dt.Rows[0]["DistrictId"].ToString();

                CommonDAL.Fillddl(ddlUpazila, @"SELECT UpazilaId, UpazilaName FROM Conf_Upazila
                WHERE (DistrictId = " + ddlDistrict.SelectedValue + ") ORDER BY UpazilaName", "UpazilaName", "UpazilaId");

                ddlUpazila.SelectedValue = dt.Rows[0]["UpazilaId"].ToString();
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                txtContactNumber.Text = dt.Rows[0]["ContactNo"].ToString();
                ddlReligion.SelectedValue = dt.Rows[0]["ReligionId"].ToString();
                ddlGender.SelectedValue = dt.Rows[0]["GenderId"].ToString();
                txtDateOfBirth.Text = (string)DateTime.Parse(dt.Rows[0]["DOB"].ToString()).ToString("yyyy-MM-dd");
                ddlBloodGroup.SelectedValue = dt.Rows[0]["BloodGroupId"].ToString();
            }
        }

        protected void gvStudentProfile_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
        }
    }
}