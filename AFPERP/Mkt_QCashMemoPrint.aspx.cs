using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace BLL
{
    public partial class Mkt_QCashMemoPrint : System.Web.UI.Page
    {
        DataAccessObject DAO = new DataAccessObject();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Request.QueryString["Memono"] != null || Request.QueryString["Memono"] != "")
                    {
                        txtChallanMemo.Text = Request.QueryString["Memono"].ToString();
                    }
                }
                catch (Exception)
                {


                }
            }
        }
        ReportDocument rd = new ReportDocument();
        protected void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {

                rd.Load(Server.MapPath(@"~/Reports/MKT/CASH/rptPrintQCashChalanbyMemo.rpt"));
                rd.DataSourceConnections.Clear();
                //rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, "ALF_QC", false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@MemoNo", txtChallanMemo.Text);
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "ChalanByMemo");
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