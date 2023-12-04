using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
   public class li_UserAccessLog
    {
        public int SlNo { get; set; }
        public int UserId { get; set; }
        public string IPAdd { get; set; }
        public string PhyAdd { get; set; }
        public DateTime login_time { get; set; }
        public DateTime logout_time { get; set; }
    }
}
