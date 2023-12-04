using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Marketing
{
  public  class li_DonPrimaryObservation
    {
        public int PORId { get; set; }
        public string AgrNo { get; set; }
        public string AgrYNo { get; set; }
        public string AgrYear { get; set; }
        public int ThanaId { get; set; }
        public int EIIN { get; set; }

        public int DoFId { get; set; }
        public string DoName { get; set; }
        public string VillRoBaz { get; set; }
        public string PostOff { get; set; }
        public string ContactNo { get; set; }

        public string RecceivedInfo { get; set; }
        public string Problems { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
  }
}
