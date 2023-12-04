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
    public partial class SpecimenAdjustmentLetter : System.Web.UI.Page
    {
        string FormID = "MF046";
     
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                 txtLetterNo.Attributes.Remove("readonly");
                 txtLetterNo .Attributes.Add("autocomplete", "off");
                 
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
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

                if (Session["result"] != null)
                {
                    txtLetterNo.Text = Session["result"].ToString();
                        
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
                LoadComboData.LoadZoneByDivision(ddlZone, int.Parse(ddlDivision.SelectedValue.ToString()));
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
                LoadComboData.LoadTeritoryByZone(ddlTeritory, int.Parse(ddlZone.SelectedValue.ToString()));
                ddlTeritory.DataBind();
            }
            catch (Exception)
            {


            }

        }
      
        protected void btnShow_Click(object sender, EventArgs e)
        {


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

        protected void ddlTeritory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                ddlTsoName.Items.Clear();

                ListItem li = new ListItem("Select a TSO", "0");
                ddlTsoName.Items.Add(li);

                List<Li_SalesPerson> SalesMen = new List<Li_SalesPerson>();
                SalesMen=Li_SalesPersonManager.GetLi_SalesPersonsByTerritory(ddlTeritory.SelectedValue );

                foreach (Li_SalesPerson tso in SalesMen)
                {
                    ListItem item = new ListItem(tso.Name, tso.TSOID);
                    ddlTsoName.Items.Add(item);
                }
             

            }
            catch
            {

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                Li_SpecimenAdjLetter SpeAdjustment = new Li_SpecimenAdjLetter();
                SpeAdjustment.AdjustAmt = txtTotalAdjustment.Text.Trim() == "" ? 0.0m : decimal.Parse(txtTotalAdjustment.Text);
                SpeAdjustment.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                SpeAdjustment.CreatedDate = DateTime.Now;
                SpeAdjustment.LetterNo = 0;
                SpeAdjustment.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                SpeAdjustment.ModifiedDate = DateTime.Now;
                SpeAdjustment.ReturnAmt = txtTotalReturn.Text.Trim() == "" ? 0.0m : decimal.Parse(txtTotalReturn.Text);
                SpeAdjustment.Status_d = "C";
                SpeAdjustment.TsoId = ddlTsoName.SelectedValue;
                Session["SpecimenLetter"] = Li_SpecimenAdjLetterManager.InsertLi_SpecimenAdjLetter(SpeAdjustment);


                for (int i = 0; i < gvSpecimenLetter.Rows.Count; i++)
                {
                    Li_SpecimenAdjLetterDetail SpeDetailAdjustment = new Li_SpecimenAdjLetterDetail();
                    SpeDetailAdjustment.AdjustAmount = decimal.Parse(gvSpecimenLetter.Rows[i].Cells[6].Text);
                    SpeDetailAdjustment.IsIntFrom = false;// bool.Parse(gvSpecimenLetter.Rows[i].Cells[10].Text);
                    SpeDetailAdjustment.LetDetId = 0;
                    SpeDetailAdjustment.LetterId = Int32.Parse(Session["SpecimenLetter"].ToString());
                    SpeDetailAdjustment.MemoNo = gvSpecimenLetter.Rows[i].Cells[2].Text;
                    SpeDetailAdjustment.ReturnAmount = decimal.Parse(gvSpecimenLetter.Rows[i].Cells[5].Text);
                    SpeDetailAdjustment.Tran_Date = DateTime.Parse(gvSpecimenLetter.Rows[i].Cells[1].Text);
                    Li_SpecimenAdjLetterDetailManager.InsertLi_SpecimenAdjLetterDetail(SpeDetailAdjustment);

                }

                string message = "Saved Successfully.";
                string script = "  alert('";
                script += message;
                script += "');"; 

                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",                script, true);
                txtLetterNo.Text = Session["SpecimenLetter"].ToString();
                gvSpecimenLetter.DataSource = null;
            }
            catch (Exception)
            {
                
               
            }

        }

        protected void ddlTsoName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtTotalAdjustment.Text = "0.0";
                txtTotalReturn.Text = "0.0";
                gvSpecimenLetter.DataSource = null;



                decimal TotalReturn = 0.0m;
                decimal TotalAdjustment = 0.0m;


                gvSpecimenLetter.DataSource = Li_SpecimenChalanManager.getSpecimenForLetter(ddlTsoName.SelectedValue, dtpFromDate.Text, dtpToDate.Text);
                gvSpecimenLetter.DataBind();

                for (int i = 0; i < gvSpecimenLetter.Rows.Count; i++)
                {
                    decimal totalReturn = decimal.Parse(gvSpecimenLetter.Rows[i].Cells[5].Text);
                    TotalReturn += totalReturn;

                    decimal totalAdjustment = decimal.Parse(gvSpecimenLetter.Rows[i].Cells[6].Text);
                    TotalAdjustment += totalAdjustment;
                }

                txtTotalAdjustment.Text = TotalAdjustment.ToString();
                txtTotalReturn.Text = TotalReturn.ToString();

            }
            catch (Exception ex)
            {

            }
        }
        ReportDocument rd = new ReportDocument();
        DataAccessObject DAO = new DataAccessObject();
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {

                Session["result"] = null;
                rd.Load(Server.MapPath(@"~/Reports/MKT/rptSpecimenAdjustmentLetter.rpt"));
                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@LetterNo", txtLetterNo.Text);          
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Specimen Adjustment Letter ");
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
    }
}