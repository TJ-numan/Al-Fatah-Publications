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
    public partial class RnD_WorkOrderTransferQawmi : System.Web.UI.Page
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
                    string toDay = DateTime.Now.ToString("yyyy-MM-dd");
                    txtEDDate.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Now);



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
                        //btnShow.Enabled = true;
                    }
                    else
                    {
                        //btnShow.Enabled = false;
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
                //Response.Redirect("~/RandDHome.aspx");
            }
        }
        protected void ddlSection_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (ddlSection.SelectedIndex >= 0)
                {

                    LoadEmployee(int.Parse(ddlSection.SelectedValue.ToString()), int.Parse(ddlEmplyeeFor.SelectedValue.ToString()));
                }
            }
            catch (Exception)
            {


            }
        }
        private void LoadEmployee(int id, int employeer)
        {

            ddlEmpName.DataSource = Li_EmployeeInfoManager.GetLi_EmployeeListRZBySecID(id, employeer);
            ddlEmpName.DataTextField = "Name";
            ddlEmpName.DataValueField = "EmployeeID";
            ddlEmpName.DataBind();
            ddlEmpName.Items.Insert(0, new ListItem("--Select--", ""));

        }
        //private void LoadEmpName(int id, int employeer)
        //{

        //    ddlEmployeeName.DataSource = Li_EmployeeInfoManager.GetLi_EmployeeListRZBySecID(id, employeer);
        //    ddlEmployeeName.DataTextField = "Name";
        //    ddlEmployeeName.DataValueField = "EmployeeID";
        //    ddlEmployeeName.DataBind();
        //    ddlEmployeeName.Items.Insert(0, new ListItem("--Select--", ""));

        //}
        protected void ddlEmployeeFor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEmplyeeFor.SelectedValue.ToString() == "1")
            {
                ddlSection.DataSource = Li_SectionManager.LoadAllSection();
                ddlSection.DataTextField = "SectionName";
                ddlSection.DataValueField = "SectionID";
                ddlSection.DataBind();
                ddlSection.Items.Insert(0, new ListItem("--Select--", ""));
            }
            else if (ddlEmplyeeFor.SelectedValue.ToString() == "2")
            {
                ddlSection.DataSource = Li_SectionManager.LoadHireSection();
                ddlSection.DataTextField = "SectionName";
                ddlSection.DataValueField = "SectionID";
                ddlSection.DataBind();
                ddlSection.Items.Insert(0, new ListItem("--Select--", ""));
            }
        }

        protected void gvDateWiseWorkDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
        }

        protected void gvDateWiseWorkDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePanel.Visible = true;
            try
            {
                try
                {
                    GridViewRow row = gvDateWiseWorkOrderDetails.SelectedRow;
                    ViewState["WorkOrderDetID"] = row.Cells[2].Text;
                    DataTable dtWorkDetails = Li_RnDQawmiWorkOrderDetailsManager.GetLi_RnDWorkOrderDetailsByWorkOrderDetIDForTransfer(Int32.Parse(ViewState["WorkOrderDetID"].ToString())).Tables[0];
                    WorkOrderDetID.Text = dtWorkDetails.Rows[0]["WorkOrderDetID"].ToString();
                    txtTotalQty.Text = dtWorkDetails.Rows[0]["TotalQty"].ToString();
                    txtTotalDeliveryQty.Text = dtWorkDetails.Rows[0]["TotalDelivery"].ToString();
                    txtTotalTransferQty.Text = dtWorkDetails.Rows[0]["TransferedQty"].ToString();
                    txtTotalDueQty.Text = dtWorkDetails.Rows[0]["DueQty"].ToString();
                    ddlEmployeeName.Text = dtWorkDetails.Rows[0]["EmployeeID"].ToString();
                    //ddlEmployeeName.SelectedValue = dtWorkDetails.Rows[0]["EmployeeID"].ToString();
                }
                catch (Exception)
                {

                }
            }
            catch (Exception)
            {


            }

        }
        protected void btnTranfer_OnClick(object sender, EventArgs e)
        {
            try
            {
                decimal tq = decimal.Parse(txtTotalTransfer.Text.ToString());
                decimal dq = decimal.Parse(txtTotalDueQty.Text.ToString());
                if (tq > dq)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Transfer Qty is Greater than Due Qty');", true);
                    return;
                }
                Li_RnDWorkOrderDetails WorkOderBill = new Li_RnDWorkOrderDetails();
                WorkOderBill.WorkOrderDetID = Int32.Parse(WorkOrderDetID.Text.ToString());
                WorkOderBill.SectionID = Int32.Parse(ddlSection.SelectedValue.ToString());
                WorkOderBill.IsHired = Int32.Parse(ddlEmplyeeFor.SelectedValue.ToString());
                WorkOderBill.EmployeeID = ddlEmpName.SelectedValue.ToString();
                WorkOderBill.WorkDate = DateTime.Parse(txtEDDate.Text);
                WorkOderBill.TotalForma = decimal.Parse(txtTotalTransfer.Text.ToString());
                WorkOderBill.CreatedBy = int.Parse(Session["UserID"].ToString());
                WorkOderBill.CreatedDate = DateTime.Now;
                Li_RnDWorkOrderDetailsManager.TransferLi_RnDWorkOrderDetails(WorkOderBill);
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Transfered Successfully');", true);
                UpdatePanel.Visible = false;
                gvDateWiseWorkOrderDetails.DataSource = Li_RnDQawmiWorkOrderDetailsManager.GetLi_RnDWorkOrderDetailsByWorkIDforBillGenerate(txtEmpName.Text, int.Parse(Session["UserID"].ToString()));
                gvDateWiseWorkOrderDetails.DataBind();
            }
            catch (Exception)
            {

            }
        }
        protected void txtEmpName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                gvDateWiseWorkOrderDetails.DataSource = Li_RnDQawmiWorkOrderDetailsManager.GetLi_RnDWorkOrderDetailsByWorkIDforBillGenerate(txtEmpName.Text, int.Parse(Session["UserID"].ToString()));
                gvDateWiseWorkOrderDetails.DataBind();

            }
            catch (Exception)
            {


            }

        }
    }
}