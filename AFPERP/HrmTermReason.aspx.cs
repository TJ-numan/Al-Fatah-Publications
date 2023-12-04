using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmTermReason : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                    gvwTermReason.DataSource = Li_TermReasonManager.GetAllLi_TermReasons();
                    gvwTermReason.DataBind();

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

               if (txtTermReason.Text.Trim() == "")
               {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Reason');", true);
                    return;
               }

               Li_TermReason reason = new Li_TermReason();
               reason.CreatedBy = Int32.Parse(Session["UserID"].ToString());
               reason.CreatedDate = DateTime.Now;
               reason.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                reason .ModifiedBy =Int32.Parse(Session["UserID"].ToString());
                reason.ModifiedDate = DateTime.Now;
                reason.TeReDes = txtTermReasDes.Text;
                reason.TeReId = 0;
                reason.TeReName = txtTermReason.Text;
                Li_TermReasonManager.InsertLi_TermReason(reason);
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

                if (txtTermReason.Text.Trim() == "" || txtTermReasonId.Text.Trim() == "" )
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Reason');", true);
                    return;
                }

                Li_TermReason reason = new Li_TermReason(); 
                reason.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                reason.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                reason.ModifiedDate = DateTime.Now;
                reason.TeReDes = txtTermReasDes.Text;
                reason.TeReId = Int32.Parse(txtTermReasonId.Text);
                reason.TeReName = txtTermReason.Text;
                Li_TermReasonManager. UpdateLi_TermReason(reason);

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

        protected void gvwTermReason_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
				
				
        }

        protected void gvwTermReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                GridViewRow row = gvwTermReason.SelectedRow;
                ViewState["TeReId"] = row.Cells[1].Text;
                Li_TermReason reason = new Li_TermReason();
                reason = Li_TermReasonManager.GetLi_TermReasonByID(Int32.Parse(ViewState["TeReId"].ToString()));
                txtTermReasDes.Text = reason.TeReDes;
                txtTermReason.Text = reason.TeReName;
                txtTermReasonId.Text = reason.TeReId.ToString();
                ddlInfoStatus.SelectedValue = reason.InfStId.ToString();
                btnSave.Enabled = false;

            }
            catch (Exception)
            {
                
                 
            }
        }
    }
}