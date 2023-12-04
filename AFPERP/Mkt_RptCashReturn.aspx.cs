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
    public partial class Mkt_RptCashReturn : System.Web.UI.Page
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
                        txtReturnMemo.Text = Request.QueryString["Memono"].ToString();
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

                rd.Load(Server.MapPath(@"~/Reports/MKT/rptPrintCashReturn.rpt"));
                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, "ALF_C", false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@MemoNo", txtReturnMemo.Text);
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "CashRetunByMemo");
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
