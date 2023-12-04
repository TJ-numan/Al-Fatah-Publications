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
    public partial class RnD_WorkOrderUpdate : System.Web.UI.Page
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
                    LoadBookSize();
                    gvDateWiseWorkOrderDetails.DataSource = Li_RnDWorkOrderDetailsManager.GetRndWorkOrderUpdateSearchByEmployeeName(txtEmpName.Text, int.Parse(Session["UserID"].ToString()));
                    gvDateWiseWorkOrderDetails.DataBind();
                    txtEDDate.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
                    LoadTask();
                    
                           

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
                    ViewState["WorkOrderDetID"] = row.Cells[2].Text;
                    DataTable dtWorkDetails = Li_RnDWorkOrderDetailsManager.GetLi_RnDWorkOrderDetailsByWorkOrderDetID(Int32.Parse(ViewState["WorkOrderDetID"].ToString())).Tables[0];
                    WorkOrderDetID.Text = dtWorkDetails.Rows[0]["WorkOrderDetID"].ToString();
                    txtEDDate.Text = dtWorkDetails.Rows[0]["EDD"].ToString();
                    ddlSubject.Text= dtWorkDetails.Rows[0]["BookID"].ToString();  
                    ddlTask.SelectedValue = dtWorkDetails.Rows[0]["WorkTypeID"].ToString();
                    ddlBookSize.SelectedValue = dtWorkDetails.Rows[0]["SizeID"].ToString();
                    txtFromPage.Text = dtWorkDetails.Rows[0]["PageStart"].ToString();
                    txtToPage.Text = dtWorkDetails.Rows[0]["PageEnd"].ToString();
                    txtTotalPage.Text = dtWorkDetails.Rows[0]["TotalPage"].ToString();
                    txtTotalForma.Text = dtWorkDetails.Rows[0]["TotalForma"].ToString();
                    txtTotalCharacter.Text = dtWorkDetails.Rows[0]["TotalCharacter"].ToString();
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
                    WorkOderBill.WorkOrderDetID = Int32.Parse(WorkOrderDetID.Text.ToString());
                    WorkOderBill.WorkDate = DateTime.Parse(txtEDDate.Text);
                    WorkOderBill.PageStart = Int32.Parse(txtFromPage.Text.ToString());
                    WorkOderBill.PageEnd = Int32.Parse(txtToPage.Text.ToString());
                    WorkOderBill.TotalPage = (Int32.Parse(txtToPage.Text.ToString())) - (Int32.Parse(txtFromPage.Text.ToString())) + 1;
                    WorkOderBill.TotalForma = decimal.Parse(txtTotalForma.Text.ToString());
                    WorkOderBill.TotalCharacter = decimal.Parse(txtTotalCharacter.Text.ToString());
                    WorkOderBill.CreatedBy = int.Parse(Session["UserID"].ToString());
                    WorkOderBill.SizeID = ddlBookSize.SelectedValue.ToString();
                    WorkOderBill.WorkTypeID = int.Parse(ddlTask.SelectedValue.ToString());
                    WorkOderBill.CreatedDate = DateTime.Now;
                    Li_RnDWorkOrderDetailsManager.UpdateLi_RnDWorkOrderDetails(WorkOderBill);
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Update Successfully');", true);
                    UpdatePanel.Visible = false;
                   // gvDateWiseWorkOrderDetails.DataSource = Li_RnDWorkOrderDetailsManager.GetDatewiseRndWorkOrderDetailsByEmployeeID(dtpFromDate.Text, dtpToDate.Text, ddlEmpName.SelectedValue, ddlEmplyeeFor.SelectedIndex);
                    gvDateWiseWorkOrderDetails.DataSource = Li_RnDWorkOrderDetailsManager.GetRndWorkOrderUpdateSearchByEmployeeName(txtEmpName.Text, int.Parse(Session["UserID"].ToString()));
                    gvDateWiseWorkOrderDetails.DataBind();
            }
            catch (Exception)
            {
               
            }
        }
        private void LoadTask()
        {
            ddlTask.DataSource = Li_TaskManager.GetAllLi_Tasks();
            ddlTask.DataTextField = "TaskName";
            ddlTask.DataValueField = "TaskID";
            ddlTask.DataBind();
            ddlTask.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        protected void txtTopage_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (ddlTask.SelectedValue.ToString() == "12")
                {
                    txtTotalForma.Text = "0";
                }
                else
                {
                    txtTotalCharacter.Text = "0";
                    decimal toPage = Decimal.Parse(txtToPage.Text);
                    decimal fromPage = Decimal.Parse(txtFromPage.Text);
                    //---------------Calculation Book Forma---------------------------------
                    string bookSize = ddlBookSize.SelectedValue.ToString();
                    decimal Setting;
                    decimal formaQty = toPage - fromPage + 1;
                    txtTotalPage.Text = formaQty.ToString();
                    // for DC 1/8 
                    if (ddlBookSize.SelectedValue.ToString() == "BS-001")
                    {
                        Setting = 8;
                        string TotalForma = string.Format("{0:0.##}", ((formaQty / Setting)));
                        txtTotalForma.Text = TotalForma;
                    }
                    // for DD 1/16 
                    else if (ddlBookSize.SelectedValue.ToString() == "BS-002")
                    {
                        Setting = 16;
                        string TotalForma = string.Format("{0:0.##}", ((formaQty / Setting)));
                        txtTotalForma.Text = TotalForma;
                    }
                    // for SDD 1/8
                    else if (ddlBookSize.SelectedValue.ToString() == "BS-003")
                    {
                        Setting = 8;
                        string TotalForma = string.Format("{0:0.##}", ((formaQty / Setting)));
                        txtTotalForma.Text = TotalForma;
                    }

                    // for RL 1/8
                    else if (ddlBookSize.SelectedValue.ToString() == "BS-004")
                    {
                        Setting = 8;
                        string TotalForma = string.Format("{0:0.##}", ((formaQty / Setting)));
                        txtTotalForma.Text = TotalForma;
                    }

                    // for DD 1/8
                    else if (ddlBookSize.SelectedValue.ToString() == "BS-005")
                    {
                        Setting = 8;
                        string TotalForma = string.Format("{0:0.##}", ((formaQty / Setting)));
                        txtTotalForma.Text = TotalForma;
                    }

                    // for SDD 1/4
                    else if (ddlBookSize.SelectedValue.ToString() == "BS-006")
                    {
                        Setting = 4;
                        string TotalForma = string.Format("{0:0.##}", ((formaQty / Setting)));
                        txtTotalForma.Text = TotalForma;
                    }

                    // for DC 1/4
                    else if (ddlBookSize.SelectedValue.ToString() == "BS-0011")
                    {
                        Setting = 4;
                        string TotalForma = string.Format("{0:0.##}", ((formaQty / Setting)));
                        txtTotalForma.Text = TotalForma;
                    }

                    // for DC 1/16
                    else if (ddlBookSize.SelectedValue.ToString() == "BS-0021")
                    {
                        Setting = 16;
                        string TotalForma = string.Format("{0:0.##}", ((formaQty / Setting)));
                        txtTotalForma.Text = TotalForma;
                    }

                    // for RL 1/12

                    else if (ddlBookSize.SelectedValue.ToString() == "BS-007")
                    {
                        Setting = 9;
                        string TotalForma = string.Format("{0:0.##}", ((formaQty / Setting)));
                        txtTotalForma.Text = TotalForma;
                    }

                    else
                    {
                        txtTotalForma.Text = "0";
                    }

                }

            }
            catch (Exception)
            {


            }

        }
        protected void txtEmpName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                gvDateWiseWorkOrderDetails.DataSource = Li_RnDWorkOrderDetailsManager.GetRndWorkOrderUpdateSearchByEmployeeName(txtEmpName.Text, int.Parse(Session["UserID"].ToString()));
                gvDateWiseWorkOrderDetails.DataBind();

            }
            catch (Exception)
            {


            }

        }
        private void LoadBookSize()
        {
            ddlBookSize.DataSource = Li_BookSizeBasicManager.GetAllLi_BookSizeBasics();
            ddlBookSize.DataTextField = "SizeType";
            ddlBookSize.DataValueField = "BookSizeID";
            ddlBookSize.DataBind();
            ddlBookSize.Items.Insert(0, new ListItem("--select--", "0"));
        }
    }
}