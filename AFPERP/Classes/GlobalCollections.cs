using System;
using System.Data;

namespace BLL.Classes
{
  public  class GlobalCollections
    {

      public GlobalCollections()
      {

      }

        public static int userID;
        public static string userName;
        public static int RuleID;
        public static int challanDetailsStatus;
        public static int DepartmentID;
        public static string Location;

        public static bool RSM;

        public static bool ASM;

        public static bool TSO;

        public static int RegionID;

        public static int AreaID;

        public static string TerritoryID;

        public static DateTime ServerDate;
        
        public static int S_Version;


        public static void AddConstraint(DataTable table, string col)
        {
            UniqueConstraint uniqueConstraint;
            // Assuming a column named "UniqueColumn" exists, and 
            // its Unique property is true.
            uniqueConstraint = new UniqueConstraint(
                table.Columns[col]);
            table.Constraints.Add(uniqueConstraint);
        }



    }


}
