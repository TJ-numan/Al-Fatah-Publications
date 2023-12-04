using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PlateSupply_Type
{
    public Li_PlateSupply_Type()
    {
    }

    public Li_PlateSupply_Type
        (

        int iD,
        string sup_Type,
        int createdBy,
        DateTime createdDate


        )
    {
        this.ID = iD;
        this.Sup_Type = sup_Type;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;

    }




    private int _iD;
    public int ID
    {
        get { return _iD; }
        set { _iD = value; }
    }

    private string _sup_Type;
    public string Sup_Type
    {
        get { return _sup_Type; }
        set { _sup_Type = value; }
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

    private char _status_D;
    public char Status_D
    {
        get { return _status_D; }
        set { _status_D = value; }
    }
}
