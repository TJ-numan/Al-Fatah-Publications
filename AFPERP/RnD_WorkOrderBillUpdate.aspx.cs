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
    public partial class RnD_WorkOrderBillUpdate : System.Web.UI.Page
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
                    //LoadBookBySection();
                    gvDateWiseWorkOrderDetails.DataSource = Li_RnDWorkOrderDetailsManager.GetLi_RnDWorkOrderBillUpdateInfoByOrderNo(txtEmpName.Text.ToString(), int.Parse(Session["UserID"].ToString()));
                    gvDateWiseWorkOrderDetails.DataBind();
                    for (int i = 0; i < gvDateWiseWorkOrderDetails.Rows.Count; i++)
                    {
                        Button paid = (Button)gvDateWiseWorkOrderDetails.Rows[i].FindControl("btnStatus");
                        if (paid.Text == "Pending")
                        {
                            paid.Enabled = false;

                        }
                        else if (paid.Text == "Rejected")
                        {
                            paid.Enabled = false;
                            paid.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            paid.Enabled = false;
                            paid.ForeColor = System.Drawing.Color.Green;
                        }
                    }
                    txtDDate.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
                    //LoadTask();
                    
                           

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

        //private void LoadBookBySection()
        //{
        //    ddlSubject.DataSource = li_BookInformationManager.GetAll_BookInformations();
        //    ddlSubject.DataTextField = "BookName";
        //    ddlSubject.DataValueField = "BookID";
        //    ddlSubject.DataBind();
        //}

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
                    ViewState["BillNo"] = row.Cells[3].Text;
                    DataTable dtWorkDetails = Li_RnDWorkOrderDetailsManager.GetLi_RnDWorkOrderBillDetailsByBillNo(Int32.Parse(ViewState["BillNo"].ToString())).Tables[0];
                    TxtBillNo.Text = dtWorkDetails.Rows[0]["BillNo"].ToString();
                    WorkOrderDetID.Text = dtWorkDetails.Rows[0]["WorkOrderDetID"].ToString();
                    ddlEmployeeName.Text= dtWorkDetails.Rows[0]["EmployeeID"].ToString();                   
                    //ddlSubject.SelectedValue = dtWorkDetails.Rows[0]["BookID"].ToString();
                    ddlSubject.Text= dtWorkDetails.Rows[0]["BookID"].ToString();  
                    //ddlTask.SelectedValue = dtWorkDetails.Rows[0]["WorkTypeID"].ToString();
                    ddlTask.Text = dtWorkDetails.Rows[0]["WorkTypeID"].ToString(); 
                    txtDDate.Text = dtWorkDetails.Rows[0]["DD"].ToString();
                    txtTotalPage.Text = dtWorkDetails.Rows[0]["TotalPage"].ToString();
                    txtTotalDelivery.Text = dtWorkDetails.Rows[0]["TotalDelivery"].ToString();
                    txtRate.Text = dtWorkDetails.Rows[0]["Rate"].ToString();
                    txtTotalAmount.Text = dtWorkDetails.Rows[0]["Amount"].ToString();
                }
                catch (Exception)
                {

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
                    Li_RnDWorkOrderDetails WorkOderBill = new Li_RnDWorkOrderDetails();
                    WorkOderBill.WorkOrderID = Int32.Parse(TxtBillNo.Text.ToString());
                    WorkOderBill.WorkDate = DateTime.Parse(txtDDate.Text);
                    WorkOderBill.TotalForma = decimal.Parse(txtTotalDelivery.Text.ToString());
                    WorkOderBill.TotalCharacter = decimal.Parse(txtRate.Text.ToString());
                    WorkOderBill.CreatedBy = int.Parse(Session["UserID"].ToString());
                    WorkOderBill.CreatedDate = DateTime.Now;
                    Li_RnDWorkOrderDetailsManager.UpdateLi_RnDWorkOrderBill(WorkOderBill);
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Update Successfully');", true);
                    UpdatePanel.Visible = false;
                    gvDateWiseWorkOrderDetails.DataSource = Li_RnDWorkOrderDetailsManager.GetLi_RnDWorkOrderBillUpdateInfoByOrderNo(txtEmpName.Text.ToString(), int.Parse(Session["UserID"].ToString()));
                    gvDateWiseWorkOrderDetails.DataBind();
                    for (int i = 0; i < gvDateWiseWorkOrderDetails.Rows.Count; i++)
                    {
                        Button paid = (Button)gvDateWiseWorkOrderDetails.Rows[i].FindControl("btnStatus");
                        if (paid.Text == "Pending")
                        {
                            paid.Enabled = false;

                        }
                        else if (paid.Text == "Rejected")
                        {
                            paid.Enabled = false;
                            paid.BackColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            paid.Enabled = false;
                            paid.BackColor = System.Drawing.Color.Green;
                        }
                    }
            }
            catch (Exception)
            {
               
            }
        }
        //private void LoadTask()
        //{
        //    ddlTask.DataSource = Li_TaskManager.GetAllLi_Tasks();
        //    ddlTask.DataTextField = "TaskName";
        //    ddlTask.DataValueField = "TaskID";
        //    ddlTask.DataBind();
        //    ddlTask.Items.Insert(0, new ListItem("-Select-", "0"));
        //}

        protected void txtEmpName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                gvDateWiseWorkOrderDetails.DataSource = Li_RnDWorkOrderDetailsManager.GetLi_RnDWorkOrderBillUpdateInfoByOrderNo(txtEmpName.Text.ToString(), int.Parse(Session["UserID"].ToString()));
                gvDateWiseWorkOrderDetails.DataBind();
                for (int i = 0; i < gvDateWiseWorkOrderDetails.Rows.Count; i++)
                {
                    Button paid = (Button)gvDateWiseWorkOrderDetails.Rows[i].FindControl("btnStatus");
                    if (paid.Text == "Pending")
                    {
                        paid.Enabled = false;

                    }
                    else if (paid.Text == "Rejected")
                    {
                        paid.Enabled = false;
                        paid.BackColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        paid.Enabled = false;
                        paid.BackColor = System.Drawing.Color.Green;
                    }
                }

            }
            catch (Exception)
            {


            }

        }
        protected void txtQtyChange_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal qty = Decimal.Parse(txtTotalDelivery.Text.ToString());
                decimal rate = Decimal.Parse(txtRate.Text.ToString());
                txtTotalAmount.Text = (qty * rate).ToString("0.00");
            }
            catch (Exception)
            {


            }

        }
    }
}