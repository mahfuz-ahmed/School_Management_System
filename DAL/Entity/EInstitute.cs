using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
   public class EInstitute
    {
        public int Action { get;  set; }

        public int InstituteId { get; set; }
        public string EIIN_RegistrationNo { get; set; }
        public string InstituteName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public Nullable<int> DistrictId { get; set; }
        public Nullable<int> UpazilaId { get; set; }
        public string Address { get; set; }
        public string InstituteType { get; set; }
        public string InstituteLogo { get; set; }
        public Nullable<int> EntryBy { get; set; }
        public Nullable<DateTime> EntryDate { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<DateTime> UpdateDate { get; set; }
    }

}
