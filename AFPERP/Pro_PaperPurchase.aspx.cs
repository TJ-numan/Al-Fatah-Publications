using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Pro_PaperPurchase : System.Web.UI.Page
    {
        string FormID = "PF017";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                getUserAccess();
                if (!IsPostBack)
                {
                    LoadPartyName();

                    LoadPaperType();

                    LoadPaperBrand();

                    LoadPaperOrigin();
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
                        btnPaperSave.Enabled = true;
                    }
                    else
                    {
                        btnPaperSave.Enabled = false;
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
                        Response.Redirect("~/ProHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }

        private void LoadPaperOrigin()
        {
            ddlPaperOrigin.DataSource = Li_PaperOriginBasicManager.GetAllLi_PaperOriginBasics();
            ddlPaperOrigin.DataTextField = "Origin";
            ddlPaperOrigin.DataValueField = "ID";
            ddlPaperOrigin.DataBind();
            ddlPaperOrigin.Items.Insert(0, new ListItem("--select--", ""));
        }

        private void LoadPaperBrand()
        {
            ddlPaperBrand.DataSource = Li_PaperBrandBasicManager.GetAllLi_PaperBrandBasics();
            ddlPaperBrand.DataTextField = "Brand";
            ddlPaperBrand.DataValueField = "ID";
            ddlPaperBrand.DataBind();
            ddlPaperBrand.Items.Insert(0, new ListItem("--select--", ""));
        }

        private void LoadPaperType()
        {
            ddlPaperType.DataSource = Li_PaperTypeBasicManager.GetAllLi_PaperTypeBasics();
            ddlPaperType.DataTextField = "Type";
            ddlPaperType.DataValueField = "ID";
            ddlPaperType.DataBind();
            ddlPaperType.Items.Insert(0, new ListItem("--select--", ""));
        }

        private void LoadPartyName()
        {
            ddlPartyName.DataSource = Li_PaperPartyManager.GetAllLi_PaperParties();
            ddlPartyName.DataTextField = "Name";
            ddlPartyName.DataValueField = "ID";
            ddlPartyName.DataBind();
            ddlPartyName.Items.Insert(0, new ListItem("--select--", ""));
        }

        protected void ddlPaperSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                ddlPaperGSM.DataSource = Li_PaperWeightBasicManager.GetAllLi_PaperWeightBasics(ddlPaperSize.SelectedValue.ToString());
                ddlPaperGSM.DataTextField = "Weight";
                ddlPaperGSM.DataValueField = "ID";
                ddlPaperGSM.DataBind();
                ddlPaperGSM.Items.Insert(0, new ListItem("--select--", ""));
            }
            catch (Exception ex)
            {
            }
        }

        protected void ddlPaperType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlPaperSize.DataSource = Li_PaperSizeBasicManager.GetLi_PaperSizeBasicByID(ddlPaperType.SelectedValue.ToString());
                ddlPaperSize.DataTextField = "Size";
                ddlPaperSize.DataValueField = "SizeID";
                ddlPaperSize.DataBind();
                ddlPaperSize.Items.Insert(0, new ListItem("--select--", ""));


                ddlPaperQtyUnit.DataSource = Li_Paper_M_UManager.GetAllLi_Paper_M_Us(ddlPaperType.SelectedValue.ToString());
                ddlPaperQtyUnit.DataTextField = "Pap_U_Name";
                ddlPaperQtyUnit.DataValueField = "Pap_U_ID";
                ddlPaperQtyUnit.DataBind();


                if (ddlPaperQtyUnit.SelectedItem.Text == "Kg")
                {
                    lblRoll.Visible = true;
                    txtRoll.Visible = true;

                }

                else
                {
                    lblRoll.Visible = false;
                    txtRoll.Visible = false;
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnPaperSave_Click(object sender, EventArgs e)
        {
            try
            {
                Li_PaperPhurchase li_PaperPhurchase = new Li_PaperPhurchase();

                li_PaperPhurchase.OrderNo = txtOrderNo.Text;
                li_PaperPhurchase.OrderDate = Convert.ToDateTime(dtpOrderDate.Text);
                li_PaperPhurchase.PartyID = ddlPartyName.SelectedValue.ToString();
                li_PaperPhurchase.PaperSize = ddlPaperSize.SelectedValue.ToString();
                li_PaperPhurchase.PaperType = ddlPaperType.SelectedValue.ToString();
                li_PaperPhurchase.PaperBrand = ddlPaperBrand.SelectedValue.ToString();
                li_PaperPhurchase.PaperOrigin = ddlPaperOrigin.SelectedValue.ToString();
                li_PaperPhurchase.GSM = ddlPaperGSM.SelectedValue.ToString();
                li_PaperPhurchase.Qty = Decimal.Parse(txtQuantity.Text);
                li_PaperPhurchase.MUint = ddlPaperQtyUnit.Text;
                li_PaperPhurchase.UnitPrice = Decimal.Parse(txtUnitPrice.Text);
                li_PaperPhurchase.Total = Decimal.Parse(txtTotal.Text);
                li_PaperPhurchase.Remark = txtRemark.Text;

                li_PaperPhurchase.CreatedBy = int.Parse(Session["UserID"].ToString());
                li_PaperPhurchase.CreatedDate = DateTime.Now;
                li_PaperPhurchase.Roll = txtRoll.Text != "" ? decimal.Parse(txtRoll.Text) : 0.0m;
                li_PaperPhurchase.Purchase_OrderNo = txtOrderNo.Text;

                txtSerialNo.Text = Li_PaperPhurchaseManager.InsertLi_PaperPhurchase(li_PaperPhurchase);

                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);

                ClearData();

                ddlPartyName.Focus();

            }
            catch (Exception ex)
            {
                
            }
        }

        private void ClearData()
        {


            ddlPartyName.SelectedIndex = 0;
            ddlPaperSize.SelectedIndex = 0;
            ddlPaperType.SelectedIndex = 0;
            ddlPaperBrand.SelectedIndex = 0;
            ddlPaperOrigin.SelectedIndex = 0;
            ddlPaperGSM.SelectedIndex = 0;
            txtQuantity.Text = "";
            ddlPaperQtyUnit.SelectedIndex = -1;
            txtUnitPrice.Text = "";
            txtTotal.Text = "";
            txtRemark.Text = "";


        }

        protected void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal unitPrice = txtUnitPrice.Text == "" ? 0.0m : decimal.Parse(txtUnitPrice.Text);
                decimal qty = txtQuantity.Text == "" ? 0.0m : decimal.Parse(txtQuantity.Text);
                txtTotal.Text = string.Format("{0:0.##}", unitPrice * qty);
            }
            catch (Exception)
            {
                
                 
            }
        }
    }
}