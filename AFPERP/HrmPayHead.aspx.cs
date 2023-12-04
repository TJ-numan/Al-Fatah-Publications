using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmPayHead : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                    gvwPayHead.DataSource = Li_PayHeadManager.GetAllLi_PayHeads();
                    gvwPayHead.DataBind();
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

                if (txtPayHead.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Pay Head.');", true);
                    return;
                }

                Li_PayHead payHead = new Li_PayHead();
                payHead.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                payHead.CreatedDate = DateTime.Now;
                payHead.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                payHead.IsExcluedGross = chkIsExCludedGross.Checked;
                payHead.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                payHead.ModifiedDate = DateTime.Now;
                payHead.PaHId = 0;
                payHead.PaHName = txtPayHead.Text;
                Li_PayHeadManager.InsertLi_PayHead(payHead);

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

                if (txtPayHead.Text.Trim() == "" || txtPayHeadId .Text .Trim ()=="")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Pay Head.');", true);
                    return;
                }

                Li_PayHead payHead = new Li_PayHead(); 
                payHead.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                payHead.IsExcluedGross = chkIsExCludedGross.Checked;
                payHead.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                payHead.ModifiedDate = DateTime.Now;
                payHead.PaHId = Int32 .Parse (txtPayHeadId .Text );
                payHead.PaHName = txtPayHead.Text;
                Li_PayHeadManager. UpdateLi_PayHead(payHead);

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

        protected void gvwPayHead_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
				
				
        }

        protected void gvwPayHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvwPayHead.SelectedRow;
                ViewState["PaHId"] = row.Cells[1].Text;

                Li_PayHead payHead = new Li_PayHead();
                payHead = Li_PayHeadManager.GetLi_PayHeadByID(Int32.Parse(ViewState["PaHId"].ToString()));

                txtPayHeadId.Text = payHead.PaHId.ToString();
                txtPayHead.Text = payHead.PaHName;
                ddlInfoStatus.SelectedValue = payHead.InfStId.ToString();

                btnSave.Enabled = false;
            }
            catch (Exception)
            {
                
                
            }
        }
    }
}