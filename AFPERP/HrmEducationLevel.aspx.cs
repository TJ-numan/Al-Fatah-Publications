using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmEducationLevel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                    gvwEducationLevel.DataSource = Li_EducationLevelManager.GetAllLi_EducationLevels();
                    gvwEducationLevel.DataBind();
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

                if (txtEducationLevel.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Education Level.');", true);
                    return;
                }

                Li_EducationLevel eduLevel = new Li_EducationLevel();
                eduLevel.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                eduLevel.CreatedDate = DateTime.Now;
                eduLevel.EduLevelName = txtEducationLevel.Text;
                eduLevel.EduLId = 0;
                eduLevel.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                eduLevel.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                eduLevel.ModifiedDate = DateTime.Now;
                Li_EducationLevelManager.InsertLi_EducationLevel(eduLevel);

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

                if (txtEducationLevel.Text.Trim() == "" || txtEducationLevelId .Text .Trim ()=="")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Education Level.');", true);
                    return;
                }

                Li_EducationLevel eduLevel = new Li_EducationLevel(); 
                eduLevel.EduLevelName = txtEducationLevel.Text;
                eduLevel.EduLId = Int32 .Parse(txtEducationLevelId.Text );
                eduLevel.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                eduLevel.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                eduLevel.ModifiedDate = DateTime.Now;
                Li_EducationLevelManager. UpdateLi_EducationLevel(eduLevel);

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

        protected void gvwEducationLevel_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
				
				
        }

        protected void gvwEducationLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvwEducationLevel.SelectedRow;
                ViewState["EduLId"] = row.Cells[1].Text;

                Li_EducationLevel eduLevel = new Li_EducationLevel();
                eduLevel = Li_EducationLevelManager.GetLi_EducationLevelByID(Int32.Parse(ViewState["EduLId"].ToString()));
                txtEducationLevelId.Text = eduLevel.EduLId.ToString();
                txtEducationLevel.Text = eduLevel.EduLevelName;
                ddlInfoStatus.SelectedValue = eduLevel.InfStId.ToString();
                btnSave.Enabled = false;
            }
            catch (Exception)
            {
                                 
            }


        }
    }
}