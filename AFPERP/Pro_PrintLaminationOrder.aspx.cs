using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Pro_PrintLaminationOrder : System.Web.UI.Page
    {
        string FormID = "PF034";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                getUserAccess();
                if (!IsPostBack)
                {
                    LoadLemiParty();
                    txtOrderDate.Text = String.Format("{0:yyyy-MM-dd}", DateTime.Now);
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
                        btnSavePrint.Enabled = true;
                    }
                    else
                    {
                        btnSavePrint.Enabled = false;
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

        private void LoadLemiParty()
        {
            ddlLemination.DataSource = Li_LeminatioPartyInfoManager.GetAllLi_LeminatioPartyInfos();
            ddlLemination.DataTextField = "Name";
            ddlLemination.DataValueField = "ID";
            ddlLemination.DataBind();

            ddlLemination.Items.Insert(0, new ListItem("--Select--", ""));
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            txtTotalQty.Text = "";
            //crvPrintLeminationOrder.Hide();
            //gvLeminationOrder.Rows.Clear();
            //DateTime d1 = dtpfromDate.Value;
            //DateTime d2 = dtpTodate.Value;
            //string fromdate = d1.ToString("d", DateTimeFormatInfo.InvariantInfo);
            //string todate = d2.ToString("d", DateTimeFormatInfo.InvariantInfo);

            DataSet ds = new DataSet();
            ds = Li_LeminationOrderManager.GetLeminationOrderForPrint(ddlLemination.SelectedValue.ToString(), dtpFromDate.Text, dtpToDate.Text);

            gvwPrintLemiOrder.DataSource = ds.Tables[0];
            gvwPrintLemiOrder.DataBind();

        }

        protected void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int TotalQty = 0;
                for (int i = 0; i < gvwPrintLemiOrder.Rows.Count; i++)
                {

                    CheckBox chkRow = (gvwPrintLemiOrder.Rows[i].Cells[0].FindControl("chkSelect") as CheckBox);
                    if (chkRow.Checked == true)
                    {
                        int qty = Int32.Parse(gvwPrintLemiOrder.Rows[i].Cells[8].Text);

                        TotalQty += qty;

                    }

                    txtTotalQty.Text = TotalQty.ToString(); 


                }
            }
            catch (Exception)
            {


            }
        }

        protected void btnSavePrint_Click(object sender, EventArgs e)
        {
            //crvPrintLeminationOrder.Show();

            if (decimal.Parse(txtTotalQty.Text) == 0.0m || txtTotalQty.Text=="")
            {

                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select for Total Qty');", true);
                return;
            }

            Li_LeminationOrderPrint orderPrint = new Li_LeminationOrderPrint();
            orderPrint.CauseOfDel = "";
            orderPrint.CreatedBy = int.Parse(Session["UserID"].ToString());
            orderPrint.CreatedDate = DateTime.Now;
            orderPrint.DeleBy = 0;
            orderPrint.DeleDate = DateTime.Now;
            orderPrint.OrderDate = DateTime.Parse(txtOrderDate.Text);
            orderPrint.OrderNo = "";
            orderPrint.Status_D = 'C';
            string result = Li_LeminationOrderPrintManager.InsertLi_LeminationOrderPrint(orderPrint);

            for (int i = 0; i < gvwPrintLemiOrder.Rows.Count; i++)
            {

                CheckBox chkRow = (gvwPrintLemiOrder.Rows[i].Cells[0].FindControl("chkSelect") as CheckBox);
                if (chkRow.Checked == true)
                {
                    Li_LeminationOrderPrintDetail OrderPrintDetail = new Li_LeminationOrderPrintDetail();
                    OrderPrintDetail.LemiSerial = Int32.Parse(gvwPrintLemiOrder.Rows[i].Cells[6].Text);
                    OrderPrintDetail.OrderID = result;
                    Li_LeminationOrderPrintDetailManager.InsertLi_LeminationOrderPrintDetail(OrderPrintDetail);
                }
            }

            txtLemiOrderNo.Text = result;
            ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);
            gvwPrintLemiOrder.DataSource = null;
            gvwPrintLemiOrder.DataBind();
        }
    }
}