using BLL.Production;
using Common.Production;
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
    public partial class Pro_SutrapurLami_ItemChallan : System.Web.UI.Page
    {
        string FormID = "";
        DataAccessObject DAO = new DataAccessObject();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                // getUserAccess();
                if (!IsPostBack)
                {
                    LoadPartyName();
                    LaminationSize();
                    LoadLemiType();
                    AddDefaultFirstRecord();

                    dtpChallanDate.Text = String.Format("{0:yyyy-MM-dd}", DateTime.Now);
                }
            }
            catch (Exception)
            {


            }
        }


        private void LaminationSize()
        {


            ddlLamiSize.DataSource = Li_SutrapurLaminationManager.GetAllLi_LemiSizeBasics();
            ddlLamiSize.DataTextField = "LemiSize";
            ddlLamiSize.DataValueField = "LemiSizeID";
            ddlLamiSize.DataBind();
            ddlLamiSize.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        private void LoadLemiType()
        {
            ddlLamiType.DataSource = Li_LaminationTypeBasicManager.GetAllLi_LaminationTypeBasics();
            ddlLamiType.DataTextField = "Type";
            ddlLamiType.DataValueField = "ID";
            ddlLamiType.DataBind();
            ddlLamiType.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        private void LoadPartyName()
        {
            ddlPartyName.DataSource = Li_LeminatioPartyInfoManager.GetAllLi_LeminatioPartyInfos();
            ddlPartyName.DataTextField = "Name";
            ddlPartyName.DataValueField = "ID";
            ddlPartyName.DataBind();
            ddlPartyName.Items.Insert(0, new ListItem("--Select--", "0"));

        }
        private void AddDefaultFirstRecord()
        {
            bool fromLinkButton = false;
            //creating dataTable   
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "tblGodownRcv";
            dt.Columns.Add("Serial", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("TypeID", typeof(string));
            dt.Columns.Add("Size", typeof(string));
            dt.Columns.Add("SizeID", typeof(string));
            dt.Columns.Add("Qty", typeof(Decimal));
            dt.Columns.Add("Unit", typeof(string));
            dt.Columns.Add("Price", typeof(Decimal));
            dt.Columns.Add("Amount", typeof(Decimal));

            dr = dt.NewRow();
            dt.Rows.Add(dr);
            //saving databale into viewstate   
            ViewState["tblGodownRcv"] = dt;
            //bind Gridview  
            gvwPaperAddedData.DataSource = dt;
            gvwPaperAddedData.DataBind();

            ViewState["LinkClick"] = fromLinkButton;

        }

        private void AddNewRecordRowToGrid()
        {

            DataTable dtCurrentTable = (DataTable)ViewState["tblGodownRcv"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count == 0)
            {
                AddDefaultFirstRecord();
                txtTotalAmount.Text = "0.00";
                txtNetAmount.Text = "0.00";
                txtLabourCost.Text = "0";

            }
            else
            {
                if ((bool)ViewState["LinkClick"] == true)
                {


                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                    {
                        dtCurrentTable.Rows[i][0] = i + 1;
                        dtCurrentTable.AcceptChanges();
                    }

                    ViewState["LinkClick"] = false;
                }
                else
                {


                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {



                        //add each row into data table  
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["Serial"] = dtCurrentTable.Rows.Count + 1;

                        //if ( decimal .Parse  ( txtChlNewQty.Text )_== 0.0m ) 
                        //{
                        //    return;
                        //}

                    }

                    // New row for data table


                    drCurrentRow["Type"] = ddlLamiType.SelectedItem.Text;
                    drCurrentRow["TypeID"] = ddlLamiType.SelectedValue;
                    drCurrentRow["Size"] = ddlLamiSize.SelectedItem.Text;
                    drCurrentRow["SizeID"] = ddlLamiSize.SelectedValue;

                    drCurrentRow["Qty"] = decimal.Parse(txtQty.Text);
                    drCurrentRow["Unit"] = ddlUnit.SelectedItem.Text;
                    drCurrentRow["Price"] = decimal.Parse(txtUnitPrice.Text);
                    drCurrentRow["Amount"] = decimal.Round((decimal.Parse(txtUnitPrice.Text) * decimal.Parse(txtQty.Text)), 2);






                    //Remove initial blank row  
                    if (dtCurrentTable.Rows[0][0].ToString() == "")
                    {
                        drCurrentRow["Serial"] = dtCurrentTable.Rows.Count;
                        dtCurrentTable.Rows[0].Delete();
                        dtCurrentTable.AcceptChanges();

                    }

                    //add created Rows into dataTable  
                    dtCurrentTable.Rows.Add(drCurrentRow);
                }

                //Save Data table into view state after creating each row  

                ViewState["tblGodownRcv"] = dtCurrentTable;
                //Bind Gridview with latest Row  
                gvwPaperAddedData.DataSource = dtCurrentTable;
                gvwPaperAddedData.DataBind();

                UpdateTotalAmount(dtCurrentTable);


                ddlLamiType.SelectedIndex = -1;
                ddlLamiSize.SelectedIndex = -1;
                txtQty.Text = "";
                txtUnitPrice.Text = "";

            }
        }

        private void UpdateTotalAmount(DataTable dtCurrentTable)
        {
            decimal TotalAmnt = 0.0m;
            decimal lay_Cost = 0.0m;

            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                {
                    decimal unitTotal = decimal.Parse(dtCurrentTable.Rows[i]["Amount"].ToString());
                    TotalAmnt += unitTotal;
                }
            }
            lay_Cost = txtLabourCost.Text == "" ? 0.0m : decimal.Parse(txtLabourCost.Text);

            txtTotalAmount.Text = String.Format("{0:0.##}", TotalAmnt);
            txtNetAmount.Text = String.Format("{0:0.##}", TotalAmnt + lay_Cost);
        }
        protected void lbDelete_Click(object sender, EventArgs e)
        {
            try
            {

                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                DataTable dtCurrentTable = (DataTable)ViewState["tblGodownRcv"];
                dtCurrentTable.Rows[Convert.ToInt32(linkButton.CommandArgument) - 1].Delete();
                dtCurrentTable.AcceptChanges();
                ViewState["LinkClick"] = true;
                AddNewRecordRowToGrid();

            }
            catch (Exception)
            {


            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlPartyName.SelectedIndex < 0 || ddlPartyName.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select a Press Name.');", true);
                    ddlPartyName.Focus();
                    return;
                }

                if (ddlLamiType.SelectedIndex < 0 || ddlLamiType.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select a Type.');", true);

                    ddlLamiType.Focus();
                    return;
                }


                if (ddlLamiSize.SelectedIndex < 0 || ddlLamiSize.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select a  Size.');", true);

                    ddlLamiSize.Focus();
                    return;
                }







                if (txtQty.Text == "" || decimal.Parse(txtQty.Text) == 0.0m)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please give and qty.');", true);
                    txtQty.Focus();
                    return;
                }

                AddNewRecordRowToGrid();

            }



            catch (Exception ex)
            {

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (decimal.Parse(txtTotalAmount.Text) <= 0.0m)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please Add minimum one Item.');", true);
                return;
            }
            if (ddlPartyName.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please Select Supply Party');", true);
                return;
            }
            if (txtRefNo.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Reference No Entry Missing');", true);
                return;
            }

            SutrapurLamiItemChallan sutLami = new SutrapurLamiItemChallan();
            sutLami.RefNo = txtRefNo.Text.Trim();
            sutLami.PartyID = ddlPartyName.SelectedValue;
            sutLami.ChallanDate = DateTime.Parse(dtpChallanDate.Text);
            sutLami.TotalAmount = decimal.Parse(txtTotalAmount.Text.Trim());
            sutLami.Remarks = txtRemarks.Text.Trim();
            sutLami.CreatedBy = Int32.Parse(Session["UserID"].ToString());
            sutLami.CreatedDate = DateTime.Now;
            sutLami.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
            sutLami.ModifiedDate = DateTime.Now;
            sutLami.Status_D = 'C';
            sutLami.CauseOfDelete = "";
            Session["ChallanID"] = Li_SutrapurLaminationManager.InsertLi_SutrapurLaminationItemChallan(sutLami);

            DataTable dtCurrentTable = (DataTable)ViewState["tblGodownRcv"];
            for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
            {
                SutrapurLamiItemChallanDetails sutLamiDetails = new SutrapurLamiItemChallanDetails();
                sutLamiDetails.ChallanID = Session["ChallanID"].ToString();
                sutLamiDetails.TypeId = dtCurrentTable.Rows[i]["TypeID"].ToString();
                sutLamiDetails.SizeID = dtCurrentTable.Rows[i]["SizeID"].ToString();
                sutLamiDetails.Quantity = decimal.Parse(dtCurrentTable.Rows[i]["Qty"].ToString());
                sutLamiDetails.UnitMeasure = dtCurrentTable.Rows[i]["Unit"].ToString();
                sutLamiDetails.UnitPrice = decimal.Parse(dtCurrentTable.Rows[i]["Price"].ToString());
                sutLamiDetails.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                sutLamiDetails.CreatedDate = DateTime.Now;
                sutLamiDetails.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                sutLamiDetails.ModifiedDate = DateTime.Now;
                sutLamiDetails.Status_D = "C";
                sutLamiDetails.CauseOfDelete = "";

                Li_SutrapurLaminationManager.InsertLi_SutrapurLaminationItemChallanDetails(sutLamiDetails);
            }

            dtCurrentTable.Rows.Clear();

            txtChallanID.Text = Session["ChallanID"].ToString();

            string message = "Saved successfully.";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            script += Request.Url.AbsoluteUri;
            script += "'; }";
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);


        }

        ReportDocument rd = new ReportDocument();
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                rd.Load(Server.MapPath("~/Reports/Store/rptSutrapurLamItemChllanMemo.rpt"));
                rd.DataSourceConnections.Clear();
                rd.SetDatabaseLogon(DAO.ServerName, DAO.DatabaseName);
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@ChallanID", txtChallanID.Text);
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Sutrapur Lami. Item Chalan");
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