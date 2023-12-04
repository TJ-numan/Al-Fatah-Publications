using BLL.Classes;
using BLL.Marketing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Mkt_MadrashaDonationInfoEdit : System.Web.UI.Page
    {
        string FormID = "MF037";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    LoadComboData.LoadDonYear(ddlAgreementYear);

                    getUserAccess();
                    txtAgreementNo.Text = Request.QueryString["AgrNo"];
                    ddlDonationFor.SelectedValue = Request.QueryString["DoFId"];
                    ddlAgreementYear.SelectedValue = Request.QueryString["AgrYear"];

                    txtAgreementNo.Attributes.Add("autocomplete", "off");

                    GetAllDonationType();
                    GetAllDistrict();
                    GetAllDonationFor();
                    GetAllMadrashaLevel();

                    Get_MadSomityPersonalInfoForEdit();
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
                    if (Boolean.Parse(dt.Rows[0]["Insert_"].ToString()) == true)
                    {
                        btnUpdate.Enabled = true;
                    }
                    else
                    {
                        btnUpdate.Enabled = false;
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

        private void Get_MadSomityPersonalInfoForEdit()
        {
            DataTable dtEdit = Li_DonationBasicManager.GetMadrashaSomiteePersonInfo_ForEdit(txtAgreementNo.Text, int.Parse(ddlDonationFor.SelectedValue), ddlAgreementYear.SelectedItem.Text.Substring(ddlAgreementYear.SelectedItem.Text.Length - 2, 2)).Tables[0];
            txtTeritorySL.Text = dtEdit.Rows[0]["TerritorySl"].ToString();
            txtAgreementNo.Text = dtEdit.Rows[0]["AgrNo"].ToString();
            ddlAgreementYear.SelectedValue = dtEdit.Rows[0]["AgrYear"].ToString();

            DataTable dtThana = li_ThanaManager.GetOne_ThanasWithRelationByThana(dtEdit.Rows[0]["ThanaId"].ToString()).Tables[0];
            ddlDistrict.SelectedValue = dtThana.Rows[0]["DistrictID"].ToString();
            ddlThana.DataSource = li_ThanaManager.Get_ThanaByDistrictID(int.Parse(dtThana.Rows[0]["DistrictID"].ToString()));
            ddlThana.DataTextField = "ThanaName";
            ddlThana.DataValueField = "ThanaID";
            ddlThana.DataBind();

            ddlThana.SelectedValue = dtEdit.Rows[0]["ThanaId"].ToString();
            txtName.Text = dtEdit.Rows[0]["DoName"].ToString();
            txtVillRoBaz.Text = dtEdit.Rows[0]["VillRoBaz"].ToString();
            txtPostOffice.Text = dtEdit.Rows[0]["PostOff"].ToString();
            txtPhoneNo.Text = dtEdit.Rows[0]["ContactNo"].ToString();
            txtChair_Prin.Text = dtEdit.Rows[0]["Chair_Prin"].ToString();
            txtChair_PrinCont.Text = dtEdit.Rows[0]["Chair_PrinCont"].ToString();
            txtSec_ViceP.Text = dtEdit.Rows[0]["Sec_ViceP"].ToString();
            txtSec_VicePCont.Text = dtEdit.Rows[0]["Sec_VicePCont"].ToString();



            DataTable dtAmount = Li_DonationBasicManager.GetMadrashaSomiteePersonInfo_ForEditAmount(txtAgreementNo.Text, int.Parse(ddlDonationFor.SelectedValue), ddlAgreementYear.SelectedItem.Text.Substring(ddlAgreementYear.SelectedItem.Text.Length - 2, 2)).Tables[0];
            gvwDonationType.DataSource = dtAmount;
            gvwDonationType.DataBind();
        }

        private void GetAllDonationType()
        {
            try
            {
                //ddlDonationType.DataSource = Li_DonationDesManager.GetAllLi_DonationDess();
                //ddlDonationType.DataTextField = "DoDescription";
                //ddlDonationType.DataValueField = "DoDesId";
                //ddlDonationType.DataBind();
                //ddlDonationType.Items.Insert(0, new ListItem("--select--", "0"));
            }
            catch (Exception)
            {

            }
        }

        private void GetAllDonationFor()
        {
            try
            {
                ddlDonationFor.DataSource = Li_DonationForManager.GetAllLi_DonationFors();
                ddlDonationFor.DataTextField = "DonationFor";
                ddlDonationFor.DataValueField = "DoFId";
                ddlDonationFor.DataBind();
                ddlDonationFor.Items.Insert(0, new ListItem("--select--", "0"));
            }
            catch (Exception)
            {

            }
        }

        private void GetAllDistrict()
        {
            try
            {
                ddlDistrict.DataSource = li_DistrictManager.GetAll_Districts();
                ddlDistrict.DataTextField = "DistrictName";
                ddlDistrict.DataValueField = "DistrictID";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("--select--", "0"));
            }
            catch (Exception)
            {

            }
        }

        private void GetAllMadrashaLevel()
        {
            try
            {
                ddlMadrashaLevel.DataSource = li_MadrashalevelsManager.GetAllLi_MadrashaLevels();
                ddlMadrashaLevel.DataTextField = "Level_Name";
                ddlMadrashaLevel.DataValueField = "Level_ID";
                ddlMadrashaLevel.DataBind();
            }
            catch (Exception)
            {

            }
        }

        protected void txtAgreementNo_TextChanged(object sender, EventArgs e)
        {
            txtAgreementNo.Text = txtAgreementNo.Text.PadLeft(4, '0');
            txtAgreementNo.Focus();
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlThana.DataSource = li_ThanaManager.Get_ThanaByDistrictID(int.Parse(ddlDistrict.SelectedValue));
                ddlThana.DataTextField = "ThanaName";
                ddlThana.DataValueField = "ThanaID";
                ddlThana.DataBind();

                ddlDistrict.Focus();
            }
            catch (Exception)
            {

            }
        }

        protected void gvwDonationType_RowEditing(object sender, GridViewEditEventArgs e)
        {
            lbltempAmount.Text = string.Empty;
            gvwDonationType.EditIndex = e.NewEditIndex;
            DataTable dtAmount = Li_DonationBasicManager.GetMadrashaSomiteePersonInfo_ForEditAmount(txtAgreementNo.Text, int.Parse(ddlDonationFor.SelectedValue), ddlAgreementYear.SelectedItem.Text.Substring(ddlAgreementYear.SelectedItem.Text.Length - 2, 2)).Tables[0];
            gvwDonationType.DataSource = dtAmount;
            gvwDonationType.DataBind();
            TextBox txtAmount = (TextBox)gvwDonationType.Rows[e.NewEditIndex].FindControl("txtAmount");
            lbltempAmount.Text = txtAmount.Text;
        }

        protected void gvwDonationType_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int DetId = Convert.ToInt32(gvwDonationType.Rows[e.RowIndex].Cells[0].Text);
            int DoDesId = Convert.ToInt32(gvwDonationType.Rows[e.RowIndex].Cells[1].Text);
            TextBox txtAmount = (TextBox)gvwDonationType.Rows[e.RowIndex].FindControl("txtAmount");

            if (DoDesId == 1 || DoDesId == 3 || DoDesId == 4)
            {
                decimal TerBudgAmt = 0;
                decimal TerBudgAmtPaid = 0;

                int DoDescriptionId = DoDesId == 4 ? 1 : DoDesId;

                DataTable dtTerBudget = Li_DonationDetailManager.GetTeritoryWiseBudgetAmt(int.Parse(ddlThana.SelectedValue), DoDescriptionId, ddlAgreementYear .SelectedItem .Text ).Tables[0];
                if (dtTerBudget.Rows.Count > 0)
                {
                    TerBudgAmt = decimal.Parse(dtTerBudget.Rows[0]["Amount"].ToString());
                }
                DataTable dtTerAllocatedBudget = Li_DonationDetailManager.GetTeritoryWiseBudgetAmtPaid(int.Parse(ddlThana.SelectedValue), DoDesId, ddlAgreementYear .SelectedItem .Text ).Tables[0];
                if (dtTerAllocatedBudget.Rows.Count > 0)
                {
                    TerBudgAmtPaid = decimal.Parse(dtTerAllocatedBudget.Rows[0]["Amount"].ToString());
                }

                decimal BudgetAvailable = TerBudgAmt - TerBudgAmtPaid;
                decimal existAmt = decimal.Parse(lbltempAmount.Text);
                decimal ChangeAmt = decimal.Parse(txtAmount.Text);
                decimal ShedAmt = 0;


                if ((ChangeAmt - existAmt) > 0)
                {
                    if ((ChangeAmt - existAmt) > BudgetAvailable)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Amount is greater than Budget');", true);
                        return;
                    }
                }

                DataTable SheduleAmt = Li_DonationBasicManager.GetScheduleAmountForDonationType(DetId, DoDesId).Tables[0];
                ShedAmt = decimal.Parse(SheduleAmt.Rows[0]["Amount"].ToString());
                if (ChangeAmt <= ShedAmt)
                {
                        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('This amount already has been scheduled');", true);
                        return;
                }

            }

            Li_DonationAmt liDonationAmt=new Li_DonationAmt();
            liDonationAmt.DetId = DetId;
            liDonationAmt.DoDesId = DoDesId;
            liDonationAmt.Amount = decimal.Parse(txtAmount.Text);
            //liDonationAmt.CreatedBy = 0;
            //liDonationAmt.CreatedDate = DateTime.Now;
            Li_DonationAmtManager.UpdateLi_DonationAmt(liDonationAmt);
            
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Li_DonationDetail li_donationDetail = new Li_DonationDetail();

                li_donationDetail.DetId = Convert.ToInt32(gvwDonationType.Rows[0].Cells[0].Text);
                li_donationDetail.DoFId = int.Parse(ddlDonationFor.SelectedValue);
                li_donationDetail.DoName = txtName.Text;
                li_donationDetail.VillRoBaz = txtVillRoBaz.Text;
                li_donationDetail.PostOff = txtPostOffice.Text;
                li_donationDetail.ThanaId = int.Parse(ddlThana.SelectedValue);
                li_donationDetail.ContactNo = txtPhoneNo.Text;
                li_donationDetail.Chair_Prin = txtChair_Prin.Text;
                li_donationDetail.Chair_PrinCont = txtChair_PrinCont.Text;
                li_donationDetail.Sec_ViceP = txtSec_ViceP.Text;
                li_donationDetail.Sec_VicePCont = txtSec_VicePCont.Text;

                Li_DonationDetailManager.UpdateLi_DonationDetail(li_donationDetail);
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Update Successfully');", true);
            }
            catch (Exception)
            {
                
            }
        }

    }
}