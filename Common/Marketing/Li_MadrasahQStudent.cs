using System;
using System.Data;
using System.Configuration;
using System.Linq;
 

public class Li_MadrasahQStudent
{
    public Li_MadrasahQStudent()
    {
    }

    public Li_MadrasahQStudent
        (
       
        int serialNo, 
        int madrasahID, 
        int classID, 
        int students  
         
        )
    {
 
        this.SerialNo = serialNo;
        this.MadrasahID = madrasahID;
        this.ClassID = classID;
        this.Students = students;
 
    }


 
    private int _serialNo;
    public int SerialNo
    {
        get { return _serialNo; }
        set { _serialNo = value; }
    }

    private int _madrasahID;
    public int MadrasahID
    {
        get { return _madrasahID; }
        set { _madrasahID = value; }
    }

    private int _classID;
    public int ClassID
    {
        get { return _classID; }
        set { _classID = value; }
    }

    private int _students;
    public int Students
    {
        get { return _students; }
        set { _students = value; }
    }

    
}
