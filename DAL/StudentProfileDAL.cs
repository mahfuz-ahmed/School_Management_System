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
    public class StudentProfileDAL
    {

        public int InsertUpdateDelete_StudentProfileDAL(Entity.EStudentProfile objEStuP)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupStudentProfile_insertUpdateDelete");

            db.AddInParameter(dbcmd, "Action", DbType.Int32, objEStuP.Action);
            
            db.AddInParameter(dbcmd, "RegistrationNo", DbType.String, objEStuP.RegistrationNo);
            db.AddInParameter(dbcmd, "FirstName", DbType.String, objEStuP.FirstName);
            db.AddInParameter(dbcmd, "LastName", DbType.String, objEStuP.LastName);
            db.AddInParameter(dbcmd, "ContactNo", DbType.String, objEStuP.ContactNo);
            db.AddInParameter(dbcmd, "FatherName", DbType.String, objEStuP.FatherName);
            db.AddInParameter(dbcmd, "FatherContactNo", DbType.String, objEStuP.FatherContactNo);
            db.AddInParameter(dbcmd, "FatherOccupation", DbType.String, objEStuP.FatherOccupation);
            db.AddInParameter(dbcmd, "MotherName", DbType.String, objEStuP.MotherName);
            db.AddInParameter(dbcmd, "MotherContactNo", DbType.String, objEStuP.MotherContactNo);
            db.AddInParameter(dbcmd, "MotherOcupation", DbType.String, objEStuP.MotherOcupation);
            db.AddInParameter(dbcmd, "GurdianName", DbType.String, objEStuP.GurdianName);
            db.AddInParameter(dbcmd, "Relation", DbType.String, objEStuP.Relation);
            db.AddInParameter(dbcmd, "DistrictId", DbType.Int32, objEStuP.DistrictId);
            db.AddInParameter(dbcmd, "UpazilaId", DbType.Int32, objEStuP.UpazilaId);
            db.AddInParameter(dbcmd, "Address", DbType.String, objEStuP.Address);
            db.AddInParameter(dbcmd, "BloodGroupId", DbType.Int32, objEStuP.BloodGroupId);
            db.AddInParameter(dbcmd, "ReligionId", DbType.Int32, objEStuP.ReligionId);
            db.AddInParameter(dbcmd, "GenderId", DbType.Int32, objEStuP.GenderId);
            db.AddInParameter(dbcmd, "DOB", DbType.DateTime, objEStuP.DOB);
            db.AddInParameter(dbcmd, "StuPic", DbType.String, objEStuP.StuPic);
            db.AddInParameter(dbcmd, "UserId", DbType.Int32, objEStuP.EntryBy);
            db.AddInParameter(dbcmd, "StudentId", DbType.Int32, objEStuP.StudentId);

            ret = db.ExecuteNonQuery(dbcmd);

            return ret;
        }

        public int InsertAdmission(Entity.EStudentProfile objEStuP)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("Insert_SpAdmission");

            db.AddInParameter(dbcmd, "RegSl", DbType.Int32, objEStuP.RegSl);
            db.AddInParameter(dbcmd, "RegistrationNo", DbType.String, objEStuP.RegistrationNo);
            db.AddInParameter(dbcmd, "RollNo", DbType.Int32, objEStuP.RollNo);
            db.AddInParameter(dbcmd, "SessionYear", DbType.Int32, objEStuP.SessionYear);
            db.AddInParameter(dbcmd, "AdmissionDate", DbType.DateTime, objEStuP.AdmissionDate);
            db.AddInParameter(dbcmd, "Shift", DbType.Int32, objEStuP.Shift);
            db.AddInParameter(dbcmd, "ClassId", DbType.Int32, objEStuP.ClassId);
            db.AddInParameter(dbcmd, "StudentId", DbType.Int32, objEStuP.StudentId);
            db.AddInParameter(dbcmd, "EntryBy", DbType.Int32, objEStuP.EntryBy);

            ret = db.ExecuteNonQuery(dbcmd);

            return ret;
        }
        public int DeleteAdmission(int AdmissionId)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("Admission_SpDelete");
            db.AddInParameter(dbcmd, "AdmissionId", DbType.Int32, AdmissionId);
            ret = db.ExecuteNonQuery(dbcmd);

            return ret;
        }
        public DataTable SetupSp_GetStudentProfileDAL(int StudentId)
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupSp_GetStudentProfile");
            dt = db.ExecuteDataSet(dbcmd).Tables[0];

            return dt;
        }

        public DataTable StudentSearch(string StuName, int District, int Upazila,int RollNo)
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("Student_SpGetByParam");
            db.AddInParameter(dbcmd, "StuName", DbType.String, StuName);
            db.AddInParameter(dbcmd, "District", DbType.Int32, District);
            db.AddInParameter(dbcmd, "Upazila", DbType.Int32, Upazila);
            db.AddInParameter(dbcmd, "RollNo", DbType.Int32, RollNo);

            dt = db.ExecuteDataSet(dbcmd).Tables[0];

            return dt;
        }
    }
}
