using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmNationality : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                    gvwNationality.DataSource = Li_NationalityManager.GetAllLi_Nationalities();
                    gvwNationality.DataBind();
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

                if (txtNationality.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Nationality.');", true);
                    return;
                }

                Li_Nationality nationality = new Li_Nationality();
                nationality.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                nationality.CreatedDate = DateTime.Now;
                nationality.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                nationality.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                nationality.ModifiedDate = DateTime.Now;
                nationality.NatiId = 0;
                nationality.NatiName = txtNationality.Text;
                Li_NationalityManager.InsertLi_Nationality(nationality);

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

                if (txtNationality.Text.Trim() == "" || txtNationalityId.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Nationality.');", true);
                    return;
                }

                Li_Nationality nationality = new Li_Nationality();
                nationality.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                nationality.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                nationality.ModifiedDate = DateTime.Now;
                nationality.NatiId = Int32.Parse(txtNationalityId.Text);
                nationality.NatiName = txtNationality.Text;
                Li_NationalityManager.UpdateLi_Nationality(nationality);

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

        protected void gvwNationality_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));

        }

        protected void gvwNationality_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvwNationality.SelectedRow;
                ViewState["NatiId"] = row.Cells[1].Text;

                Li_Nationality nationality = new Li_Nationality();
                nationality = Li_NationalityManager.GetLi_NationalityByID(Int32.Parse(ViewState["NatiId"].ToString()));

                txtNationalityId.Text = nationality.NatiId.ToString();
                txtNationality.Text = nationality.NatiName;
                ddlInfoStatus.SelectedValue = nationality.InfStId.ToString();

            }
            catch (Exception)
            {


            }
        }
    }
}