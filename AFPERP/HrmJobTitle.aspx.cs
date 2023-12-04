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
    public partial class HrmJobTitle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (!IsPostBack)
                    {
                        LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                        gvJobTitle.DataSource = Li_JobTitleManager.GetAllLi_JobTitles();
                        gvJobTitle.DataBind();
                    }
                }
                catch (Exception)
                {


                }
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

                if (txtJobTitle.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Title Name');", true);
                    return;
                }

                Li_JobTitle Jtitle = new Li_JobTitle();
                Jtitle.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                Jtitle.CreatedDate = DateTime.Now;
                Jtitle.JobTiId = 0;
                Jtitle.JobTiName = txtJobTitle.Text;
                Jtitle.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                Jtitle.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                Jtitle.ModifiedDate = DateTime.Now;
                Li_JobTitleManager.InsertLi_JobTitle(Jtitle);


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

                if (txtJobTitle.Text.Trim() == "" || txtJobTitleId.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Title Name');", true);
                    return;
                }

                Li_JobTitle Jtitle = new Li_JobTitle();
                Jtitle.JobTiId = Int32.Parse(txtJobTitleId.Text);
                Jtitle.JobTiName = txtJobTitle.Text;
                Jtitle.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                Jtitle.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                Jtitle.ModifiedDate = DateTime.Now;
                Li_JobTitleManager.UpdateLi_JobTitle(Jtitle);

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

        protected void gvJobTitle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
				
				
        }

        protected void gvJobTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvJobTitle.SelectedRow;
                ViewState["BinderCode"] = row.Cells[1].Text;

                Li_JobTitle Jtitle = new Li_JobTitle();
                Jtitle = Li_JobTitleManager.GetLi_JobTitleByID(Int32.Parse(ViewState["BinderCode"].ToString()));

                txtJobTitleId.Text = Jtitle.JobTiId.ToString();
                txtJobTitle.Text = Jtitle.JobTiName;
                ddlInfoStatus.SelectedValue = Jtitle.InfStId.ToString();
                btnSave.Enabled = false;
            }
            catch (Exception)
            {
                
                
            }
        }


       
 
 
    }
}