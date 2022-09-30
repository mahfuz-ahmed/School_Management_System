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
    
    public class ClassSheduleBLL
    {
        ClassSheduleDAL objclsSDAL = new ClassSheduleDAL();

        public int InsertClassSheduleDALDetails(List<EClassShedule> collection)
        {
            int ret = 0;
            ret = objclsSDAL.InsertClassSheduleDAL(collection);
            return ret;
        }
     
    }
}
