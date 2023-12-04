using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Pro_PastingPartyInfo : System.Web.UI.Page
    {
        string FormID = "PF020";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserID"] == null)
                Response.Redirect("~/Login.aspx");
            getUserAccess();
            LoadToGridAllPestingPartyInfo();
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
                        btnPastingSave.Enabled = true;
                    }
                    else
                    {
                        btnPastingSave.Enabled = false;
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
        private void LoadToGridAllPestingPartyInfo()
        {
            try
            {
                gvwPastingParty.DataSource = Li_PestingPartyInfoManager.GetAllLi_PestingPartyInfos();
                gvwPastingParty.DataBind();
            }
            catch (Exception)
            {

            }
        }

        protected void btnPastingSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPastinPartyName.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please give the Party name.');", true);
                    return; 
                }

                Li_PestingPartyInfo party = new Li_PestingPartyInfo();
                party.Address = txtPastinAddress.Text;
                party.Address_Bn = txtPastinAddress_Bn.Text;
                party.CreatedBy = int.Parse(Session["UserID"].ToString());
                party.CreatedDate = DateTime.Now;
                party.Name = txtPastinPartyName.Text;
                party.Name_Bn = txtPastinPartyName_Bn.Text;
                party.O_Balance = txtPastinOpeningBalance.Text != "" ? decimal.Parse(txtPastinOpeningBalance.Text) : 0.0m;
                party.Phone = txtPastinPhone.Text;
                txtPastingPartyID.Text = Li_PestingPartyInfoManager.InsertLi_PestingPartyInfo(party);

                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);

                ClearData();
                LoadToGridAllPestingPartyInfo();
            }
            catch (Exception ex)
            {
              
            }
        }

        private void ClearData()
        {
            txtPastinAddress.Text = "";
            txtPastinAddress_Bn.Text = "";
            txtPastinPartyName.Text = "";
            txtPastinPartyName_Bn.Text = "";
            txtPastinOpeningBalance.Text = "";
            txtPastinPhone.Text = "";

        }

        protected void btnPastingUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPastingPartyID.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Party ID missing');", true);
                    return;
                }

                Li_PestingPartyInfo party = new Li_PestingPartyInfo();
                party.ID= txtPastingPartyID.Text;
                party.Address = txtPastinAddress.Text;
                party.Address_Bn = txtPastinAddress_Bn.Text;
                party.CreatedBy = int.Parse(Session["UserID"].ToString());
                party.CreatedDate = DateTime.Now;
                party.Name = txtPastinPartyName.Text;
                party.Name_Bn = txtPastinPartyName_Bn.Text;
                party.O_Balance = txtPastinOpeningBalance.Text != "" ? decimal.Parse(txtPastinOpeningBalance.Text) : 0.0m;
                party.Phone = txtPastinPhone.Text;Li_PestingPartyInfoManager.UpdateLi_PestingPartyInfo(party);

                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Update Successfully');", true);

                ClearData();
                LoadToGridAllPestingPartyInfo();
            }
            catch (Exception)
            {
                
            }
        }

        protected void gvwPastingParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvwPastingParty.SelectedRow;
                ViewState["PartyID"] = row.Cells[1].Text;

                DataTable dtPartyInfo = Li_PestingPartyInfoManager.GetLi_PestingPartyInfoByID(ViewState["PartyID"].ToString()).Tables[0];

                txtPastingPartyID.Text=dtPartyInfo.Rows[0]["ID"].ToString();
                txtPastinPartyName.Text = dtPartyInfo.Rows[0]["Name"].ToString();
                txtPastinPartyName_Bn.Text = dtPartyInfo.Rows[0]["Name_Bn"].ToString();
                txtPastinAddress.Text = dtPartyInfo.Rows[0]["Address"].ToString();
                txtPastinAddress_Bn.Text = dtPartyInfo.Rows[0]["Address_Bn"].ToString();
                txtPastinPhone.Text = dtPartyInfo.Rows[0]["Phone"].ToString();
                txtPastinOpeningBalance.Text = dtPartyInfo.Rows[0]["O_Balance"].ToString();
            }
            catch (Exception)
            {

            }
        }

        protected void gvwPastingParty_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));

        }
    }
}