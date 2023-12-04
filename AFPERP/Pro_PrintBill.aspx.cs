using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Pro_PrintBill : System.Web.UI.Page
    {
        string FormID = "PF032";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                getUserAccess();
                if (!IsPostBack)
                {
                    LoadPress();
                    LoadBook();
                    //LoadPlateFor();
                    //cmbOrderNo.Text = OrderNo;
                    SetPlateFor();
                    LoadOrder();

                    txtPrintBillDate.Text = String.Format("{0:yyyy/MM/dd}", DateTime.Now);
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

        private void LoadPress()
        {
            ddlPressName.DataSource = Li_PressInfoManager.GetAllLi_PressInfos();
            ddlPressName.DataTextField = "PressName";
            ddlPressName.DataValueField = "PressID";
            ddlPressName.DataBind();
            ddlPressName.SelectedIndex= - 1;
            //ddlPressName.Items.Insert(0, new ListItem("--select--", ""));

        }

        private void LoadBook()
        {
            ddlBookName.DataSource = li_BookInformationManager.Get_BookInformations_ComboSourceData();
            ddlBookName.DataTextField = "BookName";
            ddlBookName.DataValueField = "BookID";
            ddlBookName.DataBind();
            ddlBookName.SelectedIndex = -1;

        }

        private void SetPlateFor()
        {

            string[] arr = ddlOrderNo.Text.Split(new char[] { '-' });//'-'

            string OrderPrifix = arr[0];

            if (OrderPrifix == "POF")
            {
                ddlPlateFor.SelectedValue = "F";
            }
            else if (OrderPrifix == "POC")
            {
                ddlPlateFor.SelectedValue = "C";
            }
            else if (OrderPrifix == "POA")
            {
                ddlPlateFor.SelectedValue = "A";
            }
            else if (OrderPrifix == "POP")
            {
                ddlPlateFor.SelectedValue = "P";
            }
            else
            {
                return;
            }
        }

        private void LoadOrder()
        {
            try
            {
                txtTotalBill.Text = "0";
                txtPrintBill.Text = "0";
                txtTotalPlateBill.Text = "0";
                txtTotalPlateQty.Text = "0";
                txtTotalProcessBill.Text = "0";

                //gvwPrintBill.Rows.Clear();
                //gvwPlateBill.Rows.Clear();
                DataSet ds = new DataSet();
                ds = Li_Print_Order_FormaManager.GetPrintOrderInforByOrderNoAndPress(ddlOrderNo.Text, ddlPressName.SelectedValue.ToString(), ddlPlateFor.SelectedValue.ToString(), chkExtra.Checked ? true : false, true);
                //cmbOrderNo.Text = ds.Tables[0].Rows[0]["Print_OrderNo"].ToString();
                ddlBookName.SelectedValue = ds.Tables[0].Rows[0]["BookID"].ToString();
                txtGroup.Text = ds.Tables[0].Rows[0]["GName"].ToString();
                txtClass.Text = ds.Tables[0].Rows[0]["ClassName"].ToString();
                txtType.Text = ds.Tables[0].Rows[0]["TypeName"].ToString();
                txtEdition.Text = ds.Tables[0].Rows[0]["Edition"].ToString();
                txtPrintQty.Text = ds.Tables[0].Rows[0]["PrintQty"].ToString();
                txtPrintOrderDate.Text = DateTime.Parse(ds.Tables[0].Rows[0]["OrderDate"].ToString()).ToString("yyyy/MM/dd");


                gvwPlateBill.Focus();


                if (chkExtra.Checked) { }
                else
                {

                    gvwPrintBill.DataSource = ds.Tables[0];
                    gvwPrintBill.DataBind();
                    //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    //{



                    //    object[] row = { 
                    //                 ds.Tables[0].Rows[i]["SerialNo"].ToString(), 
                    //                 true  ,
                    //                ds.Tables[0].Rows[i]["BookPart"].ToString(), 
                    //                ds.Tables[0].Rows[i]["PrintSl"].ToString(), 
                    //                ds.Tables[0].Rows[i]["FormaQty"].ToString(), 
                    //                ds.Tables[0].Rows[i]["FormaDis"].ToString(), 
                    //                ds.Tables[0].Rows[i]["ColorNo"].ToString(),

                    //               ds.Tables[0].Rows[i]["PrintQty"].ToString(),
                    //               ds.Tables[0].Rows[i]["BillRate"].ToString() ,
                    //               ds.Tables[0].Rows[i]["TotalBill"].ToString()  
                    //           };
                    //    gvwPrintBill.Rows.Add(row);

                    //}
                }
                DataSet dsPlate = new DataSet();

                dsPlate = Li_PlateSupply_FormaManager.GetPlateDeliveryInforByPrintOrderNoAndPress(ddlOrderNo.Text, ddlPressName.SelectedValue.ToString(), chkExtra.Checked ? true : false);


                gvwPlateBill.DataSource = dsPlate.Tables[0];
                gvwPlateBill.DataBind();
                //for (int i = 0; i < dsPlate.Tables[0].Rows.Count; i++)
                //{

                //    object[] row = { 
                //                    dsPlate.Tables[0].Rows[i]["SlNo"].ToString(), 
                //                    true  ,
                //                    dsPlate.Tables[0].Rows[i]["Type"].ToString(), 
                //                    dsPlate.Tables[0].Rows[i]["Size"].ToString(), 
                //                    dsPlate.Tables[0].Rows[i]["PlateQty"].ToString(), 
                //                    dsPlate.Tables[0].Rows[i]["PlateGivenType"].ToString(), 
                //                    dsPlate.Tables[0].Rows[i]["PlateBillRate"].ToString(),
                //                    dsPlate.Tables[0].Rows[i]["ProcessGivenType"].ToString(),
                //                    dsPlate.Tables[0].Rows[i]["ProcessBillRate"].ToString() ,
                //                    dsPlate.Tables[0].Rows[i]["TotalAmount"].ToString()  
                //               };
                //    gvPlateBill.Rows.Add(row);

                //}



                UpdateTotalPrice();

            }
            catch (Exception)
            {


            }
        }

        private void UpdateTotalPrice()
        {
            decimal totalPlateQty = 0.0m;
            decimal totalPlateBill = 0.0m;
            decimal totalProcess = 0.0m;
            decimal totalPrintBill = 0.0m;
            decimal totalBill = 0.0m;

            for (int i = 0; i < gvwPlateBill.Rows.Count; i++)
            {

                decimal _PlateQty = gvwPlateBill.Rows[i].Cells[3].Text != "" ? decimal.Parse(gvwPlateBill.Rows[i].Cells[3].Text) : 0.0m;


                decimal _PlateBill = gvwPlateBill.Rows[i].Cells[5].Text != "" ? decimal.Parse(gvwPlateBill.Rows[i].Cells[5].Text) : 0.0m;
                totalPlateQty += _PlateQty;

                totalPlateBill += _PlateQty * _PlateBill;


                decimal _ProcessBill = gvwPlateBill.Rows[i].Cells[7].Text != "" ? decimal.Parse(gvwPlateBill.Rows[i].Cells[7].Text) : 0.0m;


                totalProcess += _PlateQty * _ProcessBill;



                decimal _TotalBill = gvwPlateBill.Rows[i].Cells[8].Text != "" ? decimal.Parse(gvwPlateBill.Rows[i].Cells[8].Text) : 0.0m;

                totalBill += _TotalBill;

            }



            for (int i = 0; i < gvwPrintBill.Rows.Count; i++)
            {



                decimal _TotalBill = gvwPrintBill.Rows[i].Cells[8].Text != "" ? decimal.Parse(gvwPrintBill.Rows[i].Cells[8].Text) : 0.0m;

                totalPrintBill += _TotalBill;

            }




            txtPrintBill.Text = String.Format("{0:0.##}", totalPrintBill);
            txtTotalPlateQty.Text = String.Format("{0:0.##}", totalPlateQty);
            txtTotalPlateBill.Text = String.Format("{0:0.##}", totalPlateBill);
            txtTotalProcessBill.Text = String.Format("{0:0.##}", totalProcess);
            txtTotalBill.Text = String.Format("{0:0.##}", totalBill + totalPrintBill);

        }

        protected void ddlOrderNo_TextChanged(object sender, EventArgs e)
        {
            SetPlateFor();
            gvwPlateBill.DataSource=null;
            gvwPlateBill.DataBind();
            LoadOrder();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {


                if (txtTotalBill.Text == "" || txtTotalBill.Text == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please give a valid Print Order');", true);
                    return;
                }


                Li_PrintBill printBill = new Li_PrintBill();
                printBill.BillNo = txtBillNo.Text;
                printBill.BillDate = DateTime.Parse(txtPrintBillDate.Text);
                printBill.OrderNo = ddlOrderNo.Text;
                printBill.BookCode = ddlBookName.SelectedValue.ToString() + "/" + txtEdition.Text;
                printBill.PrintBill = Decimal.Parse(txtPrintBill.Text);
                printBill.PlateBill = Decimal.Parse(txtTotalPlateBill.Text);
                printBill.ProcessBill = Decimal.Parse(txtTotalProcessBill.Text);
                printBill.TotalBill = Decimal.Parse(txtTotalBill.Text);
                printBill.Remark = txtRemark.Text;
                printBill.CreatedDate = DateTime.Now;
                printBill.CreatedBy = int.Parse(Session["UserID"].ToString());
                printBill.Status_D = 'C';
                printBill.CauseOfDel = "";
                printBill.DelDate = DateTime.Now;
                printBill.DelBy = int.Parse(Session["UserID"].ToString());
                printBill.PressID = ddlPressName.SelectedValue.ToString();

                printBill.PrintQty = txtPrintQty.Text != "" ? decimal.Parse(txtPrintQty.Text) : 0.0m;

                printBill.Extra = chkExtra.Checked ? true : false;

                int resutl = Li_PrintBillManager.InsertLi_PrintBill(printBill);

                if (chkExtra.Checked)
                {
                }
                else
                {

                    for (int i = 0; i < gvwPrintBill.Rows.Count; i++)
                    {

                        Li_PrintBillDetail printBillDetail = new Li_PrintBillDetail();


                        printBillDetail.BillSerial = resutl;
                        printBillDetail.PintDSerial = Int32.Parse(gvwPrintBill.Rows[i].Cells[0].Text);
                        printBillDetail.Rate = Decimal.Parse(gvwPrintBill.Rows[i].Cells[7].Text);
                        printBillDetail.Bill = Decimal.Parse(gvwPrintBill.Rows[i].Cells[8].Text);

                        Li_PrintBillDetailManager.InsertLi_PrintBillDetail(printBillDetail);

                    }
                }

                for (int i = 0; i < gvwPlateBill.Rows.Count; i++)
                {

                    Li_PrintBillDetail_Plate BillDetail_Plate = new Li_PrintBillDetail_Plate();


                    BillDetail_Plate.BillSerial = resutl;
                    BillDetail_Plate.PintPSerial = Int32.Parse(gvwPlateBill.Rows[i].Cells[0].Text);
                    BillDetail_Plate.PlateQty = Int32.Parse(gvwPlateBill.Rows[i].Cells[3].Text);
                    BillDetail_Plate.PlateRate = Decimal.Parse(gvwPlateBill.Rows[i].Cells[5].Text);
                    BillDetail_Plate.ProcessRate = Decimal.Parse(gvwPlateBill.Rows[i].Cells[7].Text);
                    BillDetail_Plate.TotalBill = Decimal.Parse(gvwPlateBill.Rows[i].Cells[8].Text);

                    Li_PrintBillDetail_PlateManager.InsertLi_PrintBillDetail_Plate(BillDetail_Plate);
                }

                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);
                txtPrintBill.Text = "0";
                txtTotalBill.Text = "0";
                txtTotalProcessBill.Text = "0";
                txtTotalPlateBill.Text = "0";
                txtTotalPlateQty.Text = "0";
                gvwPlateBill.DataSource=null;
                gvwPlateBill.DataBind();
                gvwPrintBill.DataSource = null;
                gvwPrintBill.DataBind();


            }
            catch (Exception)
            {


            }
        }

        protected void btnPrintBillUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateTotalPrice();
            }
            catch (Exception)
            {


            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string BillNo = txtBillNo.Text;
            string PressName = ddlPressName.SelectedValue;
            string billdate = txtPrintBillDate.Text;

            Response.Redirect("~/Pro_Rpt_PrintBill.aspx?No=" + BillNo + "&binder=" + PressName + "&date=" + billdate);
        }
    }
}