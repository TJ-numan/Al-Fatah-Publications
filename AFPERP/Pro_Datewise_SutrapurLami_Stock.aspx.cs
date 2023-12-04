using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Pro_Datewise_SutrapurLami_Stock : System.Web.UI.Page
    {
        DataAccessObject DAO = new DataAccessObject();
        string FormID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    getUserAccess();
                    int year = DateTime.Now.Year;
                    int month = DateTime.Now.Month;
                    int day = DateTime.Now.Day;

                    if (month >= 11)
                    {
                        var mydate = new DateTime(year, 11, 01);

                        dtpFromDate.Text = String.Format("{0:yyyy-MM-dd}", mydate);
                    }

                    else
                    {
                        var mydate = new DateTime(year - 1, 11, 01);
                        dtpFromDate.Text = String.Format("{0:yyyy-MM-dd}", mydate);
                    }
                    dtpToDate.Text = String.Format("{0:yyyy-MM-dd}", DateTime.Now);
                }
            }
            catch (Exception)
            {

            }
        }
        private void getUserAccess()
        {
            DataTable dt = Li_AdminUserManager.GetUserAccess(int.Parse(Session["UserID"].ToString()), FormID).Tables[0];
            if (dt.Rows.Count > 0)
            {

                if (Session["UserID"].ToString() == dt.Rows[0]["UserID"].ToString() && FormID == dt.Rows[0]["FormId"].ToString())
                {
                    if (Boolean.Parse(dt.Rows[0]["Insert_"].ToString()) == true)
                    {
                        btnShow.Enabled = true;
                    }
                    else
                    {
                        btnShow.Enabled = false;
                    }
                    if (Boolean.Parse(dt.Rows[0]["Update_"].ToString()) == true)
                    {
                        //btnUpdate.Enabled = true;
                    }
                    else
                    {
                        //btnUpdate.Enabled = false;
                    }
                    if (Boolean.Parse(dt.Rows[0]["Delete_"].ToString()) == true)
                    {
                        //btnDelete.Enabled = true;
                    }
                    else
                    {
                        //btnDelete.Enabled = false;
                    }
                    if (Boolean.Parse(dt.Rows[0]["View_"].ToString()) == false)
                    {
                        Response.Redirect("~/DistributionHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }
        ReportDocument rd = new ReportDocument();
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {


                rd.Load(Server.MapPath(@"~/Reports/Store/rptDatewiseSutrapurLamiStockReport.rpt"));


                    rd.DataSourceConnections.Clear();
                    rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                    rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);

                    rd.SetParameterValue("@fromdate", dtpFromDate.Text);
                    rd.SetParameterValue("@todate", dtpToDate.Text);
                    //rd.SetParameterValue("@UserID", int.Parse(Session["UserID"].ToString()));
                    //rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "DatewiseSutrapurLamiStockReport");
                    if (ddlViewers.SelectedValue == "0")
                    {

                    }

                    else if (ddlViewers.SelectedValue == "1")
                    {
                        rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "DatewiseSutrapurLamiStockReport");
                    }

                    else if (ddlViewers.SelectedValue == "2")
                    {
                        rd.ExportToHttpResponse(ExportFormatType.ExcelRecord, Response, false, "DatewiseSutrapurLamiStockReport");
                    }


                    else if (ddlViewers.SelectedValue == "3")
                    {
                        rd.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, false, "DatewiseSutrapurLamiStockReport");
                    }

                    else
                    {

                    }

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