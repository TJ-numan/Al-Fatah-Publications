using System;
using BLL.Classes;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DAL;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace BLL
{
    public partial class Mkt_Rpt_BonusStatement : System.Web.UI.Page
    {
        string FormID = "MR009";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    getUserAccess();
                    LoadAgent();
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
        private void LoadAgent()
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
        DataAccessObject DAO = new DataAccessObject();

        ReportDocument rd = new ReportDocument();
        protected void btnShow_Click(object sender, EventArgs e)
        {

            try
            {

               

                if (ddlYear.SelectedIndex == 0)
                {
                    lblYearMsg.Text = "Select Year!";

                }


                else
                {
                    if (chkIsQawmi.Checked)
                    {
                        if (ddlYear.SelectedIndex == 1)
                        {
                            rd.Load(Server.MapPath(@"~/Reports/MKT/rptLibraryWiseBonus_2022-2023_Q.rpt"));
                        }
                        else if (ddlYear.SelectedIndex == 2)
                        {
                            rd.Load(Server.MapPath(@"~/Reports/MKT/rptLibraryWiseBonus_2021-2022_Q.rpt"));
                        }
                        else if (ddlYear.SelectedIndex == 3)
                        {
                            rd.Load(Server.MapPath(@"~/Reports/MKT/rptLibraryWiseBonus_2020-2021_Q.rpt"));
                        }
                        else if (ddlYear.SelectedIndex == 4)
                        {
                            rd.Load(Server.MapPath(@"~/Reports/MKT/rptLibraryWiseBonus_2019-2020_Q.rpt"));
                        }
                        else if (ddlYear.SelectedIndex == 5)
                        {
                            rd.Load(Server.MapPath(@"~/Reports/MKT/rptLibraryWiseBonus_2018-2019_Q.rpt"));
                        }
                        else if (ddlYear.SelectedIndex == 6)
                        {
                            rd.Load(Server.MapPath(@"~/Reports/MKT/rptLibraryWiseBonus_2017-2018_Q.rpt"));
                        }  
                        else if (ddlYear.SelectedIndex == 7)
                        {
                            rd.Load(Server.MapPath(@"~/Reports/MKT/rptLibraryWiseBonus_2016-2017_Q.rpt"));
                        }
                        else if (ddlYear.SelectedIndex == 8)
                        {
                            rd.Load(Server.MapPath(@"~/Reports/MKT/rptLibraryWiseBonus_2015-2016_Q.rpt"));
                        }
                       
                        else
                        {

                        }
                    }
                    else
                    {
                        if (ddlYear.SelectedIndex == 1)
                        {
                            rd.Load(Server.MapPath(@"~/Reports/MKT/rptLibraryWiseBonus_2022-2023.rpt"));
                        }
                        else if (ddlYear.SelectedIndex == 2)
                        {
                            rd.Load(Server.MapPath(@"~/Reports/MKT/rptLibraryWiseBonus_2021-2022.rpt"));
                        }
                        else if (ddlYear.SelectedIndex == 3)
                        {
                            rd.Load(Server.MapPath(@"~/Reports/MKT/rptLibraryWiseBonus_2020-2021.rpt"));
                        }
                        else if (ddlYear.SelectedIndex == 4)
                        {
                            rd.Load(Server.MapPath(@"~/Reports/MKT/rptLibraryWiseBonus_2019-2020.rpt"));
                        }
                        else if (ddlYear.SelectedIndex == 5)
                        {
                            rd.Load(Server.MapPath(@"~/Reports/MKT/rptLibraryWiseBonus_2018-2019.rpt"));
                        }
                        else if (ddlYear.SelectedIndex == 6)
                        {
                            rd.Load(Server.MapPath(@"~/Reports/MKT/rptLibraryWiseBonus_2017-2018.rpt"));
                        }

                        else if (ddlYear.SelectedIndex == 7)
                        {
                            rd.Load(Server.MapPath(@"~/Reports/MKT/rptLibraryWiseBonus_2016-2017.rpt"));
                        }
                        else if (ddlYear.SelectedIndex == 8)
                        {
                            rd.Load(Server.MapPath(@"~/Reports/MKT/rptLibraryWiseBonus_2015-2016.rpt"));
                        }
                        else
                        {

                        }
                    }




                    //rd.SetDatabaseLogon(DAO.UserID, DAO.Password, DAO.ServerName, DAO.DatabaseName);
                    rd.DataSourceConnections.Clear();
                    rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                    rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                    rd.SetParameterValue("@fromdate", dtpFromDate.Text);
                    rd.SetParameterValue("@todate", dtpToDate.Text);
                    rd.SetParameterValue("@libraryID", ddlLibraryName.SelectedValue);

                    ////For Auto
                    //OleDbConnection cons;
                    //DataSet ds;
                    //OleDbDataAdapter MyCommand;

                    //cons = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=I:\Marketing\Marketing Annual Closing\Annual Closing 2022\Aliya\LibraryList_AliyaCredit.xlsx; Extended Properties=Excel 8.0;");
                    ////cons = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=I:\Marketing\Marketing Annual Closing\Annual Closing 2022\Qawmi\LibraryList_QawmiCredit.xlsx; Extended Properties=Excel 8.0;");
                    //MyCommand = new OleDbDataAdapter("select * from [Sheet1$]", cons);
                    //MyCommand.TableMappings.Add("Table", "Product");
                    //ds = new System.Data.DataSet();
                    //MyCommand.Fill(ds);
                    //cons.Close();

                    //DataTable dtlib = new DataTable();
                    //dtlib = ds.Tables[0];

                    //for (int i = 0; i < dtlib.Rows.Count; i++)
                    //{
                    //    rd.SetParameterValue("@fromdate", "2021-11-01");
                    //    rd.SetParameterValue("@todate", "2022-10-31");
                    //    rd.SetParameterValue("@libraryID", dtlib.Rows[i]["LibraryID"].ToString());
                    //    rd.PrintToPrinter(1, false, 1, 1);
                    //}
                    ////  End For Auto




                   // FormulaFieldDefinition formulaField = rd.DataDefinition.FormulaFields["totalBonus"];
                   // // Get the formula text
                   // string formulaText = formulaField.Text;
                   // //rd.ExportToHttpResponse(ExportFormatType.Excel, Response, false, "BonusStatementReport");

                   //// // Create a formula field evaluator
                   ////// FormulaFieldEvaluator formulaEvaluator = new FormulaFieldEvaluator(report);

                   //// // Evaluate the formula field
                   //// string formulaName = formulaField.Text;
                   //// object formulaValue = formulaEvaluator.Evaluate(formulaName);
                    

                    rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "BonusStatementReport");
                    rd.Close();
                    rd.Dispose();
                }


            }
            catch (Exception)
            {


            }

        }
        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlYear.SelectedIndex == 1)
            {
                dtpFromDate.Text = "2022-11-01";
                dtpToDate.Text = "2023-10-31";
            }
            else if (ddlYear.SelectedIndex == 2)
            {
                dtpFromDate.Text = "2021-11-01";
                dtpToDate.Text = "2022-10-31";
            }
            else if (ddlYear.SelectedIndex == 3)
            {
                dtpFromDate.Text = "2020-11-01";
                dtpToDate.Text = "2021-10-31";
            }

            else if (ddlYear.SelectedIndex == 4)
            {
                dtpFromDate.Text = "2019-11-01";
                dtpToDate.Text = "2020-10-31";
            }
            else if (ddlYear.SelectedIndex == 5)
            {
                dtpFromDate.Text = "2018-11-01";
                dtpToDate.Text = "2019-10-31";
            }
            else if (ddlYear.SelectedIndex == 6)
            {
                dtpFromDate.Text = "2017-07-01";
                dtpToDate.Text = "2018-10-31";
            }

            else  if (ddlYear.SelectedIndex == 7)
            {
                dtpFromDate.Text = "2016-07-01";
                dtpToDate.Text = "2017-06-30";
            }


            else if (ddlYear.SelectedIndex == 8)
            {
                dtpFromDate.Text = "2015-07-01";
                dtpToDate.Text = "2016-06-30";
            }

            else if (ddlYear.SelectedIndex == 9)
            {
                dtpFromDate.Text = "2014-07-01";
                dtpToDate.Text = "2015-06-30";
            }


            else if (ddlYear.SelectedIndex == 0)
            {
                dtpFromDate.Text = string.Empty;
                dtpToDate.Text = string.Empty;
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