using DAL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TeacherAssignBLL
    {
        TeacherAssignDAL objTADAL = new TeacherAssignDAL();

        public int InsertUpdateDelete_TeacherAssignInfo(List<ETeacherAssign> collection)
        {
            int ret = 0;
            ret = objTADAL.InsertUpdateDelete_TeacherAssign(collection);
            return ret;
        }
    }
}
