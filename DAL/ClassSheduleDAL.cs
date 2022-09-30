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
    public class ClassSheduleDAL
    {

        public int InsertClassSheduleDAL(List<Entity.EClassShedule> collection)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transection = connection.BeginTransaction();
                try
                {
                    foreach (Entity.EClassShedule EclsS in collection)
                    {
                        dbcmd = db.GetStoredProcCommand("ClassShedule_SpInsert");
                        db.AddInParameter(dbcmd, "ShiftId", DbType.Int32, EclsS.ShiftId);
                        db.AddInParameter(dbcmd, "ClassID", DbType.Int32, EclsS.ClassId);
                        db.AddInParameter(dbcmd, "SubjectId", DbType.Int32, EclsS.SubjectId);
                        db.AddInParameter(dbcmd, "WeekDay", DbType.String, EclsS.WeekDay);
                        db.AddInParameter(dbcmd, "StartTime", DbType.DateTime, EclsS.StartTime);
                        db.AddInParameter(dbcmd, "EndTime", DbType.DateTime, EclsS.EndTime);
                        db.AddInParameter(dbcmd, "EntryBy", DbType.Int32, EclsS.EntryBy);
                        ret = db.ExecuteNonQuery(dbcmd);
                    }
                    transection.Commit();
                }
                catch (Exception)
                {
                    ret = 0;
                    transection.Rollback();
                }


            }


            return ret;
        }

    }
}
