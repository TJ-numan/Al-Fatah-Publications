using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Pro_PlateProcessBill : System.Web.UI.Page
    {
        string FormID = "PF024";
        DataAccessObject DAO = new DataAccessObject();
        string ReturnMemo;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                getUserAccess();
                if (!IsPostBack)
                {
                    txtTotalQty.Text = ReturnMemo;

                    LoadPlateProcess();
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
                        btnSave.Enabled = true;
                    }
                    else
                    {
                        btnSave.Enabled = false;
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
                        Response.Redirect("~/ProHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }

        private void LoadPlateProcess()
        {
            ddlSupplier.DataSource = Li_PlateProcessPartyManager.GetAllLi_PlateProcessParties();
            ddlSupplier.DataTextField = "Name";
            ddlSupplier.DataValueField = "ID";
            ddlSupplier.DataBind();
            ddlSupplier.Items.Insert(0, new ListItem("--Select--", ""));
        }

        protected void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtTotalQty.Text = "0";
                txtTotalBill.Text = "0";

                gvwReceiveDetails.DataSource = null;

                DataSet ds = new DataSet();
                ds = Li_ProcessBillManager.GetPlateProcessDetail(ddlSupplier.SelectedValue);

                gvwReceiveDetails.DataSource = ds.Tables[0];
                gvwReceiveDetails.DataBind();

                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    object[] row = { false
                //                     ,ds.Tables[0].Rows[i]["PlateQty"].ToString() 
                //                     ,ds.Tables[0].Rows[i]["Pro_ID"].ToString()
                //                     ,ds.Tables[0].Rows[i]["TotalBill"].ToString()
                //                     ,ds.Tables[0].Rows[i]["ReceiveIn"].ToString()
                //                    ,ds.Tables[0].Rows[i]["PressID"].ToString()
                //                   };

                //    gvPlateReceive.Rows.Add(row);

                //} 

            }
            catch (Exception)
            {


            }
        }

        protected void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int totalPlate = 0; decimal totalBill = 0.0m;
                for (int i = 0; i < gvwReceiveDetails.Rows.Count; i++)
                {

                    CheckBox chkRow = (gvwReceiveDetails.Rows[i].Cells[0].FindControl("chkSelect") as CheckBox);
                    if (chkRow.Checked == true)
                    {
                        int plate = int.Parse(gvwReceiveDetails.Rows[i].Cells[1].Text);
                        decimal bill = decimal.Parse(gvwReceiveDetails.Rows[i].Cells[3].Text);

                        totalPlate += plate;
                        totalBill += bill;

                    }


                    txtTotalBill.Text = string.Format("{0:0.##}", totalBill);
                    txtTotalQty.Text = string.Format("{0:0.##}", totalPlate);


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
                if (txtBillDate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please given a Valid Date');", true);
                    return;
                }
                if (decimal.Parse(txtTotalBill.Text) == 0.0m)
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select order for Bill adjustment');", true);
                    return;
                }

                Li_ProcessBill processBill = new Li_ProcessBill();
                processBill.Amount = decimal.Parse(txtTotalBill.Text);
                processBill.BillNo = txtBillNo.Text;
                processBill.CreatedBy = int.Parse(Session["UserID"].ToString());
                processBill.CreatedDate = DateTime.Parse(txtBillDate.Text);
                processBill.ProcessID = ddlSupplier.SelectedValue;
                processBill.Status_D = 'C';
                int result = Li_ProcessBillManager.InsertLi_ProcessBill(processBill);

                for (int i = 0; i < gvwReceiveDetails.Rows.Count; i++)
                {
                    CheckBox chkRow = (gvwReceiveDetails.Rows[i].Cells[0].FindControl("chkSelect") as CheckBox);
                    if (chkRow.Checked)
                    {
                        Li_ProcessBillDetail processBillDetail = new Li_ProcessBillDetail();

                        processBillDetail.Pro_Order = gvwReceiveDetails.Rows[i].Cells[2].Text;
                        processBillDetail.Bill = decimal.Parse(gvwReceiveDetails.Rows[i].Cells[3].Text);
                        processBillDetail.PressID = gvwReceiveDetails.Rows[i].Cells[5].Text;
                        processBillDetail.BillSerial = result;
                        Li_ProcessBillDetailManager.InsertLi_ProcessBillDetail(processBillDetail);
                    }


                }


                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);
                gvwReceiveDetails.DataSource = null;
                gvwReceiveDetails.DataBind();

                txtTotalBill.Text = "";
                txtTotalQty.Text = "";

            }
            catch (Exception)
            {


            }
        }

        protected void btnShowBill_Click(object sender, EventArgs e)
        {
            try
            {
                ReportDocument rd = new ReportDocument();
                rd.Load(Server.MapPath(@"~/Reports/PRO/rptPrintPlateProcessBill.rpt"));
                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@BillNo", txtBillNo.Text);
                rd.SetParameterValue("@ProcessID", ddlSupplier.SelectedValue);
                rd.SetParameterValue("@BillDate", txtBillDate.Text);
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Plate Process Bill");
            }
            catch (Exception ex)
            {

            }
        }


    }
}