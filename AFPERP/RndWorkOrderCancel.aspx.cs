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
    public partial class RndWorkOrderCancel : System.Web.UI.Page
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
                        ((Button)gvWorkOderDetails.Rows[i].FindControl("btnCancel")).Enabled = true;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("txtRemarks")).Enabled = true;

                    }
                    else
                    {
                        ((Button)gvWorkOderDetails.Rows[i].FindControl("btnCancel")).Enabled = false;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("txtRemarks")).Enabled = false;

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
            try
            {
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

                        ((Button)gvWorkOderDetails.Rows[i].FindControl("btnCancel")).Enabled = true;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("txtRemarks")).Enabled = true;
                   
                    }
                    else
                    {
                        ((Button)gvWorkOderDetails.Rows[i].FindControl("btnCancel")).Enabled = false;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("txtRemarks")).Enabled = false;
                        
                        
                    }

                }
            }
            catch (Exception)
            {


            }
        }
        protected void btnCancel_OnClick(object sender, EventArgs e)
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
                        string Remarks = (((TextBox)gvWorkOderDetails.Rows[i].FindControl("txtRemarks")).Text);
                        WorkOderBill.EmployeeID = Remarks;
                        WorkOderBill.CreatedBy = int.Parse(Session["UserID"].ToString());
                        WorkOderBill.CreatedDate = DateTime.Now;
                        Li_RnDWorkOrderDetailsManager.Delete_Li_RnDWorkOrder(WorkOderBill);
                        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Delete Successfully');", true);
                        gvWorkOderDetails.DataSource = Li_RnDWorkOrderDetailsManager.GetLi_RnDWorkOrderDetailsByWorkIDForUpdateAndDelete(txtWorkOrder.Text.ToString(), int.Parse(Session["UserID"].ToString()));
                        gvWorkOderDetails.DataBind();
                    }

               }

            }
            catch (Exception)
            {

            }
        }
    }
}