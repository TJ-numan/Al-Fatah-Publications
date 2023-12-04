using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Pro_PlateParty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    gvwAllPurchaseParty.DataSource = Li_PlateBuyerInfoManager.GetAllLi_PlateBuyerInfos();
                    gvwAllPurchaseParty.DataBind();
                }
            }
            catch (Exception)
            { 
                
            }
        }

        protected void btnPlateSave_Click(object sender, EventArgs e)
        {
            try
            {

                Li_PlateBuyerInfo platebyer = new Li_PlateBuyerInfo();
                platebyer.Address = txtPlatePurchaseAddress.Text;
                platebyer.B_Add = txtPlatePurchaseAddress_Bn.Text;
                platebyer.CreatedBy = int.Parse(Session["UserID"].ToString());
                platebyer.CreatedDate = DateTime.Now;
                platebyer.Name = txtPlatePurchaseName.Text;
                platebyer.B_Name = txtPlatePurchaseName_Bn.Text;
                platebyer.O_Balance = txtPurchase_Open_Bal.Text != "" ? decimal.Parse(txtPurchase_Open_Bal.Text) : 0.0m;
                platebyer.Phone = txtPlatePurchasePhone.Text;
                txtPurchaseID.Text = Li_PlateBuyerInfoManager.InsertLi_PlateBuyerInfo(platebyer);

                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);

                gvwAllPurchaseParty.DataSource = Li_PlateBuyerInfoManager.GetAllLi_PlateBuyerInfos();
                gvwAllPurchaseParty.DataBind();

                txtPlatePurchaseAddress.Text = "";
                txtPlatePurchaseAddress_Bn.Text = "";
                txtPurchase_Open_Bal.Text = "";
                txtPlatePurchasePhone.Text = "";
                txtPlatePurchaseName.Text = "";
                txtPlatePurchaseName_Bn.Text = "";

            }
            catch (Exception ex)
            {
                
            }
        }

        protected void gvwAllPurchaseParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvwAllPurchaseParty.SelectedRow;
                ViewState["Purchase_PartyID"] = row.Cells[1].Text;

                DataTable dtPartyInfo = Li_PlateProcessPartyManager.GetLi_PlateBuyerInfoByID(ViewState["Purchase_PartyID"].ToString()).Tables[0];

                txtPurchaseID.Text = dtPartyInfo.Rows[0]["ID"].ToString();
                txtPlatePurchaseName.Text = dtPartyInfo.Rows[0]["Name"].ToString();
                txtPlatePurchaseName_Bn.Text = dtPartyInfo.Rows[0]["B_Name"].ToString();
                txtPlatePurchaseAddress.Text = dtPartyInfo.Rows[0]["Address"].ToString();
                txtPlatePurchaseAddress_Bn.Text = dtPartyInfo.Rows[0]["B_Add"].ToString();
                txtPlatePurchasePhone.Text = dtPartyInfo.Rows[0]["Phone"].ToString();
                txtPurchase_Open_Bal.Text = dtPartyInfo.Rows[0]["O_Balance"].ToString();
            }
            catch (Exception)
            {

            }
        }

        protected void gvwAllPurchaseParty_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
        }

        protected void btnPlateUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                Li_PlateBuyerInfo platebyer = new Li_PlateBuyerInfo();
                platebyer.ID=txtPurchaseID.Text;
                platebyer.Address = txtPlatePurchaseAddress.Text;
                platebyer.B_Add = txtPlatePurchaseAddress_Bn.Text;
                platebyer.CreatedBy = int.Parse(Session["UserID"].ToString()); ;
                platebyer.CreatedDate = DateTime.Now;
                platebyer.Name = txtPlatePurchaseName.Text;
                platebyer.B_Name = txtPlatePurchaseName_Bn.Text;
                platebyer.O_Balance = txtPurchase_Open_Bal.Text != "" ? decimal.Parse(txtPurchase_Open_Bal.Text) : 0.0m;
                platebyer.Phone = txtPlatePurchasePhone.Text; 
                Li_PlateBuyerInfoManager.UpdateLi_PlateBuyerInfo(platebyer);

                
                
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Update Successfully');", true);

                gvwAllPurchaseParty.DataSource = Li_PlateBuyerInfoManager.GetAllLi_PlateBuyerInfos();
                gvwAllPurchaseParty.DataBind();

                txtPurchaseID.Text = "";
                txtPlatePurchaseAddress.Text = "";
                txtPlatePurchaseAddress_Bn.Text = "";
                txtPurchase_Open_Bal.Text = "";
                txtPlatePurchasePhone.Text = "";
                txtPlatePurchaseName.Text = "";
                txtPlatePurchaseName_Bn.Text = "";

            }
            catch (Exception ex)
            {

            }
        }

        
    }
}