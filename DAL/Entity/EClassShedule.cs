using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
   public class EClassShedule
    {
        public int Action { get;  set; }

        public int ShiftId { get; set; }
        public int ClassId { get; set; }
        public string WeekDay { get; set; }
        public int SubjectId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Nullable<int> EntryBy { get; set; }
        public Nullable<DateTime> EntryDate { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<DateTime> UpdateDate { get; set; }
    }

}
