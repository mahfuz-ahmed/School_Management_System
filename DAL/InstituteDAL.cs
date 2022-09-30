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
    public class InstituteDAL
    {

        public int InsertUpdateDelete_InstituteDAL(Entity.EInstitute objEIns)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupInstitute_insertUpdateDelete");

            db.AddInParameter(dbcmd, "Action", DbType.Int32, objEIns.Action);
            
            db.AddInParameter(dbcmd, "EIIN_RegistrationNo", DbType.String, objEIns.EIIN_RegistrationNo);
            db.AddInParameter(dbcmd, "InstituteName", DbType.String, objEIns.InstituteName);
            db.AddInParameter(dbcmd, "Email", DbType.String, objEIns.Email);
            db.AddInParameter(dbcmd, "Phone", DbType.String, objEIns.Phone);
            db.AddInParameter(dbcmd, "Fax", DbType.String, objEIns.Fax);
            db.AddInParameter(dbcmd, "DistrictId", DbType.Int32, objEIns.DistrictId);
            db.AddInParameter(dbcmd, "UpazilaId", DbType.Int32, objEIns.UpazilaId);
            db.AddInParameter(dbcmd, "Address", DbType.String, objEIns.Address);
            db.AddInParameter(dbcmd, "InstituteType", DbType.String, objEIns.InstituteType);
            db.AddInParameter(dbcmd, "InstituteLogo", DbType.String, objEIns.InstituteLogo);
            db.AddInParameter(dbcmd, "UserId", DbType.Int32, objEIns.EntryBy);
            db.AddInParameter(dbcmd, "InstituteId", DbType.Int32, objEIns.InstituteId);

            ret = db.ExecuteNonQuery(dbcmd);

            return ret;
        }

        public DataTable SetupSp_GetInstituteDAL(int InstituteId)
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupSp_GetInstitute");
            db.AddInParameter(dbcmd, "InstituteId", DbType.Int32, InstituteId);
            dt = db.ExecuteDataSet(dbcmd).Tables[0];

            return dt;
        }
    }
}
