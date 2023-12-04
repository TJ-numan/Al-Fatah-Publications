using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Classes;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DAL;
using BLL.Marketing;

namespace BLL
{
    public partial class Mkt_Rpt_TargetVsAchievement : System.Web.UI.Page
    {
        DataAccessObject DAO = new DataAccessObject();
        string FormID = "MR008";
        DataRow dr;
        DataTable dtSubItem = new DataTable();
  
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");

                dtSubItem.Columns.Add("BookCodeEdition", typeof(string));

                if (!IsPostBack)
                {
                    getUserAccess();
                    LoadCategory();
                    LoadDemarcation();

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
        private void LoadCategory()
        {
            ddlCategory.DataSource = Li_CategoryManager.GetAllCategories();
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "ID";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("--Select--", "0"));

        }

        private void LoadAllStock()
        {
            gvwAllBookStock.DataSource = li_StockManager.GetAllStocks(ddlCategory.SelectedValue.ToString(), txtBookName.Text, txtClass.Text, txtEdition.Text, txtBookType.Text).Tables[0];
            gvwAllBookStock.DataBind();
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
        //    {
        //    }
        //}

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

                LoadComboData.LoadDivisionByRegionID(ddlDivision, int.Parse(ddlRegion.SelectedValue.ToString()));
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
        protected void btnShow_Click(object sender, EventArgs e)
        {

            try
            {
                string bookcodes = getSelectedBookCode();
                rd.Load(Server.MapPath(@"~/Reports/MKT/rptTargetVsAcheivement.rpt"));
                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@FromDate", dtpFromDate.Text);
                rd.SetParameterValue("@ToDate", dtpToDate.Text);
                rd.SetParameterValue("@RegionMainID", int.Parse(ddlRegionMain.SelectedValue));
                rd.SetParameterValue("@RegionID", int.Parse(ddlRegion.SelectedValue));
                rd.SetParameterValue("@DivisionID", int.Parse(ddlDivision.SelectedValue));
                rd.SetParameterValue("@ZoneID", int.Parse(ddlZone.SelectedValue));
                rd.SetParameterValue("@TerritoryCode", ddlTeritory.SelectedValue);
                rd.SetParameterValue("@Com", chkQawmi.Checked ? "Q" : "A");
                rd.SetParameterValue("@BookCode", bookcodes);
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "TargetVsAchievement");
                rd.Close();
                rd.Dispose();
            }
            catch (Exception  )
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

        protected void txtEdition_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadAllStock();
                gvwSubItem.Visible = false;
            }
            catch (Exception ex)
            {

            }
        }

        protected void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            try
            {


                for (int i = 0; i < gvwAllBookStock.Rows.Count; i++)
                {

                    CheckBox chkRow = (gvwAllBookStock.Rows[i].Cells[0].FindControl("chkSelect") as CheckBox);
                    if (chkRow.Checked == true)
                    {
                        string BookEdition = "";
                        BookEdition = gvwAllBookStock.Rows[i].Cells[1].Text + "/" + gvwAllBookStock.Rows[i].Cells[5].Text;

                        dr = dtSubItem.NewRow();
                        dr["BookCodeEdition"] = BookEdition.ToString();

                        dtSubItem.Rows.Add(dr);
                        ViewState["book"] = dtSubItem;

                        gvwSubItem.DataSource = dtSubItem;
                        gvwSubItem.DataBind();
                        gvwSubItem.Visible = true;
                    }


                }


            }
            catch (Exception)
            {


            }
        }

        protected void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {

                for (int i = 0; i < gvwAllBookStock.Rows.Count; i++)
                {

                    ((CheckBox)gvwAllBookStock.Rows[i].Cells[0].FindControl("chkSelect")).Checked = true;

                    string BookEdition = "";
                    BookEdition = gvwAllBookStock.Rows[i].Cells[1].Text + "/" + gvwAllBookStock.Rows[i].Cells[5].Text;

                    dr = dtSubItem.NewRow();
                    dr["BookCodeEdition"] = BookEdition.ToString();

                    dtSubItem.Rows.Add(dr);
                    ViewState["book"] = dtSubItem;

                    gvwSubItem.DataSource = dtSubItem;
                    gvwSubItem.DataBind();
                    gvwSubItem.Visible = true;
                }
            }
            else
            {

                for (int i = 0; i < gvwAllBookStock.Rows.Count; i++)
                {

                    ((CheckBox)gvwAllBookStock.Rows[i].Cells[0].FindControl("chkSelect")).Checked = false;

                }
            }

        }

        private string getSelectedBookCode()
        {
            string BookSelectedCode = "";
            if (gvwSubItem.Rows.Count > 0)
            {
                for (int j = 0; j < gvwSubItem.Rows.Count; j++)
                {

                    BookSelectedCode += gvwSubItem.Rows[j].Cells[0].Text + ",";
                }

            }



            return BookSelectedCode;
        }

        protected void gvwSubItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            dtSubItem = (DataTable)ViewState["book"];

            dtSubItem.Rows.RemoveAt(e.RowIndex);
            gvwSubItem.DataSource = dtSubItem;
            gvwSubItem.DataBind();
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