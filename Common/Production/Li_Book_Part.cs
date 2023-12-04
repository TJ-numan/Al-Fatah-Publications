using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_Book_Part
{
    public Li_Book_Part()
    {
    }

    public Li_Book_Part
        (
       
        int iD, 
        string pa_Nm, 
        int createdBy, 
        DateTime createdDate 
         
        )
    {
         
        this.ID = iD;
        this.Pa_Nm = pa_Nm;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
         
    }


    

    private int _iD;
    public int ID
    {
        get { return _iD; }
        set { _iD = value; }
    }

    private string _pa_Nm;
    public string Pa_Nm
    {
        get { return _pa_Nm; }
        set { _pa_Nm = value; }
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
