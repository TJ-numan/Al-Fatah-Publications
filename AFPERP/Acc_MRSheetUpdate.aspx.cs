using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Acc_MRSheetUpdate : System.Web.UI.Page
    {
        string FormID = "AF004";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    getUserAccess();
                    decimal totalAmount = 0.0m;

                    LoadComboData.LoadBank(ddlBank);
                    LoadComboData.LoadTransactionTypes(ddlDepositType);

                    if (Request.QueryString["SheetNo"] != null || Request.QueryString["SheetNo"] != "")
                    {
                        ViewState["SheetNo"] = Request.QueryString["SheetNo"];
                        txtMRId.Text = ViewState["SheetNo"].ToString();

                        DataTable dt = new DataTable();
                        dt = Li_MRSheetManager.Get_MRSheetNoWiseDetails(Int32.Parse(ViewState["SheetNo"].ToString()));

                        if (dt.Rows.Count > 0)
                        {

                            gvMRSheetDetailsUpdate.DataSource = dt;
                            gvMRSheetDetailsUpdate.DataBind();

                            for (int i = 0; i < gvMRSheetDetailsUpdate.Rows.Count; i++)
                            {
                                decimal totalAmtRow = Convert.ToDecimal(gvMRSheetDetailsUpdate.Rows[i].Cells[7].Text);
                                totalAmount += totalAmtRow;
                            }

                            txtTotalAmount.Text = totalAmount.ToString();
                        }
                        else
                        {
                            txtTotalAmount.Text = totalAmount.ToString();
                            gvMRSheetDetailsUpdate.DataSource = null;
                            gvMRSheetDetailsUpdate.DataBind();
                        }
                    }

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
                        btnPrint.Enabled = true;
                    }
                    else
                    {
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


            }
            catch (Exception)
            {

            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Int32.Parse(txtMRDetId.Text) <= 0 || txtMRDetId.Text == "" || ddlDepositType.SelectedValue == "" || ddlDepositType.SelectedValue == "0" || ddlBank.SelectedValue == "" || ddlBank.SelectedValue == "0" ||

                     decimal.Parse(txtAmount.Text) <= 0.0m || txtAmount.Text == "")
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
                    mrSheetDetail.DepositForId = 0;
                    mrSheetDetail.LibraryID = "";
                    mrSheetDetail.CauseOfDelete = "";
                    mrSheetDetail.Com = "";
                    mrSheetDetail.DeleteDate = DateTime.Now;
                    mrSheetDetail.DeletedBy = 0;
                    mrSheetDetail.IsDeleted = false;
                    mrSheetDetail.IsHeldUp = false;
                    Li_MRSheetDetailManager.UpdateLi_MRSheetDetail(mrSheetDetail);

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

        protected void lblDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCauseOfDel.Text.Trim() == "")
                { 
                    string message = "Please give a valid reason for delete.";
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
                    mrSheetDetail.CauseOfDelete = txtCauseOfDel.Text;
                    mrSheetDetail.DeletedBy = Convert.ToInt32(Session["UserID"].ToString());

                    Li_MRSheetDetailManager.DeleteLi_MRSheetDetail(mrSheetDetail);

                    string message = "Deleted successfully.";
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

        protected void btnUpdateSend_Click(object sender, EventArgs e)
        {
            Li_MRSheet mrSheet = new Li_MRSheet();
            mrSheet.IsSend = true;
            mrSheet.MRId = Int32.Parse(txtMRId.Text);
            mrSheet.MRDate = DateTime.Parse(dtpMrDate.Text);
            mrSheet.SendDate = DateTime.Now;
            mrSheet.SenderId = Convert.ToInt32(Session["UserID"].ToString());
            Li_MRSheetManager.UpdateLi_MRSheetSenderMkt(mrSheet);

            string message = "Updated and Send successfully.";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            script += Request.Url.AbsoluteUri;
            script += "'; }";
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);

        }

    }
}