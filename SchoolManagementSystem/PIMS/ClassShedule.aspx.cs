using DAL;
using DAL.Entity;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SchoolManagementSystem.PIMS
{
    public partial class ClassShedule : System.Web.UI.Page
    {
        ClassSheduleBLL objclsSBll = new ClassSheduleBLL();
        CommonDAL objc = new CommonDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                CommonDAL.Fillddl(ddlShift, @"SELECT ShiftId, ShiftName FROM Conf_Shift", "ShiftName", "ShiftId");
                CommonDAL.Fillddl(ddlClass, @"
SELECT SchoolClassId, ClassName FROM Conf_SchoolClass", "ClassName", "SchoolClassId");
                CommonDAL.Fillddl(ddlSubject, @"
select SubjectId,SubjectName from Conf_Subject order by SubjectName asc", "SubjectName", "SubjectId");
            }
        }



        //private void Save()
        //{
        //    int save = 0;

        //    EStudentProfile objEStuPro = new EStudentProfile();

        //    objEStuPro.RegSl = int.Parse(hdnRegsl.Value)+1;
        //    objEStuPro.RegistrationNo = txtRegNo.Text;
        //    objEStuPro.RollNo = int.Parse(txtRoll.Text);
        //    objEStuPro.SessionYear = int.Parse(ddlSession.SelectedValue);
        //    objEStuPro.AdmissionDate = Convert.ToDateTime(txtDate.Text);
        //    objEStuPro.Shift = int.Parse(ddlShift.SelectedValue);
        //    objEStuPro.ClassId = int.Parse(ddlClass.SelectedValue);
        //    objEStuPro.StudentId = int.Parse(hdnStuId.Value);
        //    objEStuPro.EntryBy = int.Parse(Session["UserId"].ToString());

        //    save = objStuBll.InsertAdmissionInfo(objEStuPro);
        //    if (save > 0)
        //    {
        //        rmmsg.SuccessMessage = "Save Done";
        //    }
        //}
        private bool checkValue()
        {
            rmmsg.SetResponseMessageVisibleFalse();
            bool isReq = false;
            DataTable dt = new DataTable();

            if (gvClassShedule.Rows.Count > 0)
            {
                dt = (DataTable)ViewState["VSCS"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string shiftId = dt.Rows[i]["ShiftId"].ToString();
                    string ClassID = dt.Rows[i]["ClassID"].ToString();
                    string WeekDay = dt.Rows[i]["WeekDay"].ToString();
                    string SubjectId = dt.Rows[i]["SubjectId"].ToString();

                    DateTime StartTime = DateTime.Parse(dt.Rows[i]["StartTime"].ToString());
                    DateTime EndTime = DateTime.Parse(dt.Rows[i]["EndTime"].ToString());

                    if (shiftId == ddlShift.SelectedValue && ClassID == ddlClass.SelectedValue && WeekDay == ddlWeekDay.SelectedValue && SubjectId == ddlSubject.SelectedValue)
                    {
                        isReq = true;
                        rmmsg.FailureMessage = "This Subject already Exist.";

                    }
                    else if (shiftId == ddlShift.SelectedValue && ClassID == ddlClass.SelectedValue && WeekDay == ddlWeekDay.SelectedValue && (DateTime.Parse(txtStartTime.Text) >= StartTime && DateTime.Parse(txtStartTime.Text) <= EndTime))
                    {
                        isReq = true;
                        rmmsg.FailureMessage = "This time already Exist.";
                    }
                    else if (shiftId == ddlShift.SelectedValue && ClassID == ddlClass.SelectedValue && WeekDay == ddlWeekDay.SelectedValue && (DateTime.Parse(txtEndTime.Text) >= StartTime && DateTime.Parse(txtEndTime.Text) <= EndTime))
                    {
                        isReq = true;
                        rmmsg.FailureMessage = "This time already Exist.";
                    }


                }
            }

            return isReq;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Save();
        }
        protected void AddBtn_Click(object sender, EventArgs e)
        {
            if (checkValue()==false)
            {
                ListAdd();
            }
       
        }
        private void ListAdd()
        {
           
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("Shift", typeof(String)));
            dt.Columns.Add(new DataColumn("ShiftID", typeof(String)));
            dt.Columns.Add(new DataColumn("Class", typeof(String)));   
            dt.Columns.Add(new DataColumn("ClassID", typeof(String)));
            dt.Columns.Add(new DataColumn("WeekDay", typeof(String)));
            dt.Columns.Add(new DataColumn("Subject", typeof(String)));
            dt.Columns.Add(new DataColumn("SubjectId", typeof(String)));
            dt.Columns.Add(new DataColumn("StartTime", typeof(String)));
            dt.Columns.Add(new DataColumn("EndTime", typeof(String)));

            if (ViewState["VSCS"]!=null)
            {
                dt = (DataTable)ViewState["VSCS"];
            }
            DataRow dr = dt.NewRow();
            dr[0] = ddlShift.SelectedItem.Text;
            dr[1] = ddlShift.SelectedValue;
            dr[2] = ddlClass.SelectedItem.Text;
            dr[3] = ddlClass.SelectedValue;
            dr[4] = ddlWeekDay.SelectedValue;
            dr[5] = ddlSubject.SelectedItem.Text;
            dr[6] = ddlSubject.SelectedValue;
            dr[7] = txtStartTime.Text;
            dr[8] = txtEndTime.Text;

            dt.Rows.Add(dr);

            gvClassShedule.DataSource = dt;
            gvClassShedule.DataBind();
            ViewState["VSCS"] = dt;


        }
        List<EClassShedule> collection = new List<EClassShedule>();

        private void Save()
        {
            if (gvClassShedule.Rows.Count>0)
            {
                DataTable dt = new DataTable();
                if (ViewState["VSCS"] != null)
                {
                    dt = (DataTable)ViewState["VSCS"];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        EClassShedule objclss = new EClassShedule();
                        objclss.ShiftId = int.Parse(dt.Rows[i]["ShiftId"].ToString());
                        objclss.ClassId = int.Parse(dt.Rows[i]["ClassID"].ToString());
                        objclss.WeekDay = dt.Rows[i]["WeekDay"].ToString();
                        objclss.SubjectId = int.Parse(dt.Rows[i]["SubjectId"].ToString());
                        objclss.StartTime = DateTime.Parse(dt.Rows[i]["StartTime"].ToString());
                        objclss.EndTime = DateTime.Parse(dt.Rows[i]["EndTime"].ToString());
                        objclss.EntryBy = int.Parse(Session["UserId"].ToString());
                        collection.Add(objclss);
                    }
                   int save= objclsSBll.InsertClassSheduleDALDetails(collection);
                    if (save>0)
                    {
                        rmmsg.SuccessMessage = "Save Done";
                    }
                    else
                    {
                        rmmsg.FailureMessage = "Save Failure.";
                    }
                }
            }
            else
            {
                rmmsg.FailureMessage = "There is no data.";
            }
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string sqlStr = @"SELECT        Conf_Shift.ShiftName Shift, Conf_ClassShedule.ShiftId ShiftId, Conf_SchoolClass.ClassName Class, Conf_ClassShedule.ClassId ClassID,
            Conf_ClassShedule.WeekDay WeekDay, Conf_Subject.SubjectName Subject, Conf_ClassShedule.SubjectId SubjectId, 
            CAST(Conf_ClassShedule.StartTime as TIME)  StartTime, CAST(Conf_ClassShedule.EndTime as TIME) EndTime
            FROM            Conf_ClassShedule INNER JOIN
            Conf_SchoolClass ON Conf_ClassShedule.ClassId = Conf_SchoolClass.SchoolClassId INNER JOIN
            Conf_Shift ON Conf_ClassShedule.ShiftId = Conf_Shift.ShiftId INNER JOIN
            Conf_Subject ON Conf_ClassShedule.SubjectId = Conf_Subject.SubjectId
            WHERE(Conf_ClassShedule.ShiftId = " + ddlShift.SelectedValue + ") AND(Conf_ClassShedule.ClassId = " + ddlClass.SelectedValue + ")";
            dt = objc.loaddt(sqlStr);
            gvClassShedule.DataSource = dt;
            gvClassShedule.DataBind();

            ViewState["VSCS"] = dt;
        }
    }
}