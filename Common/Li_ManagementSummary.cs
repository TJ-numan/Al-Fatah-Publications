using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
public class Li_ManagementSummary
{
    public Li_ManagementSummary()
    {
    }


    public Li_ManagementSummary
        (
         
        string companyName,
        decimal cChallan,
        decimal cReturn,
        decimal cDeposit
         
        )
    {
        this.CompanyName = companyName;
        this.CChallan = cChallan;
        this.CReturn = cReturn;
        this.CDeposit = cDeposit;    
    }


    private string _companyName;
    public string CompanyName
    {
        get { return _companyName; }
        set { _companyName = value; }
    }
    private decimal _cChallan;
    public decimal CChallan
    {
        get { return _cChallan; }
        set { _cChallan = value; }
    }
    private decimal _cReturn;
    public decimal CReturn
    {
        get { return _cReturn; }
        set { _cReturn = value; }
    }
    private decimal _cDeposit;
    public decimal CDeposit
    {
        get { return _cDeposit; }
        set { _cDeposit = value; }
    }
 
}

