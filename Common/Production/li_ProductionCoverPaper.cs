using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_ProductionCoverPaper
{
    public Li_ProductionCoverPaper()
    {
    }

    public Li_ProductionCoverPaper
        (
       
        string bookCode, 
        string coverPaper, 
        string coverColor, 
        string coverSize, 
        string coverWeight, 
        string coverBrand 
         
        )
    {
        
        this.BookCode = bookCode;
        this.CoverPaper = coverPaper;
        this.CoverColor = coverColor;
        this.CoverSize = coverSize;
        this.CoverWeight = coverWeight;
        this.CoverBrand = coverBrand;
         
    }


   

    private string _bookCode;
    public string BookCode
    {
        get { return _bookCode; }
        set { _bookCode = value; }
    }

    private string _coverPaper;
    public string CoverPaper
    {
        get { return _coverPaper; }
        set { _coverPaper = value; }
    }

    private string _coverColor;
    public string CoverColor
    {
        get { return _coverColor; }
        set { _coverColor = value; }
    }

    private string _coverSize;
    public string CoverSize
    {
        get { return _coverSize; }
        set { _coverSize = value; }
    }

    private string _coverWeight;
    public string CoverWeight
    {
        get { return _coverWeight; }
        set { _coverWeight = value; }
    }

    private string _coverBrand;
    public string CoverBrand
    {
        get { return _coverBrand; }
        set { _coverBrand = value; }
    }

   
}
