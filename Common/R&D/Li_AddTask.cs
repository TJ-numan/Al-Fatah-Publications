using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Li_AddTask
    {
           public Li_AddTask()
    {
    }

           public Li_AddTask
        (
        
        int taskID, 
        string taskName, 
        int IsHourly 
         
        )
    {
       
        this.TaskID = taskID;
        this.TaskName = taskName;
        this.IsHourly = IsHourly;
         
    }

 

    private int _taskID;
    public int TaskID
    {
        get { return _taskID; }
        set { _taskID = value; }
    }

    private string _taskName;
    public string TaskName
    {
        get { return _taskName; }
        set { _taskName = value; }
    }

    private int _IsHourly;
    public int IsHourly 
    {
        get { return _IsHourly; }
        set { _IsHourly = value; }
    }
 


    }
