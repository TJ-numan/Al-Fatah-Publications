using System.Security.Principal;
using BLL.Classes;
using BLL.Reports.MKT;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace BLL
{
    public partial class Mkt_Rpt_AgentPaymentCashParty : System.Web.UI.Page
    {
        DataAccessObject DAO = new DataAccessObject();
        string FormID = "MR035";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    getUserAccess();
                    LoadDemarcation();

                    dtpFromDate.Text = String.Format("{0:yyyy-MM-dd}", DateTime.Now);

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
        private void LoadDemarcation()
        {
            try
            {

                DataSet ds = new DataSet();
                ds = li_RegionManager.GetRegionByUser(int.Parse(Session["UserID"].ToString()));
                DataTable dtregmain = ds.Tables[0].DefaultView.ToTable(true, "RegionMainName", "RegionMainID");
                DataTable dtreg = ds.Tables[0].DefaultView.ToTable(true, "RegionName", "RegionID");
                DataTable dtdiv = ds.Tables[0].DefaultView.ToTable(true, "DivName", "DivID");
                DataTable dtzone = ds.Tables[0].DefaultView.ToTable(true, "ZonName", "ZonID");
                DataTable dtTer = ds.Tables[0].DefaultView.ToTable(true, "TeritoryName", "TeritoryCode");

                if (dtTer.Rows.Count == 1)
                {
                    ddlRegionMain.DataSource = dtregmain;
                    ddlRegionMain.DataTextField = "RegionMainName";
                    ddlRegionMain.DataValueField = "RegionMainID";
                    ddlRegionMain.DataBind();

                    ddlRegion.DataSource = dtreg;
                    ddlRegion.DataTextField = "RegionName";
                    ddlRegion.DataValueField = "RegionID";
                    ddlRegion.DataBind();

                    ddlDivision.DataSource = dtdiv;
                    ddlDivision.DataTextField = "DivName";
                    ddlDivision.DataValueField = "DivID";
                    ddlDivision.DataBind();

                    ddlZone.DataSource = dtzone;
                    ddlZone.DataTextField = "ZonName";
                    ddlZone.DataValueField = "ZonID";
                    ddlZone.DataBind();

                    ddlTeritory.DataSource = dtTer;
                    ddlTeritory.DataTextField = "TeritoryName";
                    ddlTeritory.DataValueField = "TeritoryCode";
                    ddlTeritory.DataBind();

                }
                else if (dtzone.Rows.Count == 1)
                {
                    ddlRegionMain.DataSource = dtregmain;
                    ddlRegionMain.DataTextField = "RegionMainName";
                    ddlRegionMain.DataValueField = "RegionMainID";
                    ddlRegionMain.DataBind();

                    ddlRegion.DataSource = dtreg;
                    ddlRegion.DataTextField = "RegionName";
                    ddlRegion.DataValueField = "RegionID";
                    ddlRegion.DataBind();

                    ddlDivision.DataSource = dtdiv;
                    ddlDivision.DataTextField = "DivName";
                    ddlDivision.DataValueField = "DivID";
                    ddlDivision.DataBind();

                    ddlZone.DataSource = dtzone;
                    ddlZone.DataTextField = "ZonName";
                    ddlZone.DataValueField = "ZonID";
                    ddlZone.DataBind();

                    ddlTeritory.DataSource = dtTer;
                    ddlTeritory.DataTextField = "TeritoryName";
                    ddlTeritory.DataValueField = "TeritoryCode";
                    ddlTeritory.DataBind();
                    ddlTeritory.Items.Insert(0, new ListItem("All", ""));
                }
                else if (dtdiv.Rows.Count == 1)
                {

                    ddlRegionMain.DataSource = dtregmain;
                    ddlRegionMain.DataTextField = "RegionMainName";
                    ddlRegionMain.DataValueField = "RegionMainID";
                    ddlRegionMain.DataBind();

                    ddlRegion.DataSource = dtreg;
                    ddlRegion.DataTextField = "RegionName";
                    ddlRegion.DataValueField = "RegionID";
                    ddlRegion.DataBind();

                    ddlDivision.DataSource = dtdiv;
                    ddlDivision.DataTextField = "DivName";
                    ddlDivision.DataValueField = "DivID";
                    ddlDivision.DataBind();

                    ddlZone.DataSource = dtzone;
                    ddlZone.DataTextField = "ZonName";
                    ddlZone.DataValueField = "ZonID";
                    ddlZone.DataBind();
                    ddlZone.Items.Insert(0, new ListItem("All", "0"));

                    ddlTeritory.Items.Insert(0, new ListItem("All", ""));
                }
                else if (dtreg.Rows.Count == 1)
                {
                    ddlRegionMain.DataSource = dtregmain;
                    ddlRegionMain.DataTextField = "RegionMainName";
                    ddlRegionMain.DataValueField = "RegionMainID";
                    ddlRegionMain.DataBind();

                    ddlRegion.DataSource = dtreg;
                    ddlRegion.DataTextField = "RegionName";
                    ddlRegion.DataValueField = "RegionID";
                    ddlRegion.DataBind();

                    ddlDivision.DataSource = dtdiv;
                    ddlDivision.DataTextField = "DivName";
                    ddlDivision.DataValueField = "DivID";
                    ddlDivision.DataBind();

                    ddlDivision.Items.Insert(0, new ListItem("All", "0"));

                    ddlZone.Items.Insert(0, new ListItem("All", "0"));

                    ddlTeritory.Items.Insert(0, new ListItem("All", ""));
                }
                else if (dtregmain.Rows.Count == 1)
                {
                    ddlRegionMain.DataSource = dtregmain;
                    ddlRegionMain.DataTextField = "RegionMainName";
                    ddlRegionMain.DataValueField = "RegionMainID";
                    ddlRegionMain.DataBind();

                    ddlRegion.DataSource = dtreg;
                    ddlRegion.DataTextField = "RegionName";
                    ddlRegion.DataValueField = "RegionID";
                    ddlRegion.DataBind();
                    ddlRegion.Items.Insert(0, new ListItem("All", "0"));

                    ddlDivision.Items.Insert(0, new ListItem("All", "0"));

                    ddlZone.Items.Insert(0, new ListItem("All", "0"));

                    ddlTeritory.Items.Insert(0, new ListItem("All", ""));
                }
                else
                {
                    ddlRegionMain.DataSource = dtregmain;
                    ddlRegionMain.DataTextField = "RegionMainName";
                    ddlRegionMain.DataValueField = "RegionMainID";
                    ddlRegionMain.DataBind();

                    ddlRegionMain.Items.Insert(0, new ListItem("All", "0"));
                    ddlRegion.Items.Insert(0, new ListItem("All", "0"));
                    ddlDivision.Items.Insert(0, new ListItem("All", "0"));
                    ddlZone.Items.Insert(0, new ListItem("All", "0"));
                    ddlTeritory.Items.Insert(0, new ListItem("All", ""));
                }

            }
            catch (Exception)
            {
            }
        }

        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                LoadComboData.LoadDivisionByRegionID(ddlDivision, int.Parse(ddlRegion.SelectedValue));
                ddlDivision.DataBind();


                ddlZone.Items.Clear();
                ddlZone.Items.Insert(0, new ListItem("All", "0"));

                ddlTeritory.Items.Clear();
                ddlTeritory.Items.Insert(0, new ListItem("All", ""));
                //ClearDemarcaton(new DropDownList[] { ddlZone, ddlTeritory });

            }
            catch (Exception)
            {

            }
        }



        protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadComboData.LoadZoneByDivision(ddlZone, int.Parse(ddlDivision.SelectedValue));
                ddlZone.DataBind();

                ddlTeritory.Items.Clear();
                ddlTeritory.Items.Insert(0, new ListItem("All", ""));

            }
            catch (Exception)
            {

            }
        }

        protected void ddlZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadComboData.LoadTeritoryByZone(ddlTeritory, int.Parse(ddlZone.SelectedValue));
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


                rd.Load(Server.MapPath(@"~/Reports/MKT/rptPrintCashPartyPayment.rpt"));
                //rd.SetDatabaseLogon(DAO.UserID, DAO.Password, DAO.ServerName, DAO.DatabaseName);
                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@fromdate", dtpFromDate.Text);
                rd.SetParameterValue("@todate", dtpToDate.Text);
                rd.SetParameterValue("@RegionMainID", int.Parse(ddlRegionMain.SelectedValue));
                rd.SetParameterValue("@RegionID", int.Parse(ddlRegion.SelectedValue));
                rd.SetParameterValue("@DivisionID", int.Parse(ddlDivision.SelectedValue));
                rd.SetParameterValue("@ZoneID", int.Parse(ddlZone.SelectedValue));
                rd.SetParameterValue("@TerritoryCode", ddlTeritory.SelectedValue);
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "AgentPayment");

                rd.Close();
                rd.Dispose();
            }
            catch (Exception ex)
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

        protected void lb_Click(object sender, EventArgs e)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath(@"~/Reports/MKT/rptPrintCashPartyPayment.rpt"));
            rd.SetDatabaseLogon(DAO.UserID, DAO.Password, DAO.ServerName, DAO.DatabaseName);
            rd.SetParameterValue("@fromdate", dtpFromDate.Text);
            rd.SetParameterValue("@todate", dtpToDate.Text);
            rd.SetParameterValue("@RegionID", int.Parse(ddlRegion.SelectedValue));
            rd.SetParameterValue("@DivisionID", int.Parse(ddlDivision.SelectedValue));
            rd.SetParameterValue("@ZoneID", int.Parse(ddlZone.SelectedValue));
            rd.SetParameterValue("@TerritoryCode", ddlTeritory.SelectedValue);
            rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "AgentPayment");

        }

        protected void ddlRegionMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = li_RegionManager.GetRegionByRegionMainId(ddlRegionMain.SelectedValue).Tables[0];
                ddlRegion.DataSource = dt;
                ddlRegion.DataTextField = "RegionName";
                ddlRegion.DataValueField = "RegionID";
                ddlRegion.DataBind();

                ddlDivision.Items.Clear();
                ddlDivision.Items.Insert(0, new ListItem("All", "0"));

                ddlZone.Items.Clear();
                ddlZone.Items.Insert(0, new ListItem("All", "0"));

                ddlTeritory.Items.Clear();
                ddlTeritory.Items.Insert(0, new ListItem("All", ""));



            }
            catch (Exception)
            {

            }
        }


    }
}