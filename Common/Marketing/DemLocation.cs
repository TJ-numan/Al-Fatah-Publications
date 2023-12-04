using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
 public class DemLocation
    {
     public DemLocation()
     {
         
     }

     public DemLocation( string  locId, string location)
     {
         LocID = locId;
         Location = location;
     }


     public  string LocID { get; set; }
     public  string  Location { get; set; }
    }
}
