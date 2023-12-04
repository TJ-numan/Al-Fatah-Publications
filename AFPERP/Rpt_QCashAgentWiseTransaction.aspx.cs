using BLL.Classes;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Rpt_QCashAgentWiseTransaction : System.Web.UI.Page
    {
        DataAccessObject DAO = new DataAccessObject();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                {
                    LoadLibrary();

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
                catch (Exception)
                {


                }
            }
        }

        private void LoadLibrary()
        {

            try
            {
                //LoadComboData.LoadLibrary(ddlLibraryName);
                DataTable dtLib = Li_LibraryInformationManager.GetAll_ComboBox_QCashLibraryInformationsByUser(int.Parse(Session["UserID"].ToString())).Tables[0];
                ddlLibraryName.DataSource = dtLib;
                ddlLibraryName.DataValueField = "LibraryID";
                ddlLibraryName.DataTextField = "LibraryName";
                ddlLibraryName.DataBind();
            }
            catch (Exception)
            {

            }
            ddlLibraryName.Items.Insert(0, new ListItem("--Select Library--", ""));
        }
        ReportDocument rd = new ReportDocument();
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                rd.Load(Server.MapPath(@"~/Reports/MKT/QAWMI/rptQCashLibraryTransectionDatewiseDetails.rpt"));
                rd.DataSourceConnections.Clear();
                //rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, "ALF_QC", false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@libraryID", ddlLibraryName.SelectedValue);
                rd.SetParameterValue("@FromDate", dtpFromDate.Text);
                rd.SetParameterValue("@ToDate", dtpToDate.Text);

                ////  Start For Auto
                //OleDbConnection cons;
                //DataSet ds;
                //OleDbDataAdapter MyCommand;

                ////cons = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=I:\Marketing\Marketing Annual Closing\Annual Closing 2022\Aliya\LibraryList_AliyaCash.xlsx; Extended Properties=Excel 8.0;");
                //cons = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=I:\Marketing\Marketing Annual Closing\Annual Closing 2022\Qawmi\LibraryList_QawmiCash.xlsx; Extended Properties=Excel 8.0;");
                //MyCommand = new OleDbDataAdapter("select * from [Sheet1$]", cons);
                //MyCommand.TableMappings.Add("Table", "Product");
                //ds = new System.Data.DataSet();
                //MyCommand.Fill(ds);
                //cons.Close();

                //DataTable dtlib = new DataTable();
                //dtlib = ds.Tables[0];

                //for (int i = 0; i < dtlib.Rows.Count; i++)
                //{
                //    rd.SetParameterValue("@libraryID", dtlib.Rows[i]["LibraryID"].ToString());
                //    rd.SetParameterValue("@FromDate", "2021-11-01");
                //    rd.SetParameterValue("@ToDate", "2022-10-31");
                //    rd.PrintToPrinter(1, false, 1, 15);
                //}
                ////  End For Auto

                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "AgentTransectionReport");

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