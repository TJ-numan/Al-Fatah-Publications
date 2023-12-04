using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Pro_ActualPaperUsed : System.Web.UI.Page
    {
        string FormID = "PF002";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    getUserAccess();
                    LoadPress();
                    LoadBook();
                    //LoadPlateFor();
                    //cmbOrderNo.Text = OrderNo;
                    SetPlateFor();
                    LoadOrder();

                    txtDate.Text = String.Format("{0:yyyy/MM/dd}", DateTime.Now);

                    AddDefaultFirstRecord();
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
            ddlPressName.SelectedIndex = -1;

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
            string[] arr = txtOrderNo.Text.Split(new char[] { '-' });//'-'

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
                gvwPrintBill.DataSource = null;
                gvwPrintBill.DataBind();
                DataSet ds = new DataSet();
                ds = Li_Print_Order_FormaManager.GetPrintOrderInforByOrderNoAndPress(txtOrderNo.Text, ddlPressName.SelectedValue.ToString(), ddlPlateFor.SelectedValue.ToString(), false, false);
                txtPrintOrderDate.Text = DateTime.Parse(ds.Tables[0].Rows[0]["OrderDate"].ToString()).ToString("yyyy/MM/dd");
                ddlBookName.SelectedValue = ds.Tables[0].Rows[0]["BookID"].ToString();
                txtGroup.Text = ds.Tables[0].Rows[0]["GName"].ToString();
                txtClass.Text = ds.Tables[0].Rows[0]["ClassName"].ToString();
                txtType.Text = ds.Tables[0].Rows[0]["TypeName"].ToString();
                ddlEdition.Text = ds.Tables[0].Rows[0]["Edition"].ToString();
                txtPrintQty.Text = ds.Tables[0].Rows[0]["PrintQty"].ToString();

            }
            catch (Exception)
            {


            }
        }

        protected void txtOrderNo_TextChanged(object sender, EventArgs e)
        {
            SetPlateFor();
            LoadOrder();
        }

        private void UpdateTotalQty()
        {
            decimal totalPlateQty = 0.0m;
            decimal totalPrintBill = 0.0m;



            for (int i = 0; i < gvwPrintBill.Rows.Count; i++)
            {

                decimal _TotalBill = gvwPrintBill.Rows[i].Cells[4].Text != "" ? decimal.Parse(gvwPrintBill.Rows[i].Cells[4].Text) : 0.0m;
                totalPrintBill += _TotalBill;

            }

            txtTotalPaperQty.Text = String.Format("{0:0.##}", totalPrintBill);
            txtTotalPlateQty.Text = String.Format("{0:0.##}", totalPlateQty);


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int totalPlate = txtTotalPlateQty.Text != "" ? Int32.Parse(txtTotalPlateQty.Text) : 0;
                int totalPrint = txtTotalPrint.Text != "" ? Int32.Parse(txtTotalPrint.Text) : 0;
                decimal totalRoll = txtTotalRoll.Text != "" ? decimal.Parse(txtTotalRoll.Text) : 0.0m;

                //if (totalPlate == 0)
                //{
                //    MessageBox.Show("Please give plate Qty");
                //    return;
                //}


                if (totalPrint == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please give Print Qty');", true);
                    return;
                }

                //if ( totalRoll == 0.0m)
                //{
                //    MessageBox.Show("Please give Roll Qty ");
                //    return;
                //}


                Li_PaperAcUsed paperused = new Li_PaperAcUsed();
                paperused.CauseOFDel = "";
                paperused.CreatedBy = int.Parse(Session["UserID"].ToString());
                paperused.CreatedDate = DateTime.Now;
                paperused.DelBy = 0;
                paperused.PaperUsed = decimal.Parse(txtTotalPaperQty.Text);
                paperused.PlateUsed = totalPlate;
                paperused.Print_OrderNo = txtOrderNo.Text;
                paperused.PrintDate = DateTime.Parse(txtPrintOrderDate.Text);
                paperused.PrintQty = totalPrint;
                paperused.Remark = txtRemark.Text;
                paperused.RollQty = totalRoll;
                paperused.Status_D = 'C';
                paperused.PressID = ddlPressName.SelectedValue;

                int result = Li_PaperAcUsedManager.InsertLi_PaperAcUsed(paperused);



                for (int i = 0; i < gvwPrintBill.Rows.Count; i++)
                {

                    Li_PaperAcUsedDetail paperUsedDetail = new Li_PaperAcUsedDetail();
                    paperUsedDetail.AFNo = gvwPrintBill.Rows[i].Cells[2].Text;
                    paperUsedDetail.BRNo = gvwPrintBill.Rows[i].Cells[3].Text;
                    paperUsedDetail.PaperQty = decimal.Parse(gvwPrintBill.Rows[i].Cells[4].Text);
                    paperUsedDetail.PrintOrderSl = result;
                    paperUsedDetail.RollNo = gvwPrintBill.Rows[i].Cells[1].Text;
                    paperUsedDetail.RunNo = gvwPrintBill.Rows[i].Cells[0].Text;
                    Li_PaperAcUsedDetailManager.InsertLi_PaperAcUsedDetail(paperUsedDetail);



                }
                txtTotalPaperQty.Text = "";
                txtTotalPlateQty.Text = "";
                txtTotalPrint.Text = "";
                txtTotalRoll.Text = "";
                txtRemark.Text = "";


                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);

                gvwPrintBill.DataSource=null;
                gvwPrintBill.DataBind();

                ddlPressName.Focus();



            }
            catch (Exception)
            {


            }
        }

        private void AddDefaultFirstRecord()
        {
            bool fromLinkButton = false;
            //creating dataTable   
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "tblActualUsed";
            dt.Columns.Add("Serial", typeof(string));
            dt.Columns.Add("RunNo", typeof(string));
            dt.Columns.Add("RollNo", typeof(string));
            dt.Columns.Add("AFNo", typeof(string));
            dt.Columns.Add("BRNo", typeof(string));
            dt.Columns.Add("PaperQty", typeof(string));

            dr = dt.NewRow();
            dt.Rows.Add(dr);
            //saving databale into viewstate   
            ViewState["tblActualUsed"] = dt;
            //bind Gridview  
            gvwPrintBill.DataSource = dt;
            gvwPrintBill.DataBind();

            ViewState["LinkClick"] = fromLinkButton;

        }

        private void AddNewRecordRowToGrid()
        {


            DataTable dtCurrentTable = (DataTable)ViewState["tblActualUsed"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count == 0)
            {
                AddDefaultFirstRecord();

            }
            else
            {
                if ((bool)ViewState["LinkClick"] == true)
                {


                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                    {
                        dtCurrentTable.Rows[i][0] = i + 1;
                        dtCurrentTable.AcceptChanges();
                    }

                    ViewState["LinkClick"] = false;
                }
                else
                {


                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {



                        //add each row into data table  
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["Serial"] = dtCurrentTable.Rows.Count + 1;

                        //if ( decimal .Parse  ( txtChlNewQty.Text )_== 0.0m ) 
                        //{
                        //    return;
                        //}

                    }

                    // New row for data table

                    drCurrentRow["RunNo"] = txtRunNo.Text;
                    drCurrentRow["RollNo"] = txtRollNo.Text;
                    drCurrentRow["AFNo"] = txtAFNo.Text;
                    drCurrentRow["BRNo"] = txtBRNo.Text;
                    drCurrentRow["PaperQty"] = txtPaperQty.Text;






                    //Remove initial blank row  
                    if (dtCurrentTable.Rows[0][0].ToString() == "")
                    {
                        drCurrentRow["Serial"] = dtCurrentTable.Rows.Count;
                        dtCurrentTable.Rows[0].Delete();
                        dtCurrentTable.AcceptChanges();

                    }

                    //add created Rows into dataTable  
                    dtCurrentTable.Rows.Add(drCurrentRow);
                }

                //Save Data table into view state after creating each row  

                ViewState["tblActualUsed"] = dtCurrentTable;
                //Bind Gridview with latest Row  
                gvwPrintBill.DataSource = dtCurrentTable;
                gvwPrintBill.DataBind();

            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                AddNewRecordRowToGrid();
                UpdateTotalQty();
                txtRunNo.Text = "";
                txtRollNo.Text = "";
                txtAFNo.Text = "";
                txtBRNo.Text = "";
                txtPaperQty.Text = "";
                txtRunNo.Focus();

            }
            catch (Exception)
            {

            }
        }

        protected void lbDelete_Click(object sender, EventArgs e)
        {
            try
            {

                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                DataTable dtCurrentTable = (DataTable)ViewState["tblActualUsed"];
                dtCurrentTable.Rows[Convert.ToInt32(linkButton.CommandArgument) - 1].Delete();
                dtCurrentTable.AcceptChanges();
                ViewState["LinkClick"] = true;
                AddNewRecordRowToGrid();

            }
            catch (Exception)
            {


            }
        }


    }
}