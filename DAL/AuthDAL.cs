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
    public class AuthDAL
    {
       
        public DataTable LoginCheck(string UserName,string UPassword)
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("AuthSp_CheckLogin");
            db.AddInParameter(dbcmd, "UserName", DbType.String, UserName);
            db.AddInParameter(dbcmd, "UPassword", DbType.String, UPassword);
            dt = db.ExecuteDataSet(dbcmd).Tables[0];
           
            return dt;
        }

        public int Insert_URegistration(Entity.EURegistration objEUR)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("AuthSp_InsertURegistration");

            //db.AddInParameter(dbcmd, "UserId", DbType.Int32, objEUR.UserId);
            db.AddInParameter(dbcmd, "UserName", DbType.String, objEUR.UserName);
            db.AddInParameter(dbcmd, "FirstName", DbType.String, objEUR.FirstName);
            db.AddInParameter(dbcmd, "MiddleName", DbType.String, objEUR.MiddleName);
            db.AddInParameter(dbcmd, "LastName", DbType.String, objEUR.LastName);
            db.AddInParameter(dbcmd, "Gender", DbType.Int32, objEUR.Gender);
            db.AddInParameter(dbcmd, "DateofBirth", DbType.String, objEUR.DateofBirth);
            db.AddInParameter(dbcmd, "Email", DbType.String, objEUR.Email);
            db.AddInParameter(dbcmd, "ContactNo", DbType.String, objEUR.ContactNo);
            db.AddInParameter(dbcmd, "Address", DbType.String, objEUR.Address);
            db.AddInParameter(dbcmd, "Nationality", DbType.String, objEUR.Nationality);
            db.AddInParameter(dbcmd, "ReligionId", DbType.Int32, objEUR.ReligionId);
            //db.AddInParameter(dbcmd, "EntryDate", DbType.DateTime, objEUR.EntryDate);
            db.AddInParameter(dbcmd, "UserImage", DbType.String, objEUR.UserImage);

            ret = db.ExecuteNonQuery(dbcmd);

            return ret;
        }

        public DataTable LoadUserReg(int ReligionId, int Gender, int UserID)
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("AuthSp_GetUserReg");
            db.AddInParameter(dbcmd, "ReligionId", DbType.Int32, ReligionId);
            db.AddInParameter(dbcmd, "Gender", DbType.Int32, Gender);
            db.AddInParameter(dbcmd, "UserId", DbType.Int32, UserID);
            dt = db.ExecuteDataSet(dbcmd).Tables[0];

            return dt;
        }

    }
}
