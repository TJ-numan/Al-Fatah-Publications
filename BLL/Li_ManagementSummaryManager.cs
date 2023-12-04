using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
public class Li_ManagementSummaryManager
{
    public Li_ManagementSummaryManager()
	{
	}
    public static DataSet GetLi_ManagementDatewiseSummaryDetails(String Fromdate, String Todate)
    {
        Li_ManagementSummary li_ManagementSummary = new Li_ManagementSummary();
        SqlLi_ManagementSummaryManager SearchSammaryInformation = new SqlLi_ManagementSummaryManager();
        return SearchSammaryInformation.GetLi_ManagementDatewiseSummaryDetails(Fromdate, Todate);
        
    }
}

