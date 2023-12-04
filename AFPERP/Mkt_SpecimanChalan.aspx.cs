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
    public partial class Mkt_SpecimanChalan : System.Web.UI.Page
    {
        string FormID = "MF017";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    txtChalanDate.Text = string.Format("{0:dd-MM-yyyy}", DateTime.Now);
                    AddDefaultRowToGrid();
                    LoadYear();
                    LoadTso();
                    getUserAccess();
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
        //private void LoadTso()
        //{

        //    ddlTso.DataSource = Li_SalesPersonManager.GetAllLi_SalesPersons(ddlTso.Text);
        //    ddlTso.DataTextField = "Name";
        //    ddlTso.DataValueField = "TSOID";
        //    ddlTso.DataBind();
        //    ddlTso.Items.Insert(0, new ListItem("-Select-", "0"));
           
           
        //}
        private void LoadTso()
        {

            //ddlTSOName.DataSource = Li_SalesPersonManager.GetAllLi_SalesPersons(ddlTSOName.text);
            LoadComboData.LoadTSOIndo(ddlTso);
            ddlTso.DataTextField = "Name";
            ddlTso.DataValueField = "TSOID";
            ddlTso.DataBind();
            ddlTso.Items.Insert(0, new ListItem("-Select-", "0"));

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
            dt.Columns.Add("Qty", typeof(decimal));
            dt.Columns.Add("UnitPrice", typeof(decimal));
            dt.Columns.Add("TotalAmount", typeof(decimal));
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
            AddNewRecordRowToGrid();
            ClearTextData();
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
                        drCurrentRow["Qty"] = decimal.Parse(txtQty.Text);
                        drCurrentRow["TotalAmount"] = decimal.Parse(txtUnitPrice.Text) * decimal.Parse(txtQty.Text);

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
                            decimal amount = decimal.Parse(dtCurrentTable.Rows[i]["TotalAmount"].ToString());
                            totalAmount += amount;
                        }
                        txtQty.Text = string.Format("{0:0.##}", totalQuantity);
                        txtTotalAmount.Text = String.Format("{0:0.##}", totalAmount);
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
                DataTable dtCurrentTable = (DataTable)ViewState["tblChalan"];
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
            if (Decimal.Parse(txtAmountReceivable.Text) > 0.0m)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["tblChalan"];
                Li_SpecimenChalan specimen = new Li_SpecimenChalan();
                specimen.AmountReceivable = decimal.Parse(txtAmountReceivable.Text);
                specimen.CreatedBy = Session["UserID"].ToString();
                specimen.CreatedDate = DateTime.Now;//Convert.ToDateTime(txtChalanDate.Text);
                specimen.DeliveredAddress = txtDeliveredAddress.Text;
                specimen.DeliveryDate = DateTime.Now;
                specimen.MemoNo = txtMemoNo.Text;
                specimen.ModifiedBy = int.Parse(Session["UserID"].ToString());
                specimen.ModifiedDate = DateTime.Now;
                specimen.PacketNo = Int32.Parse(txtPacketNo.Text);
                specimen.PerPacketCost = decimal.Parse(txtPerPacketCost.Text);
                specimen.TotalAmount = decimal.Parse(txtTotalAmount.Text);
                specimen.TSO = ddlTso.SelectedValue.ToString();
                specimen.FreeChalan = radFreeChalan.Checked ? true : false;
                specimen.Donation = radDonationChalan.Checked ? true : false;
                string chalanID = Li_SpecimenChalanManager.InsertLi_SpecimenChalan(specimen);

                for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                {
                    Li_SpecimenChalan_Detail specimenDetails = new Li_SpecimenChalan_Detail();
                    specimenDetails.ChallanDetailsID = Guid.NewGuid().ToString();
                    specimenDetails.ChallanID = chalanID;
                    specimenDetails.BookAcCode = dtCurrentTable.Rows[i]["BookCode"].ToString();
                    specimenDetails.Qty = int.Parse(dtCurrentTable.Rows[i]["Qty"].ToString());                   
                    specimenDetails.UnitPrice = decimal.Parse(dtCurrentTable.Rows[i]["UnitPrice"].ToString());
                    specimenDetails.Edition = dtCurrentTable.Rows[i]["Edition"].ToString();
                    Li_SpecimenChalan_DetailManager.InsertLi_SpecimenChalan_Detail(specimenDetails);
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

                txtMemoNo.Text = chalanID.Substring(16).ToString();
                txtChalanId.Text = chalanID.ToString();

            }
           
            
        }

        protected void btnPrint_OnClick(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Mkt_Rpt_SpecimanMemo.aspx");
            }
            catch (Exception)
            {
                
                
            }
        }
    }
}