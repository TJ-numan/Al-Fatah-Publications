using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.MIS
{
   public class li_UserAccess
    {
       public int UserId { get; set; }
       public string FormId { get; set; }
       public bool View { get; set; }
       public bool Insert { get; set; }
       public bool Update { get; set; }
       public bool Delete { get; set; }

    }
}
