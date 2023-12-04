using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmJobDesEducationalReq : System.Web.UI.Page
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

                Li_JobDesEducationalReq jdEduReq = new Li_JobDesEducationalReq();
                jdEduReq.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                jdEduReq.CreatedDate = DateTime.Now;
                jdEduReq.EduReq = txtJobDesEducationalReq.Text;
                jdEduReq.EduReqId = 0;
                jdEduReq.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                jdEduReq.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                jdEduReq.ModifiedDate = DateTime.Now;
                Li_JobDesEducationalReqManager.InsertLi_JobDesEducationalReq(jdEduReq);



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