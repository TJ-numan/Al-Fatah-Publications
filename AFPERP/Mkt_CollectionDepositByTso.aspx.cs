using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Mkt_CollectionDepositByTso : System.Web.UI.Page
    {
        string FormID = "MF020";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("~/Login.aspx");
            if (!IsPostBack)
            {
                getUserAccess();
                LoadsalesPerson();
                LoadTransactionTypes();
                LoadBank(); 
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
        private void LoadsalesPerson()
        {          
            ddTsoName.DataSource = Li_SalesPersonManager.GetAllLi_SalesPersons(ddTsoName.Text);
            ddTsoName.DataTextField = "Name";
            ddTsoName.DataValueField = "TSOID";
            ddTsoName.DataBind();
            ddTsoName.Items.Insert(0, new ListItem("-Select-","0"));
        }
        private void LoadBank()
        {
            ddlBankName.DataSource = Li_BankNameManager.GetAllLi_BankNames();
            ddlBankName.DataTextField = "BankName";
            ddlBankName.DataValueField = "BankCode";
            ddlBankName.DataBind();
            ddlBankName.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        private void LoadTransactionTypes()
        {
            ddlDepositType.DataSource = Li_TransectionTypeManager.GetAllLi_TransectionTypes();
            ddlDepositType.DataTextField = "TranbType";
            ddlDepositType.DataValueField = "TannID";
            ddlDepositType.DataBind();
            ddlDepositType.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {

                if (ddTsoName.SelectedIndex == -1)
                {
                   
                }

                if (Int32.Parse(ddlDepositType.SelectedValue.ToString()) <= 0)
                {
                   
                }

                if (txtAmount.Text == "")
                {
                 
                }

                Li_Deposit deposit = new Li_Deposit();
                deposit.Alim = radAlim.Checked ? true : false;
                deposit.AmountOfMoney = txtAmount.Text != "" ? decimal.Parse(txtAmount.Text) : 0.0m;
                deposit.BankAddress = txtBankAddress.Text;
                deposit.BankCode = ddlBankName.SelectedValue.ToString();
                deposit.BankSlipNo = txtDDNo.Text;
                deposit.Boishaki = radBoishakhi.Checked ? true : false;
                deposit.CauseOfDelete = "";
                deposit.ClearDate = Convert.ToDateTime(txtClearanceDate.Text);
                deposit.CreatedBy = int.Parse(Session["UserID"].ToString());
                deposit.Dele_By = 0;
                deposit.Deledate = DateTime.Now;
                deposit.DepositedDate = Convert.ToDateTime(txtDepositDate.Text);
                deposit.DepositeTpe = Int32.Parse(ddlDepositType.SelectedValue.ToString());
                deposit.LibraryID = ddTsoName.SelectedValue.ToString();
                deposit.MRDate = Convert.ToDateTime(txtMRDate.Text);
                deposit.Remark = txtRemark.Text;
                deposit.Status_D = 'C';
                deposit.VrifiedBy = txtVerifiedBy.Text;
                txtInvoice.Text = Li_DepositManager.InsertLi_DepositByTSO(deposit);
                string message = "Saved Successfully!";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += Request.Url.AbsoluteUri;
                script += "'; }";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script,
                    true);
                ddTsoName.Focus();
            }

            catch (Exception)
            {
            }



        }
    }
}