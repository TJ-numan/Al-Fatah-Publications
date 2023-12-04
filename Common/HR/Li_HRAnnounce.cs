using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_HRAnnounce
{
    public Li_HRAnnounce()
    {
    }

    public Li_HRAnnounce
        (
       
        int annId, 
        string annTitle, 
        string annDetail, 
        DateTime publishDate, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.AnnId = annId;
        this.AnnTitle = annTitle;
        this.AnnDetail = annDetail;
        this.PublishDate = publishDate;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 
    private int _annId;
    public int AnnId
    {
        get { return _annId; }
        set { _annId = value; }
    }

    private string _annTitle;
    public string AnnTitle
    {
        get { return _annTitle; }
        set { _annTitle = value; }
    }

    private string _annDetail;
    public string AnnDetail
    {
        get { return _annDetail; }
        set { _annDetail = value; }
    }

    private DateTime _publishDate;
    public DateTime PublishDate
    {
        get { return _publishDate; }
        set { _publishDate = value; }
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
