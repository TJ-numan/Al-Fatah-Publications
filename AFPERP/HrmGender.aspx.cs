using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmGender : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                    gvwGender.DataSource = Li_GenderManager.GetAllLi_Genders();
                    gvwGender.DataBind();
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

                if (txtGender.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Gender');", true);
                    return;
                }

                Li_Gender gender = new Li_Gender();
                gender.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                gender.CreatedDate = DateTime.Now;
                gender.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                gender.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                gender.ModifiedDate = DateTime.Now;
                gender.GenId = 0;
                gender.GenGp = txtGender.Text;
                Li_GenderManager.InsertLi_Gender(gender);


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

                if (txtGender.Text.Trim() == "" || txtGenderId .Text .Trim ()=="")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Gender');", true);
                    return;
                }

                Li_Gender gender = new Li_Gender(); 
                gender.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                gender.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                gender.ModifiedDate = DateTime.Now;
                gender.GenId = Int32 .Parse (txtGenderId .Text ) ;
                gender.GenGp = txtGender.Text;
                Li_GenderManager. UpdateLi_Gender(gender);


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

        protected void gvwGender_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
				
				
        }

        protected void gvwGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvwGender.SelectedRow;
                ViewState["GenId"] = row.Cells[1].Text;

                Li_Gender gender = new Li_Gender();
                gender = Li_GenderManager.GetLi_GenderByID(Int32.Parse(ViewState["GenId"].ToString()));

                txtGenderId.Text = gender.GenId.ToString();
                txtGender.Text = gender.GenGp;
                ddlInfoStatus.SelectedValue = gender.InfStId.ToString();
                btnSave.Enabled = false;
            }
            catch (Exception)
            {
                
                 
            }

        }
    }
}