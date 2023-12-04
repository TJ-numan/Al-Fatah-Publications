using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Common;
using DAL;

namespace BLL
{
 public    class DemLocationManager
    {
     public DemLocationManager() { }

     public static List<DemLocation> GetLocationsByDemarcation(int DemID)
     {
         List<DemLocation> demLocations = new List< DemLocation>();
         DemLocationProvider sqldemLocations = new DemLocationProvider();
         demLocations = sqldemLocations.GetLocationsByDemarcation(DemID);
         return demLocations;
     }

     public static DataSet getRoutePlanMappings(int ComID, int DemID)
     {
         DataSet ds = new DataSet();
         DemLocationProvider  sqlDemLocationProvider = new DemLocationProvider() ;
         ds =  sqlDemLocationProvider. getRoutePlanMappings(ComID, DemID );
         return ds;
     }

    }
}
