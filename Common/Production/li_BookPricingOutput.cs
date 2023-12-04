using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_BookPricingOutput
{
    public Li_BookPricingOutput()
    {
    }

    public Li_BookPricingOutput
        (
         
        string bookAcCode, 
        string tot_Dir_Cost, 
        string tot_Cost_Sale, 
        string final_Rev, 
        string net_Price, 
        string writ_Price, 
        string tCS_Forma, 
        string finalRe_Forma ,
        string mrp_forma
         
        )
    {
      
        this.BookAcCode = bookAcCode;
        this.Tot_Dir_Cost = tot_Dir_Cost;
        this.Tot_Cost_Sale = tot_Cost_Sale;
        this.Final_Rev = final_Rev;
        this.Net_Price = net_Price;
        this.Writ_Price = writ_Price;
        this.TCS_Forma = tCS_Forma;
        this.FinalRe_Forma = finalRe_Forma;
        this.MRP_Forma = mrp_forma;
         
    }


   

    private string _bookAcCode;
    public string BookAcCode
    {
        get { return _bookAcCode; }
        set { _bookAcCode = value; }
    }

    private string _tot_Dir_Cost;
    public string Tot_Dir_Cost
    {
        get { return _tot_Dir_Cost; }
        set { _tot_Dir_Cost = value; }
    }

    private string _tot_Cost_Sale;
    public string Tot_Cost_Sale
    {
        get { return _tot_Cost_Sale; }
        set { _tot_Cost_Sale = value; }
    }

    private string _final_Rev;
    public string Final_Rev
    {
        get { return _final_Rev; }
        set { _final_Rev = value; }
    }

    private string _net_Price;
    public string Net_Price
    {
        get { return _net_Price; }
        set { _net_Price = value; }
    }

    private string _writ_Price;
    public string Writ_Price
    {
        get { return _writ_Price; }
        set { _writ_Price = value; }
    }

    private string _tCS_Forma;
    public string TCS_Forma
    {
        get { return _tCS_Forma; }
        set { _tCS_Forma = value; }
    }

    private string _finalRe_Forma;
    public string FinalRe_Forma
    {
        get { return _finalRe_Forma; }
        set { _finalRe_Forma = value; }
    }
 private string _mrp_Forma;
    public string MRP_Forma
    {
        get { return _mrp_Forma; }
        set { _mrp_Forma = value; }
    }
   
}
