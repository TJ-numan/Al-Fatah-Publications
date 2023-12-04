using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmPayScale : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                    LoadPayGrade();
                    gvwPayScale.DataSource = Li_PayScaleManager.GetAllLi_PayScales();
                    gvwPayScale.DataBind();
                }


            }
            catch (Exception)
            {
                
                 
            }
        }

        private void LoadPayGrade()
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlPayGrade.Items.Add(li);

            List<Li_PayGrade> payGrades = new List<Li_PayGrade>();
            payGrades = Li_PayGradeManager.GetAllLi_PayGrades();
            foreach (Li_PayGrade payGrade in payGrades)
            {
                ListItem item = new ListItem(payGrade.PayGrName, payGrade.PayGrId.ToString());
                ddlPayGrade.Items.Add(item);
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

                if (Int32.Parse(ddlPayGrade.SelectedValue) < 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Grade.');", true);
                    return;
                }

                if(txtPayScaleAmt.Text.Trim()=="")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Grade Amount.');", true);
                    return;
                }

                Li_PayScale payScale = new Li_PayScale();
                payScale.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                payScale.CreatedDate = DateTime.Now;
                payScale.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                payScale.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                payScale.ModifiedDate = DateTime.Now;
                payScale.PayGrId = Int32.Parse(ddlPayGrade.SelectedValue);
                payScale.PScId = 0;
                payScale.PSAmt = decimal.Parse(txtPayScaleAmt.Text);
                Li_PayScaleManager.InsertLi_PayScale(payScale);

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

                if (Int32.Parse(ddlPayGrade.SelectedValue) < 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Grade.');", true);
                    return;
                }

                if (txtPayScaleAmt.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Grade Amount.');", true);
                    return;
                }

                Li_PayScale payScale = new Li_PayScale(); 
                payScale.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                payScale.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                payScale.ModifiedDate = DateTime.Now;
                payScale.PayGrId = Int32.Parse(ddlPayGrade.SelectedValue);
                payScale.PScId = Int32.Parse(txtPayScaleId.Text);
                payScale.PSAmt = decimal.Parse(txtPayScaleAmt.Text);
                Li_PayScaleManager.UpdateLi_PayScale(payScale);

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

        protected void gvwPayScale_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
				
        }

        protected void gvwPayScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvwPayScale.SelectedRow;
                ViewState["PScId"] = row.Cells[1].Text;

                Li_PayScale payScale = new Li_PayScale();
                payScale = Li_PayScaleManager.GetLi_PayScaleByID(Int32.Parse(ViewState["PScId"].ToString()));
                txtPayScaleAmt.Text = payScale.PSAmt.ToString();
                txtPayScaleId.Text = payScale.PScId.ToString();
                ddlInfoStatus.SelectedValue = payScale.InfStId.ToString();
                ddlPayGrade.SelectedValue = payScale.PayGrId.ToString();
                btnSave.Enabled = false;
            }
            catch (Exception)
            {
                
                 
            }
        }
    }
}