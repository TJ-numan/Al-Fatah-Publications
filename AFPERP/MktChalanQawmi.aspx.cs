using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Classes;

namespace BLL
{
    public partial class MktChalanQawmi : System.Web.UI.Page
    {
        string FormID = "MF016";
        bool IsDirty = false;
        string ChallanID;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");

                if (!IsPostBack)
                {
                    getUserAccess();
                    txtChalanDate.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
                    AddDefaultRowToGrid();
                    LoadYear();
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
                    if (Boolean.Parse(dt.Rows[0]["View_"].ToString()) == false)
                    {
                        Response.Redirect("~/MarketingHome.aspx");
                    }
                    if (Boolean.Parse(dt.Rows[0]["Insert_"].ToString()) == true)
                    {
                        btnSave.Enabled = true;
                    }
                    else
                    {
                        btnSave.Enabled = false;
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
        private void LoadAgent()
        {
            try
            {
                LoadComboData.LoadLibrary(ddlLibraryName, int.Parse(Session["UserID"].ToString()));
                ddlLibraryName.DataBind();
                ddlLibraryName.Items.Insert(0, new ListItem("-Select-", "0"));
            }
            catch (Exception)
            {

            }
        }
        private void AddDefaultRowToGrid()
        {
            bool linkClick = false;
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "tblChalan";
            dt.Columns.Add("Serial", typeof(int));
            dt.Columns.Add("BookCode", typeof(string));
            dt.Columns.Add("BookName", typeof(string));
            dt.Columns.Add("Class", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("Edition", typeof(string));
            //dt.Columns.Add("SpecimanQty", typeof (decimal));
            dt.Columns.Add("Qty", typeof(decimal));
            dt.Columns.Add("UnitPrice", typeof(decimal));
            //dt.Columns.Add("SpecimenAmount", typeof(decimal));
            dt.Columns.Add("SellAmount", typeof(decimal));
            dr = dt.NewRow();
            dt.Rows.Add(dr);
            gvChalan.DataSource = dt;
            gvChalan.DataBind();
            ViewState["tblChalan"] = dt;
            ViewState["LinkClick"] = linkClick;
        }
        protected void btnEnter_OnClick(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = li_BookVersionInfoManager.GetAll_BookVersionInfosWithRelation_Alia(txtBookCode.Text);
                txtBookName.Text = ds.Tables[0].Rows[0]["BookName"].ToString();
                txtType.Text = ds.Tables[0].Rows[0]["BookType"].ToString();
                txtClass.Text = ds.Tables[0].Rows[0]["ClassName"].ToString();
                ddlEdition.Text = ds.Tables[0].Rows[0]["Edition"].ToString();
                txtCurrentStock.Text = ds.Tables[0].Rows[0]["StockQuantity"].ToString();
                txtUnitPrice.Text = ds.Tables[0].Rows[0]["Price"].ToString();

                // txtBookCode.Text = string.Empty;
            }
            catch (Exception)
            {


            }

        }

        protected void txtBookCode_OnTextChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = li_BookVersionInfoManager.GetAll_BookVersionInfosWithRelation_Alia(txtBookCode.Text);
                txtBookName.Text = ds.Tables[0].Rows[0]["BookName"].ToString();
                txtType.Text = ds.Tables[0].Rows[0]["BookType"].ToString();
                txtClass.Text = ds.Tables[0].Rows[0]["ClassName"].ToString();
                ddlEdition.Text = ds.Tables[0].Rows[0]["Edition"].ToString();
                txtCurrentStock.Text = ds.Tables[0].Rows[0]["StockQuantity"].ToString();
                txtUnitPrice.Text = ds.Tables[0].Rows[0]["Price"].ToString();

                //txtBookCode.Text = string.Empty;
            }
            catch (Exception)
            {


            }
        }
        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            int stc = int.Parse(txtCurrentStock.Text.ToString());
            int qty = int.Parse(txtQty.Text.ToString());
            if (stc < qty)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Challan quantity is greater than Stock quantity');", true);
                return;
            }
            else
            {
                AddNewRecordRowToGrid();
                ClearTextData();
            }

        }
        private void ClearTextData()
        {
            txtBookCode.Text = string.Empty;
            txtBookName.Text = string.Empty;
            txtClass.Text = string.Empty;
            txtType.Text = string.Empty;
            ddlEdition.SelectedIndex = 0;
            txtCurrentStock.Text = string.Empty;
            txtUnitPrice.Text = string.Empty;
            txtQty.Text = string.Empty;
        }
        private void AddNewRecordRowToGrid()
        {

            // check view state is not null  
            if (ViewState["tblChalan"] != null)
            {
                //get datatable from view state   
                DataTable dtCurrentTable = (DataTable)ViewState["tblChalan"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count == 0)
                {
                    AddDefaultRowToGrid();
                    txtTotalAmount.Text = "0.00";
                    txtQty.Text = "0.00";

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
                        drCurrentRow["UnitPrice"] = decimal.Parse(txtUnitPrice.Text);
                        //drCurrentRow["SpecimanQty"] = decimal.Parse(txtSpecimanQty.Text);
                        drCurrentRow["Qty"] = decimal.Parse(txtQty.Text);
                        //drCurrentRow["SpecimenAmount"] = decimal.Parse(txtUnitPrice.Text) * decimal.Parse(txtSpecimanQty.Text);
                        drCurrentRow["SellAmount"] = decimal.Parse(txtUnitPrice.Text) * decimal.Parse(txtQty.Text);

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

                    ViewState["tblChalan"] = dtCurrentTable;
                    //Bind Gridview with latest Row  
                    gvChalan.DataSource = dtCurrentTable;
                    gvChalan.DataBind();


                    decimal totalQuantity = 0.0m;
                    decimal totalAmount = 0.0m;
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                        {
                            decimal qty = decimal.Parse(dtCurrentTable.Rows[i]["Qty"].ToString());
                            totalQuantity += qty;
                            decimal amount = decimal.Parse(dtCurrentTable.Rows[i]["SellAmount"].ToString());
                            totalAmount += amount;
                        }
                        txtQty.Text = string.Format("{0:0.##}", totalQuantity);
                        txtTotalAmount.Text = String.Format("{0:0.##}", totalAmount);
                        int packNo = txtPacketNo.Text != "" ? int.Parse(txtPacketNo.Text) : 0;
                        decimal PerPacCost = txtPerPacketCost.Text != "" ? decimal.Parse(txtPerPacketCost.Text) : 0.0m;
                        txtTotalPacketCost.Text = decimal.Round((packNo * PerPacCost)).ToString();
                        txtAmountReceivable.Text = String.Format("{0:0.##}", (totalAmount + (packNo * PerPacCost)).ToString());
                    }

                }
            }
        }
        private void ClearTextBoxData()
        {
            txtQty.Text = string.Empty;
            txtBookName.Text = string.Empty;
            txtType.Text = string.Empty;
            txtClass.Text = string.Empty;
            ddlEdition.SelectedIndex = 0;
            txtUnitPrice.Text = string.Empty;
            txtCurrentStock.Text = string.Empty;
            txtQty.Text = string.Empty;
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
        protected void txtPacketNo_TextChanged(object sender, EventArgs e)
        {
            try
            {

                decimal subTotal = decimal.Parse(txtTotalAmount.Text);
                int packNo = txtPacketNo.Text != "" ? int.Parse(txtPacketNo.Text) : 0;
                decimal PerPacCost = txtPerPacketCost.Text != "" ? decimal.Parse(txtPerPacketCost.Text) : 0.0m;
                txtTotalPacketCost.Text = decimal.Round((packNo * PerPacCost)).ToString();
                txtAmountReceivable.Text = (subTotal + (packNo * PerPacCost)).ToString();

            }
            catch (Exception)
            {


            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            int status = 0;
            try
            {
                if (Decimal.Parse(txtAmountReceivable.Text) > 0.0m)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["tblChalan"];
                    li_Challan _chalan = new li_Challan();

                    //Generating challanID 

                    ChallanID = "CHL" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
                    _chalan.MemoNo = txtMemoNo.Text;
                    _chalan.TotalAmount = txtTotalAmount.Text != "" ? decimal.Parse(txtTotalAmount.Text) : 0;
                    _chalan.AmountReceivable = txtAmountReceivable.Text != "" ? decimal.Parse(txtAmountReceivable.Text) : 0;
                    _chalan.CreatedDate = Convert.ToDateTime(txtChalanDate.Text);
                    _chalan.CreatedBy = Session["UserID"].ToString();
                    _chalan.ModifiedBy = int.Parse(Session["UserID"].ToString());
                    _chalan.ModifiedDate = DateTime.Now;
                    _chalan.DeliveredBy = txtDeliveredBy.Text;
                    _chalan.DeliveryDate = DateTime.Now;
                    //_chalan.Bonus = decimal.Parse(txtSpcialDiscount.Text);
                    _chalan.Bonus = 0.0m;
                    _chalan.LibraryID = ddlLibraryName.SelectedValue.ToString();
                    _chalan.PacketNo = Int32.Parse(txtPacketNo.Text);
                    _chalan.PerPacketCost = decimal.Parse(txtPerPacketCost.Text);
                    _chalan.IsBonuChalan = radBChalan.Checked ? true : false;
                    _chalan.AlimBonus = radAlimBonus.Checked ? true : false;
                    _chalan.AlimSpecial = radAlimSpecial.Checked ? true : false;
                    _chalan.DakhilBonus = radBBonus.Checked ? true : false;

                    //_chalan.Comp = ddlCompany.SelectedIndex == 0 ? "A" : "Q";
                    _chalan.Comp = "Q";
                    string returnchalanID = li_ChallanManager.Insert_Challan_Qawmi(_chalan);
                    txtMemoNo.Text = returnchalanID.Substring(13).ToString();

                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                    {

                        li_ChallanDetails chldtl = new li_ChallanDetails();
                        chldtl.ChallanID = returnchalanID;
                        chldtl.BookAcCode = dtCurrentTable.Rows[i]["BookCode"].ToString();
                        chldtl.Qty = int.Parse(dtCurrentTable.Rows[i]["Qty"].ToString());
                        chldtl.UnitPrice = decimal.Parse(dtCurrentTable.Rows[i]["UnitPrice"].ToString());
                        chldtl.Specimen = 0;// Int32.Parse(dtCurrentTable.Rows[i]["SpecimanQty"].ToString());
                        chldtl.Edition = dtCurrentTable.Rows[i]["Edition"].ToString();

                        chldtl.CreatedDate = DateTime.Now;
                        chldtl.BonusPercentage = 0;//decimal.Parse(dtCurrentTable.Rows[i]["SpecimenAmount"].ToString());
                        chldtl.Boishaki = radRegular.Checked ? true : false;
                        chldtl.AlimBonus = radAlimBonus.Checked ? true : false;
                        chldtl.AlimSpecial = radAlimSpecial.Checked ? true : false;
                        chldtl.DakhilBonus = radBBonus.Checked ? true : false;
                        //now insert to the database
                        status = li_ChallanDetailsManager.Insert_ChallanDetails_Qawmi(chldtl);

                    }
                    txtMemoNo.Text = returnchalanID.Substring(13).ToString();
                    string message = "Saved Successfully!";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "');";
                    script += "window.location = '";
                    script += Request.Url.AbsoluteUri;
                    script += "'; }";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script,
                        true);

                    // txtMemoNo.Text = returnchalanID .Remove(0, returnchalanID.Length   - 6);
                    txtMemoNo.Text = returnchalanID.Substring(13).ToString();



                }
            }
            catch (Exception)
            {
                
              
            }


        }

        protected void btnPrint_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Mkt_Rpt_ChalanMemoQawmi.aspx");
        }
    }
}