using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmJobDesResponsibility : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                }
            }
            catch (Exception)
            {
                
                
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(ddlInfoStatus.SelectedValue) < 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Information Status.');", true);
                return;
            }

            Li_JobDesReponsibility jdResponsibility = new Li_JobDesReponsibility();
            jdResponsibility.CreatedBy = Int32.Parse(Session["UserID"].ToString());
            jdResponsibility.CreatedDate = DateTime.Now;
            jdResponsibility.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
            jdResponsibility.JobRes = txtJobDesResponsibility.Text;
            jdResponsibility.JobResId = 0;
            jdResponsibility .ModifiedBy =Int32.Parse(Session["UserID"].ToString());
            jdResponsibility.ModifiedDate = DateTime.Now;
            Li_JobDesReponsibilityManager.InsertLi_JobDesReponsibility(jdResponsibility);

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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}