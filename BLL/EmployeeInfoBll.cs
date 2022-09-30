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
    
    public class EmployeeInfoBll
    {
        EmployeeInfoDAL objEmpDAL = new EmployeeInfoDAL();

        public int InsertUpdateDelete_EmployeeInfoBLL(EEmployeeInfo objEEmp)
        {
            int ret = 0;
            ret = objEmpDAL.InsertUpdateDelete_EmployeeInfoDAL(objEEmp);
            return ret;
        }
        public DataTable SetupSp_GetInstituteBLL(int EmployeeId = 0)
        {
            DataTable dt = new DataTable();

            dt = objEmpDAL.SetupSp_GetEmployeeInfoDAL(EmployeeId);

            return dt;
        }
    }
}
