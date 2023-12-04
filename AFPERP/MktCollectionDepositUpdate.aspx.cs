using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Marketing;
using Common.Marketing;
using System.Data;
using BLL.Classes;

namespace BLL
{
    public partial class MktCollectionDepositUpdate : System.Web.UI.Page
    {
        string FormID = "MF009";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    getUserAccess();
                    LoadDepositFor();
                    LoadLibrary();
                    LoadTransactionTypes();
                    LoadBank();
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
                        //btnPrint.Enabled = true;
                    }
                    else
                    {
                        //btnPrint.Enabled = false;
                    }
                    if (Boolean.Parse(dt.Rows[0]["Update_"].ToString()) == true)
                    {
                        btnUpdate.Enabled = true;
                    }
                    else
                    {
                        btnUpdate.Enabled = false;
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
        private void LoadLibrary()
        {

            try
            {
                lblAssetList.Visible = false;
                ddlAssetList.Visible = false;

                if (ddlLibraryName.Items.Count > 0)
                {
                    ddlLibraryName.Items.Clear();
                    ddlAssetList.Items.Clear();

                }


                if (ddlDepositFor.SelectedValue == "6")
                {
                    ddlLibraryName.DataSource = Li_Dam_PartyManager.GetAllLi_Dam_Parties();
                    ddlLibraryName.DataTextField = "PartName";
                    ddlLibraryName.DataValueField = "PartyID";
                    ddlLibraryName.DataBind();
                    ddlLibraryName.Items.Insert(0, new ListItem("--select--", "0"));
                    return;

                }

                if (ddlDepositFor.SelectedValue == "7")
                {

                    ddlLibraryName.DataSource = Li_Dam_Oth_PartyManager.GetAllLi_Dam_Oth_Parties();
                    ddlLibraryName.DataTextField = "PartName";
                    ddlLibraryName.DataValueField = "PartyID";
                    ddlLibraryName.DataBind();
                    ddlLibraryName.Items.Insert(0, new ListItem("--select--", "0"));
                    return;
                }



                if (ddlDepositFor.SelectedValue == "8")
                {
                    lblAssetList.Visible = true;
                    ddlAssetList.Visible = true;

                    ddlLibraryName.DataSource = Li_HouseRent_PartyManager.GetAllLi_HouseRent_Parties();
                    ddlLibraryName.DataTextField = "PartName";
                    ddlLibraryName.DataValueField = "PartyID";
                    ddlLibraryName.DataBind();
                    ddlLibraryName.Items.Insert(0, new ListItem("--select--", "0"));
                    LoadComboData.LaodAssetList(ddlAssetList);
                    return;


                }

                List<li_LibraryInformation> li_LibraryInformation = new List<li_LibraryInformation>();
                li_LibraryInformation = li_LibraryInformationManager.GetAll_ComboBox_LibraryInformations();
                ddlLibraryName.DataSource = li_LibraryInformation;
                ddlLibraryName.DataTextField = "LibraryName";
                ddlLibraryName.DataValueField = "LibraryID";
                ddlLibraryName.DataBind();
                ddlLibraryName.Items.Insert(0, new ListItem("--select--", "0"));

            }
            catch (Exception rt)
            {
            }
        }

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
        private void LoadTransactionTypes()
        {
            ddlDepositeType.DataSource = Li_TransectionTypeManager.GetAllLi_TransectionTypes();
            ddlDepositeType.DataTextField = "TranbType";
            ddlDepositeType.DataValueField = "TannID";
            ddlDepositeType.DataBind();
            ddlDepositeType.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        private void LoadBank()
        {
            ddlBankName.DataSource = Li_BankNameManager.GetAllLi_BankNames();
            ddlBankName.DataTextField = "BankName";
            ddlBankName.DataValueField = "BankCode";
            ddlBankName.DataBind();
            ddlBankName.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        protected void btnUpdate_OnClick(object sender, EventArgs e)
        {
            if (txtMemoNo.Text != string.Empty)
            {
                Li_Deposit deposit = new Li_Deposit();
                deposit.Alim = false;
                deposit.AmountOfMoney = txtAmount.Text != "" ? decimal.Parse(txtAmount.Text) : 0.0m;
                deposit.BankAddress = txtBankAddress.Text;
                deposit.BankCode = ddlBankName.SelectedValue.ToString();
                deposit.BankSlipNo = txtDDNo.Text;
                deposit.Boishaki = false;
                deposit.CauseOfDelete = "";
                deposit.ClearDate = Convert.ToDateTime(txtClearanceDate.Text);
                deposit.Dele_By = int.Parse(Session["UserID"].ToString());
                deposit.Deledate = DateTime.Now;
                deposit.DepositedDate = Convert.ToDateTime(txtDepositedDate.Text);
                deposit.DepositeTpe = Int32.Parse(ddlDepositeType.SelectedValue.ToString());
                deposit.LibraryID = ddlLibraryName.SelectedValue.ToString();
                deposit.MRDate = Convert.ToDateTime(txtMemoDate.Text);
                deposit.Remark = txtRemarks.Text;
                deposit.Status_D = 'C';
                deposit.VrifiedBy = txtVerifiedBy.Text;
                deposit.Dam_BookSale = false;
                deposit.Dam_Other = false;
                deposit.HouseRent = false;
                deposit.Others = false;
                deposit.Comp = ddlCom.SelectedIndex == 0 ? "A" : "Q";
                deposit.DepositForId = Int32.Parse(ddlDepositFor.SelectedValue);
                deposit.AssetList = Int32.Parse(ddlDepositFor.SelectedValue) == 8 ? Int32.Parse(ddlAssetList.SelectedValue) : 0;
                deposit.MRno = txtMemoNo.Text;
               
                Li_DepositManager.UpdateLi_Deposit(deposit);

                string message = "Updated successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += Request.Url.AbsoluteUri;
                script += "'; }";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",
                script, true);

            }

        }

        protected void txtMemoNo_OnSelectedTextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtMemoNo.Text != string.Empty)
                {
                    string memoNo = txtMemoNo.Text;
                    if (memoNo != string.Empty && ddlCom.SelectedValue == "0")
                    {
                        List<li_DepositInformation> depositInfo = li_DepositInformationManager.GetDepositInformationByMRno(memoNo);
                        if (depositInfo.Count == 0)
                        {
                            string message = "MR No is not valid for Company Alia or Over 7 Days ";
                            string script = "window.onload = function(){ alert('";
                            script += message;
                            script += "');";
                            script += "window.location = '";
                            script += Request.Url.AbsoluteUri;
                            script += "'; }";
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "MR is not valid",
                            script, true);
                        }
                        else
                        {

                            lblAssetList.Visible = false;
                            ddlAssetList.Visible = false;

                            foreach (var information in depositInfo)
                            {
                                txtMemoDate.Text = string.Format("{0:yyyy-MM-dd}", information.MRDate);
                                txtAmount.Text = information.AmountOfMoney.ToString();
                                txtDDNo.Text = information.BankSlipNo.ToString();
                                txtDepositedDate.Text = string.Format("{0:yyyy-MM-dd}", information.DepositedDate);
                                txtClearanceDate.Text = string.Format("{0:yyyy-MM-dd}", information.ClearDate);
                                ddlBankName.SelectedValue = Convert.ToString(information.BankCode);
                                //ddlLibraryName.SelectedValue = Convert.ToString(information.LibraryID);
                                ddlDepositeType.SelectedValue = Convert.ToString(information.TrannID);
                                ddlDepositFor.SelectedValue = Convert.ToString(information.DepositForID);
                                LoadLibrary();

                                ddlLibraryName.SelectedValue = Convert.ToString(information.LibraryID);

                                txtBankAddress.Text = information.BankAddress;
                                txtDDNo.Text = information.BankSlipNo;
                                txtRemarks.Text = information.Remark;
                                txtVerifiedBy.Text = information.VerifiedBy;
                                ddlAssetList.SelectedValue = Convert.ToString(information.AssetId);
                            }
                        }
                    }
                    else if (txtMemoNo.Text != string.Empty && ddlCom.SelectedValue == "1")
                    {
                        List<li_DepositInformation> depositInfo = li_DepositInformationManager.GetDepositInformationByMRno_Q(memoNo);
                        if (depositInfo.Count == 0)
                        {
                            string message = "MR No is not valid for Company Qawmi or Over 7 Days";
                            string script = "window.onload = function(){ alert('";
                            script += message;
                            script += "');";
                            script += "window.location = '";
                            script += Request.Url.AbsoluteUri;
                            script += "'; }";
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",
                            script, true);
                        }
                        else
                        {
                            foreach (var information in depositInfo)
                            {

                                txtMemoDate.Text = string.Format("{0:yyyy-MM-dd}", information.MRDate);
                                txtAmount.Text = information.AmountOfMoney.ToString();
                                txtDDNo.Text = information.BankSlipNo.ToString();
                                txtDepositedDate.Text = string.Format("{0:yyyy-MM-dd}", information.DepositedDate);
                                txtClearanceDate.Text = string.Format("{0:yyyy-MM-dd}", information.ClearDate);
                                ddlBankName.SelectedValue = information.BankCode;
                                ddlDepositFor.SelectedValue = Convert.ToString(information.DepositForID);

                                ddlLibraryName.SelectedValue = information.LibraryID;
                                ddlDepositeType.SelectedValue = Convert.ToString(information.TrannID);
                                txtBankAddress.Text = information.BankAddress;
                                txtDDNo.Text = information.BankSlipNo;
                                txtRemarks.Text = information.Remark;
                                txtVerifiedBy.Text = information.VerifiedBy;
                            }

                        }
                    }               
                    
                }
               
            }
            catch (Exception)
            {


            }
        }

        protected void ddlDepositFor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadLibrary();
            }
            catch (Exception)
            {

            }
        }

    }
}