using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Marketing;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DAL;


namespace BLL
{
    public partial class RnD_WorkOrderUpdateByOrderNo : System.Web.UI.Page
    {
       string FormID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");

                if (!IsPostBack)
                {
                    getUserAccess();
                    gvWorkOderDetails.DataSource = Li_RnDWorkOrderDetailsManager.GetLi_RnDWorkOrderDetailsByWorkIDForUpdateAndDelete(txtWorkOrder.Text.ToString(), int.Parse(Session["UserID"].ToString()));
                    gvWorkOderDetails.DataBind();

                }

            }
            catch (Exception)
            {

            }
        }
        private void getUserAccess()
        {
            DataTable dt = Li_AdminUserManager.GetUserAccess(int.Parse(Session["UserID"].ToString()), FormID).Tables[0];
            if (dt.Rows.Count > 0)
            {

                if (Session["UserID"].ToString() == dt.Rows[0]["UserID"].ToString() && FormID == dt.Rows[0]["FormId"].ToString())
                {
                    if (Boolean.Parse(dt.Rows[0]["Insert_"].ToString()) == true)
                    {
                        btnShow.Enabled = true;
                    }
                    else
                    {
                        btnShow.Enabled = false;
                    }
                    if (Boolean.Parse(dt.Rows[0]["Update_"].ToString()) == true)
                    {
                        //btnUpdate.Enabled = true;
                    }
                    else
                    {
                        //btnUpdate.Enabled = false;
                    }
                    if (Boolean.Parse(dt.Rows[0]["Delete_"].ToString()) == true)
                    {
                        //btnDelete.Enabled = true;
                    }
                    else
                    {
                        //btnDelete.Enabled = false;
                    }
                    if (Boolean.Parse(dt.Rows[0]["View_"].ToString()) == false)
                    {
                        Response.Redirect("~/RandDHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                gvWorkOderDetails.DataSource = Li_RnDWorkOrderDetailsManager.GetLi_RnDWorkOrderDetailsByWorkIDForUpdateAndDelete(txtWorkOrder.Text.ToString(), int.Parse(Session["UserID"].ToString()));
                gvWorkOderDetails.DataBind();
                for (int i = 0; i < gvWorkOderDetails.Rows.Count; i++)
                {

                    CheckBox chkRow = (gvWorkOderDetails.Rows[i].Cells[0].FindControl("chkWorkOrderSelect") as CheckBox);

                    if (chkRow.Checked == true)
                    {

                        ((Button)gvWorkOderDetails.Rows[i].FindControl("btnUpdate")).Enabled = true;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("EDD")).Enabled = true;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("PageStart")).Enabled = true;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("PageEnd")).Enabled = true;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("TotalPage")).Enabled = true;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("TotalForma")).Enabled = true;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("TotalCharacter")).Enabled = true;

                    }
                    else
                    {
                        ((Button)gvWorkOderDetails.Rows[i].FindControl("btnUpdate")).Enabled = false;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("EDD")).Enabled = false;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("PageStart")).Enabled = false;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("PageEnd")).Enabled = false;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("TotalPage")).Enabled = false;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("TotalForma")).Enabled = false;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("TotalCharacter")).Enabled = false;

                    }

                }


            }
            catch (Exception)
            {

            }
        }

        protected void gvWorkOderDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }
        protected void gvWorkOderDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePanel.Visible = true;
            try
            {
                try
                {
                    GridViewRow row = gvWorkOderDetails.SelectedRow;
                    ViewState["WorkDetailID"] = row.Cells[1].Text;
                    DataTable dtLibrary = Li_RnDWorkDetailsManager.GetLi_RnDWorkDetailsByWorkID(Int32.Parse(ViewState["WorkDetailID"].ToString())).Tables[0];
                    txtDetailsID.Text = dtLibrary.Rows[0]["WorkDetailID"].ToString();
                    txtDate.Text = dtLibrary.Rows[0]["WorkDate"].ToString();
                    txtStartTime.Text = dtLibrary.Rows[0]["WorkStartTime"].ToString();
                    txtEndTime.Text = dtLibrary.Rows[0]["WorkEndTime"].ToString();
                    ddlSubject.SelectedValue = dtLibrary.Rows[0]["BookID"].ToString();
                    ddlTask.SelectedValue = dtLibrary.Rows[0]["WorkTypeID"].ToString();
                    txtStartPage.Text = dtLibrary.Rows[0]["PageStart"].ToString();
                    txtEndPage.Text = dtLibrary.Rows[0]["PageEnd"].ToString();
                    txtComments.Text = dtLibrary.Rows[0]["Comments"].ToString();
                }
                catch (Exception)
                {

                }
            }
            catch (Exception)
            {


            }

        }
        protected void chkWorkOrderSelect_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvWorkOderDetails.Rows.Count; i++)
                {

                    CheckBox chkRow = (gvWorkOderDetails.Rows[i].Cells[0].FindControl("chkWorkOrderSelect") as CheckBox);

                    if (chkRow.Checked == true)
                    {

                        ((Button)gvWorkOderDetails.Rows[i].FindControl("btnUpdate")).Enabled = true;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("EDD")).Enabled = true;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("PageStart")).Enabled = true;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("PageEnd")).Enabled = true;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("TotalPage")).Enabled = true;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("TotalForma")).Enabled = true;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("TotalCharacter")).Enabled = true;
                   
                    }
                    else
                    {
                        ((Button)gvWorkOderDetails.Rows[i].FindControl("btnUpdate")).Enabled = false;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("EDD")).Enabled = false;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("PageStart")).Enabled = false;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("PageEnd")).Enabled = false;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("TotalPage")).Enabled = false;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("TotalForma")).Enabled = false;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("TotalCharacter")).Enabled = false;
                        
                        
                    }

                }
            }
            catch (Exception)
            {


            }
        }
        protected void btnUpdate_OnClick(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvWorkOderDetails.Rows.Count; i++)
                {
                    CheckBox chkRow = (gvWorkOderDetails.Rows[i].Cells[0].FindControl("chkWorkOrderSelect") as CheckBox);

                    if (chkRow.Checked == true)
                    {
                        Li_RnDWorkOrderDetails WorkOderBill = new Li_RnDWorkOrderDetails();
                        WorkOderBill.WorkOrderDetID = int.Parse(gvWorkOderDetails.Rows[i].Cells[2].Text);
                        WorkOderBill.WorkDate = DateTime.Parse(((TextBox)gvWorkOderDetails.Rows[i].FindControl("EDD")).Text);
                        WorkOderBill.PageStart = int.Parse(((TextBox)gvWorkOderDetails.Rows[i].FindControl("PageStart")).Text);
                        WorkOderBill.PageEnd = int.Parse(((TextBox)gvWorkOderDetails.Rows[i].FindControl("PageEnd")).Text);
                        WorkOderBill.TotalPage = (int.Parse(((TextBox)gvWorkOderDetails.Rows[i].FindControl("PageEnd")).Text) - int.Parse(((TextBox)gvWorkOderDetails.Rows[i].FindControl("PageStart")).Text)) +1;
                        WorkOderBill.TotalForma = decimal.Parse(((TextBox)gvWorkOderDetails.Rows[i].FindControl("TotalForma")).Text);
                        WorkOderBill.TotalCharacter = decimal.Parse(((TextBox)gvWorkOderDetails.Rows[i].FindControl("TotalCharacter")).Text);
                        WorkOderBill.CreatedBy = int.Parse(Session["UserID"].ToString());
                        WorkOderBill.CreatedDate = DateTime.Now;
                        Li_RnDWorkOrderDetailsManager.UpdateLi_RnDWorkOrderDetails(WorkOderBill);
                    }

               }


                string message = "Update Successfully!";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += Request.Url.AbsoluteUri;
                script += "'; }";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script,
                    true);
            }
            catch (Exception)
            {

            }
        }
        DataAccessObject DAO = new DataAccessObject();
        ReportDocument rd = new ReportDocument();
        protected void btnPrint_OnClick(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvWorkOderDetails.Rows.Count; i++)
                {
                    CheckBox chkRow = (gvWorkOderDetails.Rows[i].Cells[0].FindControl("chkWorkOrderSelect") as CheckBox);

                    if (chkRow.Checked == true)
                    {
                        int WorkDetID = int.Parse(gvWorkOderDetails.Rows[i].Cells[2].Text);
                        String BillNo;
                        DataSet ds = new DataSet();
                        ds =  Li_RnDWorkOrderDetailsManager.GetLi_RnDWorkOrderBillNoByWorkDetID(WorkDetID);
                        int rowNumber = ds.Tables[0].Rows.Count;
                        if (rowNumber > 0)
                        {
                            for (int j = 0; j < rowNumber; j++)
                            {
                                BillNo = ds.Tables[0].Rows[j]["WorkOrderBillID"].ToString();
                                Response.Redirect("~/Rnd_WorkOderBillPayment.aspx?BillNo=" + BillNo);
                            }
                        }
                        //Response.Redirect("~/Rnd_WorkOderBillPayment.aspx?BillNo=" + BillNo);
                    }
                }
            }
            catch
            {

            }
        }
    }
}
