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
    public partial class Mkt_MadrashaDonationPayment : System.Web.UI.Page
    {
        string FormID = "MF026";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    getUserAccess();
                    gvwletter.DataSource = Li_DonPaymentManager.GetLi_DonLetterInfoByLetterNO("0").Tables[0]; ;
                    gvwletter.DataBind();
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

        protected void txtLetterNo_TextChanged(object sender, EventArgs e)
        {
            DataTable dtLetterInfo = Li_DonPaymentManager.GetLi_DonLetterInfoByLetterNO(txtLetterNo.Text).Tables[0];
            gvwletter.DataSource = dtLetterInfo;
            gvwletter.DataBind();

        }
        protected void chkDonSelect_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvwletter.Rows.Count; i++)
                {

                    CheckBox chkRow = (gvwletter.Rows[i].Cells[0].FindControl("chkDonSelect") as CheckBox);
                   
                    if (chkRow.Checked == true)
                    {
                        ((TextBox)gvwletter.Rows[i].FindControl("txtPayMedium")).Enabled = true;
                        ((TextBox)gvwletter.Rows[i].FindControl("txtChallanValue")).Enabled = true;
                        ((TextBox)gvwletter.Rows[i].FindControl("txtpayDate")).Enabled = true;
                    }
                    else
                    {
                        ((TextBox)gvwletter.Rows[i].FindControl("txtPayMedium")).Enabled = false;
                        ((TextBox)gvwletter.Rows[i].FindControl("txtChallanValue")).Enabled = false;
                        ((TextBox)gvwletter.Rows[i].FindControl("txtpayDate")).Enabled = false;
                    }

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
                for (int i = 0; i < gvwletter.Rows.Count; i++)
                {

                    CheckBox chkRow = (gvwletter.Rows[i].Cells[0].FindControl("chkDonSelect") as CheckBox);

                    if (chkRow.Checked == true)
                    {
                        Li_DonLetterPayment li_DonLetterPayment = new Li_DonLetterPayment();
                        li_DonLetterPayment.PSId = int.Parse(gvwletter.Rows[i].Cells[17].Text);
                        li_DonLetterPayment.LetterNo = txtLetterNo.Text;
                        li_DonLetterPayment.PaymentMethod =((TextBox)gvwletter.Rows[i].FindControl("txtPayMedium")).Text ;
                        li_DonLetterPayment.ChallanValue = ((TextBox)gvwletter.Rows[i].FindControl("txtChallanValue")).Text;
                        li_DonLetterPayment.PaymentDate = ((TextBox)gvwletter.Rows[i].FindControl("txtpayDate")).Text;
                        li_DonLetterPayment.CreatedBy = int.Parse(Session["UserID"].ToString());
                        li_DonLetterPayment.CreatedDate = DateTime.Now;

                        li_DonLetterPaymentManager.InsertLi_DonLetterPayment(li_DonLetterPayment);
                    }

                }
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);

                DataTable dtLetterInfo = Li_DonPaymentManager.GetLi_DonLetterInfoByLetterNO(txtLetterNo.Text).Tables[0];
                gvwletter.DataSource = dtLetterInfo;
                gvwletter.DataBind();
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Any field missing or Exception problem');", true);
            }
        }

    }
}