using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Marketing;
using Common.Marketing;
using BLL.Classes;

namespace BLL
{
    public partial class Mkt_Madrasah_Payment_Return : System.Web.UI.Page
    {

        string FormID = "MF033";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("~/Login.aspx");

            if (!IsPostBack)
            {
                LoadComboData.LoadDonYear(ddlAgreementYear);
                ddlAgreementYear.SelectedValue = "2018-2019";

                getUserAccess();
                GetAllDonationType();
            }
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

        protected void txtAgreementNo_TextChanged(object sender, EventArgs e)
        {
            try
            {

                DataSet dsDonName = Li_DonPaymentSheduleManager.GetDonationNameR2(txtAgreementNo.Text.Trim(), ddlAgreementYear.SelectedItem.Text.Substring(ddlAgreementYear.SelectedItem.Text.Length - 2, 2));
                ddlMadSomPer.DataSource = dsDonName.Tables[0];
                ddlMadSomPer.DataTextField = "DoName";
                ddlMadSomPer.DataValueField = "DetId";
                ddlMadSomPer.DataBind();
                ddlMadSomPer.Items.Insert(0, new ListItem("--select--", "0"));

                txtAgreementNo.Focus();

            }
            catch (Exception)
            {


            }
        }

        protected void ddlMadSomPer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblbudget.Text = "0.0m";
                DataTable dt = Li_DonPaymentSheduleManager.GetAgreementAmountByMadSomiPerson(int.Parse(ddlMadSomPer.SelectedValue)).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    lblbudget.Text = dt.Rows[0]["DonAmt"].ToString();
                }

                gvwAgreementAmount.DataSource = Li_DonPaymentSheduleManager.GetAgreementAmount(txtAgreementNo.Text, int.Parse(ddlMadSomPer.SelectedValue));
                gvwAgreementAmount.DataBind();
            }
            catch (Exception ex)
            {
                 
            }
        }

        protected void ddlDonationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int DetId=int.Parse(ddlMadSomPer.SelectedValue);
                int DoDesId=int.Parse(ddlDonationType.SelectedValue);
                DataTable dtDeliveredAmt = li_DonPaymentReturnManager.GetDonationPaymentReturn(DetId, DoDesId).Tables[0];
                txtDeliveredAmt.Text = dtDeliveredAmt.Rows[0]["Deli_Amount"].ToString();
            }
            catch (Exception ex)
            {
               
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(decimal.Parse(txtReturnAmount.Text)>decimal.Parse(txtDeliveredAmt.Text))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Return amount is greater than Delivered Amount');", true);
                    return;
                }
                if(txtReturnCause.Text=="")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Cause of Return missing');", true);
                    return;
                }


                li_DonPaymentReturn li_donPaymentreturn = new li_DonPaymentReturn();
                li_donPaymentreturn.DetId = int.Parse(ddlMadSomPer.SelectedValue);
                li_donPaymentreturn.DoDesId = int.Parse(ddlDonationType.SelectedValue);
                li_donPaymentreturn.ReturnAmt = decimal.Parse(txtReturnAmount.Text);
                li_donPaymentreturn.CauseOfReturn =  txtReturnCause.Text;

                li_DonPaymentReturnManager.InsertLi_DonPaymentShedule(li_donPaymentreturn);

                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Information Saved Successfully');", true);
            }
            catch (Exception ex)
            {
                
               
            }
        }


    }
}