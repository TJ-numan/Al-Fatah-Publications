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
    public partial class HrmJobCategory : System.Web.UI.Page
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
                        gvJobCategory.DataSource = Li_JobCategoryManager.GetAllLi_JobCategories();
                        gvJobCategory.DataBind();
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

                if (txtJobCategory.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Section Name');", true);
                    return;
                }

                Li_JobCategory   JobCategory = new  Li_JobCategory ();
                JobCategory.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                JobCategory.CreatedDate = DateTime.Now;
                JobCategory.JobCatId = 0;
                JobCategory.JobCatName = txtJobCategory.Text;
                JobCategory.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                JobCategory.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                JobCategory.ModifiedDate = DateTime.Now;
                Li_JobCategoryManager . InsertLi_JobCategory(JobCategory);


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

                if (txtJobCategory.Text.Trim() == "" || txtJobCategoryId.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Department Name');", true);
                    return;
                }

                Li_JobCategory JobCategory = new Li_JobCategory();
                JobCategory.JobCatId = Int32.Parse (txtJobCategoryId .Text);
                JobCategory.JobCatName = txtJobCategory.Text;
                JobCategory.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                JobCategory.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                JobCategory.ModifiedDate = DateTime.Now;
                Li_JobCategoryManager. UpdateLi_JobCategory(JobCategory);

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

     

        protected void lbSelect_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                ViewState["rowNo"] = Convert.ToInt32(linkButton.CommandArgument);
                int row = Int32.Parse(ViewState["rowNo"].ToString());
                Label lblId = (Label)gvJobCategory.Rows[row].Cells[1].FindControl("lblJobCatId");
                Label lblName = (Label)gvJobCategory.Rows[row].Cells[2].FindControl("lblJobCatName");
                txtJobCategoryId.Text = lblId.Text;
                txtJobCategory.Text = lblName.Text;
                btnSave.Enabled = false;


            }
            catch (Exception)
            {


            }
        }

        protected void gvJobCategory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
				
				
        }

        protected void gvJobCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvJobCategory.SelectedRow;
            ViewState["JobCatId"] = row.Cells[1].Text;

            Li_JobCategory JCategory = new Li_JobCategory();
            JCategory = Li_JobCategoryManager.GetLi_JobCategoryByID( Int32 .Parse ( ViewState["JobCatId"].ToString ()) );
            txtJobCategoryId.Text = JCategory.JobCatId.ToString();
            txtJobCategory.Text = JCategory.JobCatName;
            ddlInfoStatus.SelectedValue = JCategory.InfStId.ToString();
            btnSave.Enabled = false;




        }





    }
}