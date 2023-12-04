using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Pro_LaminationParty : System.Web.UI.Page
    {
        string FormID = "PF012";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                getUserAccess();

                gvwAllParty.DataSource = Li_LeminatioPartyInfoManager.GetAllLi_LeminatioPartyInfos();
                gvwAllParty.DataBind();
                gvwAllParty.Focus();
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
                        Response.Redirect("~/ProHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPartyName.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please type a Press name.');", true);
                    txtPartyName.Focus();
                    return;
                }



                Li_LeminatioPartyInfo partyInfo = new Li_LeminatioPartyInfo();
                partyInfo.Address = txtPartyAddress.Text;
                partyInfo.CreatedBy = int.Parse(Session["UserID"].ToString());
                partyInfo.CrteatedDate = DateTime.Now;
                partyInfo.OpeningBalance = txtOppeningBalance.Text != "" ? decimal.Parse(txtOppeningBalance.Text) : 0.0m;
                partyInfo.Phone = txtPhone.Text;
                partyInfo.Name = txtPartyName.Text;
                partyInfo.Add_Bn = txtPartyAddress_Bn.Text;
                partyInfo.Name_Bn = txtPartyName_Bn.Text;
                string result = Li_LeminatioPartyInfoManager.InsertLi_LeminatioPartyInfo(partyInfo);
                txtPartyID.Text = result;
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);
                ClearData();
                gvwAllParty.DataSource = Li_LeminatioPartyInfoManager.GetAllLi_LeminatioPartyInfos();
                gvwAllParty.DataBind();
                txtPartyName.Focus();
            }
            catch (Exception ex)
            {
                
            }

        }

        private void ClearData()
        {
            txtPartyAddress.Text = "";
            txtOppeningBalance.Text = "";
            txtPhone.Text = "";
            txtPartyName.Text = "";
        }

        protected void gvwAllParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvwAllParty.SelectedRow;
                ViewState["PartyId"] = row.Cells[1].Text;

                DataTable dtPartyInfo = Li_LeminatioPartyInfoManager.GetLi_LeminatioPartyInfosByID(ViewState["PartyId"].ToString()).Tables[0];

                txtPartyID.Text = dtPartyInfo.Rows[0]["ID"].ToString();
                txtPartyName.Text = dtPartyInfo.Rows[0]["Name"].ToString();
                txtPartyName_Bn.Text = dtPartyInfo.Rows[0]["Name_Bn"].ToString();
                txtPartyAddress.Text = dtPartyInfo.Rows[0]["Address"].ToString();
                txtPartyAddress_Bn.Text = dtPartyInfo.Rows[0]["Add_Bn"].ToString();
                txtPhone.Text = dtPartyInfo.Rows[0]["Phone"].ToString();
                txtOppeningBalance.Text = dtPartyInfo.Rows[0]["OpeningBalance"].ToString();
            }
            catch (Exception)
            {

            }
        }

        protected void gvwAllParty_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
        }
    }
}