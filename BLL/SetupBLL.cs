using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class SetupBLL
    {
        SetupDAL objSetup = new SetupDAL();

        public int SetupInstituteBLL_InsertUpdateDelete(int Action, string InstituteName, string Email, string Phone, string Mobile, string Address, int UserId, int InstituteId = 0)
        {
            int ret = 0;
            ret = objSetup.SetupInstituteDAL_InsertUpdateDelete(Action, InstituteName, Email, Phone, Mobile, Address, UserId, InstituteId);
            return ret;
        }

        public int SetupSchoolClassBLL_InsertUpdateDelete(int Action, string ClassName, int UserId, int SchoolClassId = 0)
        {
            int ret = 0;
            ret = objSetup.SetupSchoolClassDAL_InsertUpdateDelete(Action, ClassName, UserId, SchoolClassId);
            return ret;
        }

        public int SetupSubjectBLL_InsertUpdateDelete(int Action, string SubjectName, int UserId, int SubjectId=0)
        {
            int ret = 0;
            ret = objSetup.SetupSubjectDAL_InsertUpdateDelete(Action, SubjectName, UserId, SubjectId);
            return ret;
        }

        public int SetupDistrictBLL_InsertUpdateDelete(int Action, string DistrictName, int UserId, int DistrictId = 0)
        {
            int ret = 0;
            ret = objSetup.SetupDistrictDAL_InsertUpdateDelete(Action, DistrictName, UserId, DistrictId);
            return ret;
        }
        public int SetupUpazilaBLL_InsertUpdateDelete(int Action, int DistrictId, string UpazilaName, int UserId, int UpazilaId = 0)
        {
            int ret = 0;
            ret = objSetup.SetupUpazilaDAL_InsertUpdateDelete(Action, DistrictId, UpazilaName, UserId, UpazilaId);
            return ret;
        }
        public int SetupDesignationBLL_InsertUpdateDelete(int Action, string DesignationName, int Position, int UserId, int DesignationId = 0)
        {
            int ret = 0;
            ret = objSetup.SetupDesignationDAL_InsertUpdateDelete(Action, DesignationName, Position, UserId, DesignationId);
            return ret;
        }

        public int SetupShiftBLL_InsertUpdateDelete(int Action, string ShiftName, int UserId, int ShiftId = 0)
        {
            int ret = 0;
            ret = objSetup.SetupShiftDAL_InsertUpdateDelete(Action, ShiftName, UserId, ShiftId);
            return ret;
        }

        public int Setup_InsertUpdateDelete(int Action, string Category, int UserId, int CategoryId = 0)
        {
            int ret = 0;
            ret = objSetup.Setup_InsertUpdateDelete(Action,Category,UserId,CategoryId);
            return ret;
        }
        public int SetupSubcategory_InsertUpdateDelete(int Action, int CategoryId, string SubCategory, int UserId, int SubCategoryId = 0)
        {
            int ret = 0;
            ret = objSetup.SetupSubcategory_InsertUpdateDelete(Action, CategoryId, SubCategory, UserId, SubCategoryId);
            return ret;
        }
        public DataTable LoadCategory()
        {
            DataTable dt = new DataTable();
            dt = objSetup.LoadCategory();
            return dt;
        }
        public DataTable LoadSubCategory()
        {
            DataTable dt = new DataTable();
            dt = objSetup.LoadSubCategory();
            return dt;
        }

        public DataTable LoadSchoolClassBLL()
        {
            DataTable dt = new DataTable();
            dt = objSetup.LoadSchoolClassDAL();
            return dt;
        }
        public DataTable LoadSubjectBLL()
        {
            DataTable dt = new DataTable();
            dt = objSetup.LoadSSubjectDAL();
            return dt;
        }
        public DataTable LoadDistrictBLL()
        {
            DataTable dt = new DataTable();
            dt = objSetup.LoadDistrictDAL();
            return dt;
        }
        public DataTable LoadUpazilaBLL()
        {
            DataTable dt = new DataTable();
            dt = objSetup.LoadUpazilaDLL();
            return dt;
        }
        public DataTable LoadDesignationBLL()
        {
            DataTable dt = new DataTable();
            dt = objSetup.LoadDesignationDAL();
            return dt;
        }
        public DataTable LoadShiftBLL()
        {
            DataTable dt = new DataTable();
            dt = objSetup.LoadShiftDAL();
            return dt;
        }
    }
}
