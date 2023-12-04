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
    public partial class Mkt_MadrasahEntry : System.Web.UI.Page
    {
        string FormID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    btnUpdate.Enabled = false;
                    txtEIIN.Enabled = true;
                    getUserAccess();
                    GetAllDistrict();
                    GetAllMadrashaLevel();

                    gvwMadrasahEntry.DataSource = Li_MadrasahEntryManager.GetAllMadrasahEntry();
                    gvwMadrasahEntry.DataBind();
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
        private void GetAllDistrict()
        {
            try
            {
                ddlDristrict.DataSource = li_DistrictManager.GetAll_Districts();
                ddlDristrict.DataTextField = "DistrictName";
                ddlDristrict.DataValueField = "DistrictID";
                ddlDristrict.DataBind();
                ddlDristrict.Items.Insert(0, new ListItem("--select--", "0"));
            }
            catch (Exception)
            {

            }
        }

        protected void ddlDristrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlThana.DataSource = li_ThanaManager.Get_ThanaByDistrictID(int.Parse(ddlDristrict.SelectedValue));
                ddlThana.DataTextField = "ThanaName";
                ddlThana.DataValueField = "ThanaID";
                ddlThana.DataBind();
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Li_MadrasahEntry li_MadEntry = new Li_MadrasahEntry();
                li_MadEntry.Code = txtEIIN.Text;
                li_MadEntry.Name = txtMadrasahName.Text;
                li_MadEntry.Address = txtVillRoBaz.Text;
                li_MadEntry.PostOffice = txtPostOffice.Text;
                li_MadEntry.Mobile = txtPhoneNo.Text;
                li_MadEntry.MadLevel = int.Parse(ddlMadrashaLevel.SelectedValue);
                li_MadEntry.Th_ID = int.Parse(ddlThana.SelectedValue);
                li_MadEntry.CreatedBy = int.Parse(Session["UserID"].ToString());
                li_MadEntry.CreatedDate = DateTime.Now;
                li_MadEntry.ModifiedBy = int.Parse(Session["UserID"].ToString());
                li_MadEntry.ModifiedDate = DateTime.Now;

                Li_MadrasahEntryManager.InsertLi_MadrasahEntry(li_MadEntry);

                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved successfully.');", true);


                Clears();

                //string message = "Saved successfully.";
                //string script = "window.onload = function(){ alert('";
                //script += message;
                //script += "');";
                //script += "window.location = '";
                //script += Request.Url.AbsoluteUri;
                //script += "'; }";
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",
                //script, true);
            }
            catch (Exception)
            {


            }
        }

        protected void gvwMadrasahEntry_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
        }

        protected void gvwMadrasahEntry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
                txtEIIN.Enabled = false;

                GridViewRow row = gvwMadrasahEntry.SelectedRow;
                ViewState["EIIN_No"] = row.Cells[1].Text;

                DataTable dtMadrasahEntry = Li_MadrasahEntryManager.GetAllLi_MadrasahEntryByEIIN(ViewState["EIIN_No"].ToString()).Tables[0];

                txtEIIN.Text = dtMadrasahEntry.Rows[0]["Code"].ToString();
                txtMadrasahName.Text = dtMadrasahEntry.Rows[0]["Name"].ToString();
                txtVillRoBaz.Text = dtMadrasahEntry.Rows[0]["Address"].ToString();
                txtPostOffice.Text = dtMadrasahEntry.Rows[0]["PostOffice"].ToString();
                txtPhoneNo.Text = dtMadrasahEntry.Rows[0]["Mobile"].ToString();
                ddlDristrict.SelectedValue = dtMadrasahEntry.Rows[0]["DistrictID"].ToString();

                ddlThana.DataSource = li_ThanaManager.Get_ThanaByDistrictID(int.Parse(dtMadrasahEntry.Rows[0]["DistrictID"].ToString()));
                ddlThana.DataTextField = "ThanaName";
                ddlThana.DataValueField = "ThanaID";
                ddlThana.DataBind();

                ddlThana.SelectedValue = dtMadrasahEntry.Rows[0]["Th_ID"].ToString();
                ddlMadrashaLevel.SelectedValue = dtMadrasahEntry.Rows[0]["MadLevel"].ToString();


            }
            catch (Exception)
            {

            }
        }

        protected void gvwMadrasahEntry_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvwMadrasahEntry.PageIndex = e.NewPageIndex;
                //gvwMadrasahEntry.DataSource = Li_MadrasahEntryManager.GetAllMadrasahEntry();
                gvwMadrasahEntry.DataSource = Li_MadrasahEntryManager.GetMadrasahEntryByMadrashName(txtSearch.Text).Tables[0];
                gvwMadrasahEntry.DataBind();
                gvwMadrasahEntry.SelectedIndex = -1;
            }
            catch (Exception ex)
            {

              
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Li_MadrasahEntry li_MadEntry = new Li_MadrasahEntry();
                li_MadEntry.Code = ViewState["EIIN_No"].ToString();
                li_MadEntry.Name = txtMadrasahName.Text;
                li_MadEntry.Address = txtVillRoBaz.Text;
                li_MadEntry.PostOffice = txtPostOffice.Text;
                li_MadEntry.Mobile = txtPhoneNo.Text;
                li_MadEntry.MadLevel = int.Parse(ddlMadrashaLevel.SelectedValue);
                li_MadEntry.Th_ID = int.Parse(ddlThana.SelectedValue);
                //li_MadEntry.CreatedBy = int.Parse(Session["UserID"].ToString());
                //li_MadEntry.CreatedDate = DateTime.Now;
                li_MadEntry.ModifiedBy = int.Parse(Session["UserID"].ToString());
                li_MadEntry.ModifiedDate = DateTime.Now;

                Li_MadrasahEntryManager.UpdateLi_MadrasahEntry(li_MadEntry);

                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Update successfully.');", true);


                Clears();

            }
            catch (Exception)
            {


            }
        }

        private void Clears()
        {
            gvwMadrasahEntry.DataSource = Li_MadrasahEntryManager.GetAllMadrasahEntry();
            gvwMadrasahEntry.DataBind();

            txtEIIN.Text = "";
            txtMadrasahName.Text = "";
            txtVillRoBaz.Text = "";
            txtPostOffice.Text = "";
            txtPhoneNo.Text = "";
            ddlMadrashaLevel.SelectedValue = "0";
            ddlDristrict.SelectedValue = "0";
            ddlThana.SelectedValue = "0";

            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            txtEIIN.Enabled = true;
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtg = Li_MadrasahEntryManager.GetMadrasahEntryByMadrashName(txtSearch.Text).Tables[0];
                gvwMadrasahEntry.DataSource = dtg;
                gvwMadrasahEntry.DataBind();
            }
            catch (Exception ex)
            {
                
            }
        }

    }
}