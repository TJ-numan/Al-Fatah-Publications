using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Dist_DailyPackingCost : System.Web.UI.Page
    {
        private static int PageSize = 5;
        string FormID = "DF002";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                getUserAccess();
                BindDummyRow();
                BindDummyRowPaidChalan();
            }

            LoadTransport();

            AddDefaultFirstRecord();

            txtPacketNo.Attributes.Add("autocomplete", "off");
            txtVan.Attributes.Add("autocomplete", "off");
            txtTransport.Attributes.Add("autocomplete", "off");
            txtChoat.Attributes.Add("autocomplete", "off");
            txtPolythin.Attributes.Add("autocomplete", "off");
            txtSelaiIn.Attributes.Add("autocomplete", "off");
            txtSelaiOut.Attributes.Add("autocomplete", "off");
            txtPerPktCost.Attributes.Add("autocomplete", "off");
            txtPktCostTotal.Attributes.Add("autocomplete", "off");
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
                        Response.Redirect("~/DistributionHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }
        private void BindDummyRowPaidChalan()
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("MemoNo",typeof(string));
            dt.Columns.Add("LibraryID", typeof (string));
            dt.Columns.Add("LibraryName", typeof (string));
            dt.Columns.Add("LibraryAddress", typeof (string));
            dt.Columns.Add("TransportName", typeof (string));
            dt.Columns.Add("RRNo", typeof (string));
            dt.Columns.Add("PackNo", typeof(string));
            dt.Columns.Add("PerPackCost", typeof(string));
            dt.Columns.Add("TotalPackCost", typeof(string));
            dt.Columns.Add("CreatedDate", typeof(string));
            dt.Columns.Add("DeliveryDate", typeof(string));
            dr = dt.NewRow();
            dt.Rows.Add(dr);
            gvwLeftPaidChalan.DataSource = dt;
            gvwLeftPaidChalan.DataBind();
        }

        private void BindDummyRow()
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("MemoNo", typeof(string));
            dt.Columns.Add("LibraryName", typeof(string));
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("RRNo", typeof(string));
            dt.Columns.Add("PackNo", typeof(string));
            dt.Columns.Add("PerPackCost", typeof(string));
            dt.Columns.Add("TotalPackCost", typeof(string));
            dt.Columns.Add("ChalanDate", typeof(string));
            dt.Columns.Add("DeliveryDate", typeof(string));
            dr = dt.NewRow();
            dt.Rows.Add(dr);
            gvwLeft.DataSource = dt;
            gvwLeft.DataBind();
        }

        private void LoadTransport()
        {
            ddlTransport.DataSource = Li_TransportInfoManager.GetAllLi_TransportInfos();
            ddlTransport.DataTextField = "TransportName";
            ddlTransport.DataValueField = "TransportID";
            ddlTransport.DataBind();

        }

        protected void btnShow1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime d1 = DateTime.Parse (dtpFromDate.Text);
                DateTime d2 = DateTime.Parse ( dtpToDate.Text);



                int dateDiff = (int)Math.Truncate((d2 - d1).TotalDays);
                /*
                                if (dateDiff >= 1)
                                {
                                    MessageBox.Show("Your not permitted to show  more than one day Chalan at a time.");
                                    return;

                                }
                */

                if (dateDiff < 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('From date cannot be grater than To date.');", true);
                    return;
                }

                string fromdate = d1.ToString("d",
                                 DateTimeFormatInfo.InvariantInfo);

                string todate = d2.ToString("d",
                                 DateTimeFormatInfo.InvariantInfo);

                if (radChalan.Checked)
                {

                    // For Chalan

                    if (radPaid.Checked || radUnPaid.Checked)
                    {

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select one of paid or unpaid chalan');", true);
                        return;
                    }


                    if (radUnPaid.Checked)
                    {
                       
                        DataTable dtgvw = li_ChallanManager.Get_DailyPackingCost(fromdate, todate, string.Empty, string.Empty, chkIsQawmi.Checked).Tables[0];
                        gvwLeft.DataSource = dtgvw;
                        gvwLeft.DataBind();


                        decimal totalPac = 0.0m;
                        decimal totalPacCost = 0.0m;

                        for (int i = 0; i < dtgvw.Rows.Count; i++)
                        {

                            decimal Pac = decimal.Parse(dtgvw.Rows[i]["PackNo"].ToString());

                            decimal PacAmount = decimal.Parse(dtgvw.Rows[i]["TotalPackCost"].ToString());


                            totalPac += Pac;
                            totalPacCost += PacAmount;

                        }

                        txtTotalPacket1.Text = String.Format("{0:0.##}", totalPac);
                        txtPacketCost1.Text = String.Format("{0:0.##}", totalPacCost);

                    }


                    if (radPaid.Checked)
                    {                       
                        gvwLeftPaidChalan.DataSource = li_ChallanManager.Get_DailyPaidChalan(fromdate, todate, string.Empty, string.Empty, chkIsQawmi.Checked).Tables[0];
                        gvwLeftPaidChalan.DataBind();

                    }


                }
            

                if (radSpeciman.Checked)
                {

                    if (radPaid.Checked || radUnPaid.Checked)
                    {

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select one of paid or unpaid chalan');", true);
                        return;
                    }


                    if (radUnPaid.Checked)
                    {
                        //gvLeft.Focus();
                        //gvLeft.Show();
                        //gvPaidChalan.Hide();

                        ////this.gvLeft.Location = new System.Drawing.Point(25, 155);

                        ////this.gvPaidChalan.Location = new System.Drawing.Point(155, 255);



                        DataTable dtgvw2 = Li_SpecimenChalanManager.Get_DailyPackingCost(fromdate, todate, string.Empty, string.Empty).Tables[0];
                        gvwLeft.DataSource = dtgvw2;
                        gvwLeft.DataBind();


                        decimal totalPac = 0.0m;
                        decimal totalPacCost = 0.0m;

                        for (int i = 0; i < dtgvw2.Rows.Count; i++)
                        {

                            decimal Pac = decimal.Parse(dtgvw2.Rows[i]["PackNo"].ToString());

                            decimal PacAmount = decimal.Parse(dtgvw2.Rows[i]["TotalPackCost"].ToString());


                            totalPac += Pac;
                            totalPacCost += PacAmount;

                        }

                        txtTotalPacket1.Text = String.Format("{0:0.##}", totalPac);
                        txtPacketCost1.Text = String.Format("{0:0.##}", totalPacCost);

                    }

                    if (radPaid.Checked)
                    {                    
                        gvwLeftPaidChalan.DataSource = Li_SpecimenChalanManager.Get_DailyPaidChalan(fromdate, todate, string.Empty, string.Empty).Tables[0];
                        gvwLeftPaidChalan.DataBind();

                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        protected void gvwLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvwLeft.SelectedRow;
                ViewState["MemoNo"] = row.Cells[1].Text;
                ViewState["libID"] = row.Cells[2].Text;
                ViewState["libname"] = row.Cells[3].Text;
                ViewState["libAdd"] = row.Cells[4].Text;
                lblPacNo.Text = " Pack No : " + row.Cells[5].Text;
                lblPerPacCost.Text = " Per Pack Cost : " + row.Cells[6].Text;
                lblPacCostTotal.Text = "Total Pack Cost : " + row.Cells[7].Text;
                ViewState["createddate"] = DateTime.Parse(row.Cells[8].Text);
                ViewState["deliveryDate"] = DateTime.Parse(row.Cells[9].Text);

            }
            catch (Exception)
            {

            }
        }

        protected void gvwLeft_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                //string a = libAdd; string b = libname; string c = libID; string m = memo; return;

                decimal selaiIn = txtSelaiIn.Text != "" ? decimal.Parse(txtSelaiIn.Text) : 0.0m;
                decimal selaiOut = txtSelaiOut.Text != "" ? decimal.Parse(txtSelaiOut.Text) : 0.0m;

                if (selaiIn != 0.0m && selaiOut != 0.0m)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please correct the In House or Out Source Selai Bill');", true);
                    return;
                }


                AddNewRecordRowToGrid();

                txtPacketNo.Text = "";
                txtPerPktCost.Text = "";
                txtPktCostTotal.Text = "";
                ddlTransport.SelectedIndex = -1;
                txtRRNo.Text = "";
                chkIsIncomplete.Checked = false;

                txtVan.Text = "";
                txtTransport.Text = "";


                txtPerPktCost.Text = "";
                



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
            dt.TableName = "tblDailyPackingCost";
            dt.Columns.Add("Serial", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("MemoNo", typeof(string));
            dt.Columns.Add("PackNo", typeof(string));
            dt.Columns.Add("Van", typeof(Decimal));
            dt.Columns.Add("Transport", typeof(Decimal));
            dt.Columns.Add("Choat", typeof(Decimal));
            dt.Columns.Add("Polithin", typeof(Decimal));
            dt.Columns.Add("InSelai", typeof(Decimal));
            dt.Columns.Add("OutSelai", typeof(Decimal));
            dt.Columns.Add("PerPackCost", typeof(string));
            dt.Columns.Add("TotalPackCost", typeof(string));
            dt.Columns.Add("TransPortName", typeof(string));
            dt.Columns.Add("RRNo", typeof(string));
            dt.Columns.Add("ChalanDate2", typeof(DateTime));
            dt.Columns.Add("DeliveryDate", typeof(DateTime));
            dt.Columns.Add("IsPending", typeof(int));
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("TransportID", typeof(string));

            dr = dt.NewRow();
            dt.Rows.Add(dr);
            //saving databale into viewstate   
            ViewState["tblDailyPackingCost"] = dt;
            //bind Gridview  
            gvwRight.DataSource = dt;
            gvwRight.DataBind();

            ViewState["LinkClick"] = fromLinkButton;

        }

        private void AddNewRecordRowToGrid()
        {


            DataTable dtCurrentTable = (DataTable)ViewState["tblDailyPackingCost"];
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

                    drCurrentRow["Name"] = ViewState["libname"];
                    drCurrentRow["Address"] = ViewState["libAdd"];
                    drCurrentRow["MemoNo"] = ViewState["MemoNo"];
                    drCurrentRow["PackNo"] = txtPacketNo.Text;
                    drCurrentRow["Van"] = txtVan.Text != "" ? decimal.Parse(txtVan.Text) : 0.0m;
                    drCurrentRow["Transport"] = txtTransport.Text != "" ? decimal.Parse(txtTransport.Text) : 0.0m;
                    drCurrentRow["Choat"] = txtChoat.Text != "" ? decimal.Parse(txtChoat.Text) : 0.0m;
                    drCurrentRow["Polithin"] = txtPolythin.Text != "" ? decimal.Parse(txtPolythin.Text) : 0.0m;
                    drCurrentRow["InSelai"] = txtSelaiIn.Text != "" ? decimal.Parse(txtSelaiIn.Text) : 0.0m;
                    drCurrentRow["OutSelai"] = txtSelaiOut.Text != "" ? decimal.Parse(txtSelaiOut.Text) : 0.0m;
                    drCurrentRow["PerPackCost"] = txtPerPktCost.Text;
                    drCurrentRow["TotalPackCost"] = txtPktCostTotal.Text;
                    drCurrentRow["TransPortName"] = ddlTransport.SelectedItem.Text;
                    drCurrentRow["RRNo"] = txtRRNo.Text;
                    drCurrentRow["ChalanDate2"] = ViewState["createddate"];
                    drCurrentRow["DeliveryDate"] = ViewState["deliveryDate"];
                    drCurrentRow["IsPending"] = chkIsIncomplete.Checked ? 0 : 1;
                    drCurrentRow["ID"] = ViewState["libID"];
                    drCurrentRow["TransportID"] = ddlTransport.SelectedValue;






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

                ViewState["tblDailyPackingCost"] = dtCurrentTable;
                //Bind Gridview with latest Row  
                gvwRight.DataSource = dtCurrentTable;
                gvwRight.DataBind();

                UpdateTotalPrice(dtCurrentTable);



            }
        }

        private void UpdateTotalPrice(DataTable dtCurrentTable)
        {
            decimal totalPac = 0.0m;
            decimal totalPacCost = 0.0m;

            for (int i = 0; i < gvwRight.Rows.Count; i++)
            {

                decimal Pac = decimal.Parse(gvwRight.Rows[i].Cells[3].Text);

                decimal PacAmount = decimal.Parse(gvwRight.Rows[i].Cells[11].Text);


                totalPac += Pac;
                totalPacCost += PacAmount;

            }
            txtPacBill.Text = String.Format("{0:0.##}", totalPac);
            txtTotalPacBill.Text = String.Format("{0:0.##}", totalPacCost);



        }

        protected void lbDelete_Click(object sender, EventArgs e)
        {
            try
            {

                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                DataTable dtCurrentTable = (DataTable)ViewState["tblDailyPackingCost"];
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
                DataTable dtCurrentTable = (DataTable)ViewState["tblDailyPackingCost"];
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                    {

                        Li_PacketBill li_PacketBill = new Li_PacketBill();

                        li_PacketBill.MemoNo = dtCurrentTable.Rows[i]["MemoNo"].ToString();
                        li_PacketBill.TransportID = dtCurrentTable.Rows[i]["TransportID"].ToString();
                        li_PacketBill.LibraryID = dtCurrentTable.Rows[i]["ID"].ToString();
                        li_PacketBill.LibraryName = dtCurrentTable.Rows[i]["Name"].ToString();
                        li_PacketBill.LibraryAddress = dtCurrentTable.Rows[i]["Address"].ToString();
                        li_PacketBill.TransportName = dtCurrentTable.Rows[i]["TransPortName"].ToString();
                        li_PacketBill.RRNo = dtCurrentTable.Rows[i]["RRNo"].ToString();
                        li_PacketBill.PackNo = decimal.Parse(dtCurrentTable.Rows[i]["PackNo"].ToString());
                        li_PacketBill.PerPacCost = decimal.Parse(dtCurrentTable.Rows[i]["PerPackCost"].ToString());
                        li_PacketBill.TotalPackCost = decimal.Parse(dtCurrentTable.Rows[i]["TotalPackCost"].ToString());
                        li_PacketBill.ChalanDate = DateTime.Parse(dtCurrentTable.Rows[i]["ChalanDate2"].ToString());
                        li_PacketBill.DeliveryDate = DateTime.Parse(dtCurrentTable.Rows[i]["DeliveryDate"].ToString());
                        li_PacketBill.CreatedBy = int.Parse(Session["UserID"].ToString());
                        li_PacketBill.IsPending = Int32.Parse(dtCurrentTable.Rows[i]["IsPending"].ToString());
                        li_PacketBill.Van = decimal.Parse(dtCurrentTable.Rows[i]["Van"].ToString());
                        li_PacketBill.Transport = decimal.Parse(dtCurrentTable.Rows[i]["Transport"].ToString());
                        li_PacketBill.Choat = decimal.Parse(dtCurrentTable.Rows[i]["Choat"].ToString());
                        li_PacketBill.Polithin = decimal.Parse(dtCurrentTable.Rows[i]["Polithin"].ToString());
                        li_PacketBill.SelaiIn = decimal.Parse(dtCurrentTable.Rows[i]["InSelai"].ToString());
                        li_PacketBill.SelaiOut = decimal.Parse(dtCurrentTable.Rows[i]["OutSelai"].ToString());

                        if (radChalan.Checked)
                        {

                            li_PacketBill.ISQawmi = chkIsQawmi.Checked;
                            int resutl = Li_PacketBillManager.InsertLi_PacketBill(li_PacketBill);

                        }

                        if (radSpeciman.Checked)
                        {
                            int resutl = Li_PacketBillManager.InsertLi_SpecimenPacketBill(li_PacketBill);

                        }

                    }
                }



                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);

                dtCurrentTable.Rows.Clear();
                ViewState["tblDailyPackingCost"] = null;
                AddDefaultFirstRecord();
            }
            catch (Exception ex)
            {
                
            }
        }
             
    }
}