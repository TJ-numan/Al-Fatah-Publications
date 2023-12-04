using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 



   public class TaskWiseBookManager
    {
       public TaskWiseBookManager()
       {

       }


       public static DataSet GetALLLBookInformation(string BookID,int ClassID,string Edition,string SizeID)
       {
           DataSet ds = new DataSet();
           SqlLi_TaskWiseBookInformationProvider SearchBookInformation = new SqlLi_TaskWiseBookInformationProvider();
           ds = SearchBookInformation.GetALLBookInformation(BookID, ClassID, Edition, SizeID);
           return ds;
       }

    }
