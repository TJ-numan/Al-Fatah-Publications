using System;
using System.Data;
using System.Configuration;
using System.Linq;




public class li_Thana
{
    public li_Thana()
    {
    }


    public li_Thana
        (
        int thanaID,
        string thanaName,
        int districtID,
        DateTime createdDate,
        int createdBy,
        DateTime modifiedDate,
        int modefiedBy,
        string thana_Bn

        )

    {
        this.ThanaID = thanaID;
        this.ThanaName = thanaName;
        this.DistrictID = districtID;
        this.CreatedDate = createdDate;
        this.CreatedBy = createdBy;
        this.ModifiedDate = modifiedDate;
        this.ModefiedBy = modefiedBy;
        this.Thana_Bn = thana_Bn;


    }

    public li_Thana(int thanaID,  string thanaName)
    {
        this.ThanaID = thanaID;
        this.ThanaName = thanaName;
    }

    private int _thanaID;
    public int ThanaID
    {
        get { return _thanaID; }
        set { _thanaID = value; }
    }

    private string _thanaName;
    public string ThanaName
    {
        get { return _thanaName; }
        set { _thanaName = value; }
    }

    private int _districtID;
    public int DistrictID
    {
        get { return _districtID; }
        set { _districtID = value; }
    }

    private DateTime _createdDate;
    public DateTime CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = value; }
    }

    private int _createdBy;
    public int CreatedBy
    {
        get { return _createdBy; }
        set { _createdBy = value; }
    }

    private DateTime _modifiedDate;
    public DateTime ModifiedDate
    {
        get { return _modifiedDate; }
        set { _modifiedDate = value; }
    }

    private int _modefiedBy;
    public int ModefiedBy
    {
        get { return _modefiedBy; }
        set { _modefiedBy = value; }
    }

    private string _thana_Bn;
    public string Thana_Bn
    {
        get { return _thana_Bn; }
        set { _thana_Bn = value; }
    }

}

