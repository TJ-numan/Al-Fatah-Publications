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
    public partial class Rnd_WorkOderBillPaymentGraphics : System.Web.UI.Page
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
                    txtWorkOrder.Text = Request.QueryString["BillNo"];
                    getUserAccess();
                    gvWorkOderDetails.DataSource = Li_RnDWorkOrderDetailsManager.GetLi_RnDWorkOrderDetailsByWorkDetIDGraphics(Int32.Parse(txtWorkOrder.Text.ToString()));
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
        protected void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {

                for (int i = 0; i < gvWorkOderDetails.Rows.Count; i++)
                {
                    Li_RnDWorkOrderDetails WorkOderBill = new Li_RnDWorkOrderDetails();
                    WorkOderBill.WorkOrderDetID = int.Parse(gvWorkOderDetails.Rows[i].Cells[1].Text);
                    WorkOderBill.WorkOrderID = int.Parse(txtWorkOrder.Text);
                    WorkOderBill.EmployeeID = ((TextBox)gvWorkOderDetails.Rows[i].FindControl("txRemarks")).Text;
                    WorkOderBill.CreatedBy = int.Parse(Session["UserID"].ToString());
                    WorkOderBill.CreatedDate = DateTime.Now;
                    Li_RnDWorkOrderDetailsManager.ApprovalLi_RnDWorkOrderBillGraphics(WorkOderBill);
                }
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Bill Approved Successfully!');", true);
                gvWorkOderDetails.DataSource = Li_RnDWorkOrderDetailsManager.GetLi_RnDWorkOrderDetailsByWorkDetIDGraphics(Int32.Parse(txtWorkOrder.Text.ToString()));
                gvWorkOderDetails.DataBind();
                if (gvWorkOderDetails.Rows.Count > 0)
                {
                    btnApprove.Visible = true;
                    btnReject.Visible = true;
                }
                else
                {
                    btnApprove.Visible = false;
                    btnReject.Visible = false;
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Bill already Approved');", true);
                    return;
                }
            }
            catch (Exception)
            {

            }
        }
        protected void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvWorkOderDetails.Rows.Count; i++)
                {
                    string note = ((TextBox)gvWorkOderDetails.Rows[i].FindControl("txRemarks")).Text;
                    if (note == "")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Must entered the reason for reject!');", true);
                        return;
                    }
                    Li_RnDWorkOrderDetails WorkOderBill = new Li_RnDWorkOrderDetails();
                    WorkOderBill.WorkOrderDetID = int.Parse(gvWorkOderDetails.Rows[i].Cells[1].Text);
                    WorkOderBill.WorkOrderID = int.Parse(txtWorkOrder.Text);
                    WorkOderBill.EmployeeID = ((TextBox)gvWorkOderDetails.Rows[i].FindControl("txRemarks")).Text;
                    WorkOderBill.CreatedBy = int.Parse(Session["UserID"].ToString());
                    WorkOderBill.CreatedDate = DateTime.Now;
                    Li_RnDWorkOrderDetailsManager.RejectLi_RnDWorkOrderBill(WorkOderBill);
                }
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Bill Rejected!');", true);
                gvWorkOderDetails.DataSource = Li_RnDWorkOrderDetailsManager.GetLi_RnDWorkOrderDetailsByWorkDetIDGraphics(Int32.Parse(txtWorkOrder.Text.ToString()));
                gvWorkOderDetails.DataBind();
                if (gvWorkOderDetails.Rows.Count > 0)
                {
                    btnApprove.Visible = true;
                    btnReject.Visible = true;
                }
                else
                {
                    btnApprove.Visible = false;
                    btnReject.Visible = false;
                }
            }
            catch (Exception)
            {

            }
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                gvWorkOderDetails.DataSource = Li_RnDWorkOrderDetailsManager.GetLi_RnDWorkOrderDetailsByWorkDetIDGraphics(Int32.Parse(txtWorkOrder.Text.ToString()));
                gvWorkOderDetails.DataBind();
                if (gvWorkOderDetails.Rows.Count > 0)
                {
                    btnApprove.Visible = true;
                    btnReject.Visible = true;
                }
                else
                {
                    btnApprove.Visible = false;
                    btnReject.Visible = false;
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Bill already Approved');", true);
                    return;
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
            try
            {

            }
            catch (Exception)
            {


            }

        }
    }
}