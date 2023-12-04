using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;


    public class li_NewTaskManager
    {

        public  li_NewTaskManager()
        {

        }

            public static DataSet GetLibraryInformationByLibraryIDForEdit(string libID)
    {
        DataSet ds = new DataSet();
        SqlLi_LibraryInformationProvider SearchLibraryInformation = new SqlLi_LibraryInformationProvider();
        ds = SearchLibraryInformation.GetLibraryInformationByLibraryIDForEdit(libID);
        return ds;
    }

        public static DataSet GetTaskInformationByTaskIDForEdit(int TaskID){
            DataSet ds = new DataSet();
            li_TaskProvider SearchTaskInformation = new li_TaskProvider();
            ds = SearchTaskInformation.GetTaskInformationByTaskID(TaskID);
            
            return ds;

    }

        public static string InsertTask(Li_AddTask Li_AddTask)
        {
            li_TaskProvider li_TaskProvider = new li_TaskProvider();

            return li_TaskProvider.Insert_TaskInformation(Li_AddTask); ;
        }

        public static DataSet GetALLTaskInformation()
        {
            DataSet ds = new DataSet();
            li_TaskProvider li_TaskProvider = new li_TaskProvider();
            ds = li_TaskProvider.GetALLTaskInformation();
            return ds;
        }
        public static bool DeleteTaskFromDatabase(int TaskID)
        {
            li_TaskProvider li_TaskProvider = new li_TaskProvider();
            return li_TaskProvider.DeleteTaskFromDatabase(TaskID);
        }

        public static bool Update_TaskInformation(Li_AddTask addtask)
        {
            li_TaskProvider taskprovider = new li_TaskProvider();
            return taskprovider.Update_TaskInformation(addtask);
        }



    }
