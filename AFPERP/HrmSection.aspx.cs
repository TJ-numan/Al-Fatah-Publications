using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmSection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                    gvSection.DataSource = Li_SectionManager.GetAllLi_Sections();
                    gvSection.DataBind();
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
                if (ddlInfoStatus.SelectedValue == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid info status.');", true);
                    return;
                }

                if (txtSection.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Section Name');", true);
                    return;
                }

                Li_Section Section = new Li_Section();
                Section.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                Section.CreatedDate = DateTime.Now;
                Section.SecId = 0;
                Section.SecName = txtSection.Text;
                Section.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                Section.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                Section.ModifiedDate = DateTime.Now;
                Li_SectionManager.InsertLi_Section(Section);


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
                if (ddlInfoStatus.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid info status.');", true);
                    return;
                }

                if (txtSection.Text.Trim() == "" || txtSectionId.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Department Name');", true);
                    return;
                }

                Li_Section Section = new Li_Section();
                Section.SecId = Int32.Parse(txtSectionId.Text);
                Section.SecName = txtSection.Text;
                Section.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                Section.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                Section.ModifiedDate = DateTime.Now;
                Li_SectionManager.UpdateLi_Section(Section);


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



        protected void gvSection_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));

        }

        protected void gvSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvSection.SelectedRow;
                ViewState["SecId"] = row.Cells[1].Text;
                Li_Section section = new Li_Section();
                section = Li_SectionManager.GetLi_SectionByID(Int32.Parse(ViewState["SecId"].ToString()));
                txtSectionId.Text = section.SecId.ToString();
                txtSection.Text = section.SecName;
                ddlInfoStatus.SelectedValue = section.InfStId.ToString();
                btnSave.Enabled = false;
            }
            catch (Exception)
            {


            }


        }
    }
}