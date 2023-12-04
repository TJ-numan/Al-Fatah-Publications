using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmPayGrade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                    gvwPayGrades.DataSource = Li_PayGradeManager.GetAllLi_PayGrades();
                    gvwPayGrades.DataBind();


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

                if (txtEndAmt.Text.Trim() == "" || txtPayGradeDes.Text.Trim() == "" || txtPayGradeName.Text.Trim() == "" || txtStartAmt.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Grade.');", true);
                    return;
                }

                Li_PayGrade payGrade = new Li_PayGrade();
                payGrade.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                payGrade.CreatedDate = DateTime.Now;
                payGrade.EndAmt = decimal.Parse(txtEndAmt.Text);
                payGrade.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                payGrade.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                payGrade.ModifiedDate = DateTime.Now;
                payGrade.PayGrDes = txtPayGradeDes.Text;
                payGrade.PayGrId = 0;
                payGrade.PayGrName = txtPayGradeName.Text;
                payGrade.StartAmt = decimal.Parse(txtStartAmt.Text);
                Li_PayGradeManager.InsertLi_PayGrade(payGrade);

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

                if (txtEndAmt.Text.Trim() == "" || txtPayGradeDes.Text.Trim() == "" || txtPayGradeName.Text.Trim() == "" || txtStartAmt.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Grade.');", true);
                    return;
                }

                Li_PayGrade payGrade = new Li_PayGrade();
                payGrade.EndAmt = decimal.Parse(txtEndAmt.Text);
                payGrade.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                payGrade.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                payGrade.ModifiedDate = DateTime.Now;
                payGrade.PayGrDes = txtPayGradeDes.Text;
                payGrade.PayGrId = Int32.Parse(txtPayGradeNameId.ToString());
                payGrade.PayGrName = txtPayGradeName.Text;
                payGrade.StartAmt = decimal.Parse(txtStartAmt.Text);
                Li_PayGradeManager.UpdateLi_PayGrade(payGrade);

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



        protected void gvwPayGrades_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));

        }

        protected void gvwPayGrades_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvwPayGrades.SelectedRow;
                ViewState["PayGrId"] = row.Cells[1].Text;

                Li_PayGrade payGrade = new Li_PayGrade();
                payGrade = Li_PayGradeManager.GetLi_PayGradeByID (Int32 .Parse (ViewState ["PayGrId"].ToString ()));

                txtPayGradeNameId .Text =payGrade .PayGrId .ToString() ;
                txtPayGradeName .Text =payGrade .PayGrName ;
                txtPayGradeDes .Text =payGrade .PayGrDes ;
                txtStartAmt .Text =payGrade .StartAmt .ToString ();
                txtEndAmt .Text =payGrade .EndAmt .ToString ();
                ddlInfoStatus.SelectedValue = payGrade.InfStId.ToString();
                btnSave.Enabled = false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}