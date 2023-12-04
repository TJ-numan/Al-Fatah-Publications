using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PaperWeightBasic
{
    public Li_PaperWeightBasic()
    {
    }

    public Li_PaperWeightBasic
        (
       
        string iD, 
        string weight, 
        string paperType,
        string paperSize,
        string createdBy, 
        DateTime createdDate  

         
        )
    {
        
        this.ID = iD;
        this.Weight = weight;
        this .PaperType =paperType ;
        this.PaperSize = paperSize;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        
    }


    public string @PaperSize { get; set; }

    public string PaperType { get; set; }

    private string _iD;
    public string ID
    {
        get { return _iD; }
        set { _iD = value; }
    }

    private string _weight;
    public string Weight
    {
        get { return _weight; }
        set { _weight = value; }
    }

    private string _createdBy;
    public string CreatedBy
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
