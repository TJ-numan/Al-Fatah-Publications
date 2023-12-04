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
using DAL;

namespace BLL
{
    public partial class Mkt_Rpt_DepositeReport : System.Web.UI.Page
    {
        DataAccessObject DAO = new DataAccessObject();
        string FormID = "MR011";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {

                    LoadDepositFor();
                    getUserAccess();
                    LoadDemarcation();
                    
                    LoadTransactionTypes();
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
                    ddlDepositType.Items.Insert(0, new ListItem("All Deposit Type", "0"));
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
        private void LoadTransactionTypes()
        {
            ddlDepositType.DataSource = Li_TransectionTypeManager.GetAllLi_TransectionTypes();
            ddlDepositType.DataTextField = "TranbType";
            ddlDepositType.DataValueField = "TannID";
            ddlDepositType.DataBind();

        }

        //Old Demarcation
        //private void LoadDemarcation()
        //{
        //    try
        //    {

        //        DataSet ds = new DataSet();
        //        ds = li_RegionManager.GetRegionByUser(int.Parse(Session["UserID"].ToString()));
        //        DataTable dtreg = ds.Tables[0].DefaultView.ToTable(true, "RegionName", "RegionID");
        //        DataTable dtdiv = ds.Tables[0].DefaultView.ToTable(true, "DivName", "DivID");
        //        DataTable dtzone = ds.Tables[0].DefaultView.ToTable(true, "ZonName", "ZonID");
        //        DataTable dtTer = ds.Tables[0].DefaultView.ToTable(true, "TeritoryName", "TeritoryCode");

        //        if (dtTer.Rows.Count == 1)
        //        {
        //            ddlRegion.DataSource = dtreg;
        //            ddlRegion.DataTextField = "RegionName";
        //            ddlRegion.DataValueField = "RegionID";
        //            ddlRegion.DataBind();

        //            ddlDivision.DataSource = dtdiv;
        //            ddlDivision.DataTextField = "DivName";
        //            ddlDivision.DataValueField = "DivID";
        //            ddlDivision.DataBind();

        //            ddlZone.DataSource = dtzone;
        //            ddlZone.DataTextField = "ZonName";
        //            ddlZone.DataValueField = "ZonID";
        //            ddlZone.DataBind();

        //            ddlTeritory.DataSource = dtTer;
        //            ddlTeritory.DataTextField = "TeritoryName";
        //            ddlTeritory.DataValueField = "TeritoryCode";
        //            ddlTeritory.DataBind();

        //        }
        //        else if (dtzone.Rows.Count == 1)
        //        {
        //            ddlRegion.DataSource = dtreg;
        //            ddlRegion.DataTextField = "RegionName";
        //            ddlRegion.DataValueField = "RegionID";
        //            ddlRegion.DataBind();

        //            ddlDivision.DataSource = dtdiv;
        //            ddlDivision.DataTextField = "DivName";
        //            ddlDivision.DataValueField = "DivID";
        //            ddlDivision.DataBind();

        //            ddlZone.DataSource = dtzone;
        //            ddlZone.DataTextField = "ZonName";
        //            ddlZone.DataValueField = "ZonID";
        //            ddlZone.DataBind();

        //            ddlTeritory.DataSource = dtTer;
        //            ddlTeritory.DataTextField = "TeritoryName";
        //            ddlTeritory.DataValueField = "TeritoryCode";
        //            ddlTeritory.DataBind();
        //            ddlTeritory.Items.Insert(0, new ListItem("All", ""));
        //        }
        //        else if (dtdiv.Rows.Count == 1)
        //        {
        //            ddlRegion.DataSource = dtreg;
        //            ddlRegion.DataTextField = "RegionName";
        //            ddlRegion.DataValueField = "RegionID";
        //            ddlRegion.DataBind();

        //            ddlDivision.DataSource = dtdiv;
        //            ddlDivision.DataTextField = "DivName";
        //            ddlDivision.DataValueField = "DivID";
        //            ddlDivision.DataBind();

        //            ddlZone.DataSource = dtzone;
        //            ddlZone.DataTextField = "ZonName";
        //            ddlZone.DataValueField = "ZonID";
        //            ddlZone.DataBind();
        //            ddlZone.Items.Insert(0, new ListItem("All", "0"));

        //            ddlTeritory.Items.Insert(0, new ListItem("All", ""));
        //        }
        //        else if (dtreg.Rows.Count == 1)
        //        {
        //            ddlRegion.DataSource = dtreg;
        //            ddlRegion.DataTextField = "RegionName";
        //            ddlRegion.DataValueField = "RegionID";
        //            ddlRegion.DataBind();
        //            ddlDivision.DataSource = dtdiv;
        //            ddlDivision.DataTextField = "DivName";
        //            ddlDivision.DataValueField = "DivID";
        //            ddlDivision.DataBind();
        //            ddlDivision.Items.Insert(0, new ListItem("All", "0"));

        //            ddlZone.Items.Insert(0, new ListItem("All", "0"));
        //            ddlTeritory.Items.Insert(0, new ListItem("All", ""));
        //        }
        //        else
        //        {
        //            ddlRegion.DataSource = dtreg;
        //            ddlRegion.DataTextField = "RegionName";
        //            ddlRegion.DataValueField = "RegionID";
        //            ddlRegion.DataBind();
        //            ddlRegion.Items.Insert(0, new ListItem("All", "0"));

        //            ddlDivision.Items.Insert(0, new ListItem("All", "0"));
        //            ddlZone.Items.Insert(0, new ListItem("All", "0"));
        //            ddlTeritory.Items.Insert(0, new ListItem("All", ""));
        //        }

        //    }
        //    catch (Exception)
        //    { }
        //}

        private void LoadDepositFor()
        {
            ListItem li = new ListItem("Select Any..", "0");
            ddlDepositFor.Items.Add(li);

            List<Li_DepositFor> DepositFor = new List<Li_DepositFor>();
            DepositFor = Li_DepositForManager.GetAllLi_DepositFors();
            foreach (Li_DepositFor dep in DepositFor)
            {
                ListItem item = new ListItem(dep.DepForName, dep.DepForId.ToString());
                ddlDepositFor.Items.Add(item);
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

        protected void btnShow_Click(object sender, EventArgs e)
        {
            string d1 = dtpFromDate.Text;
            string d2 = dtpToDate.Text;

            LoadReport(d1, d2);
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
        
        private void LoadReport(string d1, string d2)
        {

            try
            {

                rd.Load(Server.MapPath(@"~/Reports/MKT/LibrarywiseDeposit_R2.rpt"));
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
                rd.SetParameterValue("@DepForId", Int32.Parse ( ddlDepositFor. SelectedValue));
          
                rd.SetParameterValue("@DepositType", int.Parse(ddlDepositType.SelectedValue));
                rd.SetParameterValue("@UserID", int.Parse(Session["UserID"].ToString()));
                rd.SetParameterValue("@Com", chkQawmi.Checked ? "Q" : "A");
                if (ddlViewers.SelectedValue == "0")
                {

                }

                else if (ddlViewers.SelectedValue == "1")
                {
                    rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "DepositReport");
                }

                else if (ddlViewers.SelectedValue == "2")
                {
                    rd.ExportToHttpResponse(ExportFormatType.ExcelRecord, Response, false, "DepositReport");
                }


                else if (ddlViewers.SelectedValue == "3")
                {
                    rd.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, false, "DepositReport");
                }

                else 
                {
                   
                }


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