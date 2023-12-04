using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_RND_Plan_Detail
{
    public Li_RND_Plan_Detail()
    {
    }

    public Li_RND_Plan_Detail
        (
 
        int planID, 
        int taskID, 
        DateTime   startingDate, 
        DateTime  endingDate, 
        bool isSelect, 
        char status_D  
         
        )
    {
      
        this.PlanID = planID;
        this.TaskID = taskID;
        this.StartingDate = startingDate;
        this.EndingDate = endingDate;
        this.IsSelect = isSelect;
        this.Status_D = status_D;
         
    }


  
    private int _planID;
    public int PlanID
    {
        get { return _planID; }
        set { _planID = value; }
    }

    private int _taskID;
    public int TaskID
    {
        get { return _taskID; }
        set { _taskID = value; }
    }

    private DateTime   _startingDate;
    public DateTime StartingDate
    {
        get { return _startingDate; }
        set { _startingDate = value; }
    }

    private DateTime _endingDate;
    public DateTime EndingDate
    {
        get { return _endingDate; }
        set { _endingDate = value; }
    }

    private bool _isSelect;
    public bool IsSelect
    {
        get { return _isSelect; }
        set { _isSelect = value; }
    }

    private char _status_D;
    public char Status_D
    {
        get { return _status_D; }
        set { _status_D = value; }
    }

    
}
