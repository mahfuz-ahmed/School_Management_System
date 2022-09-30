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
    
    public class InstituteBll
    {
        InstituteDAL objInsDAL = new InstituteDAL();

        public int InsertUpdateDelete_InstituteBLL(EInstitute objIns)
        {
            int ret = 0;
            ret = objInsDAL.InsertUpdateDelete_InstituteDAL(objIns);
            return ret;
        }
        public DataTable SetupSp_GetInstituteBLL(int InstituteId = 0)
        {
            DataTable dt = new DataTable();

            dt = objInsDAL.SetupSp_GetInstituteDAL(InstituteId);

            return dt;
        }
    }
}
