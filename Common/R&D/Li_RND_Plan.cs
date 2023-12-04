using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_RND_Plan
{
    public Li_RND_Plan()
    {
    }

    public Li_RND_Plan
        (
         
        int planID, 
        string bookCode, 
        string edition, 
        int createdBy, 
        DateTime createdDate, 
        int  modifiedBy, 
        DateTime modifiedDate, 
        int firstAppBy, 
        DateTime firstAppDate, 
        int secoundAppBy, 
        DateTime secoundAppDate, 
        int thirdAppBy, 
        DateTime thirdAppDate, 
        int fourthAppBy, 
        DateTime fourthAppDate, 
        string note, 
        char status_D  
         
        )
    {
         
        this.PlanID = planID;
        this.BookCode = bookCode;
        this.Edition = edition;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.FirstAppBy = firstAppBy;
        this.FirstAppDate = firstAppDate;
        this.SecoundAppBy = secoundAppBy;
        this.SecoundAppDate = secoundAppDate;
        this.ThirdAppBy = thirdAppBy;
        this.ThirdAppDate = thirdAppDate;
        this.FourthAppBy = fourthAppBy;
        this.FourthAppDate = fourthAppDate;
        this.Note = note;
        this.Status_D = status_D;
        
    }


    

    private int _planID;
    public int PlanID
    {
        get { return _planID; }
        set { _planID = value; }
    }

    private string _bookCode;
    public string BookCode
    {
        get { return _bookCode; }
        set { _bookCode = value; }
    }

    private string _edition;
    public string Edition
    {
        get { return _edition; }
        set { _edition = value; }
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

    private int _firstAppBy;
    public int FirstAppBy
    {
        get { return _firstAppBy; }
        set { _firstAppBy = value; }
    }

    private DateTime _firstAppDate;
    public DateTime FirstAppDate
    {
        get { return _firstAppDate; }
        set { _firstAppDate = value; }
    }

    private int _secoundAppBy;
    public int SecoundAppBy
    {
        get { return _secoundAppBy; }
        set { _secoundAppBy = value; }
    }

    private DateTime _secoundAppDate;
    public DateTime SecoundAppDate
    {
        get { return _secoundAppDate; }
        set { _secoundAppDate = value; }
    }

    private int _thirdAppBy;
    public int ThirdAppBy
    {
        get { return _thirdAppBy; }
        set { _thirdAppBy = value; }
    }

    private DateTime _thirdAppDate;
    public DateTime ThirdAppDate
    {
        get { return _thirdAppDate; }
        set { _thirdAppDate = value; }
    }

    private int _fourthAppBy;
    public int FourthAppBy
    {
        get { return _fourthAppBy; }
        set { _fourthAppBy = value; }
    }

    private DateTime _fourthAppDate;
    public DateTime FourthAppDate
    {
        get { return _fourthAppDate; }
        set { _fourthAppDate = value; }
    }

    private string _note;
    public string Note
    {
        get { return _note; }
        set { _note = value; }
    }

    private char _status_D;
    public char Status_D
    {
        get { return _status_D; }
        set { _status_D = value; }
    }
 
}
