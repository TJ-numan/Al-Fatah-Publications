using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

 
  public   class WorkPlanManager
    {
      public WorkPlanManager()
      {
      }


      public static DataSet Get_Employe(int Section,string Sess)
      {
          DataSet ds = new DataSet();
          WorkPlanProvider workplanProvider = new WorkPlanProvider();
          ds = workplanProvider.GetSessionWiseBook(Section, Sess);
          return ds;
      }
    }
 
