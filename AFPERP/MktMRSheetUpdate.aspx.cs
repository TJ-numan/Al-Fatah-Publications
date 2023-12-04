using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using BLL.Marketing;
using Common.Marketing;

namespace BLL
{
    public partial class MktMRSheetUpdate : System.Web.UI.Page
    {
        string FormID = "MF043";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                     
                    LoadLibrary();
                    //LoadCashLibrary();
                    LoadComboData.LoadDepositFor(ddlDepositFor);



                    decimal totalAmount = 0.0m;

                    LoadComboData.LoadBank(ddlBank);
                    LoadComboData.LoadTransactionTypes(ddlDepositType);



                    if (Request.QueryString["SheetNo"] != null || Request.QueryString["SheetNo"] != "")
                    {
                        ViewState["SheetNo"] = Request.QueryString["SheetNo"];
                        ViewState["SendBefore"] = Request.QueryString["SendBefore"];
                        ViewState["HeldUp"] = Request.QueryString["HeldUp"];

                        txtMRId.Text = ViewState["SheetNo"].ToString();
                        chkHeldUp.Checked = bool.Parse(ViewState["HeldUp"].ToString());
                        chkIsAlSend.Checked = bool.Parse(ViewState["SendBefore"].ToString());

                        DataTable dt = new DataTable();



                        if (bool.Parse(ViewState["SendBefore"].ToString()) == false && bool.Parse(ViewState["HeldUp"].ToString()) == false)
                        {
                            btnUpdate.Enabled = true;
                            btnUpdateSend.Enabled = true;

                            dt = Li_MRSheetManager.Get_MRSheetNoWiseDetails(Int32.Parse(ViewState["SheetNo"].ToString()));
                             
                            if (dt.Rows.Count > 0)
                            {
                                gvMRSheetDetailsUpdate.DataSource = dt;
                                gvMRSheetDetailsUpdate.DataBind();

                                for (int i = 0; i < gvMRSheetDetailsUpdate.Rows.Count; i++)
                                {
                                    decimal totalAmtRow = Convert.ToDecimal(gvMRSheetDetailsUpdate.Rows[i].Cells[12].Text);
                                    totalAmount += totalAmtRow;
                                }

                                txtTotalAmount.Text = totalAmount.ToString();
                            }

                        }




                        else if  (bool.Parse(ViewState["SendBefore"].ToString()) ==   true   && bool.Parse(ViewState["HeldUp"].ToString()) ==  true )
                        {
                            btnUpdate.Enabled = true;
                            btnUpdateSend.Enabled = true;
                            dt = Li_MRSheetManager.  Get_MRSheetNoWiseDetailsForDoMR(Int32.Parse(ViewState["SheetNo"].ToString()), true ,0);
                             
                            if (dt.Rows.Count > 0)
                            {
                                gvMRSheetDetailsUpdate.DataSource = dt;
                                gvMRSheetDetailsUpdate.DataBind();

                                for (int i = 0; i < gvMRSheetDetailsUpdate.Rows.Count; i++)
                                {
                                    decimal totalAmtRow = Convert.ToDecimal(gvMRSheetDetailsUpdate.Rows[i].Cells[12].Text);
                                    totalAmount += totalAmtRow;
                                }

                                txtTotalAmount.Text = totalAmount.ToString();
                            }
                        }


                        else if  (bool.Parse(ViewState["SendBefore"].ToString()) ==   true   && bool.Parse(ViewState["HeldUp"].ToString()) ==   false )
                        {
                            btnUpdate.Enabled = false;
                            btnUpdateSend.Enabled = false;

                            dt = Li_MRSheetManager.  Get_MRSheetNoWiseDetailsForDoMR(Int32.Parse(ViewState["SheetNo"].ToString()),  false ,0 );
                             
                            if (dt.Rows.Count > 0)
                            {
                                gvMRSheetDetailsUpdate.DataSource = dt;
                                gvMRSheetDetailsUpdate.DataBind();

                                for (int i = 0; i < gvMRSheetDetailsUpdate.Rows.Count; i++)
                                {
                                    decimal totalAmtRow = Convert.ToDecimal(gvMRSheetDetailsUpdate.Rows[i].Cells[12].Text);
                                    totalAmount += totalAmtRow;
                                }

                                txtTotalAmount.Text = totalAmount.ToString();
                            }
                        }

                        else
                        {
                            txtTotalAmount.Text = totalAmount.ToString();
                            gvMRSheetDetailsUpdate.DataSource = null;
                            gvMRSheetDetailsUpdate.DataBind();
                        }
                    }
                    getUserAccess();
                }


            }
            catch (Exception ex)
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
                        btnUpdateSend.Enabled = true;
                    }
                    else
                    {
                        btnUpdateSend.Enabled = false;                        
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


        private void LoadLibrary()
        {
            try
            {
                LoadComboData.LoadLibrary(ddlLibraryName, int.Parse(Session["UserID"].ToString()));
                ddlLibraryName.DataBind();
                ddlLibraryName.Items.Insert(0, new ListItem("   ---Select---   ", ""));
            }
            catch (Exception)
            {

            }
        }

        private void LoadCashLibrary()
        {


            try
            {
                //LoadComboData.LoadLibrary(ddlLibraryName);
                DataTable dtLib = Li_LibraryInformationManager.GetAll_ComboBox_LibraryInformationsByUser(int.Parse(Session["UserID"].ToString())).Tables[0];
                ddlReceivedParty.DataSource = dtLib;
                ddlReceivedParty.DataValueField = "LibraryID";
                ddlReceivedParty.DataTextField = "LibraryName";
                ddlReceivedParty.DataBind();
            }
            catch (Exception)
            {

            }
            ddlReceivedParty.Items.Insert(0, new ListItem("--Select Library--", ""));
        }
        private void LoadQCashLibrary()
        {


            try
            {
                //LoadComboData.LoadLibrary(ddlLibraryName);
                DataTable dtLib = Li_LibraryInformationManager.GetAll_ComboBox_QCashLibraryInformationsByUser(int.Parse(Session["UserID"].ToString())).Tables[0];
                ddlReceivedParty.DataSource = dtLib;
                ddlReceivedParty.DataValueField = "LibraryID";
                ddlReceivedParty.DataTextField = "LibraryName";
                ddlReceivedParty.DataBind();
            }
            catch (Exception)
            {

            }
            ddlReceivedParty.Items.Insert(0, new ListItem("--Select Library--", ""));
        }
        protected void gvMRSheetDetailsUpdate_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));

        }

        protected void gvMRSheetDetailsUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvMRSheetDetailsUpdate.SelectedRow;
                ViewState["MRDetId"] = row.Cells[1].Text;
                Li_MRSheetDetail mrSheetDetail = new Li_MRSheetDetail();
                mrSheetDetail = Li_MRSheetDetailManager.GetLi_MRSheetDetailByID(Int32.Parse(ViewState["MRDetId"].ToString()));
                
                txtAccNo.Text = mrSheetDetail.AccountNo;
                txtAmount.Text = mrSheetDetail.Amount.ToString();
                txtBankBranch.Text = mrSheetDetail.BankAddress;
                txtDDTTRDNo.Text = mrSheetDetail.BankSlipNo;
                txtRemarkInv.Text = mrSheetDetail.Remark;
                ddlBank.SelectedValue = mrSheetDetail.BankCode;
                ddlDepositType.SelectedValue = mrSheetDetail.DepositType.ToString();
                dtpDepositDate.Text = mrSheetDetail.CollectionDate.ToString("yyyy-MM-dd");
                txtMRDetId.Text = mrSheetDetail.MRDetId.ToString();
                ddlReceivedParty.SelectedValue = mrSheetDetail.BankCode;

            }
            catch (Exception)
            {

            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (Int32.Parse(txtMRDetId.Text) <= 0 || txtMRDetId.Text == "" || ddlDepositFor.SelectedValue == "" || ddlDepositFor.SelectedValue == "0" || ddlLibraryName.SelectedValue == "" || ddlLibraryName.SelectedValue == "0")
                {
                    string message = "Update failed  .";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "');";
                    script += "window.location = '";
                    script += Request.Url.AbsoluteUri;
                    script += "'; }";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);

                }

                else
                {

                    Li_MRSheetDetail mrSheetDetail = new Li_MRSheetDetail();
                    mrSheetDetail.AccountNo = txtAccNo.Text;
                    mrSheetDetail.Amount = decimal.Parse(txtAmount.Text);
                    mrSheetDetail.BankAddress = txtBankBranch.Text;
                    mrSheetDetail.BankSlipNo = txtDDTTRDNo.Text;
                    mrSheetDetail.Remark = txtRemarkInv.Text;
                    mrSheetDetail.BankCode = ddlBank.SelectedValue;
                    mrSheetDetail.DepositType = Int32.Parse(ddlDepositType.SelectedValue);
                    mrSheetDetail.CollectionDate = Convert.ToDateTime(dtpDepositDate.Text);
                    mrSheetDetail.MRDetId = Int32.Parse(txtMRDetId.Text);
                    mrSheetDetail.MRId = Int32.Parse(txtMRId.Text);
                    mrSheetDetail.DepositForId = Int32.Parse(ddlDepositFor.SelectedValue);
                    mrSheetDetail.LibraryID = ddlLibraryName.SelectedValue;
                    mrSheetDetail.CauseOfDelete = ddlReceivedParty.SelectedValue.ToString();
                    mrSheetDetail.Com = chkQawmi.Checked ? "Q" : "A";
                    mrSheetDetail.DeleteDate = DateTime.Now;
                    mrSheetDetail.DeletedBy = 0;
                    mrSheetDetail.IsDeleted = false;
                    mrSheetDetail.IsHeldUp = false;
                    mrSheetDetail.ModifiedBy = int.Parse(Session["UserID"].ToString());
                    Li_MRSheetDetailManager.UpdateLi_MRSheetDetail(mrSheetDetail);

                    Session["DepositFor"] = ddlDepositFor.SelectedValue;
                    string message = "Updated successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "');";
                    script += "window.location = '";
                    script += Request.Url.AbsoluteUri;
                    script += "'; }";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);
                }
            }
            catch (Exception)
            {


            }

        }





        protected void btnUpdateSend_Click(object sender, EventArgs e)
        {
            Li_MRSheet mrSheet = new Li_MRSheet();
            mrSheet.IsReSend = true;
            mrSheet.MRId = Int32.Parse(txtMRId.Text);
            mrSheet.ReSendDate = DateTime.Now;
            mrSheet.ReSendId = Convert.ToInt32(Session["UserID"].ToString());
            Li_MRSheetManager.UpdateLi_MRSheetSenderAcc(mrSheet);

            string message = "Updated and Send successfully.";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            script += Request.Url.AbsoluteUri;
            script += "'; }";
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);

        }

        protected void lblHeldUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCauseOfHeldUp.Text == "")
                {
                    string message = "Pease give a valid reason for heldup.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "');";
                    script += "window.location = '";
                    script += Request.Url.AbsoluteUri;
                    script += "'; }";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);
                }
                else
                {
                    LinkButton linkButton = new LinkButton();
                    linkButton = (LinkButton)sender;

                    Li_MRSheetDetail mrSheetDetail = new Li_MRSheetDetail();
                    mrSheetDetail.MRId = Int32.Parse(txtMRId.Text);
                    mrSheetDetail.MRDetId = Convert.ToInt32(linkButton.CommandArgument);
                    mrSheetDetail.CauseOfDelete = txtCauseOfHeldUp.Text;
                    mrSheetDetail.DeletedBy = Convert.ToInt32(Session["UserID"].ToString());
                    mrSheetDetail.ModifiedBy = Convert.ToInt32(Session["UserID"].ToString());

                    Li_MRSheetDetailManager.HeldUpLi_MRSheetDetail(mrSheetDetail);

                    string message = "Held Up successful.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "');";
                    script += "window.location = '";
                    script += Request.Url.AbsoluteUri;
                    script += "'; }";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);
                }
            }
            catch (Exception)
            {


            }
        }


        protected void btnPrint_Click(object sender, EventArgs e)
        {

        }
        protected void ddlLibrary_OnSelectedChanged(object sender, EventArgs e)
        {
            if(ddlLibraryName.SelectedValue == "BAN03"){
                LoadCashLibrary();
                ddlReceivedParty.Visible = true;
                lblCashParty.Visible = true;
                chkQawmi.Checked = false;
            }
            else if (ddlLibraryName.SelectedValue == "BAN14")
            {
                LoadQCashLibrary();
                ddlReceivedParty.Visible = true;
                lblCashParty.Visible = true;
                chkQawmi.Checked = true;
            }
            else
            {
                ddlReceivedParty.Visible = false;
                lblCashParty.Visible = false;
                chkQawmi.Checked = false;
            }


        }
        protected void ddlCashParty_OnSelectedChanged(object sender, EventArgs e)
        {
            txtRemarkInv.Text = ddlReceivedParty.SelectedItem.Text;

        }
        

    }
}