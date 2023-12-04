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
    public partial class HrmDepartment : System.Web.UI.Page
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
                        gvDepartment.DataSource = Li_DepartmentManager.GetAllLi_Departments();
                        gvDepartment.DataBind();

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

                if (txtDepartment.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Department Name');", true);
                    return;
                }

                Li_Department department = new Li_Department();
                department.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                department.CreatedDate = DateTime.Now;
                department.DepId = 0;
                department.DepName = txtDepartment.Text;
                department.InfStId = Int32.Parse(ddlInfoStatus .SelectedValue );
                department .ModifiedBy =Int32.Parse(Session["UserID"].ToString());
                department.ModifiedDate = DateTime.Now;
                Li_DepartmentManager.InsertLi_Department(department);


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

                if (txtDepartment.Text.Trim() == "" || txtDepartmentId.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Department Name');", true);
                    return;
                }

                Li_Department department = new Li_Department();
                department.DepId = Int32.Parse(txtDepartmentId.Text);
                department.DepName = txtDepartment.Text;
                department.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                department.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                department.ModifiedDate = DateTime.Now;
                Li_DepartmentManager.UpdateLi_Department(department);

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

        protected void gvDepartment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
				
				
        }

        protected void gvDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvDepartment.SelectedRow;
            ViewState["DepId"] = row.Cells[1].Text;

            Li_Department department = new Li_Department();
            department = Li_DepartmentManager.GetLi_DepartmentByID (Int32 .Parse ( ViewState["DepId"].ToString ()));
            txtDepartmentId.Text = department.DepId.ToString();
            txtDepartment.Text = department.DepName;
            ddlInfoStatus.SelectedValue = department.InfStId.ToString();

            btnSave.Enabled = false;


        } 
 

    }
}