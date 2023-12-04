using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_Teritory
{

        public Li_Teritory()
        {

        }



      public Li_Teritory
        (
      
        int teritoryID, 
        string teritoryCode, 
        string teritoryName, 
        int zonID,
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        string territory_Bn ,
          string zonName
          
         
        )


    {

        this.TeritoryID = teritoryID;
        this.TeritoryCode = teritoryCode;
        this.TeritoryName = teritoryName;
        this.ZonID = zonID;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.Territory_Bn = territory_Bn;
        this.ZonName = zonName;
        
    }
    public string ZonName{ get; set; }
    public string Territory_Bn { get; set; }
    public int ZonID { get; set; }
  

    private int _teritoryID;
    public int TeritoryID
    {
        get { return _teritoryID; }
        set { _teritoryID = value; }
    }
    private string _teritoryCode;
    public string TeritoryCode
    {
        get { return _teritoryCode; }
        set { _teritoryCode = value; }
    }

    private string _teritoryName;
    public string TeritoryName
    {
        get { return _teritoryName; }
        set { _teritoryName = value; }
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

    
}
