using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmAssetDetailsByAssetCode : System.Web.UI.Page
    {
        DataAccessObject DAO = new DataAccessObject();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        ReportDocument rd = new ReportDocument();
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                rd.Load(Server.MapPath("~/Reports/HRD/rptAssetDetailsByAssetCode.rpt"));
                rd.DataSourceConnections.Clear();
                rd.SetDatabaseLogon(DAO.ServerName, DAO.DatabaseName);
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@AssetCode", txtAssetCode.Text);
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Asset Details");
                rd.Close();
                rd.Dispose();
            }
            catch (Exception)
            {


            }
        }
    }
}