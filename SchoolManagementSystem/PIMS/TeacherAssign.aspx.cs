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
    public partial class TeacherAssign : System.Web.UI.Page
    {
        TeacherAssignBLL objTABLL = new TeacherAssignBLL();
        CommonDAL objc = new CommonDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                CommonDAL.Fillddl(ddlTeacher, "SELECT EmployeeInfo.FirstName + ' ' + EmployeeInfo.LastName + '-' + Conf_Designation.DesignationName AS TeacherName, " +
                    "EmployeeInfo.EmployeeId, Conf_Designation.DesignationId FROM EmployeeInfo " +
                    "INNER JOIN " +
                    "Conf_Designation ON EmployeeInfo.DesignationId = Conf_Designation.DesignationId WHERE(EmployeeInfo.EmployeeType = 'Teacher')", "TeacherName", "EmployeeId");

                CommonDAL.Fillddl(ddlShift, @"SELECT   Conf_Shift.ShiftId, Conf_Shift.ShiftName
                FROM            Conf_ClassShedule INNER JOIN
                Conf_Shift ON Conf_ClassShedule.ShiftId = Conf_Shift.ShiftId
                GROUP BY Conf_Shift.ShiftId, Conf_Shift.ShiftName", "ShiftName", "ShiftId");

            }
        }


        private void Save()
        {
            if (gvTeacherAssign.Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                if (ViewState["VSTA"] != null)
                {
                    dt = (DataTable)ViewState["VSTA"];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ETeacherAssign objTA = new ETeacherAssign();
                        objTA.TeacherId = int.Parse(dt.Rows[i]["TeacherId"].ToString());
                        objTA.ShiftID = int.Parse(dt.Rows[i]["ShiftId"].ToString());
                        objTA.ClassId = int.Parse(dt.Rows[i]["ClassId"].ToString());
                        objTA.ScheduleId = int.Parse(dt.Rows[i]["ScheduleId"].ToString());
                        objTA.EntryBy = int.Parse(Session["UserId"].ToString());
                        collection.Add(objTA);
                    }
                    int save = objTABLL.InsertUpdateDelete_TeacherAssignInfo(collection);
                    if (save > 0)
                    {
                        rmMsg.SuccessMessage = "Save Done";
                    }
                    else
                    {
                        rmMsg.FailureMessage = "Save Failure.";
                    }
                }
            }
            else
            {
                rmMsg.FailureMessage = "There is no data.";
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkValue() == false)
            {
                ListAdd();
            }

        }
        protected void ddlTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string sqlStr = @"SELECT TeacherAssign.TeacherId, (EmployeeInfo.FirstName+' '+ EmployeeInfo.LastName) as Teacher , TeacherAssign.ShiftId, TeacherAssign.ClassId, Conf_SchoolClass.ClassName Class, TeacherAssign.ScheduleId, 
            Conf_ClassShedule.WeekDay + ' - ' + Conf_Subject.SubjectName + ' --> ' + CONVERT(varchar(5), CAST(Conf_ClassShedule.StartTime AS time)) + ' to ' + CONVERT(varchar(5), 
            CAST(Conf_ClassShedule.EndTime AS time)) AS Schedule FROM TeacherAssign 
            INNER JOIN
            Conf_SchoolClass ON TeacherAssign.ClassId = Conf_SchoolClass.SchoolClassId INNER JOIN
            EmployeeInfo ON TeacherAssign.TeacherId = EmployeeInfo.EmployeeId AND TeacherAssign.TeacherId = EmployeeInfo.EmployeeId INNER JOIN
            Conf_ClassShedule ON TeacherAssign.ScheduleId = Conf_ClassShedule.CSheduleId AND Conf_SchoolClass.SchoolClassId = Conf_ClassShedule.ClassId INNER JOIN
            Conf_Subject ON Conf_ClassShedule.SubjectId = Conf_Subject.SubjectId WHERE (TeacherAssign.TeacherId = "+ddlTeacher.SelectedValue+ ") GROUP BY TeacherAssign.TeacherId, EmployeeInfo.FirstName + ' ' + EmployeeInfo.LastName, TeacherAssign.ShiftId, TeacherAssign.ClassId, Conf_SchoolClass.ClassName, TeacherAssign.ScheduleId,  Conf_ClassShedule.WeekDay + ' - ' + Conf_Subject.SubjectName + ' --> ' + CONVERT(varchar(5), CAST(Conf_ClassShedule.StartTime AS time)) + ' to ' + CONVERT(varchar(5), CAST(Conf_ClassShedule.EndTime AS time))";
            dt = objc.loaddt(sqlStr);
            gvTeacherAssign.DataSource = dt;
            gvTeacherAssign.DataBind();

            ViewState["VSCS"] = dt;
        }
        private bool checkValue()
        {
            rmMsg.SetResponseMessageVisibleFalse();
            bool isReq = false;
            DataTable dt = new DataTable();

            if (gvTeacherAssign.Rows.Count > 0)
            {
                dt = (DataTable)ViewState["VSCS"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string TeacherId = dt.Rows[i]["TeacherId"].ToString();
                    string shift = dt.Rows[i]["shiftId"].ToString();
                    string ClassId = dt.Rows[i]["ClassId"].ToString();
                    string ScheduleId = dt.Rows[i]["ScheduleId"].ToString();

                    if (TeacherId == ddlTeacher.SelectedValue && shift == ddlShift.SelectedValue && ClassId == ddlClass.SelectedValue && ScheduleId == ddlSchedule.SelectedValue)
                    {
                        isReq = true;
                        rmMsg.FailureMessage = "This Schedule already Exist.";

                    }
                    else if (shift == ddlShift.SelectedValue && ClassId == ddlClass.SelectedValue && ScheduleId == ddlSchedule.SelectedValue && TeacherId == ddlTeacher.SelectedValue)
                    {
                        isReq = true;
                        rmMsg.FailureMessage = "Teacher already Exist.";
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
            if (checkValue() == false)
            {
                ListAdd();
            }

        }
        private void ListAdd()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Teacher", typeof(String)));
            dt.Columns.Add(new DataColumn("TeacherId", typeof(String)));
            dt.Columns.Add(new DataColumn("ShiftId", typeof(String)));
            dt.Columns.Add(new DataColumn("Class", typeof(String)));
            dt.Columns.Add(new DataColumn("ClassId", typeof(String)));
            dt.Columns.Add(new DataColumn("Schedule", typeof(String)));
            dt.Columns.Add(new DataColumn("ScheduleId", typeof(String)));

            if (ViewState["VSTA"] != null)
            {
                dt = (DataTable)ViewState["VSTA"];
            }
            DataRow dr = dt.NewRow();
            dr[0] = ddlTeacher.SelectedItem.Text;
            dr[1] = ddlTeacher.SelectedValue;
            dr[2] = ddlShift.SelectedValue;
            dr[3] = ddlClass.SelectedItem.Text;
            dr[4] = ddlClass.SelectedValue;
            dr[5] = ddlSchedule.SelectedItem.Text;
            dr[6] = ddlSchedule.SelectedValue;
            dt.Rows.Add(dr);

            gvTeacherAssign.DataSource = dt;
            gvTeacherAssign.DataBind();
            ViewState["VSTA"] = dt;

        }

        List<ETeacherAssign> collection = new List<ETeacherAssign>();

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string sqlStr = @"SELECT Conf_ClassShedule.CSheduleId, Conf_ClassShedule.WeekDay + ' - ' + Conf_Subject.SubjectName + ' --> ' + CONVERT(varchar(5), CAST(Conf_ClassShedule.StartTime AS time)) + ' to ' + CONVERT(varchar(5), 
            CAST(Conf_ClassShedule.EndTime AS time))  AS Schedule
            FROM Conf_ClassShedule INNER JOIN
            Conf_SchoolClass ON Conf_ClassShedule.ClassId = Conf_ClassShedule.ClassId INNER JOIN
            Conf_Subject ON Conf_ClassShedule.SubjectId = Conf_Subject.SubjectId
            WHERE (ShiftId = '" + ddlShift.SelectedValue + "') AND (Conf_ClassShedule.ClassId = " + ddlClass.SelectedValue + ")  GROUP BY Conf_ClassShedule.CSheduleId, Conf_ClassShedule.WeekDay + ' - ' + Conf_Subject.SubjectName + ' --> ' + CONVERT(varchar(5), CAST(Conf_ClassShedule.StartTime AS time)) + ' to ' + CONVERT(varchar(5),  CAST(Conf_ClassShedule.EndTime AS time))";
            CommonDAL.Fillddl(ddlSchedule, sqlStr, "Schedule", "CSheduleId");

        }

        protected void ddlShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonDAL.Fillddl(ddlClass, @"SELECT Conf_ClassShedule.ClassId, Conf_SchoolClass.ClassName
            FROM            Conf_ClassShedule INNER JOIN
            Conf_SchoolClass ON Conf_ClassShedule.ClassId = Conf_SchoolClass.SchoolClassId
            WHERE        (Conf_ClassShedule.ShiftId = " + ddlShift.SelectedValue+ ") GROUP BY Conf_ClassShedule.ClassId, Conf_SchoolClass.ClassName", "ClassName", "ClassId");

        }
    }
}