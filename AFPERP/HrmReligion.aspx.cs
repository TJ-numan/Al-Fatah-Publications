using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmReligion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                    gvwReligion.DataSource = Li_ReligionManager.GetAllLi_Religions();
                    gvwReligion.DataBind();
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
                if (Int32.Parse(ddlInfoStatus.SelectedValue) < 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Information Status.');", true);
                    return;
                }

                if (txtReligion.Text.Trim() == "")
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Religion');", true);
                    return;
                }

                Li_Religion religion = new Li_Religion();
                religion.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                religion.CreatedDate = DateTime.Now;
                religion.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                religion.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                religion.ModifiedDate = DateTime.Now;
                religion.RegId = 0;
                religion.RegName = txtReligion.Text;
                Li_ReligionManager.InsertLi_Religion(religion);
           


                string message = "Saved successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += Request.Url.AbsoluteUri;
                script += "'; }";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",
                script, true);
            }
            catch (Exception)
            {
                
                 
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Int32.Parse(ddlInfoStatus.SelectedValue) < 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Information Status.');", true);
                    return;
                }

                if (txtReligion.Text.Trim() == "" || txtReligionId .Text .Trim ()=="")
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Religion');", true);
                    return;
                }

                Li_Religion religion = new Li_Religion(); 
                religion.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                religion.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                religion.ModifiedDate = DateTime.Now;
                religion.RegId = Int32 .Parse (txtReligionId .Text );
                religion.RegName = txtReligion.Text;
                Li_ReligionManager.UpdateLi_Religion(religion);
                


                string message = "Updated successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += Request.Url.AbsoluteUri;
                script += "'; }";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",
                script, true);
            }
            catch (Exception)
            {


            }
        }

        protected void gvwReligion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
				
				
        }

        protected void gvwReligion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvwReligion.SelectedRow;
                ViewState["RegId"] = row.Cells[1].Text;

                Li_Religion religion = new Li_Religion();
                religion = Li_ReligionManager.GetLi_ReligionByID(Int32.Parse(ViewState["RegId"].ToString()));
                txtReligionId.Text = religion.RegId.ToString();
                txtReligion.Text = religion.RegName;
                ddlInfoStatus.SelectedValue = religion.InfStId.ToString();
            }
            catch (Exception)
            {
                
                
            }

        }
    }
}