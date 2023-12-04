using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;

namespace BLL
{
    public partial class Pro_PestingPrint : System.Web.UI.Page
    {
        DataAccessObject DAO = new DataAccessObject();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        ReportDocument rd = new ReportDocument();
        protected void btnLoad_OnClick(object sender, EventArgs e)
        {
            try
            {
                int EntryNo = int.Parse(txtEntryId.Text);
                rd.Load(Server.MapPath(@"~/Reports/MKT/rptPricingVerifyReport.rpt"));
                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@EntryNo", EntryNo);
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "ChalanReport");
                rd.Close();
                rd.Dispose();
            }
            catch (Exception)
            {


            }
        }
        protected void Page_Unload(object sender, EventArgs e)
        {
            try
            {
                rd.Dispose();
            }
            catch (Exception)
            {


            }
        }
    }
}