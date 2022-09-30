using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace DAL
{
    public class TeacherAssignDAL
    {
        public int InsertUpdateDelete_TeacherAssign(List<Entity.ETeacherAssign> collection)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    foreach (Entity.ETeacherAssign objETA in collection)
                    {
                        dbcmd = db.GetStoredProcCommand("conSp_InsertUpdateTeacherAssign");

                        db.AddInParameter(dbcmd, "TeacherId", DbType.Int32, objETA.TeacherId);
                        db.AddInParameter(dbcmd, "Shift", DbType.Int32, objETA.ShiftID);
                        db.AddInParameter(dbcmd, "ClassId", DbType.Int32, objETA.ClassId);
                        db.AddInParameter(dbcmd, "ScheduleId", DbType.Int32, objETA.ScheduleId);
                        db.AddInParameter(dbcmd, "EntryBy", DbType.Int32, objETA.EntryBy);
                        ret = db.ExecuteNonQuery(dbcmd);
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    ret = 0;
                    transaction.Rollback();
                }


            }


            return ret;
        }
    }
}
