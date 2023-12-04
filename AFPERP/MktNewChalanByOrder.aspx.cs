using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class MktNewChalanByOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Session["test"] = 0;
                    txtChlNewDate.Focus();
                    LoadAgent();
                    LoadMemoType();
                    txtChlNewDate.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
                    //txtChlNewQty.Attributes.Add("autocomplete", "off");
                    txtPacketNo.Attributes.Add("autocomplete", "off");
                    txtPerPacketCost.Attributes.Add("autocomplete", "off");
                    txtChlNewDate.Attributes.Add("autocomplete", "off");

                    //txtChlNewBookCode.Attributes.Add("autocomplete", "off");

                    AddDefaultFirstRecord();


                    /*
                    DataTable dt = new DataTable();
                    dt.Columns.AddRange(new DataColumn[10] { new DataColumn("BookCode"), 
                        new DataColumn("BookName"),  
                        new DataColumn("Class"),
                        new DataColumn("Type"),
                   
                        new DataColumn("Edition"),
                        new DataColumn("UnitPrice"), 
                        new DataColumn("Quantity"), 
                        new DataColumn("Dis_Per"),
                        new DataColumn("DisAmount"),
                        new DataColumn("SellAmount")});
                    ViewState["BookInfo"] = dt;
                    this.BindGrid();
                  */

                    //int year = DateTime.Now.Year;
                    //int month = DateTime.Now.Month;
                    //int day = DateTime.Now.Day;
                    //String FromDate;

                    //if (month >= 11)
                    //{
                    //    var mydate = new DateTime(year, 11, 02);

                    //    FromDate = String.Format("{0:yyyy-MM-dd}", mydate);
                    //}

                    //else
                    //{
                    //    var mydate = new DateTime(year - 1, 11, 02);
                    //    FromDate = String.Format("{0:yyyy-MM-dd}", mydate);
                    //}

                    //Calender1.StartDate = DateTime.Parse(FromDate);
                    Calender1.StartDate = DateTime.Now;
                    Calender1.EndDate = DateTime.Now;

                }
                catch (Exception)
                {

                }
            }
        }
        private void LoadMemoType()
        {
            //ddlMemoType.DataSource = Li_OfferManager.GetAllLi_Offers();
            //ddlMemoType.DataTextField = "OffName";
            //ddlMemoType.DataValueField = "OffID";
            //ddlMemoType.DataBind();
            //ddlMemoType.Items.Insert(0, new ListItem("--Select--", ""));
        }
        private void AddDefaultFirstRecord()
        {
            bool fromLinkButton = false;

            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.TableName = "tblChallan";
            dt.Columns.Add("Serial", typeof(string));
            dt.Columns.Add("BookCode", typeof(string));
            dt.Columns.Add("BookName", typeof(string));
            dt.Columns.Add("Class", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("Edition", typeof(string));
            dt.Columns.Add("UnitPrice", typeof(Decimal));
            dt.Columns.Add("Qty", typeof(Decimal));
            dt.Columns.Add("DiscountPer", typeof(Decimal));
            dt.Columns.Add("TotalDiscount", typeof(Decimal));
            dt.Columns.Add("Total", typeof(Decimal));
            dr = dt.NewRow();
            dt.Rows.Add(dr);
            ViewState["tblChallan"] = dt;
            gvBookReceive.DataSource = dt;
            gvBookReceive.DataBind();
            ViewState["LinkClick"] = fromLinkButton;
        }


        private void AddNewRecordRowToGrid(string OrderNo)
        {
            // check view state is not null  
            if (ViewState["tblChallan"] != null)
            {
                //get datatable from view state   
                DataTable dtCurrentTable = (DataTable)ViewState["tblChallan"];
                DataRow drCurrentRow = null;



                if (dtCurrentTable.Rows.Count == 0)
                {
                    AddDefaultFirstRecord();
                    txtSubTotal.Text = "0.00";

                }
                else
                {




                    // New row for data table

                    DataTable dt = new DataTable();
                    dt = li_ChallanManager.GetBookOrderDetailsByOrderNoForEdit(OrderNo).Tables[0];



                    for (int i = 0; i < dt.Rows.Count; i++)
                    {


                        //add each row into data table  
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["Serial"] = i + 1;
                        drCurrentRow["BookCode"] = dt.Rows[i]["BookAcCode"].ToString();
                        drCurrentRow["BookName"] = dt.Rows[i]["BookName"].ToString();
                        drCurrentRow["Class"] = dt.Rows[i]["Class"].ToString();
                        drCurrentRow["Type"] = dt.Rows[i]["Type"].ToString();
                        drCurrentRow["Edition"] = dt.Rows[i]["Edition"].ToString();
                        drCurrentRow["UnitPrice"] = decimal.Round(decimal.Parse(dt.Rows[i]["Price"].ToString()));
                        drCurrentRow["Qty"] = decimal.Parse(dt.Rows[i]["Quantity"].ToString());
                        //drCurrentRow["DiscountPer"] = 0.0m;
                        //drCurrentRow["TotalDiscount"] = 0.0m;//decimal.Parse(dt.Rows[i]["Qty"].ToString()) * decimal.Parse(dt.Rows[i]["UnitPrice"].ToString()) * decimal.Parse(dt.Rows[i]["DiscountPercent"].ToString());
                        drCurrentRow["DiscountPer"] = decimal.Parse(dt.Rows[i]["DiscountPercent"].ToString());
                        drCurrentRow["TotalDiscount"] = decimal.Parse(dt.Rows[i]["Quantity"].ToString()) * decimal.Parse(dt.Rows[i]["Price"].ToString()) * decimal.Parse(dt.Rows[i]["DiscountPercent"].ToString()) * 0.01m;
                        drCurrentRow["Total"] = decimal.Round(decimal.Parse(dt.Rows[i]["SellAmount"].ToString()));
                        dtCurrentTable.Rows.Add(drCurrentRow);

                    }

                    //Remove initial blank row  
                    if (dtCurrentTable.Rows[0][0].ToString() == "")
                    {
                        drCurrentRow["Serial"] = dtCurrentTable.Rows.Count;
                        dtCurrentTable.Rows[0].Delete();
                        dtCurrentTable.AcceptChanges();

                    }


                    //Save Data table into view state after creating each row  

                    ViewState["tblChallan"] = dtCurrentTable;
                    //Bind Gridview with latest Row  
                    gvBookReceive.DataSource = dtCurrentTable;
                    gvBookReceive.DataBind();

                    decimal subTotal = 0.0m;
                    decimal Discount = 0.0m;
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                        {
                            decimal unitTotal = decimal.Parse(dtCurrentTable.Rows[i]["Total"].ToString());
                            subTotal += unitTotal;

                            decimal totDis = decimal.Parse(dtCurrentTable.Rows[i]["TotalDiscount"].ToString());
                            Discount += totDis;
                        }
                    }

                    //txtSubTotal.Text = (subTotal - Discount).ToString();

                    ////initialy Amount Receive this but after packet cost and discount it will be change
                    //txtAmountReceivable.Text=(subTotal - Discount).ToString();

                    //same as new Challan code 26/04/2020

                    txtSubTotal.Text = subTotal.ToString();
                    txtDiscountTotal.Text = Discount.ToString();
                    txtAmountReceivable.Text = (subTotal - Discount).ToString();

                    //int packNo = txtPacketNo.Text != "" ? int.Parse(txtPacketNo.Text) : 0;
                    //decimal PerPacCost = txtPerPacketCost.Text != "" ? decimal.Parse(txtPerPacketCost.Text) : 0.0m;


                    //decimal AmountPaid = txtAmountPaid.Text != "" ? decimal.Parse(txtAmountPaid.Text) : 0.0m;
                    //txtChlNewTotPCost.Text = decimal.Round((packNo * PerPacCost)).ToString();

                    //txtAmountReceivable.Text = ((subTotal + (packNo * PerPacCost)) - Discount).ToString();
                    //txtDue.Text = ((subTotal + (packNo * PerPacCost) - Discount) - AmountPaid).ToString();





                }

            }
        }

        private void LoadAgent()
        {
            try
            {
                LoadComboData.LoadLibrary(ddlLibraryName, int.Parse(Session["UserID"].ToString()));
                ddlLibraryName.DataBind();
                ddlLibraryName.Items.Insert(0, new ListItem("-Select-", "0"));
            }
            catch (Exception)
            {

            }
        }

        protected void txtPacketNo_TextChanged(object sender, EventArgs e)
        {
            try
            {

                decimal subTotal = decimal.Parse(txtSubTotal.Text);

                decimal totalDiscount = txtDiscountTotal.Text != "" ? decimal.Parse(txtDiscountTotal.Text) : 0.0m;

                int packNo = txtPacketNo.Text != "" ? int.Parse(txtPacketNo.Text) : 0;
                decimal PerPacCost = txtPerPacketCost.Text != "" ? decimal.Parse(txtPerPacketCost.Text) : 0.0m;
                decimal AmountPaid = txtAmountPaid.Text != "" ? decimal.Parse(txtAmountPaid.Text) : 0.0m;

                //decimal spDiscount = txtChlNewSpeDis.Text != "" ? decimal.Parse(txtChlNewSpeDis.Text) : 0.0m;

                txtChlNewTotPCost.Text = decimal.Round((packNo * PerPacCost)).ToString();

                // txtDiscountTotal.Text = decimal.Round(totalDiscount + spDiscount, 2).ToString();
                txtAmountReceivable.Text = (subTotal + (packNo * PerPacCost) - totalDiscount).ToString();
                txtDue.Text = ((subTotal + (packNo * PerPacCost) - totalDiscount) - AmountPaid).ToString();

            }
            catch (Exception)
            {


            }
        }

        protected void btnChlNewSave_Click(object sender, EventArgs e)
        {
            //if (IsPostBack)
            //{
            //    try
            //    {
            //        if (ddlLibraryName.SelectedValue == "0")
            //        {
            //            ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select a library');", true);
            //            return;
            //        }
            //        if (decimal.Parse(txtSubTotal.Text) <= 0.0m)
            //        {

            //            return;
            //        }

            //        string ChallanID = "";

            //        if (Decimal.Parse(txtAmountReceivable.Text) > 0.0m)
            //        {
            //            DataTable dtCurrentTable = (DataTable)ViewState["tblChallan"];

            //            if (dtCurrentTable.Rows.Count > 0)
            //            {


            //                li_Challan _chalan = new li_Challan();
            //                ChallanID = "CHL" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
            //                _chalan.MemoNo = txtMemoNo.Text;
            //                _chalan.TotalAmount = txtTotalAmount.Text != "" ? decimal.Parse(txtTotalAmount.Text) : 0;
            //                _chalan.AmountReceivable = txtAmountReceivable.Text != "" ? decimal.Parse(txtAmountReceivable.Text) : 0;
            //                _chalan.CreatedDate = Convert.ToDateTime(txtChalanDate.Text);
            //                _chalan.CreatedBy = Session["UserID"].ToString();
            //                _chalan.ModifiedBy = int.Parse(Session["UserID"].ToString());
            //                _chalan.ModifiedDate = DateTime.Now;
            //                _chalan.DeliveredBy = txtDeliveredBy.Text;
            //                _chalan.DeliveryDate = DateTime.Now;
            //                _chalan.Bonus = 0.0m;
            //                _chalan.LibraryID = ddlLibraryName.SelectedValue.ToString();
            //                _chalan.PacketNo = Int32.Parse(txtPacketNo.Text);
            //                _chalan.PerPacketCost = decimal.Parse(txtPerPacketCost.Text);
            //                _chalan.IsBonuChalan = chkBoishakiChalan.Checked != true ? false : true;
            //                _chalan.AlimBonus = chkAlimBonus.Checked ? true : false;
            //                _chalan.AlimSpecial = chkAlimSpecial.Checked ? true : false;
            //                _chalan.DakhilBonus = chkBoishakiBonus.Checked ? true : false;

            //                _chalan.Comp = cmbComp.SelectedIndex == 0 ? "A" : "Q";//"A"; 

            //                string returnchalanID = li_ChallanManager.Insert_Challan(_chalan);
            //                txtMemoNo.Text = returnchalanID.Substring(13).ToString();
            //                for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
            //                {

            //                    li_ChallanDetails chldtl = new li_ChallanDetails();
            //                    chldtl.ChallanID = returnchalanID;
            //                    chldtl.BookAcCode = dtCurrentTable.Rows[i]["BookCode"].ToString();
            //                    chldtl.Qty = int.Parse(dtCurrentTable.Rows[i]["Qty"].ToString());
            //                    chldtl.UnitPrice = decimal.Parse(dtCurrentTable.Rows[i]["UnitPrice"].ToString());
            //                    chldtl.Specimen = 0; //Int32.Parse(dtCurrentTable.Rows[i]["SpecimenQty"].ToString());
            //                    chldtl.Edition = dtCurrentTable.Rows[i]["Edition"].ToString();
            //                    chldtl.CreatedDate = DateTime.Now;
            //                    chldtl.BonusPercentage = 0; //decimal.Parse(dtCurrentTable.Rows[i]["SpecimenAmount"].ToString());
            //                    chldtl.Boishaki = chkBoishakiChalan.Checked ? true : false;
            //                    chldtl.AlimBonus = chkAlimBonus.Checked ? true : false;
            //                    chldtl.AlimSpecial = chkAlimSpecial.Checked ? true : false;
            //                    chldtl.DakhilBonus = chkBoishakiBonus.Checked ? true : false;
            //                    //now insert to the database
            //                    li_ChallanDetailsManager.Insert_ChallanDetails(chldtl);


            //                }
            //                txtMemoNo.Text = returnchalanID.Substring(13).ToString();
            //                //txtMemoNo.Text = returnchalanID.ToString();
            //                dtCurrentTable.Rows.Clear();

            //                string message = "Saved successfully.";
            //                string script = "window.onload = function(){ alert('";
            //                script += message;
            //                script += "');";
            //                script += "window.location = '";
            //                script += Request.Url.AbsoluteUri;
            //                script += "'; }";
            //                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",
            //                script, true);
            //                txtOrderNo.Text = returnchalanID.Substring(13).ToString();
            //            }
            //        }


            //    }
            //    catch (Exception ex)
            //    {

            //    }
            //}

        }

        protected void btnChlNewPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Mkt_Rpt_ChalanByMemoNo.aspx");

            }
            catch (Exception)
            {

            }
        }

        protected void txtOrderNo_TextChanged(object sender, EventArgs e)
        {
            try
            {

                gvBookReceive.DataSource = null;
                DataSet ds = new DataSet();
                ds = li_ChallanManager.GetBookOrderDetailsByOrderNoForEdit(txtOrderNo.Text);

                int rowNumber = ds.Tables[0].Rows.Count;

                if (rowNumber > 0)
                {


                    for (int i = 0; i < rowNumber; i++)
                    {
                        string MemoNo = ds.Tables[0].Rows[i]["MemoNo"].ToString();
                        ViewState["Memono"] = MemoNo;
                        //ddlCompany.SelectedValue = ds.Tables[0].Rows[i]["CompanyId"].ToString();
                        string challanDate = ds.Tables[0].Rows[i]["ChalanDate"].ToString();
                        txtChlNewDate.Text = DateTime.Parse(challanDate).ToString("yyyy-MM-dd");
                        //txtPacketNo.Text = ds.Tables[0].Rows[i]["PackQty"].ToString();
                        //txtPerPacketCost.Text = ds.Tables[0].Rows[i]["PerPackCost"].ToString();
                        //txtDiscountTotal.Text = ds.Tables[0].Rows[i]["TotalDiscount"].ToString();
                        //txtAmountReceivable.Text = ds.Tables[0].Rows[i]["AmountPayable"].ToString();



                        AddNewRecordRowToGrid(MemoNo);

                    }
                }



            }
            catch (Exception ex)
            {

            }
        }
    }
}