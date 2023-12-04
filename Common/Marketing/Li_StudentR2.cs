using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_StudentR2
{
    public Li_StudentR2()
    {
    }

    public Li_StudentR2
        (
     
        int slNo, 
        int classID, 
        int noOfStudents, 
        string madId, 
        int createdBy, 
        DateTime createdDate
        )
    {
      
        this.SlNo = slNo;
        this.ClassID = classID;
        this.NoOfStudents = noOfStudents;
        this.MadId = madId;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
    }

 

    private int _slNo;
    public int SlNo
    {
        get { return _slNo; }
        set { _slNo = value; }
    }

    private int _classID;
    public int ClassID
    {
        get { return _classID; }
        set { _classID = value; }
    }

    private int _noOfStudents;
    public int NoOfStudents
    {
        get { return _noOfStudents; }
        set { _noOfStudents = value; }
    }

    private string _madId;
    public string MadId
    {
        get { return _madId; }
        set { _madId = value; }
    }

    private int _createdBy;
    public int CreatedBy
    {
        get { return _createdBy; }
        set { _createdBy = value; }
    }

    private DateTime _createdDate;
    public DateTime CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = value; }
    }
}
