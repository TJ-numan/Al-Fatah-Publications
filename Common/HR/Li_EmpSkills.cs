using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpSkills
{
    public Li_EmpSkills()
    {
    }

    public Li_EmpSkills
        (
       
        int skilId, 
        int empSl, 
        string skills, 
        string skilDes, 
        string extraActivities, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
      
        this.SkilId = skilId;
        this.EmpSl = empSl;
        this.Skills = skills;
        this.SkilDes = skilDes;
        this.ExtraActivities = extraActivities;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }

 

    private int _skilId;
    public int SkilId
    {
        get { return _skilId; }
        set { _skilId = value; }
    }

    private int _empSl;
    public int EmpSl
    {
        get { return _empSl; }
        set { _empSl = value; }
    }

    private string _skills;
    public string Skills
    {
        get { return _skills; }
        set { _skills = value; }
    }

    private string _skilDes;
    public string SkilDes
    {
        get { return _skilDes; }
        set { _skilDes = value; }
    }

    private string _extraActivities;
    public string ExtraActivities
    {
        get { return _extraActivities; }
        set { _extraActivities = value; }
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

    private int _modifiedBy;
    public int ModifiedBy
    {
        get { return _modifiedBy; }
        set { _modifiedBy = value; }
    }

    private DateTime _modifiedDate;
    public DateTime ModifiedDate
    {
        get { return _modifiedDate; }
        set { _modifiedDate = value; }
    }

    private int _infStId;
    public int InfStId
    {
        get { return _infStId; }
        set { _infStId = value; }
    }
}
