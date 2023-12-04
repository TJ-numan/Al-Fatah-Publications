﻿using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Data;

namespace BLL
{
    public partial class Mkt_Rpt_DatewiseBookChallan : System.Web.UI.Page
    {
        DataAccessObject DAO = new DataAccessObject();
        string FormID = "MR007";
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
        ReportDocument rd = new ReportDocument();
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkBoishaki.Checked && chkQawmi.Checked)
                {
                    lblMsg.Text = "You Should Select only one Boishaki or Qawmi!";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    
                    //TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
                    //TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                    //ConnectionInfo crConnectionInfo = new ConnectionInfo();
                    //Tables CrTables;

                    rd.Load(Server.MapPath(@"~/Reports/MKT/rptChalanQtyByDateRange.rpt"));

                    //crConnectionInfo.ServerName = DAO.ServerName;
                    //crConnectionInfo.DatabaseName = DAO.DatabaseName;
                    //crConnectionInfo.UserID = DAO.UserID;
                    //crConnectionInfo.Password = DAO.Password;

                    //CrTables = rd.Database.Tables;




                    //foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
                    //{
                    //    crtableLogoninfo = CrTable.LogOnInfo;
                    //    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    //    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                    //}

                    //  rd.SetDatabaseLogon(DAO.UserID, DAO.Password, DAO.ServerName, DAO.DatabaseName);

                    rd.DataSourceConnections.Clear();
                    rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                    rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);

                    rd.SetParameterValue("@fromdate", dtpFromDate.Text);
                    rd.SetParameterValue("@todate", dtpToDate.Text);
                    rd.SetParameterValue("@Boishaki", chkBoishaki.Checked ? 1 : 0);
                    rd.SetParameterValue("@Alim", chkQawmi.Checked ? 1 : 0);
                    rd.SetParameterValue("@UserID", int.Parse(Session["UserID"].ToString()));
                    //rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "DatewiseBookChalanReport");
                    if (ddlViewers.SelectedValue == "0")
                    {

                    }

                    else if (ddlViewers.SelectedValue == "1")
                    {
                        rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "DatewiseBookChalanReport");
                    }

                    else if (ddlViewers.SelectedValue == "2")
                    {
                        rd.ExportToHttpResponse(ExportFormatType.ExcelRecord, Response, false, "DatewiseBookChalanReport");
                    }


                    else if (ddlViewers.SelectedValue == "3")
                    {
                        rd.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, false, "DatewiseBookChalanReport");
                    }

                    else
                    {

                    }

                    rd.Close();
                    rd.Dispose();
                    
                }
               
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