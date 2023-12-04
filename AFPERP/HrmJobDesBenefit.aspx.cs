using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmJobDesBenefit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
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

                Li_JobDesBenefit jdBenefit = new  Li_JobDesBenefit ();
                jdBenefit.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                jdBenefit.CreatedDate = DateTime.Now;
                jdBenefit.JobBenefit = txtJobDesBenefit.Text;
                jdBenefit.JobBenId = 0;
                jdBenefit.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                jdBenefit.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                jdBenefit.ModifiedDate = DateTime.Now;
                Li_JobDesBenefitManager.InsertLi_JobDesBenefit(jdBenefit);



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