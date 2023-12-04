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

namespace BLL
{
    public partial class Mkt_DatewiseSpecialOfferDeposit : System.Web.UI.Page
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
                    btnSave.Enabled = true;
                    getUserAccess();
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
                        Response.Redirect("~/AccountsHome.aspx");
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
                    ddlTeritory.DataSource = dtTer;
                    ddlTeritory.DataTextField = "TeritoryName";
                    ddlTeritory.DataValueField = "TeritoryCode";
                    ddlTeritory.DataBind();

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
                    ddlTeritory.Items.Insert(0, new ListItem("All", ""));
                }

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
                string Com;
                DataTable dt = new DataTable();
                if (chkIsAlia.Checked)
                {
                    Com = "A";
                    dt = Li_DepositManager.Get_DepositSpBonusInformation(dtpFromDate.Text.ToString(), dtpToDate.Text.ToString(), Int32.Parse(ddlRegion.SelectedValue), Int32.Parse(ddlDivision.SelectedValue), ddlTeritory.SelectedValue.ToString(), Com);
                    decimal totalAmount = 0.0m;
                    decimal totalSpAmount = 0.0m;
                    if (dt.Rows.Count > 0)
                    {
                        gvMRSheetDetailsUpdate.DataSource = dt;
                        gvMRSheetDetailsUpdate.DataBind();

                        for (int i = 0; i < gvMRSheetDetailsUpdate.Rows.Count; i++)
                        {
                            decimal totalAmtRow = Convert.ToDecimal(gvMRSheetDetailsUpdate.Rows[i].Cells[4].Text);
                            totalAmount += totalAmtRow;

                            decimal totalSpBonus = Convert.ToDecimal(gvMRSheetDetailsUpdate.Rows[i].Cells[5].Text);
                            totalSpAmount += totalSpBonus;
                        }

                        txtTotalAmount.Text = totalAmount.ToString();
                        txtTotalSpBonus.Text = totalSpAmount.ToString();
                    }
                    else
                    {
                        txtTotalAmount.Text = totalAmount.ToString();
                        txtTotalSpBonus.Text = totalSpAmount.ToString();
                        gvMRSheetDetailsUpdate.DataSource = null;
                        gvMRSheetDetailsUpdate.DataBind();
                    }
                }
                else if (chkIsQawmi.Checked)
                {
                    Com = "Q";
                    dt = Li_DepositManager.Get_DepositSpBonusInformation(dtpFromDate.Text.ToString(), dtpToDate.Text.ToString(), Int32.Parse(ddlRegion.SelectedValue), Int32.Parse(ddlDivision.SelectedValue), ddlTeritory.SelectedValue.ToString(), Com);
                    decimal totalAmount = 0.0m;
                    decimal totalSpAmount = 0.0m;
                    if (dt.Rows.Count > 0)
                    {
                        gvMRSheetDetailsUpdate.DataSource = dt;
                        gvMRSheetDetailsUpdate.DataBind();

                        for (int i = 0; i < gvMRSheetDetailsUpdate.Rows.Count; i++)
                        {
                            decimal totalAmtRow = Convert.ToDecimal(gvMRSheetDetailsUpdate.Rows[i].Cells[4].Text);
                            totalAmount += totalAmtRow;

                            decimal totalSpBonus = Convert.ToDecimal(gvMRSheetDetailsUpdate.Rows[i].Cells[5].Text);
                            totalSpAmount += totalSpBonus;
                        }

                        txtTotalAmount.Text = totalAmount.ToString();
                        txtTotalSpBonus.Text = totalSpAmount.ToString();
                    }
                    else
                    {
                        txtTotalAmount.Text = totalAmount.ToString();
                        txtTotalSpBonus.Text = totalSpAmount.ToString();
                        gvMRSheetDetailsUpdate.DataSource = null;
                        gvMRSheetDetailsUpdate.DataBind();
                    }
                }
                else if (chkIsAliaCounter.Checked)
                {
                    Com = "C";
                    dt = Li_DepositManager.Get_DepositSpBonusInformation(dtpFromDate.Text.ToString(), dtpToDate.Text.ToString(), Int32.Parse(ddlRegion.SelectedValue), Int32.Parse(ddlDivision.SelectedValue), ddlTeritory.SelectedValue.ToString(), Com);
                    decimal totalAmount = 0.0m;
                    decimal totalSpAmount = 0.0m;
                    if (dt.Rows.Count > 0)
                    {
                        gvMRSheetDetailsUpdate.DataSource = dt;
                        gvMRSheetDetailsUpdate.DataBind();

                        for (int i = 0; i < gvMRSheetDetailsUpdate.Rows.Count; i++)
                        {
                            decimal totalAmtRow = Convert.ToDecimal(gvMRSheetDetailsUpdate.Rows[i].Cells[4].Text);
                            totalAmount += totalAmtRow;

                            decimal totalSpBonus = Convert.ToDecimal(gvMRSheetDetailsUpdate.Rows[i].Cells[5].Text);
                            totalSpAmount += totalSpBonus;
                        }

                        txtTotalAmount.Text = totalAmount.ToString();
                        txtTotalSpBonus.Text = totalSpAmount.ToString();
                    }
                    else
                    {
                        txtTotalAmount.Text = totalAmount.ToString();
                        txtTotalSpBonus.Text = totalSpAmount.ToString();
                        gvMRSheetDetailsUpdate.DataSource = null;
                        gvMRSheetDetailsUpdate.DataBind();
                    }
                }
                else if (chkIsQawmiCounter.Checked)
                {
                    Com = "K";
                    dt = Li_DepositManager.Get_DepositSpBonusInformation(dtpFromDate.Text.ToString(), dtpToDate.Text.ToString(), Int32.Parse(ddlRegion.SelectedValue), Int32.Parse(ddlDivision.SelectedValue), ddlTeritory.SelectedValue.ToString(), Com);
                    decimal totalAmount = 0.0m;
                    decimal totalSpAmount = 0.0m;
                    if (dt.Rows.Count > 0)
                    {
                        gvMRSheetDetailsUpdate.DataSource = dt;
                        gvMRSheetDetailsUpdate.DataBind();

                        for (int i = 0; i < gvMRSheetDetailsUpdate.Rows.Count; i++)
                        {
                            decimal totalAmtRow = Convert.ToDecimal(gvMRSheetDetailsUpdate.Rows[i].Cells[4].Text);
                            totalAmount += totalAmtRow;

                            decimal totalSpBonus = Convert.ToDecimal(gvMRSheetDetailsUpdate.Rows[i].Cells[5].Text);
                            totalSpAmount += totalSpBonus;
                        }

                        txtTotalAmount.Text = totalAmount.ToString();
                        txtTotalSpBonus.Text = totalSpAmount.ToString();
                    }
                    else
                    {
                        txtTotalAmount.Text = totalAmount.ToString();
                        txtTotalSpBonus.Text = totalSpAmount.ToString();
                        gvMRSheetDetailsUpdate.DataSource = null;
                        gvMRSheetDetailsUpdate.DataBind();
                    }
                }            

            }
            catch (Exception)
            {


            }

        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {

            try
            {
                if (chkIsAlia.Checked)
                {
                    rd.Load(Server.MapPath(@"~/Reports/MKT/CASH/rptDatewiseSpecialOfferDeposit.rpt"));
                }
                else if (chkIsQawmi.Checked)
                {
                    rd.Load(Server.MapPath(@"~/Reports/MKT/CASH/rptDatewiseSpecialOfferDepositQ.rpt"));
                }
                else if (chkIsAliaCounter.Checked)
                {
                    rd.Load(Server.MapPath(@"~/Reports/MKT/CASH/rptDatewiseSpecialOfferDeposit.rpt"));
                }
                else if (chkIsQawmiCounter.Checked)
                {
                    rd.Load(Server.MapPath(@"~/Reports/MKT/CASH/rptDatewiseSpecialOfferDepositQ.rpt"));
                }


                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@FromDate", dtpFromDate.Text);
                rd.SetParameterValue("@ToDate", dtpToDate.Text);
                rd.SetParameterValue("@RegionID", int.Parse(ddlRegion.SelectedValue));
                rd.SetParameterValue("@DivisionID", int.Parse(ddlDivision.SelectedValue));
                rd.SetParameterValue("@TeritoryID", ddlTeritory.SelectedValue);
                //------------------------Company Selection----------------------------------------
                if (chkIsAlia.Checked)
                {
                    rd.SetParameterValue("@Com", "A");
                }
                else if (chkIsQawmi.Checked)
                {
                    rd.SetParameterValue("@Com", "Q");
                }
                else if (chkIsAliaCounter.Checked)
                {
                    rd.SetParameterValue("@Com", "C");
                }
                else if (chkIsQawmiCounter.Checked)
                {
                    rd.SetParameterValue("@Com", "K");
                }



                //------------------------------------------Print------------------------------------------------------
                if (ddlViewers.SelectedValue == "0")
                {

                }

                else if (ddlViewers.SelectedValue == "1")
                {
                    rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "CashDepositReport");
                }

                else if (ddlViewers.SelectedValue == "2")
                {
                    rd.ExportToHttpResponse(ExportFormatType.ExcelRecord, Response, false, "CashDepositReport");
                }


                else if (ddlViewers.SelectedValue == "3")
                {
                    rd.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, false, "CashDepositReport");
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
        protected void btnSave_Click(object sender, EventArgs e)
        {

            string message = "", script = "";
            if (gvMRSheetDetailsUpdate.Rows.Count > 0)
                {


                    for (int i = 0; i < gvMRSheetDetailsUpdate.Rows.Count; i++)
                    {
                        decimal Amt = decimal.Parse((gvMRSheetDetailsUpdate.Rows[i].Cells[5].Text));
                        if(Amt <= 0){

                        }
                        else {

                            Li_Deposit deposit = new Li_Deposit();
                            deposit.Alim = false;
                            deposit.AmountOfMoney = decimal.Parse((gvMRSheetDetailsUpdate.Rows[i].Cells[5].Text));
                            deposit.BankAddress = "";
                            deposit.BankCode = "ADJ_AMT";
                            deposit.BankSlipNo = "";
                            deposit.Boishaki = false;
                            deposit.CauseOfDelete = "";
                            deposit.ClearDate = Convert.ToDateTime(dtpToDate.Text.ToString()); ;
                            deposit.CreatedBy = int.Parse(Session["UserID"].ToString());
                            deposit.Dele_By = 0;
                            deposit.Deledate = DateTime.Now;
                            deposit.DepositedDate = Convert.ToDateTime(dtpToDate.Text.ToString());
                            deposit.DepositeTpe = 8;
                            deposit.LibraryID = gvMRSheetDetailsUpdate.Rows[i].Cells[0].Text;
                            deposit.MRDate = Convert.ToDateTime(dtpToDate.Text.ToString()); ;
                            deposit.Remark = txtRemarks.Text.ToString();
                            deposit.Status_D = 'C';
                            deposit.VrifiedBy = "";
                            deposit.Dam_BookSale = false;
                            deposit.Dam_Other = false;
                            deposit.HouseRent = false;
                            deposit.Others = false;
                            deposit.Comp = gvMRSheetDetailsUpdate.Rows[i].Cells[3].Text;
                            deposit.DepositForId = 4;
                            deposit.AssetList = 0;
                            Li_DepositManager.InsertLi_DepositSPBonus(deposit);

                            //// For Gold Bonus Adjustment 29/03/2023
                            //Li_Deposit deposit = new Li_Deposit();
                            //deposit.Alim = false;
                            //deposit.AmountOfMoney = decimal.Parse((gvMRSheetDetailsUpdate.Rows[i].Cells[5].Text));
                            //deposit.BankAddress = "";
                            //deposit.BankCode = "ADJ_AMT";
                            //deposit.BankSlipNo = "";
                            //deposit.Boishaki = false;
                            //deposit.CauseOfDelete = "";
                            //deposit.ClearDate = Convert.ToDateTime("2023-03-29 11:00:00"); ;
                            //deposit.CreatedBy = int.Parse(Session["UserID"].ToString());
                            //deposit.Dele_By = 0;
                            //deposit.Deledate = DateTime.Now;
                            //deposit.DepositedDate = Convert.ToDateTime("2023-03-04");
                            //deposit.DepositeTpe = 8;
                            //deposit.LibraryID = gvMRSheetDetailsUpdate.Rows[i].Cells[0].Text;
                            //deposit.MRDate = Convert.ToDateTime("2023-03-04"); ;
                            //deposit.Remark = txtRemarks.Text.ToString();
                            //deposit.Status_D = 'C';
                            //deposit.VrifiedBy = "";
                            //deposit.Dam_BookSale = false;
                            //deposit.Dam_Other = false;
                            //deposit.HouseRent = false;
                            //deposit.Others = false;
                            //deposit.Comp = gvMRSheetDetailsUpdate.Rows[i].Cells[3].Text;
                            //deposit.DepositForId = 4;
                            //deposit.AssetList = 0;
                            //Li_DepositManager.InsertLi_DepositSPBonus(deposit);
                       }

                    }

                    message = "Saved successful.";
                    script = "window.onload = function(){ alert('";
                    script += message;
                    script += "');";
                    script += "window.location = '";
                    script += Request.Url.AbsoluteUri;
                    script += "'; }";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);
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