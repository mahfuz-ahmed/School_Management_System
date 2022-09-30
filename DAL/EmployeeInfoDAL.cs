using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace DAL
{
    public class EmployeeInfoDAL
    {

        public int InsertUpdateDelete_EmployeeInfoDAL(Entity.EEmployeeInfo objEEmpIn)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupEmployeeInfo_insertUpdateDelete");

            db.AddInParameter(dbcmd, "Action", DbType.Int32, objEEmpIn.Action);
            db.AddInParameter(dbcmd, "EmployeeId", DbType.Int32, objEEmpIn.EmployeeId);
            db.AddInParameter(dbcmd, "FirstName", DbType.String, objEEmpIn.FirstName);
            db.AddInParameter(dbcmd, "LastName", DbType.String, objEEmpIn.LastName);
            db.AddInParameter(dbcmd, "EmployeeType", DbType.String, objEEmpIn.EmployeeType);
            db.AddInParameter(dbcmd, "DesignationId", DbType.Int32, objEEmpIn.DesignationId);
            db.AddInParameter(dbcmd, "StartingSalary", DbType.Double, objEEmpIn.StartingSalary);
            db.AddInParameter(dbcmd, "Nationality", DbType.String, objEEmpIn.Nationality);
            db.AddInParameter(dbcmd, "NID", DbType.String, objEEmpIn.NID);
            db.AddInParameter(dbcmd, "DOB", DbType.DateTime, objEEmpIn.DateofBirth);
            db.AddInParameter(dbcmd, "JoiningDate", DbType.DateTime, objEEmpIn.JoiningDate);
            db.AddInParameter(dbcmd, "ReligionId", DbType.Int32, objEEmpIn.ReligionId);
            db.AddInParameter(dbcmd, "DistrictId", DbType.Int32, objEEmpIn.DistrictId);
            db.AddInParameter(dbcmd, "UpazilaId", DbType.Int32, objEEmpIn.UpazilaId);
            db.AddInParameter(dbcmd, "Address", DbType.String, objEEmpIn.Address);
            db.AddInParameter(dbcmd, "Email", DbType.String, objEEmpIn.Email);
            db.AddInParameter(dbcmd, "ContactNo", DbType.String, objEEmpIn.ContactNo);
            db.AddInParameter(dbcmd, "Gender", DbType.String, objEEmpIn.Gender);
            db.AddInParameter(dbcmd, "BloodGroup", DbType.String, objEEmpIn.BloodGroup);
            db.AddInParameter(dbcmd, "EmpImg", DbType.String, objEEmpIn.EmpImg);
            db.AddInParameter(dbcmd, "IsActive", DbType.Boolean, objEEmpIn.IsActive=0);
            db.AddInParameter(dbcmd, "UserId", DbType.Int32, objEEmpIn.EntryBy);

            ret = db.ExecuteNonQuery(dbcmd);

            return ret;
        }

        public DataTable SetupSp_GetEmployeeInfoDAL(int EmployeeId)
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupSp_GetEmployeeInfo");
            db.AddInParameter(dbcmd, "EmployeeId", DbType.Int32, EmployeeId);
            dt = db.ExecuteDataSet(dbcmd).Tables[0];

            return dt;
        }
    }
}
