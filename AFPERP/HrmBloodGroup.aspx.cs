using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmBloodGroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                    gvwBloodGroup.DataSource = Li_BloodGroupManager.GetAllLi_BloodGroups();
                    gvwBloodGroup.DataBind();

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

                if (txtBloodGroup.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Blood Group.');", true);
                    return;

                }

                Li_BloodGroup bloodGroup = new Li_BloodGroup();
                bloodGroup.BGId = 0;
                bloodGroup.BGName = txtBloodGroup.Text;
                bloodGroup.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                bloodGroup.CreatedDate = DateTime.Now;
                bloodGroup.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                bloodGroup.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                bloodGroup.ModifiedDate = DateTime.Now;
                Li_BloodGroupManager.InsertLi_BloodGroup(bloodGroup);
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

                if (txtBloodGroup.Text.Trim() == "" || txtBloodGroupId.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Blood Group.');", true);
                    return;

                }

                Li_BloodGroup bloodGroup = new Li_BloodGroup();
                bloodGroup.BGId = Int32.Parse(txtBloodGroupId.Text); ;
                bloodGroup.BGName = txtBloodGroup.Text;
                bloodGroup.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                bloodGroup.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                bloodGroup.ModifiedDate = DateTime.Now;
                Li_BloodGroupManager.UpdateLi_BloodGroup(bloodGroup);
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

        protected void gvwBloodGroup_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));


        }

        protected void gvwBloodGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvwBloodGroup.SelectedRow;
                ViewState["BGId"] = row.Cells[1].Text;
                Li_BloodGroup bloodGroup = new Li_BloodGroup();
                bloodGroup = Li_BloodGroupManager.GetLi_BloodGroupByID(Int32.Parse(ViewState["BGId"].ToString()));
                txtBloodGroupId.Text = bloodGroup.BGId.ToString ();
                txtBloodGroup.Text = bloodGroup.BGName;
                ddlInfoStatus.SelectedValue = bloodGroup.InfStId.ToString();
                btnSave.Enabled = false;


            }
            catch (Exception)
            {


            }
        }
    }
}