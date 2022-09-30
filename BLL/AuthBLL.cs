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
    
    public class AuthBLL
    {
        AuthDAL objAuth = new AuthDAL();
        
        public DataTable CheckUserInfo(string userame,string UPassword)
        {
            DataTable dt = new DataTable();
            dt = objAuth.LoginCheck(userame, UPassword);
            return dt;
        }

        public int Insert_URegistrationInfo(EURegistration objEUR)
        {
            int ret = 0;
            ret = objAuth.Insert_URegistration(objEUR);
            return ret;
        }

        public DataTable LoadUserRegInfo(int ReligionId, int Gender, int UserId=0)
        {
            DataTable dt = new DataTable();
            dt = objAuth.LoadUserReg(ReligionId, Gender, UserId);
            return dt;
        }
    }
}
