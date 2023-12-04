using BLL.Classes;
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
    public partial class Mkt_Rpt_RRNoReport : System.Web.UI.Page
    {
        DataAccessObject DAO = new DataAccessObject();
        string FormID = "MR037";
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
                        Response.Redirect("~/MarketingHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }
        protected void ddlReportFor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlReportFor.SelectedValue == "1")
                {
                    LoadLibrary();
                }
                else if (ddlReportFor.SelectedValue == "2")
                {
                    LoadTSO();
                }
            }
            catch (Exception)
            {

            }
        }
        private void LoadLibrary()
        {
            try
            {
                LoadComboData.LoadLibrary(ddlLibraryName, int.Parse(Session["UserID"].ToString()));
                ddlLibraryName.DataBind();
                ddlLibraryName.Items.Insert(0, new ListItem("--Select--", ""));
            }
            catch (Exception)
            {

            }
        }
        private void LoadTSO()
        {
            try
            {
                LoadComboData.LoadTSOIndo(ddlLibraryName);
                ddlLibraryName.DataBind();
                ddlLibraryName.Items.Insert(0, new ListItem("--Select--", ""));
            }
            catch (Exception)
            {

            }
        }
        ReportDocument rd = new ReportDocument();
        protected void btnShow_Click(object sender, EventArgs e)
        {
            if (ddlReportFor.SelectedValue == "1")
            {               
                rd.Load(Server.MapPath(@"~/Reports/MKT/rptPacketBookingReport.rpt"));
            }
            else if (ddlReportFor.SelectedValue == "2")
            {
                rd.Load(Server.MapPath(@"~/Reports/MKT/rptPacketBookingReportSpecimen.rpt"));
            }
            
            //rd.Load(Server.MapPath(@"~/Reports/MKT/rptPacketBookingReport.rpt"));
            rd.DataSourceConnections.Clear();
            rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
            rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
            rd.SetParameterValue("@fromdate", dtpFromDate.Text);
            rd.SetParameterValue("@todate", dtpToDate.Text);
            rd.SetParameterValue("@LibraryID", ddlLibraryName.SelectedValue.ToString());
            rd.SetParameterValue("@MemoNo", txtMemoNo.Text);
            rd.SetParameterValue("@ISQawmi", chkIsQawmi.Checked ? 1 : 0);
            rd.SetParameterValue("@UserID", int.Parse(Session["UserID"].ToString()));
            rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Packing Booking Report");
            rd.Close();
            rd.Dispose();
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