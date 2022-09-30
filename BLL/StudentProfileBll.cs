using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entity; 
using System.Data;

namespace BLL
{
    
    public class StudentProfileBll
    {
        StudentProfileDAL objStuProDAL = new StudentProfileDAL();

        public int InsertUpdateDelete_StudentProfileBLL(EStudentProfile objStuPro)
        {
            int ret = 0;
            ret = objStuProDAL.InsertUpdateDelete_StudentProfileDAL(objStuPro);
            return ret;
        }
        public DataTable SetupSp_GetStudentProfileBLL(int StudentId = 0)
        {
            DataTable dt = new DataTable();

            dt = objStuProDAL.SetupSp_GetStudentProfileDAL(StudentId);

            return dt;
        }
        public int InsertAdmissionInfo(DAL.Entity.EStudentProfile objEStuP)
        {
            int ret = 0;
            ret = objStuProDAL.InsertAdmission(objEStuP);
            return ret;
        }
        public DataTable StudentSearchByparam(string StuName, int District, int Upazila, int RollNo)
        {
            DataTable dt = new DataTable();
            dt = objStuProDAL.StudentSearch(StuName, District, Upazila, RollNo);
            return dt;
        }
    }
}
