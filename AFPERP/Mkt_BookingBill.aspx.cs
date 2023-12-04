using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using BLL.Classes;
using DAL;
using System.Net;
using System.Configuration;
using System.IO;
using System.Text;

namespace BLL
{
    public partial class Mkt_BookingBill : System.Web.UI.Page
    {
        DataAccessObject DAO = new DataAccessObject();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AddDefaultFirstRecord();
                LoadTransport();
            }
        }
        private void AddDefaultFirstRecord()
        {
            bool fromLinkButton = false;
            int result = 0;
            //creating dataTable   
            DataTable dt = new DataTable();
            DataRow dr;

            dt.TableName = "tblTransPortBill";
            dt.Columns.Add("Serial", typeof(string));
            dt.Columns.Add("Memono", typeof(Int32));
            dt.Columns.Add("LibraryID", typeof(string));
            dt.Columns.Add("AgentName", typeof(string));
            dt.Columns.Add("LibraryAddress", typeof(string));
            dt.Columns.Add("ComID", typeof(string));
            dt.Columns.Add("Com", typeof(string));
            dt.Columns.Add("TransportID", typeof(string));
            dt.Columns.Add("TransportName", typeof(string));
            dt.Columns.Add("RRNo", typeof(string));
            dt.Columns.Add("IsComplete", typeof(bool));
            dt.Columns.Add("PacketQty", typeof(Int32));
            dt.Columns.Add("ChallanDate", typeof(string));
            dt.Columns.Add("Van", typeof(Decimal));
            dt.Columns.Add("VanOwn", typeof(Decimal));
            dt.Columns.Add("LabourLoad", typeof(Decimal));
            dt.Columns.Add("LabourUnload", typeof(Decimal));
            dt.Columns.Add("Transport", typeof(Decimal));
            dt.Columns.Add("TransportOwn", typeof(Decimal));
            dt.Columns.Add("Choat", typeof(Decimal));
            dt.Columns.Add("Polithin", typeof(Decimal));
            dt.Columns.Add("SelaiIn", typeof(Decimal));
            dt.Columns.Add("SelaiOut", typeof(Decimal));
            dt.Columns.Add("PerPacketCost", typeof(Decimal));
            dt.Columns.Add("TotalPacketCost", typeof(Decimal));
            dt.Columns.Add("DeliveryDate", typeof(string));

            dr = dt.NewRow();
            dt.Rows.Add(dr);
            //saving databale into viewstate   
            ViewState["tblTransPortBill"] = dt;
            //bind Gridview  
            gvBookingBill.DataSource = dt;
            gvBookingBill.DataBind();

            ViewState["LinkClick"] = fromLinkButton;

            Session["ResultMemo"] = result;


        }

        protected void ddlBillFor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlBillFor.SelectedIndex == 1)
                {
                    try
                    {
                        LoadComboData.LoadLibrary(ddlLibraryName, int.Parse(Session["UserID"].ToString()));
                        ddlLibraryName.DataBind();
                        ddlLibraryName.Items.Insert(0, new ListItem("--Select Agent--", ""));
                    }
                    catch (Exception)
                    {

                    } 
                }
                else if (ddlBillFor.SelectedIndex == 2)
                {
                    ddlComID.SelectedValue = "A";
                    try
                    {
                        ddlLibraryName.DataSource = Li_SalesPersonManager.GetAllLi_SalesPersonsByUserID(int.Parse(Session["UserID"].ToString()));
                        ddlLibraryName.DataTextField = "Name";
                        ddlLibraryName.DataValueField = "TSOID";
                        ddlLibraryName.DataBind();
                        ddlLibraryName.Items.Insert(0, new ListItem("--Select TSO--", ""));
                    }
                    catch (Exception)
                    {

                    } 

                }

            }
            catch (Exception)
            {


            }
        }

        protected void txtMemoNo_TextChanged(object sender, EventArgs e)
        {
            if (txtMemoNo.Text=="")
            {
                return;
            }
            else
            {

                if(ddlBillFor.SelectedValue.ToString()=="1" && ddlComID.SelectedValue.ToString()=="0")
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Please Select The Company Alia or Qawmi');", true);
                }
                else if(ddlBillFor.SelectedValue.ToString()=="1" && ddlComID.SelectedValue.ToString()!="0" )
                {
                    DataSet ds = new DataSet();
                    ds = li_ChallanManager.Get_AllChallanInfoByMemoNo(txtMemoNo.Text, ddlComID.SelectedValue.ToString());
                    
                    if (ds.Tables[0].Rows[0]["MemoNo"].ToString() == "0" || ds.Tables[0].Rows[0]["MemoNo"].ToString() == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('This Memo Already Inserted! or Wrong Memo No!');", true);
                    }
                    else
                    {
                        ddlLibraryName.SelectedValue = ds.Tables[0].Rows[0]["LibraryID"].ToString();
                        txtPacketQty.Text = ds.Tables[0].Rows[0]["PacketNo"].ToString();
                        txtPerPacCost.Text = ds.Tables[0].Rows[0]["PerPacketCost"].ToString();
                        txtLibraryAddress.Text = ds.Tables[0].Rows[0]["LibraryAddress"].ToString();
                        txtChallanDate.Text = ds.Tables[0].Rows[0]["CreatedDate"].ToString();
                    }

                }
                else
                {
                    DataSet ds = new DataSet();
                    ds = li_ChallanManager.Get_AllSpecimenChallanInfoByMemoNo(txtMemoNo.Text);
                    if (ds.Tables[0].Rows[0]["MemoNo"].ToString() == "0" || ds.Tables[0].Rows[0]["MemoNo"].ToString() == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('This Memo Already Inserted! or Wrong Memo No!');", true);
                    }
                    else
                    {
                        ddlLibraryName.SelectedValue = ds.Tables[0].Rows[0]["TSO"].ToString();
                        txtPacketQty.Text = ds.Tables[0].Rows[0]["PacketNo"].ToString();
                        txtPerPacCost.Text = ds.Tables[0].Rows[0]["PerPacketCost"].ToString();
                        txtLibraryAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                        txtChallanDate.Text = ds.Tables[0].Rows[0]["CreatedDate"].ToString();
                    }
                }

            }
        }
        private void LoadTransport()
        {
            ListItem li = new ListItem("...Select a Transport...", "0");
            ddlTransportName.Items.Add(li);

            List<Li_TransportInfo> Transports = new List<Li_TransportInfo>();
            Transports = Li_TransportInfoManager.GetAllLi_TransportInfos();
            foreach (Li_TransportInfo trnasport in Transports)
            {
                ListItem item = new ListItem(trnasport.TransportName.ToString(), trnasport.TransportID.ToString());
                ddlTransportName.Items.Add(item);
            }
        }

        protected void txtAdd_Click(object sender, EventArgs e)
        {
            try
            {


                if (decimal.Parse(txtBookingTotalpackCost.Text) >= 0.0m)
                {
                    AddNewRecordRowToGrid();
                }


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
                DataTable dtCurrentTable = (DataTable)ViewState["tblTransPortBill"];
                dtCurrentTable.Rows[Convert.ToInt32(linkButton.CommandArgument) - 1].Delete();
                dtCurrentTable.AcceptChanges();

                ViewState["LinkClick"] = true;

                AddNewRecordRowToGrid();
            }
            catch (Exception)
            {


            }
        }
        private void AddNewRecordRowToGrid()
        {
            // check view state is not null  
            if (ViewState["tblTransPortBill"] != null)
            {
                //get datatable from view state   
                DataTable dtCurrentTable = (DataTable)ViewState["tblTransPortBill"];
                DataRow drCurrentRow = null;





                if (dtCurrentTable.Rows.Count == 0)
                {
                    AddDefaultFirstRecord();
                    txtAmountReceivable.Text = "0.00";

                    txtPacketNo.Text = "0";


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

                        if (ddlTransportName.SelectedIndex==0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Please Select The Transport!');", true);
                        }
                        else
                        {
                            
                            for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                            {



                                //add each row into data table  
                                drCurrentRow = dtCurrentTable.NewRow();
                                drCurrentRow["Serial"] = dtCurrentTable.Rows.Count + 1;

                                if (txtMemoNo.Text == dtCurrentTable.Rows[i - 1]["Memono"].ToString())
                                {
                                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('This Memo Already Added!');", true);
                                    return;
                                }

                            }
                            // New row for data table

                            drCurrentRow["Memono"] = Int32.Parse(txtMemoNo.Text);

                            drCurrentRow["LibraryID"] = ddlLibraryName.SelectedValue.ToString();
                            drCurrentRow["AgentName"] = ddlLibraryName.SelectedItem.Text;
                            drCurrentRow["LibraryAddress"] = txtLibraryAddress.Text;

                            drCurrentRow["ComID"] = ddlComID.SelectedValue.ToString();
                            drCurrentRow["Com"] = ddlComID.SelectedItem.Text;

                            drCurrentRow["TransportID"] = ddlTransportName.SelectedValue.ToString();
                            drCurrentRow["TransportName"] = ddlTransportName.SelectedItem.Text;
                            drCurrentRow["RRNo"] = txtRRNo.Text;
                            drCurrentRow["IsComplete"] = chkIsComplete.Checked ? true : false;

                            drCurrentRow["PacketQty"] = Int32.Parse(txtPacDelivry.Text);
                            drCurrentRow["Van"] = decimal.Parse(txtVan.Text);
                            drCurrentRow["VanOwn"] = decimal.Parse(txtVanOwn.Text);
                            drCurrentRow["LabourLoad"] = decimal.Parse(txtLabourLoad.Text);
                            drCurrentRow["LabourUnload"] = decimal.Parse(txtLabourUnload.Text);
                            drCurrentRow["ChallanDate"] = txtChallanDate.Text;

                            drCurrentRow["Transport"] = decimal.Parse(txtTransport.Text);
                            drCurrentRow["TransportOwn"] = decimal.Parse(textTransportOwn.Text);

                            drCurrentRow["Choat"] = decimal.Parse(txtChoat.Text);
                            drCurrentRow["Polithin"] = decimal.Parse(txtPolythin.Text);
                            drCurrentRow["SelaiIn"] = decimal.Parse(txtSelaiIn.Text);
                            drCurrentRow["SelaiOut"] = decimal.Parse(txtSelaiOut.Text);
                            drCurrentRow["PerPacketCost"] = decimal.Parse(txtBookingPerPacCost.Text);
                            drCurrentRow["TotalPacketCost"] = decimal.Parse(txtBookingTotalpackCost.Text);
                            drCurrentRow["DeliveryDate"] = txtDeliveryDate.Text;

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
                    } 

                    //Save Data table into view state after creating each row  

                    ViewState["tblTransPortBill"] = dtCurrentTable;
                    //Bind Gridview with latest Row  
                    gvBookingBill.DataSource = dtCurrentTable;
                    gvBookingBill.DataBind();

                    int subTotal = 0;
                    decimal totalPackCost = 0.0m;
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                        {
                            int unitTotal = int.Parse(dtCurrentTable.Rows[i]["PacketQty"].ToString());
                            subTotal += unitTotal;

                            decimal totpktCost = decimal.Parse(dtCurrentTable.Rows[i]["TotalPacketCost"].ToString());
                            totalPackCost += totpktCost;
                        }
                    }


                    txtPacketNo.Text = subTotal.ToString();




                    txtAmountReceivable.Text = totalPackCost.ToString();

                }

            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                    if (Decimal.Parse(txtAmountReceivable.Text) > 0.0m)
                    {
                        DataTable dtCurrentTable = (DataTable)ViewState["tblTransPortBill"];

                        if (dtCurrentTable.Rows.Count > 0)
                        {

                            int BillFor = int.Parse(ddlBillFor.SelectedValue.ToString());

                            if (BillFor==1)
                            {
                                for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                                {

                                    Li_PacketBill packetBillDetail = new Li_PacketBill();
                                    packetBillDetail.MemoNo = dtCurrentTable.Rows[i]["Memono"].ToString();
                                    packetBillDetail.TransportID = dtCurrentTable.Rows[i]["LibraryID"].ToString();
                                    packetBillDetail.LibraryID = dtCurrentTable.Rows[i]["TransportID"].ToString();
                                    packetBillDetail.LibraryName = dtCurrentTable.Rows[i]["AgentName"].ToString();
                                    packetBillDetail.LibraryAddress = dtCurrentTable.Rows[i]["LibraryAddress"].ToString();
                                    packetBillDetail.TransportName = dtCurrentTable.Rows[i]["TransportName"].ToString();

                                    packetBillDetail.RRNo = dtCurrentTable.Rows[i]["RRNo"].ToString();
                                    packetBillDetail.PackNo = decimal.Parse(dtCurrentTable.Rows[i]["PacketQty"].ToString());
                                    packetBillDetail.PerPacCost = decimal.Parse(dtCurrentTable.Rows[i]["PerPacketCost"].ToString());
                                    packetBillDetail.TotalPackCost = (packetBillDetail.PackNo * packetBillDetail.PerPacCost);

                                    packetBillDetail.ChalanDate = DateTime.Parse(dtCurrentTable.Rows[i]["ChallanDate"].ToString());
                                    packetBillDetail.DeliveryDate = DateTime.Parse(dtCurrentTable.Rows[i]["DeliveryDate"].ToString());
                                    packetBillDetail.CreatedBy = int.Parse(Session["UserID"].ToString());

                                    packetBillDetail.Van = decimal.Parse(dtCurrentTable.Rows[i]["Van"].ToString());
                                    packetBillDetail.VanOwn = decimal.Parse(dtCurrentTable.Rows[i]["VanOwn"].ToString());
                                    packetBillDetail.LabourLoad = decimal.Parse(dtCurrentTable.Rows[i]["LabourLoad"].ToString());
                                    packetBillDetail.LabourUnload = decimal.Parse(dtCurrentTable.Rows[i]["LabourUnload"].ToString());
                                    packetBillDetail.Transport = decimal.Parse(dtCurrentTable.Rows[i]["Transport"].ToString());
                                    packetBillDetail.TransportOwn = decimal.Parse(dtCurrentTable.Rows[i]["TransportOwn"].ToString());
                                    packetBillDetail.Choat = decimal.Parse(dtCurrentTable.Rows[i]["Choat"].ToString());
                                    packetBillDetail.Polithin = decimal.Parse(dtCurrentTable.Rows[i]["Polithin"].ToString());
                                    packetBillDetail.SelaiIn = decimal.Parse(dtCurrentTable.Rows[i]["SelaiIn"].ToString());
                                    packetBillDetail.SelaiOut = decimal.Parse(dtCurrentTable.Rows[i]["SelaiOut"].ToString());

                                    packetBillDetail.IsPending = Boolean.Parse(dtCurrentTable.Rows[i]["IsComplete"].ToString()) == false ? 0 : 1;
                                    packetBillDetail.ISQawmi = dtCurrentTable.Rows[i]["ComID"].ToString() == "A" ? false : true;

                                    Li_PacketBillManager.InsertLi_PacketBill(packetBillDetail);
                                }
                            }
                            else if (BillFor == 2)
                            {
                                for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                                {

                                    Li_PacketBill packetBillDetail = new Li_PacketBill();
                                    packetBillDetail.MemoNo = dtCurrentTable.Rows[i]["Memono"].ToString();
                                    packetBillDetail.TransportID = dtCurrentTable.Rows[i]["LibraryID"].ToString();
                                    packetBillDetail.LibraryID = dtCurrentTable.Rows[i]["TransportID"].ToString();
                                    packetBillDetail.LibraryName = dtCurrentTable.Rows[i]["AgentName"].ToString();
                                    packetBillDetail.LibraryAddress = dtCurrentTable.Rows[i]["LibraryAddress"].ToString();
                                    packetBillDetail.TransportName = dtCurrentTable.Rows[i]["TransportName"].ToString();

                                    packetBillDetail.RRNo = dtCurrentTable.Rows[i]["RRNo"].ToString();
                                    packetBillDetail.PackNo = int.Parse(dtCurrentTable.Rows[i]["PacketQty"].ToString());
                                    packetBillDetail.PerPacCost = decimal.Parse(dtCurrentTable.Rows[i]["PerPacketCost"].ToString());
                                    packetBillDetail.TotalPackCost = (packetBillDetail.PackNo * packetBillDetail.PerPacCost);

                                    packetBillDetail.ChalanDate = DateTime.Parse(dtCurrentTable.Rows[i]["ChallanDate"].ToString());
                                    packetBillDetail.DeliveryDate = DateTime.Parse(dtCurrentTable.Rows[i]["DeliveryDate"].ToString());
                                    packetBillDetail.CreatedBy = int.Parse(Session["UserID"].ToString());

                                    packetBillDetail.Van = decimal.Parse(dtCurrentTable.Rows[i]["Van"].ToString());
                                    packetBillDetail.VanOwn = decimal.Parse(dtCurrentTable.Rows[i]["VanOwn"].ToString());
                                    packetBillDetail.LabourLoad = decimal.Parse(dtCurrentTable.Rows[i]["LabourLoad"].ToString());
                                    packetBillDetail.LabourUnload = decimal.Parse(dtCurrentTable.Rows[i]["LabourUnload"].ToString());
                                    packetBillDetail.Transport = decimal.Parse(dtCurrentTable.Rows[i]["Transport"].ToString());
                                    packetBillDetail.TransportOwn = decimal.Parse(dtCurrentTable.Rows[i]["TransportOwn"].ToString());
                                    packetBillDetail.Choat = decimal.Parse(dtCurrentTable.Rows[i]["Choat"].ToString());
                                    packetBillDetail.Polithin = decimal.Parse(dtCurrentTable.Rows[i]["Polithin"].ToString());
                                    packetBillDetail.SelaiIn = decimal.Parse(dtCurrentTable.Rows[i]["SelaiIn"].ToString());
                                    packetBillDetail.SelaiOut = decimal.Parse(dtCurrentTable.Rows[i]["SelaiOut"].ToString());

                                    packetBillDetail.IsPending = Boolean.Parse(dtCurrentTable.Rows[i]["IsComplete"].ToString()) == false ? 0 : 1;

                                    Li_PacketBillManager.InsertLi_SpecimenPacketBill(packetBillDetail);
                                }
                            }
          

                        }

                        AddDefaultFirstRecord();
                        txtBookingPerPacCost.Text = "";
                        txtBookingTotalpackCost.Text = "";
                        txtChallanDate.Text = "";
                        txtChoat.Text = "";
                        txtDeliveryDate.Text = "";
                        txtLibraryAddress.Text = "";
                        txtMemoNo.Text = "";
                        txtPacketQty.Text = "";
                        txtPerPacCost.Text = "";
                        txtPolythin.Text = "";
                        txtRRNo.Text = "";
                        txtSelaiIn.Text = "";
                        txtSelaiOut.Text = "";
                        txtTransport.Text = "";
                        textTransportOwn.Text = "";
                        txtVan.Text = "";
                        txtVanOwn.Text = "";
                        txtAmountReceivable.Text = "0.00";
                        txtPacketNo.Text = "0";
                        txtLabourLoad.Text = "";
                        txtLabourUnload.Text = "";
                        txtPacDelivry.Text = "";
                        ddlTransportName.SelectedIndex = 0;
                        ddlLibraryName.SelectedIndex = 0;
                        ddlBillFor.SelectedIndex = 0;
                        ddlComID.SelectedIndex = 0;
                        chkIsComplete.Checked = false;

                        Sms_sending();

                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Saved Sucessfully');", true);


                    }
                }


            catch (Exception)
            {

                //lblError.Text = ex.Message.ToString();


            }
        }

        private void Sms_sending()
        {


            string result = "";
            WebRequest request = null;
            HttpWebResponse response = null;
            try
            { // testing team

                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand("SMPM_li_GetAgentSMS", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataAdapter myadapter = new SqlDataAdapter(command);
                    myadapter.Fill(dt);
                    myadapter.Dispose();
                    connection.Close();

                }
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //// For Greenweb SMS System 17/06/2019

                        ////String to = dt.Rows[i]["MobileNumber"].ToString(); //Recipient Phone Number multiple number must be separated by comma
                        ////String token = "6858472196e8b68d22e15fc741f9d8d1"; //generate token from the control panel
                        ////String message = System.Uri.EscapeUriString(dt.Rows[i]["SMSText"].ToString()); //do not use single quotation (') in the message to avoid forbidden result
                        ////String url = "http://api.greenweb.com.bd/api.php?token=" + token + "&to=" + to + "&message=" + message;
                        ////request = WebRequest.Create(url);

                        ////// Send the 'HttpWebRequest' and wait for response.
                        ////response = (HttpWebResponse)request.GetResponse();
                        ////Stream stream = response.GetResponseStream();
                        ////Encoding ec = System.Text.Encoding.GetEncoding("utf-8");
                        ////StreamReader reader = new
                        ////System.IO.StreamReader(stream, ec);
                        ////result = reader.ReadToEnd();
                        //////MessageBox.Show(result);
                        ////reader.Close();
                        ////stream.Close();


                        //// For BulkSMS Bd System 17/06/2019

                        //String userid = "01733210500"; //Your Login ID
                        //String password = "Fd%71&sd23!"; //Your Password
                        //String number = dt.Rows[i]["MobileNumber"].ToString(); //Recipient Phone Number multiple number must be separated by comma
                        //String message = System.Uri.EscapeUriString(dt.Rows[i]["SMSText"].ToString()); //do not use single quotation (') in the message to avoid forbidden result
                        //String url = "http://66.45.237.70/api.php?username=" + userid + "&password=" + password + "&number=" + number + "&message=" + message;                        
                        ////String url = "http://66.45.237.70/maskingapi.php?username=" + userid + "&password=" + password + "&number=" + number + "&senderid=AL%20FATAH&message=" + message;


                        //request = WebRequest.Create(url);

                        //// Send the 'HttpWebRequest' and wait for response.
                        //response = (HttpWebResponse)request.GetResponse();
                        //Stream stream = response.GetResponseStream();
                        //Encoding ec = System.Text.Encoding.GetEncoding("utf-8");
                        //StreamReader reader = new
                        //System.IO.StreamReader(stream, ec);
                        //result = reader.ReadToEnd();
                        ////Console.WriteLine(result);
                        //reader.Close();
                        //stream.Close();

                        //For Greenweb SMS 19/01/2022
                        String to = dt.Rows[i]["MobileNumber"].ToString(); //Recipient Phone Number multiple number must be separated by comma
                        String token = "7d99d50a1f4cad8b8c64fe468b83623c"; //generate token from the control panel
                        String message = System.Uri.EscapeUriString(dt.Rows[i]["SMSText"].ToString()); //do not use single quotation (') in the message to avoid forbidden result
                        String url = "http://api.greenweb.com.bd/api.php?token=" + token + "&to=" + to + "&message=" + message;
                        request = WebRequest.Create(url);

                        // Send the 'HttpWebRequest' and wait for response.
                        response = (HttpWebResponse)request.GetResponse();
                        Stream stream = response.GetResponseStream();
                        Encoding ec = System.Text.Encoding.GetEncoding("utf-8");
                        StreamReader reader = new
                        System.IO.StreamReader(stream, ec);
                        result = reader.ReadToEnd();
                        Console.WriteLine(result);
                        reader.Close();
                        stream.Close();

                        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
                        {
                            SqlCommand cmd = new SqlCommand("SMPM_li_Update_GetAgentSMS", connection);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@SmsId", SqlDbType.Int).Value = int.Parse(dt.Rows[i]["SMSID"].ToString());

                            connection.Open();
                            cmd.ExecuteNonQuery();
                        }

                    }
                }

            }
            catch (Exception exp)
            {
                //MessageBox.Show(exp.ToString());
            }
        }

    }
}