using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_CouResPerson
{
    public Li_CouResPerson()
    {
    }

    public Li_CouResPerson
        (
       
        int resoPId, 
        string resPName, 
        string profTitle, 
        string insAdd, 
        int resAdd, 
        string phone, 
        string contactPerson, 
        string contactPhone, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
  
        this.ResoPId = resoPId;
        this.ResPName = resPName;
        this.ProfTitle = profTitle;
        this.InsAdd = insAdd;
        this.ResAdd = resAdd;
        this.Phone = phone;
        this.ContactPerson = contactPerson;
        this.ContactPhone = contactPhone;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _resoPId;
    public int ResoPId
    {
        get { return _resoPId; }
        set { _resoPId = value; }
    }

    private string _resPName;
    public string ResPName
    {
        get { return _resPName; }
        set { _resPName = value; }
    }

    private string _profTitle;
    public string ProfTitle
    {
        get { return _profTitle; }
        set { _profTitle = value; }
    }

    private string _insAdd;
    public string InsAdd
    {
        get { return _insAdd; }
        set { _insAdd = value; }
    }

    private int _resAdd;
    public int ResAdd
    {
        get { return _resAdd; }
        set { _resAdd = value; }
    }

    private string _phone;
    public string Phone
    {
        get { return _phone; }
        set { _phone = value; }
    }

    private string _contactPerson;
    public string ContactPerson
    {
        get { return _contactPerson; }
        set { _contactPerson = value; }
    }

    private string _contactPhone;
    public string ContactPhone
    {
        get { return _contactPhone; }
        set { _contactPhone = value; }
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
