using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.HR
{
   public class li_AssetTransfer
    {
       public int  AssTId { get; set; }
       public int  AssetId { get; set; }
       public int  FromDepId { get; set; }
       public int  FromEmpId { get; set; }
       public int  ToDepId { get; set; }
       public int ToEmpId  { get; set; }
       public DateTime TransferDate  { get; set; }
       public int  CreatedBy { get; set; }
       public DateTime  CreatedDate { get; set; }


    }
}
