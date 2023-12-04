using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Pro_BindingDelivery : System.Web.UI.Page
    {
        string FormID = "PF005";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //DateTime firstDayOfMonth = new DateTime(2020, 2, 1);
                //DateTime LastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    getUserAccess();
                    Loadbook();
                    //int year = DateTime.Now.Year;
                    //ddlEdition.SelectedItem.Text = year.ToString();


                    LoadYear();
                    LoadBookBinder();
                    ddlBookBinderName.SelectedValue = "-1";

                    AddDefaultFirstRecord();
                }

            }
            catch (Exception ex)
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

        private void Loadbook()
        {
            ddlBookCode.DataSource = li_BookInformationManager.Get_BookInformations_ComboSourceData();
            ddlBookCode.DataTextField = "BookID";
            ddlBookCode.DataValueField = "BookID";
            ddlBookCode.DataBind();
        }

        private void LoadYear()
        {
            ddlEdition.DataSource = li_ChallanManager.LoadYear().Tables[0];
            ddlEdition.DataTextField = "Edition";
            //txtEdition.ValueMember = "Edition";
            ddlEdition.DataBind();

        }

        private void LoadBookBinder()
        {
            ddlBookBinderName.DataSource = Li_BookBinderInfoManager.GetAllLi_BookBinderInfos();
            ddlBookBinderName.DataTextField = "BinderName";
            ddlBookBinderName.DataValueField = "BinderCode";
            ddlBookBinderName.DataBind();
            ddlBookBinderName.Items.Insert(0, new ListItem("--Select--", ""));
        }

        protected void ddlBookCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlBookCode.SelectedItem.Text != "")
                {


                    DataSet ds = new DataSet();
                    ds = li_BookVersionInfoManager.GetAll_BookVersionInfosWithRelation(ddlBookCode.SelectedItem.Text);
                    txtBookName.Text = ds.Tables[0].Rows[0]["BookName"].ToString();
                    txtBookType.Text = ds.Tables[0].Rows[0]["BookType"].ToString();
                    txtClass.Text = ds.Tables[0].Rows[0]["ClassName"].ToString();
                    ddlEdition.Text = ds.Tables[0].Rows[0]["Edition"].ToString();
                    // txtCurrentStock.Text = ds.Tables[0].Rows[0]["StockQuantity"].ToString();

                }
                else
                {
                    txtBookName.Text = "";
                    txtBookType.Text = "";
                    txtClass.Text = "";
                    ddlEdition.Text = "";
                    // txtCurrentStock.Text = "";

                }

            }
            catch (Exception er)
            {
                txtBookName.Text = "";
                txtBookType.Text = "";
                txtClass.Text = "";
                ddlEdition.SelectedIndex = -1;
                // txtCurrentStock.Text = "";



            }
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();

                if (ddlType.SelectedValue == "1")
                {
                    txtSSerial.Text = "";
                    txtESerial.Text = "";
                    txtSSerial.ReadOnly = false;
                    txtESerial.ReadOnly = false;
                    txtQty.ReadOnly = true;
                    txtPrintNo.Text = "";
                    txtPrintQty.Text = "";
                    ddlBookBinderName.SelectedIndex = -1;
                    txtQty.Text = "";
                    txtOrderNo.ReadOnly = false;
                    txtOrderNo.Text = "";
                    ds = Li_Print_Order_FormaManager.getPrintingQtyAndPrintSl(ddlBookCode.SelectedItem.Text + "/" + ddlEdition.SelectedItem.Text, 'C');
                }
                else
                {
                    txtSSerial.Text = "";
                    txtESerial.Text = "";
                    txtSSerial.ReadOnly = true;
                    txtESerial.ReadOnly = true;
                    txtQty.ReadOnly = false;
                    txtPrintNo.Text = "";
                    txtPrintQty.Text = "";
                    ddlBookBinderName.SelectedIndex = -1;
                    txtQty.Text = "";
                    txtOrderNo.Text = "";
                    txtOrderNo.ReadOnly = false;
                    ds = Li_Print_Order_FormaManager.getPrintingQtyAndPrintSl(ddlBookCode.SelectedItem.Text + "/" + ddlEdition.SelectedItem.Text, 'F');
                   
                    lblFormaQty.Text = ds.Tables[0].Rows[0]["FormaTotal"].ToString();
                    txtPrintNo.Text = ds.Tables[0].Rows[0]["PrintSl"].ToString();

                }
            }
            catch { }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddlType.SelectedValue == "1")
                {
                    if (txtSSerial.Text == "" || txtESerial.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please give the Cover starting and Ending Serial No.');", true);
                        txtSSerial.Focus();
                        return;
                    }
                }

                if (ddlBookBinderName.SelectedIndex == -1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select a binder.');", true);
                    ddlBookBinderName.Focus();
                    return;
                }
                if (txtQty.Text == "" || decimal.Parse(txtQty.Text) == 0.0m)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please give the delivery quantity');", true);
                    txtQty.Focus();
                    return;
                }



                AddNewRecordRowToGrid(); 

                ddlBookBinderName.Focus();
                ClearData();

            }
            catch (Exception ex)
            {
            }
        }

        private void AddDefaultFirstRecord()
        {
            bool fromLinkButton = false;
            //creating dataTable   
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "tblBinderInfo";
            dt.Columns.Add("Serial", typeof(string));
            dt.Columns.Add("BinderName", typeof(string));
            dt.Columns.Add("BinderId", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("TypeId", typeof(string));
            dt.Columns.Add("StartingS", typeof(string));
            dt.Columns.Add("StartingE", typeof(string));
            dt.Columns.Add("Qty", typeof(int));


            dr = dt.NewRow();
            dt.Rows.Add(dr);
            //saving databale into viewstate   
            ViewState["tblBinderInfo"] = dt;
            //bind Gridview  
            gvwBindingDeli.DataSource = dt;
            gvwBindingDeli.DataBind();

            ViewState["LinkClick"] = fromLinkButton;

        }

        private void AddNewRecordRowToGrid()
        {


            DataTable dtCurrentTable = (DataTable)ViewState["tblBinderInfo"];
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

                    drCurrentRow["BinderName"] =ddlBookBinderName.SelectedItem.Text;
                    drCurrentRow["BinderId"] = ddlBookBinderName.SelectedValue;
                    drCurrentRow["Type"] = ddlType.SelectedItem.Text;
                    drCurrentRow["TypeId"] = ddlType.SelectedValue == "0" ? 1 : 0;
                    drCurrentRow["StartingS"] = txtSSerial.Text;
                    drCurrentRow["StartingE"] = txtESerial.Text;
                    drCurrentRow["Qty"] = txtQty.Text;





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

                ViewState["tblBinderInfo"] = dtCurrentTable;
                //Bind Gridview with latest Row  
                gvwBindingDeli.DataSource = dtCurrentTable;
                gvwBindingDeli.DataBind();


                UpdateTotalPrice(dtCurrentTable);
            }


        }

        private void UpdateTotalPrice(DataTable dtCurrentTable)
        {
            decimal totalQty = 0.0m;

            for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
            {

                decimal qty = decimal.Parse(dtCurrentTable.Rows[i]["Qty"].ToString());

                totalQty += qty;


            }

            txtTotalQty.Text = String.Format("{0:0.##}", totalQty);

        }

        protected void txtSSerial_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int SSr = txtSSerial.Text != "" ? Int32.Parse(txtSSerial.Text) : 0;
                int ESr = txtESerial.Text != "" ? Int32.Parse(txtESerial.Text) : 0;
                int Qty = (ESr - SSr) + 1;
                if (Qty > 0)
                {
                    txtQty.Text = Qty.ToString();

                }
                else
                {
                    txtQty.Text = "";
                }
            }
            catch { }
        }

        private void ClearData()
        {
            ddlBookBinderName.SelectedValue = "-1";
            txtQty.Text = "";
            txtSSerial.Text = "";
            txtESerial.Text = "";
        }

        protected void lbDelete_Click(object sender, EventArgs e)
        {
            try
            {

                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                DataTable dtCurrentTable = (DataTable)ViewState["tblBinderInfo"];
                dtCurrentTable.Rows[Convert.ToInt32(linkButton.CommandArgument) - 1].Delete();
                dtCurrentTable.AcceptChanges();
                ViewState["LinkClick"] = true;
                AddNewRecordRowToGrid();

            }
            catch (Exception)
            {


            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddlType.SelectedValue == "0")
                {
                    if (decimal.Parse(txtPrintQty.Text) != decimal.Parse(txtTotalQty.Text))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Print Quantity and Delivered Quantity does not match');", true);
                        //ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Print Quantity and Delivered Quantity does not match.\n please check binder delivery Quantity');", true);
                        return;

                    }

                    if (txtPrintNo.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please give the Print No');", true);
                        txtPrintNo.Focus();
                        return;
                    }

                    if (txtPrintQty.Text == "" || decimal.Parse(txtPrintQty.Text) == 0.0m)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please give the book print Quantity');", true);
                        txtPrintQty.Focus();
                        return;
                    }
                }
                //else
                //{
                //    if (txtOrderNo.Text == "")
                //    {
                //        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please give the Delivery Slip No.');", true);
                //        txtOrderNo.Focus();
                //        return;
                //    }
                //}

                if (ddlBookCode.SelectedItem.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select a book code.');", true);
                    ddlBookCode.Focus();
                    return;
                }
                 
                DataTable dtCurrentTable = (DataTable)ViewState["tblBinderInfo"];
                if (dtCurrentTable.Rows.Count > 0)
                {
                    Li_BookDeliveryToBinder delBinder = new Li_BookDeliveryToBinder();
                    delBinder.BookCode = ddlBookCode.SelectedItem.Text;
                    delBinder.CreatedBy = int.Parse(Session["UserID"].ToString());
                    delBinder.CreatedDate = DateTime.Now;
                    delBinder.DeliveryDate = DateTime.Parse(txtOrderDate.Text);
                    delBinder.Edition = ddlEdition.SelectedItem.Text;
                    delBinder.PrintNo = txtPrintNo.Text != "" ? Int32.Parse(txtPrintNo.Text) : 0;
                    delBinder.PrintQty = txtPrintQty.Text != "" ? decimal.Parse(txtPrintQty.Text) : 0.0m;
                    delBinder.Status_D = 'C';
                    delBinder.IsForma = ddlType.SelectedValue == "0" ? true : false;
                    int DeID = Li_BookDeliveryToBinderManager.InsertLi_BookDeliveryToBinder(delBinder);

                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                    {
                        Li_BookDeliveryDetail delDetail = new Li_BookDeliveryDetail();
                        delDetail.BinderId = dtCurrentTable.Rows[i]["BinderID"].ToString();
                        delDetail.DeID = DeID;
                        delDetail.IsForma = Int32.Parse(dtCurrentTable.Rows[i]["TypeId"].ToString()) == 1 ? true : false;
                        delDetail.Qty = decimal.Parse(dtCurrentTable.Rows[i]["Qty"].ToString());
                        delDetail.Status_D = 'C';
                        delDetail.StartingNo = dtCurrentTable.Rows[i]["StartingS"].ToString();
                        delDetail.EndingNo = dtCurrentTable.Rows[i]["StartingE"].ToString();
                        Li_BookDeliveryDetailManager.InsertLi_BookDeliveryDetail(delDetail);

                    }
                    txtOrderNo.Text = Convert.ToString(DeID);
                }


                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);
                ClearAll();

                
                dtCurrentTable.Rows.Clear();
                ViewState["tblBinderInfo"] = null;
                AddDefaultFirstRecord();
                ddlBookCode.Focus();



            }
            catch { }
            
        }

        private void ClearAll()
        {
            txtPrintNo.Text = "";
            txtPrintQty.Text = "";
            ddlEdition.SelectedIndex = -1; 
            txtClass.Text = "";
            txtBookType.Text = "";
            ddlBookCode.SelectedIndex = -1;
            txtBookName.Text = "";
            txtQty.Text = "";
            ddlType.SelectedValue = "-1";
            

            ddlBookCode.SelectedIndex = -1;
            ddlBookCode.SelectedItem.Text = "";
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {                 
                Response.Redirect("~/Pro_PrintBindingDeliveryMemo.aspx?BOrderNo=" + txtOrderNo.Text);
            }
            catch (Exception)
            {
                
                
            }
        }

    }
}