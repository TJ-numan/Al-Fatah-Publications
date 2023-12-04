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
    public partial class Mkt_RptMonthwiseTarget : System.Web.UI.Page
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
                    loadRegion();
                    LoadDemarcation();

                    //int year = DateTime.Now.Year;
                    //int month = DateTime.Now.Month;
                    //int day = DateTime.Now.Day;

                    //if (month >= 11)
                    //{
                    //    var mydate = new DateTime(year, 11, 01);

                    //    dtpFromDate.Text = String.Format("{0:yyyy-MM-dd}", mydate);
                    //}

                    //else
                    //{
                    //    var mydate = new DateTime(year - 1, 11, 01);
                    //    dtpFromDate.Text = String.Format("{0:yyyy-MM-dd}", mydate);
                    //}
                    //dtpToDate.Text = String.Format("{0:yyyy-MM-dd}", DateTime.Now);
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
        private void LoadDemarcation()
        {
            try
            {

                DataSet ds = new DataSet();
                ds = li_RegionManager.GetRegionByUser(int.Parse(Session["UserID"].ToString()));
                DataTable dtreg = ds.Tables[0].DefaultView.ToTable(true, "RegionName", "RegionID");
                DataTable dtdiv = ds.Tables[0].DefaultView.ToTable(true, "DivName", "DivID");
                DataTable dtTer = ds.Tables[0].DefaultView.ToTable(true, "TeritoryName", "TeritoryCode");
                if (dtTer.Rows.Count == 1)
                {

                    ddlRegion.DataSource = dtreg;
                    ddlRegion.DataTextField = "RegionName";
                    ddlRegion.DataValueField = "RegionID";
                    ddlRegion.DataBind();

                    ddlDivision.DataSource = dtdiv;
                    ddlDivision.DataTextField = "DivName";
                    ddlDivision.DataValueField = "DivID";
                    ddlDivision.DataBind();
                    ddlTeritory.DataSource = dtTer;
                    ddlTeritory.DataTextField = "TeritoryName";
                    ddlTeritory.DataValueField = "TeritoryCode";
                    ddlTeritory.DataBind();

                }
                else if (dtdiv.Rows.Count == 1)
                {

                    ddlRegion.DataSource = dtreg;
                    ddlRegion.DataTextField = "RegionName";
                    ddlRegion.DataValueField = "RegionID";
                    ddlRegion.DataBind();

                    ddlDivision.DataSource = dtdiv;
                    ddlDivision.DataTextField = "DivName";
                    ddlDivision.DataValueField = "DivID";
                    ddlDivision.DataBind();
                    ddlTeritory.Items.Insert(0, new ListItem("All", ""));

                }
                else if (dtreg.Rows.Count == 1)
                {
                    ddlRegion.DataSource = dtreg;
                    ddlRegion.DataTextField = "RegionName";
                    ddlRegion.DataValueField = "RegionID";
                    ddlRegion.DataBind();

                    ddlDivision.DataSource = dtdiv;
                    ddlDivision.DataTextField = "DivName";
                    ddlDivision.DataValueField = "DivID";
                    ddlDivision.DataBind();

                    ddlDivision.Items.Insert(0, new ListItem("All", "0"));
                    ddlTeritory.Items.Insert(0, new ListItem("All", ""));


                }

                else
                {
                    ddlRegion.Items.Insert(0, new ListItem("All", "0"));
                    ddlDivision.Items.Insert(0, new ListItem("All", "0"));
                    ddlTeritory.Items.Insert(0, new ListItem("All", ""));
                }

            }
            catch (Exception)
            {
            }
        }
        protected void loadRegion()
        {
            try
            {

                DataTable dt = li_RegionManager.GetRegion().Tables[0];
                ddlRegion.DataSource = dt;
                ddlRegion.DataTextField = "RegionName";
                ddlRegion.DataValueField = "RegionID";
                ddlRegion.DataBind();

                ddlDivision.Items.Clear();
                ddlDivision.Items.Insert(0, new ListItem("All", "0"));

                ddlTeritory.Items.Clear();
                ddlTeritory.Items.Insert(0, new ListItem("All", ""));
            }
            catch (Exception)
            {

            }
        }
        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                LoadComboData.LoadDivisionByRegionID(ddlDivision, int.Parse(ddlRegion.SelectedValue.ToString()));
                ddlDivision.DataBind();

                ddlTeritory.Items.Clear();
                ddlTeritory.Items.Insert(0, new ListItem("All", ""));
            }
            catch (Exception)
            {

            }
        }

        protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadComboData.LoadTeritoryByZone(ddlTeritory, int.Parse(ddlDivision.SelectedValue));
                ddlTeritory.DataBind();

            }
            catch (Exception)
            {


            }
        }
        ReportDocument rd = new ReportDocument();
        protected void btnShow_Click(object sender, EventArgs e)
        {

            try
            {
                if (ddlCompany.SelectedValue == "1")
                {
                    rd.Load(Server.MapPath(@"~/Reports/MKT/QAWMI/rptMonthwiseTargetReportAlia.rpt"));
                }
                else if (ddlCompany.SelectedValue == "2")
                {
                    rd.Load(Server.MapPath(@"~/Reports/MKT/QAWMI/rptMonthwiseTargetReportQ.rpt"));
                }
                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@fromDate", dtpFromDate.Text);
                rd.SetParameterValue("@toDate", dtpToDate.Text);
                rd.SetParameterValue("@RegionMainID", "0");
                rd.SetParameterValue("@RegionID", int.Parse(ddlRegion.SelectedValue));
                rd.SetParameterValue("@DivisionID", int.Parse(ddlDivision.SelectedValue));
                rd.SetParameterValue("@TerritoryID", ddlTeritory.SelectedValue);
                rd.SetParameterValue("@CompanyId", int.Parse(ddlCompany.SelectedValue));

                //------------------------------------------Print------------------------------------------------------
                if (ddlViewers.SelectedValue == "0")
                {

                }

                else if (ddlViewers.SelectedValue == "1")
                {
                    rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "FieldForceReport");
                }

                else if (ddlViewers.SelectedValue == "2")
                {
                    rd.ExportToHttpResponse(ExportFormatType.ExcelRecord, Response, false, "FieldForceReport");
                }


                else if (ddlViewers.SelectedValue == "3")
                {
                    rd.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, false, "FieldForceReport");
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

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Year = ddlYear.SelectedValue.ToString();
                if (Year != "0")
                {
                    if (ddlMonth.SelectedIndex == 1)
                    {
                        dtpFromDate.Text = Year + "-01-01";
                        dtpToDate.Text = Year + "-01-31";
                    }
                    else if (ddlMonth.SelectedIndex == 2)
                    {

                        dtpFromDate.Text = Year + "-02-01";
                        if (int.Parse(Year) % 4 == 0)
                        {
                            dtpToDate.Text = Year + "-02-29";
                        }
                        else
                        {
                            dtpToDate.Text = Year + "-02-28";
                        }
                    }
                    else if (ddlMonth.SelectedIndex == 3)
                    {
                        dtpFromDate.Text = Year + "-03-01";
                        dtpToDate.Text = Year + "-03-31";
                    }
                    else if (ddlMonth.SelectedIndex == 4)
                    {
                        dtpFromDate.Text = Year + "-04-01";
                        dtpToDate.Text = Year + "-04-30";
                    }
                    else if (ddlMonth.SelectedIndex == 5)
                    {
                        dtpFromDate.Text = Year + "-05-01";
                        dtpToDate.Text = Year + "-05-31";
                    }
                    else if (ddlMonth.SelectedIndex == 6)
                    {
                        dtpFromDate.Text = Year + "-06-01";
                        dtpToDate.Text = Year + "-06-30";
                    }
                    else if (ddlMonth.SelectedIndex == 7)
                    {
                        dtpFromDate.Text = Year + "-07-01";
                        dtpToDate.Text = Year + "-07-31";
                    }
                    else if (ddlMonth.SelectedIndex == 8)
                    {
                        dtpFromDate.Text = Year + "-08-01";
                        dtpToDate.Text = Year + "-08-31";
                    }
                    else if (ddlMonth.SelectedIndex == 9)
                    {
                        dtpFromDate.Text = Year + "-09-01";
                        dtpToDate.Text = Year + "-09-30";
                    }
                    else if (ddlMonth.SelectedIndex == 10)
                    {
                        dtpFromDate.Text = Year + "-10-01";
                        dtpToDate.Text = Year + "-10-31";
                    }
                    else if (ddlMonth.SelectedIndex == 11)
                    {
                        dtpFromDate.Text = Year + "-11-01";
                        dtpToDate.Text = Year + "-11-30";
                    }
                    else if (ddlMonth.SelectedIndex == 12)
                    {
                        dtpFromDate.Text = Year + "-12-01";
                        dtpToDate.Text = Year + "-12-31";
                    }
                    else
                    {
                        dtpFromDate.Text = "";
                        dtpToDate.Text = "";
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select a year');", true);
                    ddlMonth.SelectedValue = "0";
                    dtpFromDate.Text = "";
                    dtpToDate.Text = "";
                    return;
                }
            }
            catch (Exception)
            {


            }
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlMonth.SelectedValue = "0";
            dtpFromDate.Text = "";
            dtpToDate.Text = "";
        }

    }
}