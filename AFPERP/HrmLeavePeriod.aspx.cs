using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmLeavePeriod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                    gvLeavePeriod.DataSource = Li_LeavePeriodManager.GetAllLi_LeavePeriods();
                    gvLeavePeriod.DataBind();
                }
            }
            catch (Exception ex)
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



                if (txtLvPeriodName.Text=="")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Leave Period');", true);
                    return;
                }






                Li_LeavePeriod lvPeriod = new Li_LeavePeriod();
                lvPeriod.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                lvPeriod.CreatedDate = DateTime.Now;
                lvPeriod.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                lvPeriod.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                lvPeriod.ModifiedDate = DateTime.Now;
                lvPeriod.PerName = txtLvPeriodName.Text;
                lvPeriod.PerId = 0;
                lvPeriod.PerStDate = DateTime.Parse(txtPeriodStartDate.Text);
                lvPeriod.PerEnDate = DateTime.Parse(txtPeriodEndDate.Text);
                lvPeriod.Comments = txtComments.Text;
                Li_LeavePeriodManager.InsertLi_LeavePeriod(lvPeriod);




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
    }
}