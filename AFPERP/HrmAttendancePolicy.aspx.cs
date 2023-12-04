using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmAttendancePolicy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                    LoadComboData.LoadOffSchedule(ddlOffSchedule);
                 
                    gvAttendencePolicy.DataSource = Li_AttnPolicyManager.GetAllLi_AttnPolicies();
                    gvAttendencePolicy.DataBind();
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


                Li_AttnPolicy attnPolicy = new Li_AttnPolicy();
                attnPolicy.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                attnPolicy.CreatedDate = DateTime.Now;
                attnPolicy.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                attnPolicy.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                attnPolicy.ModifiedDate = DateTime.Now;
                attnPolicy.PoliDes = txtPolicyDesc.Text;
                attnPolicy.PoliId = 0;
                attnPolicy.PoliName = ddlOffSchedule.SelectedValue;
                Li_AttnPolicyManager.InsertLi_AttnPolicy(attnPolicy);

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

        }
    }
}