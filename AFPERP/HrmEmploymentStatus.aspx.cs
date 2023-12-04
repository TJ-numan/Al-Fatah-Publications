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
    public partial class HrmEmploymentStatus : System.Web.UI.Page
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
                        gvEmploymentStatus.DataSource = Li_EmploymentStatusManager.GetAllLi_EmploymentStatuss();
                        gvEmploymentStatus.DataBind();
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

                if (txtEmploymentStatus.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Employment Status Name');", true);
                    return;
                }

                Li_EmploymentStatus employmentStatus = new Li_EmploymentStatus();
                employmentStatus.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                employmentStatus.CreatedDate = DateTime.Now;
                employmentStatus.EmploymentStId = 0;
                employmentStatus.EmploymentStName = txtEmploymentStatus.Text;
                employmentStatus.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                employmentStatus.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                employmentStatus.ModifiedDate = DateTime.Now;
                Li_EmploymentStatusManager.InsertLi_EmploymentStatus(employmentStatus);


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

                if (txtEmploymentStatus.Text.Trim() == "" || txtEmploymentStatusId.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Employment Status Name');", true);
                    return;
                }

                Li_EmploymentStatus EmploymentStatus = new Li_EmploymentStatus();
                EmploymentStatus.EmploymentStId = Int32.Parse(txtEmploymentStatusId.Text);
                EmploymentStatus.EmploymentStName = txtEmploymentStatus.Text;
                EmploymentStatus.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                EmploymentStatus.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                EmploymentStatus.ModifiedDate = DateTime.Now;
                Li_EmploymentStatusManager.UpdateLi_EmploymentStatus(EmploymentStatus);

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

     

 

        protected void gvEmploymentStatus_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
				
				
        }

        protected void gvEmploymentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvEmploymentStatus.SelectedRow;
            ViewState["EmploymentStId"] = row.Cells[1].Text;

            Li_EmploymentStatus empStatus = new Li_EmploymentStatus();
            empStatus = Li_EmploymentStatusManager.GetLi_EmploymentStatusByID(Int32.Parse(ViewState["EmploymentStId"].ToString()));

            txtEmploymentStatusId.Text = empStatus.EmploymentStId.ToString();
            txtEmploymentStatus.Text = empStatus.EmploymentStName;
            ddlInfoStatus.SelectedValue = empStatus.InfStId.ToString();
            btnSave.Enabled = false;
        }



    }
}