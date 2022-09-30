using DAL;
using DAL.Entity;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.PIMS
{
    public partial class StudentAdmission : System.Web.UI.Page
    {
        CommonDAL objc = new CommonDAL();
        StudentProfileBll objStuBll = new StudentProfileBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnStuid.Value = Request.QueryString["StudentId"].ToString();
                loadSessionYear();
                txtName.Text = objc.loadStr(@"SELECT (FirstName+' '+ LastName) AS StuName FROM StudentProfile where StudentId="+ hdnStuid.Value + "");
                CommonDAL.Fillddl(ddlClass, "Select SchoolClassId,ClassName from Conf_SchoolClass", "ClassName", "SchoolClassId");
                CommonDAL.Fillddl(ddlShift, "Select ShiftId,ShiftName from Conf_Shift", "ShiftName", "ShiftId");
            }
        }
        private void loadRegNo()
        {
            if (ddlClass.SelectedValue != "0" || ddlSession.SelectedValue != "0" || ddlShift.SelectedValue != "0")
            {
                hdnRegsl.Value = objc.loadStr(@"SELECT  ISNULL(MAX(RegSl),0) AS RegSl
FROM Student_Admission WHERE(SessionYear = " + ddlSession.SelectedValue + ") AND(Shift = " + ddlShift.SelectedValue + ") AND(ClassId = " + ddlClass.SelectedValue + ")");

                txtRegNo.Text = "KR" + ddlSession.SelectedValue.Substring(2, 2) + ddlShift.SelectedItem.Text.Substring(0, 1) + ddlClass.SelectedValue.PadLeft(2, '0') + (int.Parse(hdnRegsl.Value) + 1).ToString().PadLeft(3, '0');
            }
            else
            {
                rmMsg.FailureMessage = "Select All Information.";
            }
        }
        private void loadSessionYear()
        {
            ListItem li1 = new ListItem("Select.....", "0");
            ListItem li2 = new ListItem((DateTime.Now.Year + 1).ToString(), (DateTime.Now.Year + 1).ToString());

            ddlSession.Items.Insert(0, li1);
            ddlSession.Items.Insert(1, li2);
            for (int i = 2; i < 50; i++)
            {
                ListItem li = new ListItem((DateTime.Now.Year - (i - 2)).ToString(), (DateTime.Now.Year - (i - 2)).ToString());
                ddlSession.Items.Insert(i, li);
            }

        }
        protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadRegNo();
        }

        private void Save()
        {
            int save = 0;

            EStudentProfile objEStuPro = new EStudentProfile();

            objEStuPro.RegSl = int.Parse(hdnRegsl.Value) + 1;
            objEStuPro.RegistrationNo = txtRegNo.Text;
            objEStuPro.RollNo = int.Parse(txtRoll.Text);
            objEStuPro.SessionYear = int.Parse(ddlSession.SelectedValue);
            objEStuPro.AdmissionDate = Convert.ToDateTime(txtDate.Text);
            objEStuPro.Shift = int.Parse(ddlShift.SelectedValue);
            objEStuPro.ClassId = int.Parse(ddlClass.SelectedValue);
            objEStuPro.StudentId = int.Parse(hdnStuid.Value);
            objEStuPro.EntryBy = int.Parse(Session["UserId"].ToString());

            save = objStuBll.InsertAdmissionInfo(objEStuPro);
            if (save > 0)
            {
                rmMsg.SuccessMessage = "Save Done";
            }
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}