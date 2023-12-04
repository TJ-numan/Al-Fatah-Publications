using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmEducationResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                    gvwEduResult.DataSource = Li_EduResultManager.GetAllLi_EduResults();
                    gvwEduResult.DataBind();
                }

            }
            catch
            {
            }
        }

        protected void gvwEduResult_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
				
				
				
        }

        protected void gvwEduResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                GridViewRow row = gvwEduResult.SelectedRow;
                ViewState["EduReId"] = row.Cells[1].Text;

                Li_EduResult eduResult = new Li_EduResult();
                eduResult = Li_EduResultManager.GetLi_EduResultByID(Int32.Parse(ViewState["EduReId"].ToString()));
                txtEduResult.Text = eduResult.EduReName;
                txtEduResultId.Text = eduResult.EduReId.ToString();
                ddlInfoStatus.SelectedValue = eduResult.InfStId.ToString();
                btnSave.Enabled = false;

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
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Status Name');", true);
                    return;
                }

                if (txtEduResult.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Education Result Name');", true);
                    return;

                }

                Li_EduResult eduResult = new Li_EduResult();
                eduResult.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                eduResult.CreatedDate = DateTime.Now;
                eduResult.EduReId = 0;
                eduResult.EduReName = txtEduResult.Text;
                eduResult.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                eduResult.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                eduResult.ModifiedDate = DateTime.Now;
                Li_EduResultManager.InsertLi_EduResult(eduResult);

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
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Status Name');", true);
                    return;
                }

                if (txtEduResult.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Education Result Name');", true);
                    return;

                }

                Li_EduResult eduResult = new Li_EduResult();
                eduResult.EduReId = Int32.Parse(txtEduResultId.Text);
                eduResult.EduReName = txtEduResult.Text;
                eduResult.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                eduResult.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                eduResult.ModifiedDate = DateTime.Now;
                Li_EduResultManager. UpdateLi_EduResult(eduResult);

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



    }
}