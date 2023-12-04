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
    public partial class MktReturnBooks : System.Web.UI.Page
    {
        string FormID = "MF010";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!Page.IsPostBack)
                {
                    getUserAccess();
                    txtReturnId.Focus();
                    LoadAgent();
                    LoadYear();
                    dtpReturnDate.Text = string.Format("{0:dd-MM-yyy}", DateTime.Now);
                    AddDefaultFirstRecord();
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
        private void LoadAgent()
        {
            try
            {
                LoadComboData.LoadLibrary(ddlLibraryName, int.Parse(Session["UserID"].ToString()));
                ddlLibraryName.DataBind();
                ddlLibraryName.Items.Insert(0, new ListItem("-Select-","0"));
            }
            catch (Exception)
            {

            }
        }
        private void LoadYear()
        {
            ddlEdition.DataSource = li_ChallanManager.LoadYear().Tables[0];
            ddlEdition.DataTextField = "Edition";
            ddlEdition.DataBind();

            ddlEdition.Items.Insert(0, new ListItem("-Select-", "0"));
        }

        protected void ddlEdition_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = li_BookVersionInfoManager.GetAll_BookVersionInfosWithEdition(txtBookCode.Text + "/" + ddlEdition.Text);
                ddlEdition.Text = ds.Tables[0].Rows[0]["Edition"].ToString();               
                txtUnitPrice.Text = ds.Tables[0].Rows[0]["Price"].ToString();

            }

            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }

        private void AddDefaultFirstRecord()
            {
            bool fromLinkButton = false;
            int result = 0;
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "tblReturn";
            dt.Columns.Add("Serial", typeof(string));
            dt.Columns.Add("BookCode", typeof(string));
            dt.Columns.Add("BookName", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("Class", typeof(string));
            dt.Columns.Add("Edition", typeof(string));            
            dt.Columns.Add("Qty", typeof(Decimal));
            dt.Columns.Add("DamageQty", typeof(Decimal));
            dt.Columns.Add("UnitPrice", typeof(Decimal));
            dt.Columns.Add("DiscountPer", typeof(decimal));
            dt.Columns.Add("DamageAmount", typeof (decimal));
            dt.Columns.Add("Discount", typeof(Decimal));
            dt.Columns.Add("ReturnAmount", typeof(Decimal));
            dr = dt.NewRow();
            dt.Rows.Add(dr);
            ViewState["tblReturn"] = dt;
            gvwReturn.DataSource = dt;
            gvwReturn.DataBind();
            ViewState["LinkClick"] = fromLinkButton;
            Session["ResultMemo"] = result;
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                AddNewRecordToGrid();
                ClearTextData();
            }
            catch (Exception)
            {
                
                
            }
                        
        }

        private void ClearTextData()
        {
           // txtBookCode.Text = string.Empty;
            txtBookName.Text = string.Empty;
            txtClass.Text = string.Empty;
            txtType.Text = string.Empty;
            ddlEdition.SelectedIndex = 0;            
            txtQty.Text = string.Empty;
            txtUnitPrice.Text = string.Empty;
            txtDiscount.Text = string.Empty;
            txtDamage.Text = string.Empty;
        }

        private void AddNewRecordToGrid()
        {
            DataTable dtCurrentTable = (DataTable)ViewState["tblReturn"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count == 0)
            {
                //txtReturnAmount.Text = "0.00";
                //txtPacketNo.Text = "0";
                //txtPerPacketCost.Text = "0.00";
                //txtTotalPacketCost.Text = "0.00";
                //txtTotalDiscount.Text = "0.00";
                //txtAmountPayable.Text = "0.00";
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

                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["Serial"] = dtCurrentTable.Rows.Count + 1;
                    }
                    if (drCurrentRow != null)
                    {
                        drCurrentRow["BookCode"] = txtBookCode.Text;
                        drCurrentRow["BookName"] = txtBookName.Text;
                        drCurrentRow["Type"] = txtType.Text;
                        drCurrentRow["Class"] = txtClass.Text;
                        drCurrentRow["Edition"] = ddlEdition.SelectedItem;
                        drCurrentRow["Qty"] =txtQty.Text.Trim() == "" ? 0.0m :decimal.Parse(txtQty.Text);
                        drCurrentRow["DamageQty"] =txtDamage.Text.Trim() == "" ? 0.0m : decimal.Parse(txtDamage.Text);
                        //drCurrentRow["Discount"] = decimal.Parse(txtDiscount.Text);
                        drCurrentRow["UnitPrice"] = decimal.Parse(txtUnitPrice.Text);
                        drCurrentRow["DiscountPer"] = decimal.Parse(txtDiscount.Text);
                        drCurrentRow["DamageAmount"] = decimal.Parse(txtUnitPrice.Text) * 0;
                        drCurrentRow["Discount"] = decimal.Round((decimal.Parse(txtQty.Text) * decimal.Parse(txtUnitPrice.Text) * decimal.Parse(txtDiscount.Text) * 0.01m), 2);
                        decimal sellAmount = txtQty.Text != "" ? (decimal.Parse(txtUnitPrice.Text) * Int32.Parse(txtQty.Text)) : 0.00m;
                        drCurrentRow["ReturnAmount"] = sellAmount;
                       

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
                }
                ViewState["tblReturn"] = dtCurrentTable;
                //Bind Gridview with latest Row  
                gvwReturn.DataSource = dtCurrentTable;
                gvwReturn.DataBind();
                decimal subTotal = 0.0m;
                decimal totalDiscount = 0.0m;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                    {
                        decimal unitTotal = decimal.Parse(dtCurrentTable.Rows[i]["ReturnAmount"].ToString());
                        subTotal += unitTotal;

                        decimal totDis = decimal.Parse(dtCurrentTable.Rows[i]["Discount"].ToString());
                        totalDiscount += totDis;
                    }
                }

                txtReturnAmount.Text = subTotal.ToString();
                txtTotalDiscount.Text = totalDiscount.ToString();
                int packNo = txtPacketNo.Text != "" ? int.Parse(txtPacketNo.Text) : 0;

                decimal PerPacketCost = txtPerPacketCost.Text != "" ? decimal.Parse(txtPerPacketCost.Text) : 0.0m;

                txtAmountPayable.Text = (subTotal + (packNo * PerPacketCost) - totalDiscount).ToString();

               
            }

        }

        protected void txtPacketNo_TextChanged(object sender, EventArgs e)
        {
            try
            {

               
            }
            catch (Exception)
            {


            }
        }
        protected void txtPerPacketCost_OnTextChanged(object sender, EventArgs e)
        {
            decimal returnAmount = decimal.Parse(txtReturnAmount.Text);
            int packNo = txtPacketNo.Text != "" ? int.Parse(txtPacketNo.Text) : 0;
            decimal PerPacCost = txtPerPacketCost.Text != "" ? decimal.Parse(txtPerPacketCost.Text) : 0.0m;
            txtTotalPacketCost.Text = decimal.Round((packNo * PerPacCost)).ToString();
            txtAmountPayable.Text = (returnAmount + (packNo * PerPacCost)).ToString();

        }
        protected void lblDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lbtn = new LinkButton();
                lbtn = (LinkButton)sender;
                DataTable dtCurrentTable = (DataTable)ViewState["tblReturn"];
                dtCurrentTable.Rows[Convert.ToInt32(lbtn.CommandArgument) - 1].Delete();
                dtCurrentTable.AcceptChanges();
                ViewState["LinkClick"] = true;
                AddNewRecordToGrid();
            }
            catch (Exception)
            {


            }
        }
        protected void txtBookCode_OnTextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBookCode != null)
                {
                    DataSet ds = new DataSet();
                    ds = li_BookVersionInfoManager.GetAll_BookVersionInfosWithRelation(txtBookCode.Text);
                    txtBookName.Text = ds.Tables[0].Rows[0]["BookName"].ToString();
                    txtType.Text = ds.Tables[0].Rows[0]["BookType"].ToString();
                    txtClass.Text = ds.Tables[0].Rows[0]["ClassName"].ToString();
                    ddlEdition.Text = ds.Tables[0].Rows[0]["Edition"].ToString();                 
                    txtUnitPrice.Text = ds.Tables[0].Rows[0]["Price"].ToString();
                    txtDiscount.Text = ds.Tables[0].Rows[0]["Bonus"].ToString();
                    txtQty.Focus();
                }
                else
                {
                    txtBookCode.Text = "Enter";

                }
            }
            catch (Exception)
            {


            }


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string returnID = "";
                if (ddlLibraryName.SelectedIndex > 0.0m)
                {
                    if (Decimal.Parse(txtAmountPayable.Text) > 0.0m)
                    {
                        DataTable dtCurrentTable = (DataTable)ViewState["tblReturn"];
                        if (dtCurrentTable.Rows.Count > 0)
                        {
                            li_Return aReturn = new li_Return();
                            aReturn.ReturnID = txtReturnId.Text;
                            aReturn.ChallanID = "";
                            aReturn.LibraryID = ddlLibraryName.SelectedValue;
                            aReturn.ReturnDate = DateTime.Parse(dtpReturnDate.Text);
                            aReturn.TotalAmount = decimal.Parse(txtReturnAmount.Text);                           
                            aReturn.BookReceivedBy = Convert.ToInt32(Session["UserID"].ToString());
                            aReturn.DamageAmount = 0;
                            aReturn.MemoNo = txtMemoNo.Text;
                            aReturn.PacketNo = int.Parse(txtPacketNo.Text);
                            aReturn.PerPacketCost = decimal.Parse(txtPerPacketCost.Text);
                            aReturn.SpcimenTotal = 0;
                            aReturn.DiscountAmount = decimal.Parse(txtTotalDiscount.Text);                          
                            Session["RetuenID"] = li_ReturnManager.Insert_Return(aReturn);
                            for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                            {

                                li_ReturnDetails ReturnDetails = new li_ReturnDetails();
                                ReturnDetails.BookAcCode = dtCurrentTable.Rows[i]["BookCode"].ToString();
                                ReturnDetails.Qty = int.Parse(dtCurrentTable.Rows[i]["Qty"].ToString());
                                ReturnDetails.UnitPrice = decimal.Parse(dtCurrentTable.Rows[i]["UnitPrice"].ToString());
                                ReturnDetails.Edition = dtCurrentTable.Rows[i]["Edition"].ToString();
                                ReturnDetails.DiscountPercentage = decimal.Parse(dtCurrentTable.Rows[i]["DiscountPer"].ToString());                              
                                ReturnDetails.ReturnID = Session["RetuenID"].ToString();
                                li_ReturnDetailsManager.Insert_ReturnDetails(ReturnDetails);


                            }

                            dtCurrentTable.Rows.Clear();
                            txtReturnId.Text = Session["RetuenID"].ToString();
                            ClearAllData();

                            ddlLibraryName.Focus();
                            AddDefaultFirstRecord();

                            string message = "Saved successfully.";
                            string script = "window.onload = function(){ alert('";
                            script += message;
                            script += "');";
                            script += "window.location = '";
                            script += Request.Url.AbsoluteUri;
                            script += "'; }";
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);
                            txtMemoNo.Text = Session["RetuenID"].ToString(); 
                        }
                    }

                }
            }
            catch (Exception)
            {


            }
        }

        private void ClearAllData()
        {


            txtReturnAmount.Text = "";
            txtAmountPayable.Text = "";
            txtTotalPacketCost.Text = "";
            txtBookName.Text = "";
            txtPacketNo.Text = "0";
            txtPerPacketCost.Text = "0";
        }


        protected void btnPrint_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Mkt_Rpt_ReturnByMemoNo.aspx");
        }
    }
}