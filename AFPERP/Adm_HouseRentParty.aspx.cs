using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Adm_HouseRentParty : System.Web.UI.Page
    {
        string FormID = "AF007";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                getUserAccess();
                LoadToGridAllHouseRentPartyInfo();
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
                        Response.Redirect("~/AccountsHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }
        private void LoadToGridAllHouseRentPartyInfo()
        {
            try
            {
                gvwHouseRentParty.DataSource = Li_HouseRent_PartyManager.GetAllLi_HouseRent_Parties();
                gvwHouseRentParty.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        protected void gvwHouseRentParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvwHouseRentParty.SelectedRow;
                ViewState["PartyID"] = row.Cells[1].Text;

                DataTable dtPartyInfo = Li_HouseRent_PartyManager.GetAllLi_HouseRentPartyInfoByID(ViewState["PartyID"].ToString()).Tables[0];

                txtHouseRentPartyID.Text = dtPartyInfo.Rows[0]["PartyID"].ToString();
                txtHouseRentPartyName.Text = dtPartyInfo.Rows[0]["PartName"].ToString();
                txtAddress.Text = dtPartyInfo.Rows[0]["P_Add"].ToString();
                txtOwnerName.Text = dtPartyInfo.Rows[0]["OwnerName"].ToString();
                txtContactPerson.Text = dtPartyInfo.Rows[0]["ContactPer"].ToString();
                txtPhone.Text = dtPartyInfo.Rows[0]["Phone"].ToString();
            }
            catch (Exception)
            {

            }
        }

        protected void gvwHouseRentParty_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                Li_HouseRent_Party party = new Li_HouseRent_Party();
                party.PartName = txtHouseRentPartyName.Text;
                party.P_Add = txtAddress.Text;
                party.OwnerName = txtOwnerName.Text;
                party.ContactPer = txtContactPerson.Text;
                party.CreatedBy = int.Parse(Session["UserID"].ToString());
                party.CreatedDate = DateTime.Now;
                party.Phone = txtPhone.Text;
                txtHouseRentPartyID.Text = Li_HouseRent_PartyManager.InsertLi_HouseRent_Party(party);

                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);
                ClearData();

                gvwHouseRentParty.DataSource = Li_HouseRent_PartyManager.GetAllLi_HouseRent_Parties();
                gvwHouseRentParty.DataBind();

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                Li_HouseRent_Party party = new Li_HouseRent_Party();
                party.PartyID = txtHouseRentPartyID.Text;
                party.PartName = txtHouseRentPartyName.Text;
                party.P_Add = txtAddress.Text;
                party.OwnerName = txtOwnerName.Text;
                party.ContactPer = txtContactPerson.Text;
                party.CreatedBy = int.Parse(Session["UserID"].ToString());
                party.CreatedDate = DateTime.Now;
                party.Phone = txtPhone.Text;
                Li_HouseRent_PartyManager.UpdateLi_HouseRent_Party(party);

                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Update Successfully');", true);
                ClearData();

                gvwHouseRentParty.DataSource = Li_HouseRent_PartyManager.GetAllLi_HouseRent_Parties();
                gvwHouseRentParty.DataBind();

            }
            catch (Exception ex)
            {

            }
        
        }

        private void ClearData()
        {
            txtHouseRentPartyName.Text = "";
            txtAddress.Text = "";
            txtOwnerName.Text = "";
            txtContactPerson.Text = "";
            txtPhone.Text = "";

        }

        protected void gvwHouseRentParty_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvwHouseRentParty.PageIndex = e.NewPageIndex;
            gvwHouseRentParty.DataSource = Li_HouseRent_PartyManager.GetAllLi_HouseRent_Parties();
            gvwHouseRentParty.DataBind();
        }

    }
}