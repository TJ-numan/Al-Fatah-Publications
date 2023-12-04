using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_Task
{
    public Li_Task()
    {
    }

    public Li_Task
        (
        
        int taskID, 
        string taskName, 
        string b_Name  
         
        )
    {
       
        this.TaskID = taskID;
        this.TaskName = taskName;
        this.B_Name = b_Name;
         
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

    private string _b_Name;
    public string B_Name
    {
        get { return _b_Name; }
        set { _b_Name = value; }
    }
 
}
