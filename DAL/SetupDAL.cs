using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SetupDAL
    {
        public int SetupInstituteDAL_InsertUpdateDelete(int Action, string InstituteName, string Email, string Phone, string Mobile, string Address, int UserId, int InstituteId = 0)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupInstitute_insertUpdateDelete");

            db.AddInParameter(dbcmd, "Action", DbType.Int32, Action);
            db.AddInParameter(dbcmd, "InstituteName", DbType.String, InstituteName);
            db.AddInParameter(dbcmd, "Email", DbType.String, Email);
            db.AddInParameter(dbcmd, "Phone", DbType.String, Phone);
            db.AddInParameter(dbcmd, "Mobile", DbType.String, Mobile);
            db.AddInParameter(dbcmd, "Address", DbType.String, Address);
            db.AddInParameter(dbcmd, "UserId", DbType.Int32, UserId);
            db.AddInParameter(dbcmd, "InstituteId", DbType.Int32, InstituteId);

            ret = db.ExecuteNonQuery(dbcmd);

            return ret;
        }

        public int SetupSchoolClassDAL_InsertUpdateDelete(int Action, string ClassName, int UserId, int SchoolClassId = 0)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupSchoolClass_insertUpdateDelete");

            db.AddInParameter(dbcmd, "Action", DbType.Int32, Action);
            db.AddInParameter(dbcmd, "ClassName", DbType.String, ClassName);
            db.AddInParameter(dbcmd, "SchoolClassId", DbType.Int32, SchoolClassId);
            db.AddInParameter(dbcmd, "UserId", DbType.Int32, UserId);

            ret = db.ExecuteNonQuery(dbcmd);

            return ret;
        }

        public int SetupSubjectDAL_InsertUpdateDelete(int Action, string SubjectName, int UserId, int SubjectId=0)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupSubject_insertUpdateDelete");

            db.AddInParameter(dbcmd, "Action", DbType.Int32, Action);
            db.AddInParameter(dbcmd, "SubjectName", DbType.String, SubjectName);
            db.AddInParameter(dbcmd, "SubjectId", DbType.Int32, SubjectId);
            db.AddInParameter(dbcmd, "UserId", DbType.Int32, UserId);

            ret = db.ExecuteNonQuery(dbcmd);

            return ret;
        }

        public int SetupDistrictDAL_InsertUpdateDelete(int Action, string DistrictName, int UserId, int DistrictId = 0)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupDistrict_insertUpdateDelete");

            db.AddInParameter(dbcmd, "Action", DbType.Int32, Action);
            db.AddInParameter(dbcmd, "DistrictName", DbType.String, DistrictName);
            db.AddInParameter(dbcmd, "DistrictId", DbType.Int32, DistrictId);
            db.AddInParameter(dbcmd, "UserId", DbType.Int32, UserId);

            ret = db.ExecuteNonQuery(dbcmd);

            return ret;
        }

        public int SetupUpazilaDAL_InsertUpdateDelete(int Action, int DistrictId, string UpazilaName, int UserId, int UpazilaId = 0)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupUpazilaSp_insertUpdateDelete");

            db.AddInParameter(dbcmd, "Action", DbType.Int32, Action);
            db.AddInParameter(dbcmd, "DistrictId", DbType.Int32, DistrictId);
            db.AddInParameter(dbcmd, "UpazilaName", DbType.String, UpazilaName);
            db.AddInParameter(dbcmd, "UserId", DbType.Int32, UserId);
            db.AddInParameter(dbcmd, "UpazilaId", DbType.Int32, UpazilaId);

            ret = db.ExecuteNonQuery(dbcmd);

            return ret;
        }

        public int SetupDesignationDAL_InsertUpdateDelete(int Action, string DesignationName, int Position, int UserId, int DesignationId = 0)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupDesignation_insertUpdateDelete");

            db.AddInParameter(dbcmd, "Action", DbType.Int32, Action);
            db.AddInParameter(dbcmd, "DesignationName", DbType.String, DesignationName);
            db.AddInParameter(dbcmd, "Position", DbType.Int32, Position);
            db.AddInParameter(dbcmd, "DesignationId", DbType.Int32, DesignationId);
            db.AddInParameter(dbcmd, "UserId", DbType.Int32, UserId);

            ret = db.ExecuteNonQuery(dbcmd);

            return ret;
        }

        public int SetupShiftDAL_InsertUpdateDelete(int Action, string ShiftName, int UserId, int ShiftId = 0)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupShift_insertUpdateDelete");

            db.AddInParameter(dbcmd, "Action", DbType.Int32, Action);
            db.AddInParameter(dbcmd, "ShiftName", DbType.String, ShiftName);
            db.AddInParameter(dbcmd, "ShiftId", DbType.Int32, ShiftId);
            db.AddInParameter(dbcmd, "UserId", DbType.Int32, UserId);

            ret = db.ExecuteNonQuery(dbcmd);

            return ret;
        }

        public int Setup_InsertUpdateDelete(int Action,string Category, int UserId, int CategoryId=0)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupSp_insertUpdateDelete");

            db.AddInParameter(dbcmd, "Action", DbType.Int32, Action);
            db.AddInParameter(dbcmd, "Cetegory", DbType.String, Category);
            db.AddInParameter(dbcmd, "UserId", DbType.Int32, UserId);
            db.AddInParameter(dbcmd, "CategoryId", DbType.Int32, CategoryId);

            ret = db.ExecuteNonQuery(dbcmd);

            return ret;
        }

        public int SetupSubcategory_InsertUpdateDelete(int Action, int CategoryId, string SubCategory, int UserId, int SubCategoryId = 0)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupSubCategorySp_insertUpdateDelete");

            db.AddInParameter(dbcmd, "Action", DbType.Int32, Action);
            db.AddInParameter(dbcmd, "CategoryId", DbType.Int32, CategoryId);
            db.AddInParameter(dbcmd, "SubCetegory", DbType.String, SubCategory);
            db.AddInParameter(dbcmd, "UserId", DbType.Int32, UserId);
            db.AddInParameter(dbcmd, "SubCategoryId", DbType.Int32, SubCategoryId);

            ret = db.ExecuteNonQuery(dbcmd);

            return ret;
        }

        public DataTable LoadCategory()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupSp_GetCategory");
            dt = db.ExecuteDataSet(dbcmd).Tables[0];

            return dt;
        }
        public DataTable LoadSubCategory()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupSp_GetSubCategory");
            dt = db.ExecuteDataSet(dbcmd).Tables[0];

            return dt;
        }

        public DataTable LoadSchoolClassDAL()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupSp_GetSchoolClass");
            dt = db.ExecuteDataSet(dbcmd).Tables[0];

            return dt;
        }

        public DataTable LoadSSubjectDAL()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupSp_GetSubject");
            dt = db.ExecuteDataSet(dbcmd).Tables[0];

            return dt;
        }

        public DataTable LoadDistrictDAL()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupSp_GetDistrict");
            dt = db.ExecuteDataSet(dbcmd).Tables[0];

            return dt;
        }

        public DataTable LoadUpazilaDLL()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupSp_GetUpazila");
            dt = db.ExecuteDataSet(dbcmd).Tables[0];

            return dt;
        }

        public DataTable LoadDesignationDAL()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupSp_GetDesignation");
            dt = db.ExecuteDataSet(dbcmd).Tables[0];

            return dt;
        }

        public DataTable LoadShiftDAL()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupSp_GetShift");
            dt = db.ExecuteDataSet(dbcmd).Tables[0];

            return dt;
        }
    }
}
