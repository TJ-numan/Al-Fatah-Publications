using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Mkt_SpecimanReturn : System.Web.UI.Page
    {
        string FormID = "MF018";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    getUserAccess();
                    dtpReturnDate.Text = string.Format("{0:dd-MM-yyyy}", DateTime.Now);
                    LoadYear();
                    LoadTso();
                    AddDefaultRowToGrid();
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
                    if (Boolean.Parse(dt.Rows[0]["View_"].ToString()) == false)
                    {
                        Response.Redirect("~/MarketingHome.aspx");
                    }
                    if (Boolean.Parse(dt.Rows[0]["Insert_"].ToString()) == true)
                    {
                        btnSave.Enabled = true;
                        btnPrint.Enabled = true;
                    }
                    else
                    {
                        btnSave.Enabled = false;
                        btnPrint.Enabled = false;
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
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }
        private void LoadYear()
        {
            ddlEdition.DataSource = li_ChallanManager.LoadYear().Tables[0];
            ddlEdition.DataTextField = "Edition";
            ddlEdition.DataBind();
            ddlEdition.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        private void LoadTso()
        {

            ddlTsoName.DataSource = Li_SalesPersonManager.GetAllLi_SalesPersons(ddlTsoName.Text);
            ddlTsoName.DataTextField = "Name";
            ddlTsoName.DataValueField = "TSOID";
            ddlTsoName.DataBind();
            ddlTsoName.Items.Insert(0, new ListItem("-Select-", "0"));


        }

        private void AddDefaultRowToGrid()
        {
            bool linkClick = false;
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "tblReturn";
            dt.Columns.Add("Serial", typeof(int));
            dt.Columns.Add("BookCode", typeof(string));
            dt.Columns.Add("BookName", typeof(string));
            dt.Columns.Add("Class", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("Edition", typeof(string));
            dt.Columns.Add("Price", typeof(decimal));
            dt.Columns.Add("Qty", typeof(decimal));
            dt.Columns.Add("AQty", typeof(decimal));
            dt.Columns.Add("RAmount", typeof(decimal));
            dt.Columns.Add("AdAmount", typeof(decimal));
            dr = dt.NewRow();
            dt.Rows.Add(dr);
            gvwReturn.DataSource = dt;
            gvwReturn.DataBind();
            ViewState["tblReturn"] = dt;
            ViewState["LinkClick"] = linkClick;
        }
        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            AddNewRecordRowToGrid();
            ClearTextData();
          
        }
        private void AddNewRecordRowToGrid()
        {

            // check view state is not null  
            if (ViewState["tblReturn"] != null)
            {
                //get datatable from view state   
                DataTable dtCurrentTable = (DataTable)ViewState["tblReturn"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count == 0)
                {
                    AddDefaultRowToGrid();
                  
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

                        }

                        // New row for data table

                        drCurrentRow["BookCode"] = txtBookCode.Text;
                        drCurrentRow["BookName"] = txtBookName.Text;
                        drCurrentRow["Class"] = txtClass.Text;
                        drCurrentRow["Type"] = txtClass.Text;
                        drCurrentRow["Edition"] = ddlEdition.SelectedValue;
                        drCurrentRow["Price"] = decimal.Parse(txtUnitPrice.Text);
                        drCurrentRow["Qty"] = decimal.Parse(txtReturnQty.Text);
                        drCurrentRow["AQty"] = decimal.Parse(txtAdjustmentQty.Text);
                        drCurrentRow["RAmount"] = decimal.Parse(txtUnitPrice.Text)*decimal.Parse(txtReturnQty.Text);
                        drCurrentRow["AdAmount"] = decimal.Parse(txtUnitPrice.Text)*decimal.Parse(txtAdjustmentQty.Text);

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

                    ViewState["tblReturn"] = dtCurrentTable;
                    //Bind Gridview with latest Row  
                    gvwReturn.DataSource = dtCurrentTable;
                    gvwReturn.DataBind();
                    decimal returnAmount = 0.0m;
                    decimal adjustmentAmount = 0.0m;
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                        {
                            decimal rAmount = decimal.Parse(dtCurrentTable.Rows[i]["RAmount"].ToString());
                            returnAmount += rAmount;
                            decimal adAmount = decimal.Parse(dtCurrentTable.Rows[i]["AdAmount"].ToString());
                            adjustmentAmount += adAmount;
                        }
                        txtTotalReturnAmount.Text = string.Format("{0:0.##}", returnAmount);
                        txtTotalAdjustAmount.Text = String.Format("{0:0.##}", adjustmentAmount);
                    }

                }
            }
        }
        private void ClearTextData()
        {
            txtBookCode.Text = string.Empty;
            txtBookName.Text = string.Empty;
            txtClass.Text = string.Empty;
            txtType.Text = string.Empty;
            ddlEdition.SelectedIndex = 0;
            txtReturnQty.Text = string.Empty;
            txtUnitPrice.Text = string.Empty;
            txtAdjustmentQty.Text = string.Empty;
        }
        protected void txtBookCode_OnTextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBookCode.Text != "")
                {


                    DataSet ds = new DataSet();
                    ds = li_BookVersionInfoManager.GetAll_BookVersionInfosWithRelation(txtBookCode.Text);
                    txtBookName.Text = ds.Tables[0].Rows[0]["BookName"].ToString();
                    txtType.Text = ds.Tables[0].Rows[0]["BookType"].ToString();
                    txtClass.Text = ds.Tables[0].Rows[0]["ClassName"].ToString();
                    ddlEdition.Text = ds.Tables[0].Rows[0]["Edition"].ToString();               
                    txtUnitPrice.Text = ds.Tables[0].Rows[0]["Price"].ToString();

                    txtReturnQty.Focus();
                }
                else
                {
                    txtBookName.Text = "";
                    txtType.Text = "";
                    txtClass.Text = "";
                    ddlEdition.SelectedIndex = 0;
                    txtUnitPrice.Text = "";
                }

            }
            catch (Exception)
            {
               
              
            }
        }

        protected void lblDelete_OnClick(object sender, EventArgs e)
        {
            try
            {

                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                DataTable dtCurrentTable = (DataTable)ViewState["tblSpecimanChalan"];
                dtCurrentTable.Rows[Convert.ToInt32(linkButton.CommandArgument) - 1].Delete();
                dtCurrentTable.AcceptChanges();
                ViewState["LinkClick"] = true;
                AddNewRecordRowToGrid();


            }
            catch (Exception)
            {


            }
           
        }       
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (Decimal.Parse(txtTotalAdjustAmount.Text) > 0.0m)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["tblReturn"];
                Li_Specimen_Return spreturn = new Li_Specimen_Return();
                spreturn.AdjustedAmount = decimal.Parse(txtTotalAdjustAmount.Text);
                //spreturn.AmountPayable = txtAmountReceivable.Text != "" ? decimal.Parse(txtAmountReceivable.Text) : 0.0m;
                spreturn.AmountPayable = 0.0m;
                spreturn.CreatedBy = Session["UserID"].ToString();
                spreturn.CreatedDate = Convert.ToDateTime(dtpReturnDate.Text);
                spreturn.MemoNo = txtMemoNo.Text;
                spreturn.DeliveredBy = txtDeliveredBy.Text;              
                spreturn.ModifiedBy = int.Parse(Session["UserID"].ToString());
                spreturn.ModifiedDate = DateTime.Now;
                //spreturn.PacketNo = txtPecketNo.Text != "" ? Int32.Parse(txtPecketNo.Text) : 0;
                spreturn.PacketNo = 0;
               //spreturn.PerPacketCost = txtPerPacketCost.Text != "" ? decimal.Parse(txtPerPacketCost.Text) : 0.0m;
                spreturn.PerPacketCost = 0.0m;
                spreturn.ReceiveDate = DateTime.Now;
                spreturn.TotalAmount = decimal.Parse(txtTotalReturnAmount.Text);
                spreturn.TSO = ddlTsoName.SelectedValue.ToString();
                spreturn.Donation = chkDonation.Checked ? true : false;
                string retID = Li_Specimen_ReturnManager.InsertLi_Specimen_Return(spreturn);

                for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                {
                    Li_Specimen_ReturnDetail specimenDetails = new Li_Specimen_ReturnDetail();
                    specimenDetails.ReturnDetailsID = Guid.NewGuid().ToString();
                    specimenDetails.ReturnID = retID;
                    specimenDetails.BookAcCode = dtCurrentTable.Rows[i]["BookCode"].ToString() + "/" +
                                                 dtCurrentTable.Rows[i]["Edition"].ToString();
                    specimenDetails.Qty = int.Parse(dtCurrentTable.Rows[i]["Qty"].ToString());
                    specimenDetails.UnitPrice = decimal.Parse(dtCurrentTable.Rows[i]["Price"].ToString());
                    specimenDetails.AdjustQty = Int32.Parse(dtCurrentTable.Rows[i]["AQty"].ToString());

                    Li_Specimen_ReturnDetailManager.InsertLi_Specimen_ReturnDetail(specimenDetails);
                }
                string message = "Saved Successfully!";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += Request.Url.AbsoluteUri;
                script += "'; }";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script,
                    true);
                txtReturnId.Text = retID.ToString();
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Mkt_Rpt_SpecimanAdjustmentMemo.aspx");
            }
            catch (Exception)
            {


            }
        }
    }
}