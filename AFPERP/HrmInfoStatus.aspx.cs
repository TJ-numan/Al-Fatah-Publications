using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmInfoStatus : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                { 
                    txtInfoStatus.Attributes.Add("autocomplete", "off");
                    gvEmpInfoStatus.DataSource = Li_InfoStatusManager.GetAllLi_InfoStatuss();
                    gvEmpInfoStatus.DataBind();
                }
                
            }
            catch (Exception)
            {


            }
        }

        //protected void lbSelect_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        LinkButton linkButton = new LinkButton();
        //        linkButton = (LinkButton)sender;
        //        ViewState["rowNo"] = Convert.ToInt32(linkButton.CommandArgument);
        //        int row = Int32.Parse(ViewState["rowNo"].ToString());
        //        Label lblInfId = (Label)gvEmpInfoStatus.Rows[row].Cells[1].FindControl("lblInfoId");
        //        Label lblInfStatus = (Label)gvEmpInfoStatus.Rows[row].Cells[2].FindControl("lblInfStatus");
        //        txtInfoId.Text = lblInfId.Text;
        //        txtInfoStatus.Text = lblInfStatus.Text;
        //        btnSave.Enabled = false;


        //    }
        //    catch (Exception)
        //    {


        //    }
        //}

/*
        private void LoadInfos()
        {
            int i = 0;

            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "tblInfoStatus";
            dt.Columns.Add("Select", typeof(Int32));
            dt.Columns.Add("InfStId", typeof(Int32));
            dt.Columns.Add("InfStatus", typeof(string));

            List<Li_InfoStatus> infos = new List<Li_InfoStatus>();
            infos = Li_InfoStatusManager.GetAllLi_InfoStatuss();

            foreach (Li_InfoStatus info in infos)
            {
                dr = dt.NewRow();
                dr["Select"] = i;
                dr["InfStId"] = info.InfStId;
                dr["InfStatus"] = info.InfStatus;
                dt.Rows.Add(dr);
                i++;

            }

            gvEmpInfoStatus.DataSource = dt;
            gvEmpInfoStatus.DataBind();

        }

*/

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInfoStatus.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Status Name');", true);
                    return;
                }

                Li_InfoStatus infStatus = new Li_InfoStatus();
                infStatus.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                infStatus.CreatedDate = DateTime.Now;
                infStatus.InfStatus = txtInfoStatus.Text;
                infStatus.InfStId = 0;
                infStatus.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                infStatus.ModifiedDate = DateTime.Now;
                Li_InfoStatusManager.InsertLi_InfoStatus(infStatus);

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

                if (txtInfoStatus.Text.Trim() == "" || txtInfoId .Text.Trim ()=="" )
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Status Name');", true);
                    return;
                }

                Li_InfoStatus infStatus = new Li_InfoStatus();

                infStatus.InfStatus = txtInfoStatus.Text;
                infStatus.InfStId =  Int32 .Parse (txtInfoId .Text );
                infStatus.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                infStatus.ModifiedDate = DateTime.Now;
                Li_InfoStatusManager.UpdateLi_InfoStatus(infStatus);

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

        protected void gvEmpInfoStatus_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
				
        }

        protected void gvEmpInfoStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvEmpInfoStatus.SelectedRow;
                ViewState["InfStId"] = row.Cells[1].Text;
                Li_InfoStatus infoStatus = new Li_InfoStatus();
                infoStatus = Li_InfoStatusManager.GetLi_InfoStatusByID(Int32.Parse(ViewState["InfStId"].ToString()));

                txtInfoId.Text = infoStatus.InfStId.ToString();
                txtInfoStatus.Text = infoStatus.InfStatus;
                btnSave.Enabled = false;
            }
            catch (Exception)
            {
                
                
            }
        }
    }
}