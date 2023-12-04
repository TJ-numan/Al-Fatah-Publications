using Common.Marketing;
using DAL.Marketing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Marketing
{
   public class li_AgentStockEntryManager
    {
       public static int InsertLi_AgentStockEntry(li_AgentStock li_agentstock)
       {
           Sqlli_AgentStockEntryProvider sqlli_AgentStockEntryProvider = new Sqlli_AgentStockEntryProvider();
           return sqlli_AgentStockEntryProvider.InsertLi_AgentStockEntry(li_agentstock);
       }

       public static DataSet  GetLi_AllStockProject()
       {
           Sqlli_AgentStockEntryProvider sqlLi_getStockProject = new Sqlli_AgentStockEntryProvider();
           return sqlLi_getStockProject.GetLi_AllStockProject();
       } 
       public static DataSet  GetLi_AllStockProject_ByPorjectID(int ProjID)
       {
           Sqlli_AgentStockEntryProvider sqlLi_getStockProject = new Sqlli_AgentStockEntryProvider();
           return sqlLi_getStockProject.GetLi_AllStockProject_ByProjectID(ProjID);
       }
       public static DataSet GetLi_AgentStockProjectForView(int ProjID)
       {
           Sqlli_AgentStockEntryProvider sqlLi_getStockProject = new Sqlli_AgentStockEntryProvider();
           return sqlLi_getStockProject.GetLi_AgentStockProjectForView(ProjID);
       }
       public static DataSet GetAllProjectNameBy_ProjIDForEdit(int ProjID, string LibraryId)
       {
           Sqlli_AgentStockEntryProvider sqlLi_getStockProject = new Sqlli_AgentStockEntryProvider();
           return sqlLi_getStockProject.GetAllProjectNameBy_ProjIDForEdit(ProjID,LibraryId);
       } 
    }
}
