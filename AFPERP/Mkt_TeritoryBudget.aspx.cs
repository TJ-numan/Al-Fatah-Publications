using BLL.Classes;
using BLL.Marketing;
using Common.Marketing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Mkt_TeritoryBudget : System.Web.UI.Page
    {
        string FormID = "MF031";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {

                    LoadComboData.LoadDonYear(ddlAgreementYear);

                    getUserAccess();
                    GetAllDonationType();
                    LoadTerritory();
                    ddlTerritoryTo.Text = "";
                    ddlTerritoryFrom.Text = "";
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

        private void LoadTerritory()
        {
            // Load Territory for Transfer From Library
            ddlTerritoryFrom.DataSource = Li_TeritoryManager.GetAllLi_Teritories(string.Empty);
            ddlTerritoryFrom.DataTextField = "TeritoryName";
            ddlTerritoryFrom.DataValueField = "TeritoryCode";
            ddlTerritoryFrom.DataBind();
            ddlTerritoryFrom.Items.Insert(0, new ListItem("--Select--", "0"));

            // Load Territory for Transfer to Library
            ddlTerritoryTo.DataSource = Li_TeritoryManager.GetAllLi_Teritories(string.Empty);
            ddlTerritoryTo.DataTextField = "TeritoryName";
            ddlTerritoryTo.DataValueField = "TeritoryCode";
            ddlTerritoryTo.DataBind();
            ddlTerritoryTo.Items.Insert(0, new ListItem("--Select--", "0"));


        }

        private void GetAllDonationType()
        {
            try
            {
                ddlDonationType.DataSource = Li_DonationDesManager.GetAllLi_DonationDessWithBudget();
                ddlDonationType.DataTextField = "DoDescription";
                ddlDonationType.DataValueField = "DoDesId";
                ddlDonationType.DataBind();
                ddlDonationType.Items.Insert(0, new ListItem("--select--", "0"));
            }
            catch (Exception)
            {

            }
        }

        protected void ddlTerritoryFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlDonationType.SelectedValue=="0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please, Select Donation Type');", true);
                return;
            }

            string DoDesId=ddlDonationType.SelectedValue=="4"?"1":ddlDonationType.SelectedValue;
            
            //Teritory Wise Budget Agreement 
            DataTable dt = li_TeritoryBudgetTransferManager.Get_DonationTeritoryWiseBudget(ddlTerritoryFrom.SelectedValue, int.Parse(DoDesId), ddlAgreementYear.SelectedItem.Text.Substring(ddlAgreementYear.SelectedItem.Text.Length - 7, 2)).Tables[0];
            if (dt.Rows.Count > 0)
            {
                txtTerBudgetFrom.Text = dt.Rows[0]["Amount"].ToString();
            }
            //Teritory Wise Budget Paid
            DataTable dtPaid = li_TeritoryBudgetTransferManager.Get_DonationTeritoryWiseBudget_Paid(ddlTerritoryFrom.SelectedValue, int.Parse(ddlDonationType.SelectedValue), ddlAgreementYear.SelectedItem.Text.Substring(ddlAgreementYear.SelectedItem.Text.Length - 2, 2)).Tables[0];
            if (dtPaid.Rows.Count > 0)
            {
                txtTerBudgetPaidFrom.Text = dtPaid.Rows[0]["Amount"].ToString();
            }

            decimal avaiableAmt = decimal.Parse(txtTerBudgetFrom.Text) - decimal.Parse(txtTerBudgetPaidFrom.Text);
            txtTerBudgetAvaiable.Text = avaiableAmt.ToString();
        }
        protected void ddlTerritoryTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDonationType.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please, Select Donation Type');", true);
                return;
            }
            string DoDesId = ddlDonationType.SelectedValue == "4" ? "1" : ddlDonationType.SelectedValue;
            
            //Teritory Wise Budget Agreement 
            DataTable dt = li_TeritoryBudgetTransferManager.Get_DonationTeritoryWiseBudget(ddlTerritoryTo.SelectedValue, int.Parse(DoDesId), ddlAgreementYear.SelectedItem.Text.Substring(ddlAgreementYear.SelectedItem.Text.Length - 7, 2)).Tables[0];
            if (dt.Rows.Count > 0)
            {
                txtTerBudgetTo.Text = dt.Rows[0]["Amount"].ToString();
            }

            //Teritory Wise Budget Paid
            DataTable dtPaid = li_TeritoryBudgetTransferManager.Get_DonationTeritoryWiseBudget_Paid(ddlTerritoryTo.SelectedValue, int.Parse(ddlDonationType.SelectedValue), ddlAgreementYear.SelectedItem.Text.Substring(ddlAgreementYear.SelectedItem.Text.Length - 2, 2)).Tables[0];
            if (dtPaid.Rows.Count > 0)
            {
                txtTerBudgetPaidTo.Text = dtPaid.Rows[0]["Amount"].ToString();
            }
        }

        protected void ddlDonationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTerBudgetAvaiable.Text = "0.00";
            txtTerBudgetFrom.Text = "0.00";
            txtTerBudgetTo.Text = "0.00";
            txtTerBudgetPaidFrom.Text = "0.00";
            txtTerBudgetPaidTo.Text = "0.00";
            ddlTerritoryFrom.SelectedValue = "0";
            ddlTerritoryTo.SelectedValue = "0";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                txtRefNo.Text = string.Empty;

                if (decimal.Parse(txtTransferAmount.Text) > decimal.Parse(txtTerBudgetAvaiable.Text))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Transfer amount is greater than avaiable amount');", true);
                    return;
                }

                li_TeritoryBudgetTransfer teritorybudget = new li_TeritoryBudgetTransfer();
                teritorybudget.RefNo = txtRefNo.Text.Trim();
                teritorybudget.DoDesId = int.Parse(ddlDonationType.SelectedValue);
                teritorybudget.FromTeritoryID = ddlTerritoryFrom.SelectedValue;
                teritorybudget.ToTeritoryID = ddlTerritoryTo.SelectedValue;
                teritorybudget.TransferAmount = decimal.Parse(txtTransferAmount.Text);
                teritorybudget.TransferDate = DateTime.Now;

                teritorybudget.FromTeritoryBudget = decimal.Parse(txtTerBudgetFrom.Text) - decimal.Parse(txtTransferAmount.Text);
                teritorybudget.ToTeritoryBudget = decimal.Parse(txtTerBudgetTo.Text) + decimal.Parse(txtTransferAmount.Text);

                teritorybudget.AgrYear = ddlAgreementYear.SelectedItem.Text;
                String result = li_TeritoryBudgetTransferManager.InsertLi_TeritoryBudgetTransfer(teritorybudget);
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);
                txtRefNo.Text = result;
                txtTransferAmount.Text = string.Empty;
            }
            catch (Exception ex)
            {
                
            }
        }

    }
}