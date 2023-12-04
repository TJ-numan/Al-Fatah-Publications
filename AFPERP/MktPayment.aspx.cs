using System.Drawing;
using BLL.Classes;
using BLL.Marketing;
using Common.Marketing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace BLL
{
    public partial class MktPayment : System.Web.UI.Page
    {
        string FormID = "MF008";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    getUserAccess();
                    LoadAgentName();
                    LoadTransactionTypes();
                    LoadAllBank();
                    LoadPayFor();
                    txtDate.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
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
        private void LoadAgentName()
        {
            try
            {
                LoadComboData.LoadLibrary(ddlLibraryName, int.Parse(Session["UserID"].ToString()));
                ddlLibraryName.DataBind();
                ddlLibraryName.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception)
            {

            }
        }

        private void LoadTransactionTypes()
        {
            try
            {
                ddlDepositType.DataSource = Li_TransectionTypeManager.GetAllLi_TransectionTypes();
                ddlDepositType.DataTextField = "TranbType";
                ddlDepositType.DataValueField = "TannID";
                ddlDepositType.DataBind();
                ddlDepositType.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception)
            {


            }
        }

        private void LoadAllBank()
        {
            try
            {
                ddlBankName.DataSource = Li_BankNameManager.GetAllLi_BankNames();
                ddlBankName.DataTextField = "BankName";
                ddlBankName.DataValueField = "BankCode";
                ddlBankName.DataBind();
                ddlBankName.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {


            }
        }

        private void LoadPayFor()
        {
            try
            {
                ddlPaymentOn.DataSource = Li_BankNameManager.GetLi_PayFor().Tables[0];
                ddlPaymentOn.DataTextField = "PayFor";
                ddlPaymentOn.DataValueField = "PayForID";
                ddlPaymentOn.DataBind();
                ddlPaymentOn.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {


            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlBankName.SelectedValue != "0" && ddlDepositType.SelectedValue != "0" && ddlPaymentOn.SelectedValue != "0"
                && ddlLibraryName.SelectedValue!="0" && txtAccountNo.Text != "" && txtAmount.Text != "" && txtBranchDeposit.Text != "")
            {
                li_Payment li_payment = new li_Payment();

                li_payment.PaySl = 0;
                li_payment.PayDate = Convert.ToDateTime(txtDate.Text);
                li_payment.LibraryID = ddlLibraryName.SelectedValue;
                li_payment.PayforID = int.Parse(ddlPaymentOn.SelectedValue);
                li_payment.BankID = ddlBankName.SelectedValue;
                li_payment.AcNo = txtAccountNo.Text.Trim();
                li_payment.TransactionID = int.Parse(ddlDepositType.SelectedValue);
                li_payment.Branch = txtBranchDeposit.Text.Trim();
                li_payment.Amount = Convert.ToDecimal(txtAmount.Text.Trim());
                li_payment.CreateBy = int.Parse(Session["UserID"].ToString());
                li_payment.CreatedDate = DateTime.Now;
                li_payment.Statud_d = 'C';
                li_payment.CauseOfDel = "";
                li_payment.DelBy = 0;


                int msg = Li_PaymentManager.InsertLi_Payments(li_payment);
                if (msg > 0)
                {
                   
                    string message = "Congratulations,Your Payment Saved Succesfully!";
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

                    string message = "Opps! Your Payment not Saved!";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "');";
                    script += "window.location = '";
                    script += Request.Url.AbsoluteUri;
                    script += "'; }";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",
                    script, true);
                }

                Empty();
            }
           
        }

        private void Empty()
        {
            txtBranchDeposit.Text = "";
            txtAmount.Text = "";
            txtAccountNo.Text = "";
            ddlBankName.SelectedIndex = 0;
            ddlDepositType.SelectedIndex = 0;
            ddlLibraryName.SelectedIndex = 0;
            ddlPaymentOn.SelectedIndex = 0;
        }
    }
}