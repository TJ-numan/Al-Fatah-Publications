using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 



  public class TaskDetailManager
    {

      public TaskDetailManager()
      {

      }


      public static string InsertTaskDetail(string workPlanID, string employeeID, DateTime updatedDate, string selectedTaskStatus)
      {
          TaskDetailProvider taskprovider = new TaskDetailProvider();

          return taskprovider.InsertTaskDetail(workPlanID,employeeID,updatedDate,selectedTaskStatus); ;
      }

      public static string SearchEmployeeInTaskforStartingDate(string employeeID)
      {
          TaskDetailProvider taskprovider = new TaskDetailProvider();

          return taskprovider.SearchEmployeeInTaskforStartingDate(employeeID); ;
      }

     





    }

