using BLL.Classes;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Data;
using System.Data.OleDb;

namespace BLL
{
    public partial class Acc_Rpt_AgentTransactionStatement : System.Web.UI.Page
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
                    LoadRegion();
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
        //private void LoadLibrary()
        //{
        //    try
        //    {
        //        LoadComboData.LoadLibrary(ddlLibraryName, int.Parse(Session["UserID"].ToString()));
        //        ddlLibraryName.DataBind();
        //        ddlLibraryName.Items.Insert(0, new ListItem("--Select--", ""));
        //    }
        //    catch (Exception)
        //    {

        //    }
        //}
        //protected void ddlTeritory_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ddlLibrary.Items.Clear();

        //        DataTable dtLib = li_LibraryInformationManager.GetLibraryNameByTeritoryID(ddlRegion.SelectedValue).Tables[0];
        //        ddlLibrary.DataSource = dtLib;
        //        ddlLibrary.DataTextField = "LibraryName";
        //        ddlLibrary.DataValueField = "LibraryID";
        //        ddlLibrary.DataBind();
        //        ddlLibrary.Items.Insert(0, new ListItem("All", "0"));



        //    }
        //    catch (Exception)
        //    {
        //    }

        //}
        private void LoadRegion()
        {
            try
            {
                LoadComboData.LoadRegion(ddlRegion);
                ddlRegion.DataBind();
                ddlRegion.Items.Insert(0, new ListItem("--Select--", ""));
            }
            catch (Exception)
            {

            }
        }
        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                ddlLibrary.Items.Clear();

                DataTable dtLib = li_LibraryInformationManager.GetLibraryNameByRegionID(ddlRegion.SelectedValue).Tables[0];
                ddlLibrary.DataSource = dtLib;
                ddlLibrary.DataTextField = "LibraryName";
                ddlLibrary.DataValueField = "LibraryID";
                ddlLibrary.DataBind();
                //ddlLibrary.Items.Insert(0, new ListItem("All", ""));



            }
            catch (Exception)
            {
            }
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {

            try
            {

                string fromdate = dtpFromDate.Text;
                string todate = dtpToDate.Text;
                string libID = ddlLibrary.SelectedValue;
                LoadReport(fromdate, todate, libID);
            }
            catch (Exception)
            {


            }

        }
        ReportDocument rd = new ReportDocument();
        private void LoadReport(string d1, string d2, string LibraryID)
        {
            try
            {


                if (chkIsQawmi.Checked)
                {
                    rd.Load(Server.MapPath(@"~/Reports/ACC/rptAgentTransactionConfirmationQawmi.rpt"));
                }
                else
                {
                    rd.Load(Server.MapPath(@"~/Reports/ACC/rptAgentTransactionConfirmationRz.rpt")); 
                }
                //rd.Load(Server.MapPath(@"~/Reports/ACC/rptAgentTransactionConfirmationRz.rpt"));
                //rd.SetDatabaseLogon(DAO.UserID, DAO.Password, DAO.ServerName, DAO.DatabaseName);
                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@libraryID", LibraryID);
                //rd.SetParameterValue("@RegionID", ddlRegion.SelectedValue);
                rd.SetParameterValue("@FromDate", d1);
                rd.SetParameterValue("@ToDate", d2);
                //rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "AgentStatementReport");

                if (ddlViewers.SelectedValue == "0")
                {

                }

                else if (ddlViewers.SelectedValue == "1")
                {
                    rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "AgentStatementReport");
                }

                else if (ddlViewers.SelectedValue == "2")
                {
                    rd.ExportToHttpResponse(ExportFormatType.ExcelRecord, Response, false, "AgentStatementReport");
                }


                else if (ddlViewers.SelectedValue == "3")
                {
                    rd.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, false, "AgentStatementReport");
                }

                else
                {

                }

                rd.Close();
                rd.Dispose();
            }
            catch (Exception)
            {
                // show error message
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

        protected void btnAutoPrint_Click(object sender, EventArgs e)
        {
            try
            {


                if (chkIsQawmi.Checked)
                {
                    rd.Load(Server.MapPath(@"~/Reports/ACC/rptAgentTransactionConfirmationQawmi.rpt"));
                }
                else
                {
                    rd.Load(Server.MapPath(@"~/Reports/ACC/rptAgentTransactionConfirmationRz.rpt"));
                }
                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                //rd.SetParameterValue("@libraryID", ddlLibrary.SelectedValue);
                //rd.SetParameterValue("@FromDate", dtpFromDate.Text);
                //rd.SetParameterValue("@ToDate", dtpToDate.Text);
                ////rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "AgentStatementReport");

                //For Auto
                OleDbConnection cons;
                DataSet ds;
                OleDbDataAdapter MyCommand;
                
                cons = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\LibraryList.xlsx; Extended Properties=Excel 8.0;");
                MyCommand = new OleDbDataAdapter("select * from [Sheet1$]", cons);
                MyCommand.TableMappings.Add("Table", "Product");
                ds = new System.Data.DataSet();
                MyCommand.Fill(ds);
                cons.Close();

                DataTable dtlib = new DataTable();
                dtlib = ds.Tables[0];

                for (int i = 0; i < dtlib.Rows.Count; i++)
                {
                    rd.SetParameterValue("@FromDate", dtpFromDate.Text);
                    rd.SetParameterValue("@ToDate", dtpToDate.Text);
                    rd.SetParameterValue("@libraryID", dtlib.Rows[i]["LibraryID"].ToString());
                    rd.PrintToPrinter(1, false, 1, 1);
                }
                //  End For Auto

                if (ddlViewers.SelectedValue == "0")
                {

                }

                else if (ddlViewers.SelectedValue == "1")
                {
                    rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "AgentStatementReport");
                }

                else if (ddlViewers.SelectedValue == "2")
                {
                    rd.ExportToHttpResponse(ExportFormatType.ExcelRecord, Response, false, "AgentStatementReport");
                }


                else if (ddlViewers.SelectedValue == "3")
                {
                    rd.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, false, "AgentStatementReport");
                }

                else
                {

                }

                rd.Close();
                rd.Dispose();
            }
            catch (Exception)
            {
                // show error message
            }
        }

    }
}