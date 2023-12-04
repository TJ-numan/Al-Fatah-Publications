using BLL.Classes;
using BLL.Marketing;
using Common;
using Common.Marketing;
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
    public partial class Mkt_Madrasha_PaymentSchedule : System.Web.UI.Page
    {
        DataAccessObject DAO = new DataAccessObject();
        string FormID = "MF025";

        string PayId, PayType;
        string ShedId;
        decimal Amnt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("~/Login.aspx");

            if (!IsPostBack)
            {
                LoadComboData.LoadDonYear(ddlAgreementYear);
                ddlAgreementYear.SelectedValue = "2022-2023";

                
                int year = DateTime.Now.Year;
                int month = DateTime.Now.Month;
                int day = DateTime.Now.Day;

                if (month >= 11)
                {
                    var mydate = new DateTime(year, 11, 01);

                    txtStartingDate.Text = String.Format("{0:yyyy-MM-dd}", mydate);

                    var Enddate = new DateTime(year+1, 10, 31);
                    txtEndingDate.Text = String.Format("{0:yyyy-MM-dd}", Enddate);
                }

                else
                {
                    var mydate = new DateTime(year - 1, 11, 01);
                    txtStartingDate.Text = String.Format("{0:yyyy-MM-dd}", mydate);

                    var Enddate = new DateTime(year, 10, 31);
                    txtEndingDate.Text = String.Format("{0:yyyy-MM-dd}", Enddate);
                }

                getUserAccess();
                AddDefaultFirstRecord();
                GetAllDistrict();
                GetAllDonationPayType();
                GetAllTransport();
                GetAllAcountType();
                GetAllDonationType();
                //AddDefaultFirstRecord_Don();
                //GetAllDonationType();
                AddDefaultFirstRecord_Letter();

            }

            if (Session["letterNo"] != null)
            {
                txtLetterNo.Text = Session["letterNo"].ToString();
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
                        Response.Redirect("~/MarketingHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }
        private void GetAllDistrict()
        {
            try
            {
                ddlDristrict.DataSource = li_DistrictManager.GetAll_Districts();
                ddlDristrict.DataTextField = "DistrictName";
                ddlDristrict.DataValueField = "DistrictID";
                ddlDristrict.DataBind();
                ddlDristrict.Items.Insert(0, new ListItem("--select--", "0"));
            }
            catch (Exception)
            {

            }
        }

        private void GetAllDonationType()
        {
            try
            {
                ddlDonationType.DataSource = Li_DonationDesManager.GetAllLi_DonationDessWithBudget();
                ddlDonationType.DataTextField = "DoDescription";
                ddlDonationType.DataValueField = "DoDesId";
                ddlDonationType.DataBind();
                ddlDonationType.Items.Insert(0, new ListItem("--select--", "0"));
            }
            catch (Exception)
            {

            }
        }
        private void GetAllDonationPayType()
        {
            try
            {
                ddlPaymentType.DataSource = Li_DonPayTypeManager.GetAllLi_DonPayTypes();
                ddlPaymentType.DataTextField = "PayTypName";
                ddlPaymentType.DataValueField = "PayTypId";
                ddlPaymentType.DataBind();
                ddlPaymentType.Items.Insert(0, new ListItem("--select--", "0"));
            }
            catch (Exception)
            {

            }
        }
        private void GetAllAcountType()
        {
            try
            {
                ddlAcountType.DataSource = Li_DonPayTypeManager.GetAllLi_DonAcountTypes();
                ddlAcountType.DataTextField = "AcTypeName";
                ddlAcountType.DataValueField = "AcTypeId";
                ddlAcountType.DataBind();
                ddlAcountType.Items.Insert(0, new ListItem("--select--", "0"));
            }
            catch (Exception)
            {

            }
        }

        private void GetAllTransport()
        {
            try
            {
                ddlTransportID.DataSource = Li_TransportInfoManager.GetAllLi_TransportInfos();
                ddlTransportID.DataTextField = "TransportName";
                ddlTransportID.DataValueField = "TransportID";
                ddlTransportID.DataBind();
                ddlTransportID.Items.Insert(0, new ListItem("--select--", "0"));
            }
            catch (Exception)
            {

            }
        }

        //private void GetAllDonationType()
        //{
        //    try
        //    {
        //        ddlDonationType.DataSource = Li_DonationDesManager.GetAllLi_DonationDess();
        //        ddlDonationType.DataTextField = "DoDescription";
        //        ddlDonationType.DataValueField = "DoDesId";
        //        ddlDonationType.DataBind();
        //        ddlDonationType.Items.Insert(0, new ListItem("--select--", "0"));
        //    }
        //    catch (Exception)
        //    {

        //    }
        //}
        protected void txtAgreementNo_TextChanged(object sender, EventArgs e)
        {
            try
            {

                DataSet dsDonName = Li_DonPaymentSheduleManager.GetDonationNameR2(txtAgreementNo.Text.Trim(), ddlAgreementYear.SelectedItem.Text.Substring(ddlAgreementYear.SelectedItem.Text.Length - 2, 2));
                ddlMadSomPer.DataSource = dsDonName.Tables[0];
                if (dsDonName.Tables[0].Rows.Count>1)
                {
                    ddlMadSomPer.DataTextField = "DoName";
                    ddlMadSomPer.DataValueField = "DetId";
                    ddlMadSomPer.DataBind();
                    ddlMadSomPer.Items.Insert(0, new ListItem("--select--", "0"));

                    lblbudget.Text = string.Empty;
                    gvwAgreementAmount.DataSource = null;
                    gvwAgreementAmount.DataBind();
                    EmptyText();
                    //txtAgreementNo.Focus();
                    ddlMadSomPer.Focus();
                }
                else
                {
                    ddlMadSomPer.DataTextField = "DoName";
                    ddlMadSomPer.DataValueField = "DetId";
                    ddlMadSomPer.DataBind();

                    ViewState["tblPaySchedule"] = null;
                    gvwPaymentSchedule.DataSource = null;
                    gvwPaymentSchedule.DataBind();
                    AddDefaultFirstRecord();

                    lblbudget.Text = "0.0m";
                    DataTable dt = Li_DonPaymentSheduleManager.GetAgreementAmountByMadSomiPerson(int.Parse(ddlMadSomPer.SelectedValue)).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        lblbudget.Text = dt.Rows[0]["DonAmt"].ToString();
                    }

                    gvwAgreementAmount.DataSource = Li_DonPaymentSheduleManager.GetAgreementAmountR2(txtAgreementNo.Text, int.Parse(ddlMadSomPer.SelectedValue), ddlAgreementYear.SelectedItem.Text.Substring(ddlAgreementYear.SelectedItem.Text.Length - 2, 2));
                    gvwAgreementAmount.DataBind();

                    DataTable dtAmntShed = Li_DonPaymentSheduleManager.GetAmntSheduleBy_DonFor(int.Parse(ddlMadSomPer.SelectedValue)).Tables[0];
                    if (dtAmntShed.Rows.Count > 0)
                    {
                        gvwPaymentSchedule.DataSource = dtAmntShed;
                        gvwPaymentSchedule.DataBind();
                    }

                    ddlMadSomPer.Focus();
                }
                

            }
            catch (Exception)
            {


            }
        }

        //private void AddDefaultFirstRecord_Don()
        //{
        //    try
        //    {
        //        bool fromLinkButton = false;

        //        DataTable dt = new DataTable();
        //        DataRow dr;
        //        dt.TableName = "tblDonationType";
        //        dt.Columns.Add("Serial", typeof(int));
        //        dt.Columns.Add("DonDesId", typeof(int));
        //        dt.Columns.Add("DonType", typeof(string));
        //        dt.Columns.Add("Amount", typeof(decimal));
        //        dr = dt.NewRow();
        //        dt.Rows.Add(dr);
        //        ViewState["tblDonationType"] = dt;
        //        gvwDonationType.DataSource = dt;
        //        gvwDonationType.DataBind();
        //        ViewState["LinkClick"] = fromLinkButton;

        //    }
        //    catch (Exception)
        //    {


        //    }
        //}

        //private void AddNewRecordRowToGrid_Don()
        //{
        //    // check view state is not null  
        //    if (ViewState["tblDonationType"] != null)
        //    {
        //        //get datatable from view state   
        //        DataTable dtCurrentTable_Don = (DataTable)ViewState["tblDonationType"];
        //        DataRow drCurrentRow = null;
        //        if (dtCurrentTable_Don.Rows.Count == 0)
        //        {
        //            AddDefaultFirstRecord_Don();
        //        }
        //        else
        //        {
        //            if (Convert.ToBoolean(ViewState["LinkClick"]) == true)
        //            {


        //                for (int i = 0; i < dtCurrentTable_Don.Rows.Count; i++)
        //                {
        //                    dtCurrentTable_Don.Rows[i][0] = i + 1;
        //                    dtCurrentTable_Don.AcceptChanges();
        //                }

        //                ViewState["LinkClick"] = false;
        //            }
        //            else
        //            {
        //                for (int i = 1; i <= dtCurrentTable_Don.Rows.Count; i++)
        //                {

        //                    //add each row into data table  
        //                    drCurrentRow = dtCurrentTable_Don.NewRow();
        //                    drCurrentRow["Serial"] = dtCurrentTable_Don.Rows.Count + 1;

        //                }
        //                drCurrentRow["DonDesId"] = ddlDonationType.SelectedItem.Value.ToString();
        //                drCurrentRow["DonType"] = ddlDonationType.SelectedItem.Text;
        //                drCurrentRow["Amount"] = decimal.Parse(txtAmount2.Text);

        //                ClearTextBoxData();
        //                //Remove initial blank row  
        //                if (dtCurrentTable_Don.Rows[0][0].ToString() == "")
        //                {
        //                    drCurrentRow["Serial"] = dtCurrentTable_Don.Rows.Count;
        //                    dtCurrentTable_Don.Rows[0].Delete();
        //                    dtCurrentTable_Don.AcceptChanges();

        //                }

        //                //add created Rows into dataTable  
        //                dtCurrentTable_Don.Rows.Add(drCurrentRow);
        //            }


        //            ViewState["tblDonationType"] = dtCurrentTable_Don;
        //            //Bind Gridview with latest Row  
        //            gvwDonationType.DataSource = dtCurrentTable_Don;
        //            gvwDonationType.DataBind();
        //            decimal subTotal = 0.0m;
        //            if (dtCurrentTable_Don.Rows.Count > 0)
        //            {
        //                for (int i = 0; i < dtCurrentTable_Don.Rows.Count; i++)
        //                {
        //                    decimal unitTotal = decimal.Parse(dtCurrentTable_Don.Rows[i]["Amount"].ToString());
        //                    subTotal += unitTotal;
        //                }
        //            }

        //            txtTotalAmount.Text = subTotal.ToString();

        //        }



        //    }

        //}

        //private void ClearTextBoxData()
        //{
        //    ddlDonationType.SelectedIndex = 0;
        //    txtAmount2.Text = string.Empty;

        //}

        private void AddDefaultFirstRecord()
        {
            bool fromLinkButton = false;
            //creating dataTable   
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "tblPaySchedule";
            dt.Columns.Add("Serial", typeof(string));
            dt.Columns.Add("ShedId", typeof(int));
            dt.Columns.Add("DoDescription", typeof(string));
            dt.Columns.Add("DoDesId", typeof(string));
            dt.Columns.Add("Amount", typeof(decimal));
            dt.Columns.Add("StartingDate", typeof(string));
            dt.Columns.Add("EndingDate", typeof(string));


            dr = dt.NewRow();
            dt.Rows.Add(dr);
            //saving databale into viewstate   
            ViewState["tblPaySchedule"] = dt;
            //bind Gridview  
            gvwPaymentSchedule.DataSource = dt;
            gvwPaymentSchedule.DataBind();

            ViewState["LinkClick"] = fromLinkButton;

        }

        private void AddNewRecordRowToGrid()
        {


            DataTable dtCurrentTable = (DataTable)ViewState["tblPaySchedule"];
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


                    }

                    // New row for data table

                    for (int i = 0; i < gvwAgreementAmount.Rows.Count; i++)
                    {

                        CheckBox chkRow = (gvwAgreementAmount.Rows[i].Cells[0].FindControl("chkSelect") as CheckBox);
                        if (chkRow.Checked == true)
                        {
                            ShedId = gvwAgreementAmount.Rows[i].Cells[1].Text;
                            PayId = gvwAgreementAmount.Rows[i].Cells[2].Text;
                            PayType = gvwAgreementAmount.Rows[i].Cells[3].Text;
                            Amnt = decimal.Parse(gvwAgreementAmount.Rows[i].Cells[4].Text);
                        }
                    }


                    if (decimal.Parse(txtAmount.Text) > Amnt)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Amount is greater than budget');", true);
                        return;
                    }

                    drCurrentRow["ShedId"] = ShedId.ToString();
                    drCurrentRow["DoDescription"] = PayType.ToString();
                    drCurrentRow["DoDesId"] = PayId.ToString();
                    drCurrentRow["Amount"] = txtAmount.Text;
                    drCurrentRow["StartingDate"] = txtStartingDate.Text;
                    drCurrentRow["EndingDate"] = txtEndingDate.Text;





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

                ViewState["tblPaySchedule"] = dtCurrentTable;
                //Bind Gridview with latest Row  
                gvwPaymentSchedule.DataSource = dtCurrentTable;
                gvwPaymentSchedule.DataBind();


            }


        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlMadSomPer.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Select a Madrasha');", true);
                    return;

                }
                if (decimal.Parse(txtAmount.Text) > 0.0m)
                {
                    if (gvwAgreementAmount.Rows.Count > 0)
                    {
                        for (int i = 0; i < gvwAgreementAmount.Rows.Count; i++)
                        {

                            CheckBox chkRow = (gvwAgreementAmount.Rows[i].Cells[0].FindControl("chkSelect") as CheckBox);
                            if (chkRow.Checked == true)
                            {
                                if (decimal.Parse(txtAmount.Text) > decimal.Parse(gvwAgreementAmount.Rows[i].Cells[4].Text))
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('This payment amount exceed');", true);
                                    return;
                                }


                                string hasData = gvwPaymentSchedule.Rows[0].Cells[1].Text.Replace("&nbsp;", "");
                                if (hasData != "")
                                {

                                    decimal existingAmt = 0.0m;
                                    for (int j = 0; j < gvwPaymentSchedule.Rows.Count; j++)
                                    {
                                        if (gvwAgreementAmount.Rows[i].Cells[3].Text == gvwPaymentSchedule.Rows[j].Cells[2].Text)
                                        {
                                            existingAmt += decimal.Parse(gvwPaymentSchedule.Rows[j].Cells[3].Text);

                                            if (existingAmt + decimal.Parse(txtAmount.Text) > decimal.Parse(gvwAgreementAmount.Rows[i].Cells[4].Text))
                                            {
                                                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('This Payment already exist');", true);
                                                return;
                                            }
                                        }
                                    }
                                }

                                AddNewRecordRowToGrid();

                            }

                        }
                    }

                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Budget not exist.');", true);
                        return;
                    }
                    txtStartingDate.Focus();

                }


                txtStartingDate.Text = string.Empty;
                txtEndingDate.Text = string.Empty;
                txtAmount.Text = "0";
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
                DataTable dtCurrentTable = (DataTable)ViewState["tblPaySchedule"];
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
                if (ddlMadSomPer.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select a Madrasha');", true);
                    return;
                }
                string hasData = gvwPaymentSchedule.Rows[0].Cells[2].Text.Replace("&nbsp;", "");
                if (hasData == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please add payment schedule');", true);
                    return;
                }

                //DataTable dtCurrentTable_Don = (DataTable)ViewState["tblDonationType"];
                //if (dtCurrentTable_Don.Rows.Count > 0)
                //{
                //    for (int i = 0; i < dtCurrentTable_Don.Rows.Count; i++)
                //    {

                //        Li_DonationAmt DonAmt = new Li_DonationAmt();
                //        DonAmt.DetId = int.Parse(ddlMadSomPer.SelectedValue);
                //        DonAmt.DoDesId = int.Parse(dtCurrentTable_Don.Rows[i]["DonDesId"].ToString());
                //        DonAmt.Amount = decimal.Parse(dtCurrentTable_Don.Rows[i]["Amount"].ToString());
                //        DonAmt.CreatedBy = int.Parse(Session["UserID"].ToString());
                //        DonAmt.CreatedDate = DateTime.Now;
                //        Li_DonationAmtManager.InsertLi_DonationAmt(DonAmt);


                //    }

                //    dtCurrentTable_Don.Rows.Clear();
                //}

                DataTable dtCurrentTable = (DataTable)ViewState["tblPaySchedule"];
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                    {

                        Li_DonPaymentShedule DonPaySchedule = new Li_DonPaymentShedule();
                        DonPaySchedule.DetId = int.Parse(ddlMadSomPer.SelectedValue);

                        DonPaySchedule.SheId = int.Parse(dtCurrentTable.Rows[i]["ShedId"].ToString());
                        DonPaySchedule.DoDesId = int.Parse(dtCurrentTable.Rows[i]["DoDesId"].ToString());
                        DonPaySchedule.Amount = decimal.Parse(dtCurrentTable.Rows[i]["Amount"].ToString());
                        DonPaySchedule.Status_d = "C";
                        DonPaySchedule.StartingDate = DateTime.Parse(dtCurrentTable.Rows[i]["StartingDate"].ToString());
                        DonPaySchedule.EndingDate = DateTime.Parse(dtCurrentTable.Rows[i]["EndingDate"].ToString());
                        DonPaySchedule.CreatedBy = int.Parse(Session["UserID"].ToString());
                        DonPaySchedule.CreatedDate = DateTime.Now;
                        int PSId = Li_DonPaymentSheduleManager.InsertLi_DonPaymentShedule(DonPaySchedule);

                        Li_DonPayment donpayment = new Li_DonPayment();
                        donpayment.PSId = PSId; //int.Parse(dtCurrentTable.Rows[i]["ShedId"].ToString());
                        donpayment.AcName = txtAcountName.Text;
                        donpayment.AcName_bn = txtAcountName_bn.Text;
                        donpayment.AcMemNo = txtAccountNo.Text;
                        donpayment.BankCof = txtBankName.Text;
                        donpayment.AcAddress = txtBranchAddress.Text;
                        donpayment.ThanaId = int.Parse(ddlThana.SelectedValue);
                        donpayment.ContactNo = txtContactNo.Text;
                        donpayment.IsBankPay = chkIsBankPay.Checked ? true : false;
                        donpayment.AccTypId = int.Parse(ddlAcountType.SelectedValue);
                        donpayment.PayTypId = int.Parse(ddlPaymentType.SelectedValue);
                        donpayment.TransportID = ddlTransportID.SelectedValue;
                        donpayment.IsRecAckNo = false;
                        donpayment.AckNo = "";
                        donpayment.Remarks = txtRemarks.Text;
                        donpayment.CreatedBy = int.Parse(Session["UserID"].ToString());
                        donpayment.CreatedDate = DateTime.Now;
                        Li_DonPaymentManager.InsertLi_DonPayment(donpayment);

                        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);
                        EmptyText();
                        txtStartingDate.Focus();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        protected void ddlMadSomPer_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                ViewState["tblPaySchedule"] = null;
                gvwPaymentSchedule.DataSource = null;
                gvwPaymentSchedule.DataBind();
                AddDefaultFirstRecord();

                lblbudget.Text = "0.0m";
                DataTable dt = Li_DonPaymentSheduleManager.GetAgreementAmountByMadSomiPerson(int.Parse(ddlMadSomPer.SelectedValue)).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    lblbudget.Text = dt.Rows[0]["DonAmt"].ToString();
                }

                gvwAgreementAmount.DataSource = Li_DonPaymentSheduleManager.GetAgreementAmountR2(txtAgreementNo.Text, int.Parse(ddlMadSomPer.SelectedValue), ddlAgreementYear.SelectedItem.Text.Substring(ddlAgreementYear.SelectedItem.Text.Length - 2, 2));
                gvwAgreementAmount.DataBind();

                DataTable dtAmntShed = Li_DonPaymentSheduleManager.GetAmntSheduleBy_DonFor(int.Parse(ddlMadSomPer.SelectedValue)).Tables[0];
                if (dtAmntShed.Rows.Count > 0)
                {
                    gvwPaymentSchedule.DataSource = dtAmntShed;
                    gvwPaymentSchedule.DataBind();
                }

                ddlMadSomPer.Focus();
            }
            catch (Exception)
            {

            }
        }

        protected void btnAdd_Don_Click(object sender, EventArgs e)
        {
            //if(ddlMadSomPer.SelectedValue=="0")
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Select a Madrasha');", true);
            //    return;

            //}
            //if(ddlDonationType.SelectedValue=="0")
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Select a Donation Type');", true);
            //    return;

            //}
            //if (decimal.Parse(txtAmount2.Text) > 0.0m)
            //{
            //    if ( decimal.Parse(txtAmount2.Text)> decimal.Parse(lblbudget.Text))
            //    {
            //        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('This amount exceed budget');", true);
            //        return;
            //    }

            //    string hasData = gvwDonationType.Rows[0].Cells[2].Text.Replace("&nbsp;","");
            //    if (hasData != "")
            //    {

            //        decimal Amount = 0.0m;
            //        for (int i = 0; i < gvwDonationType.Rows.Count; i++)
            //        {

            //            Amount += decimal.Parse(gvwDonationType.Rows[i].Cells[2].Text);
            //        }
            //        decimal giveAmnt = (Amount + decimal.Parse(txtAmount2.Text));
            //        if (giveAmnt > decimal.Parse(lblbudget.Text))
            //        {
            //            ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('This amount exceed budget');", true);
            //            return;
            //        }
            //    }



            //    AddNewRecordRowToGrid_Don();
            //}
        }

        protected void ddlDristrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlThana.DataSource = li_ThanaManager.Get_ThanaByDistrictID(int.Parse(ddlDristrict.SelectedValue));
                ddlThana.DataTextField = "ThanaName";
                ddlThana.DataValueField = "ThanaID";
                ddlThana.DataBind();

                ddlDristrict.Focus();
            }
            catch (Exception)
            {

            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            txtAgreementNo.Text = string.Empty;
            ddlMadSomPer.SelectedValue = "0";
            lblbudget.Text = string.Empty;
            gvwAgreementAmount.DataSource = null;
            gvwAgreementAmount.DataBind();

            EmptyText();
        }

        private void EmptyText()
        {
            ViewState["tblPaySchedule"] = null;
            AddDefaultFirstRecord();
            txtStartingDate.Text = string.Empty;
            txtEndingDate.Text = string.Empty;
            txtAmount.Text = string.Empty;
            chkIsBankPay.Checked = false;
            txtAcountName.Text = string.Empty;
            txtAcountName_bn.Text = string.Empty;
            txtAccountNo.Text = string.Empty;
            ddlAcountType.SelectedValue = "0";
            ddlPaymentType.SelectedValue = "0";
            txtBankName.Text = string.Empty;
            txtBranchAddress.Text = string.Empty;
            ddlDristrict.SelectedValue = "0";
            ddlThana.SelectedValue = "0";
            txtContactNo.Text = string.Empty;
            ddlTransportID.SelectedValue = "0";
            txtRemarks.Text = string.Empty;
        }

        //protected void lbDelete_Don_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        LinkButton linkButton = new LinkButton();
        //        linkButton = (LinkButton)sender;
        //        DataTable dtCurrentTable = (DataTable)ViewState["tblDonationType"];
        //        dtCurrentTable.Rows[Convert.ToInt32(linkButton.CommandArgument) - 1].Delete();
        //        dtCurrentTable.AcceptChanges();
        //        ViewState["LinkClick"] = true;
        //        AddNewRecordRowToGrid_Don();

        //    }
        //    catch (Exception)
        //    {


        //    }
        //}

        protected void chkDonSelect_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                CheckBox activeCheckBox = sender as CheckBox;
                ClearPayInfo();

                for (int i = 0; i < gvwPaymentSchedule.Rows.Count; i++)
                {

                    CheckBox chkRow = (gvwPaymentSchedule.Rows[i].Cells[0].FindControl("chkDonSelect") as CheckBox);
                    if (chkRow != activeCheckBox)
                    {
                        chkRow.Checked = false;
                    }
                    else
                    {
                        chkRow.Checked = true;
                    }
                    if (chkRow.Checked == true)
                    {

                        DataTable dtdonpay = Li_DonPaymentManager.GetDonPaymentInfoBySheID(int.Parse(gvwPaymentSchedule.Rows[i].Cells[1].Text)).Tables[0];
                        if (dtdonpay.Rows.Count > 0)
                        {
                            chkIsBankPay.Checked = bool.Parse(dtdonpay.Rows[0]["IsBankPay"].ToString()) == true ? true : false;
                            txtAcountName.Text = dtdonpay.Rows[0]["AcName"].ToString();
                            txtAcountName_bn.Text = dtdonpay.Rows[0]["AcName_bn"].ToString();
                            txtAccountNo.Text = dtdonpay.Rows[0]["AcMemNo"].ToString();
                            ddlAcountType.SelectedValue = dtdonpay.Rows[0]["AccTypId"].ToString();
                            ddlPaymentType.SelectedValue = dtdonpay.Rows[0]["PayTypId"].ToString();
                            txtBankName.Text = dtdonpay.Rows[0]["BankCof"].ToString();
                            txtBranchAddress.Text = dtdonpay.Rows[0]["AcAddress"].ToString();
                            ddlDristrict.SelectedValue = dtdonpay.Rows[0]["DistrictID"].ToString();

                            ddlThana.DataSource = li_ThanaManager.Get_ThanaByDistrictID(int.Parse(dtdonpay.Rows[0]["DistrictID"].ToString()));
                            ddlThana.DataTextField = "ThanaName";
                            ddlThana.DataValueField = "ThanaID";
                            ddlThana.DataBind();

                            ddlThana.SelectedValue = dtdonpay.Rows[0]["ThanaId"].ToString();
                            txtContactNo.Text = dtdonpay.Rows[0]["ContactNo"].ToString();
                            ddlTransportID.SelectedValue = dtdonpay.Rows[0]["TransportID"].ToString();
                            txtRemarks.Text = dtdonpay.Rows[0]["Remarks"].ToString();

                        }
                        txtAmount.Text = gvwPaymentSchedule.Rows[i].Cells[3].Text;
                        txtStartingDate.Text = gvwPaymentSchedule.Rows[i].Cells[4].Text;
                        txtEndingDate.Text = gvwPaymentSchedule.Rows[i].Cells[5].Text;
                        lblShedPaySerial.Text = gvwPaymentSchedule.Rows[i].Cells[1].Text;
                    }

                }
            }
            catch (Exception)
            {


            }
        }

        private void ClearPayInfo()
        {
            txtStartingDate.Text = string.Empty;
            txtEndingDate.Text = string.Empty;
            txtAmount.Text = string.Empty;

            chkIsBankPay.Checked = false;
            txtAcountName.Text = string.Empty;
            txtAcountName_bn.Text = string.Empty;
            txtAccountNo.Text = string.Empty;
            ddlAcountType.SelectedValue = "0";
            ddlPaymentType.SelectedValue = "0";
            txtBankName.Text = string.Empty;
            txtBranchAddress.Text = string.Empty;
            ddlDristrict.SelectedValue = "0";
            ddlThana.SelectedValue = "0";
            txtContactNo.Text = string.Empty;
            ddlTransportID.SelectedValue = "0";
            txtRemarks.Text = string.Empty;
        }

        private void AddDefaultFirstRecord_Letter()
        {
            bool fromLinkButton = false;
            //creating dataTable   
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "tblLetter";
            dt.Columns.Add("Serial", typeof(string));
            dt.Columns.Add("AgrNo", typeof(string));
            dt.Columns.Add("PSId", typeof(string));


            dt.Columns.Add("MadSomity_Id", typeof(string));
            dt.Columns.Add("MadSomityName", typeof(string));
            dt.Columns.Add("TeritoryName", typeof(string));
            dt.Columns.Add("DonationAmnt", typeof(decimal));
            dt.Columns.Add("PrevPayment", typeof(decimal));
            dt.Columns.Add("CurDemandAmnt", typeof(decimal));
            dt.Columns.Add("DueAmnt", typeof(int));
            dt.Columns.Add("PayType", typeof(string));
            dt.Columns.Add("AccountName", typeof(string));
            dt.Columns.Add("AccountNameBn", typeof(string));
            dt.Columns.Add("AccountNo", typeof(string));
            dt.Columns.Add("AccountType", typeof(string));
            dt.Columns.Add("BankName", typeof(string));
            dt.Columns.Add("Branch", typeof(string));
            dt.Columns.Add("Address", typeof(string));


            dr = dt.NewRow();
            dt.Rows.Add(dr);
            //saving databale into viewstate   
            ViewState["tblLetter"] = dt;
            //bind Gridview  
            gvwletter.DataSource = dt;
            gvwletter.DataBind();

            ViewState["LinkClick"] = fromLinkButton;

        }

        private void AddNewRecordRowToGrid_Letter()
        {


            DataTable dtLetterTable = (DataTable)ViewState["tblLetter"];
            DataRow drCurrentRow = null;
            if (dtLetterTable.Rows.Count == 0)
            {
                AddDefaultFirstRecord_Letter();
            }
            else
            {
                if ((bool)ViewState["LinkClick"] == true)
                {


                    for (int i = 0; i < dtLetterTable.Rows.Count; i++)
                    {
                        dtLetterTable.Rows[i][0] = i + 1;
                        dtLetterTable.AcceptChanges();
                    }

                    ViewState["LinkClick"] = false;
                }
                else
                {


                    for (int i = 1; i <= dtLetterTable.Rows.Count; i++)
                    {



                        //add each row into data table  
                        drCurrentRow = dtLetterTable.NewRow();
                        drCurrentRow["Serial"] = dtLetterTable.Rows.Count + 1;


                    }

                    // New row for data table

                    drCurrentRow["AgrNo"] = txtAgreementNo.Text;
                    drCurrentRow["PSId"] = lblShedPaySerial.Text;
                    drCurrentRow["MadSomity_Id"] = ddlMadSomPer.SelectedValue;
                    drCurrentRow["MadSomityName"] = ddlMadSomPer.SelectedItem.Text;
                    DataTable dtTer = li_ThanaManager.GetAll_ThanasWithRelationByThanaId(ddlMadSomPer.SelectedValue).Tables[0];
                    if (dtTer.Rows.Count > 0)
                    {
                        drCurrentRow["TeritoryName"] = dtTer.Rows[0]["TeritoryName"].ToString();
                    }

                    decimal DonAmnt = 0.00m;
                    DataTable dtDonBasicAmnt = Li_DonPaymentSheduleManager.GetDonationBasicAmntByAgreementR2(txtAgreementNo.Text, int.Parse(ddlMadSomPer.SelectedValue), ddlAgreementYear.SelectedItem.Text.Substring(ddlAgreementYear.SelectedItem.Text.Length - 2, 2)).Tables[0];
                    if (dtDonBasicAmnt.Rows.Count > 0)
                    {
                        DonAmnt = decimal.Parse(dtDonBasicAmnt.Rows[0]["Amount"].ToString());
                    }
                    drCurrentRow["DonationAmnt"] = DonAmnt;

                    decimal PrevAmnt = Li_DonPaymentSheduleManager.GetDonationPreviousPaid(Int32.Parse(ddlMadSomPer.SelectedValue), 0);


                    DataTable dtexistingAmnt = (DataTable)ViewState["tblLetter"];
                    if (dtexistingAmnt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtexistingAmnt.Rows.Count; i++)
                        {
                            if (ddlMadSomPer.SelectedValue == dtexistingAmnt.Rows[i]["MadSomity_Id"].ToString())
                            {

                                drCurrentRow["PrevPayment"] = decimal.Parse(dtLetterTable.Rows[i]["CurDemandAmnt"].ToString());
                                drCurrentRow["DueAmnt"] = DonAmnt - (decimal.Parse(dtLetterTable.Rows[i]["CurDemandAmnt"].ToString()) + decimal.Parse(txtAmount.Text));
                                //drCurrentRow["DueAmnt"] = DonAmnt - (PrevAmnt + decimal.Parse(txtAmount.Text));

                            }
                            else
                            {

                                drCurrentRow["PrevPayment"] = PrevAmnt;
                                drCurrentRow["DueAmnt"] = DonAmnt - (PrevAmnt + decimal.Parse(txtAmount.Text));
                            }
                        }
                    }


                    //drCurrentRow["PrevPayment"] = PrevAmnt;
                    drCurrentRow["CurDemandAmnt"] = txtAmount.Text;
                    drCurrentRow["PayType"] = ddlPaymentType.SelectedItem.Text;
                    drCurrentRow["AccountName"] = txtAcountName.Text;
                    drCurrentRow["AccountNameBn"] = txtAcountName_bn.Text;
                    drCurrentRow["AccountNo"] = txtAccountNo.Text;
                    drCurrentRow["AccountType"] = ddlAcountType.SelectedItem.Text;
                    drCurrentRow["BankName"] = txtBankName.Text;
                    drCurrentRow["Branch"] = txtBranchAddress.Text;
                    drCurrentRow["Address"] = ddlDristrict.SelectedItem.Text;



                    //Remove initial blank row  
                    if (dtLetterTable.Rows[0][0].ToString() == "")
                    {
                        drCurrentRow["Serial"] = dtLetterTable.Rows.Count;
                        dtLetterTable.Rows[0].Delete();
                        dtLetterTable.AcceptChanges();

                    }

                    //add created Rows into dataTable  
                    dtLetterTable.Rows.Add(drCurrentRow);
                }

                //Save Data table into view state after creating each row  

                ViewState["tblLetter"] = dtLetterTable;
                //Bind Gridview with latest Row  
                gvwletter.DataSource = dtLetterTable;
                gvwletter.DataBind();


                decimal subTotal = 0.0m;

                for (int i = 0; i < dtLetterTable.Rows.Count; i++)
                {
                    decimal unitTotal = decimal.Parse(dtLetterTable.Rows[i]["CurDemandAmnt"].ToString());
                    subTotal += unitTotal;

                }
                txtLetterAmount.Text = subTotal.ToString();

            }


        }

        protected void btnAddToLetter_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtLetterTable = (DataTable)ViewState["tblLetter"];
                if (dtLetterTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dtLetterTable.Rows.Count; i++)
                    {
                        if (txtAgreementNo.Text == dtLetterTable.Rows[i]["AgrNo"].ToString() && lblShedPaySerial.Text == dtLetterTable.Rows[i]["PSId"].ToString())
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('This Schedule already adding bellow');", true);
                            return;
                        }
                    }
                }

                AddNewRecordRowToGrid_Letter();

                txtAgreementNo.Focus();
            }
            catch (Exception)
            {

            }
        }

        protected void btnLetterSave_Click(object sender, EventArgs e)
        {
            if (ddlDonationType.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select Donation Type');", true);
                return;
            }
            if (ddlAcountType.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select Account Type');", true);
                return;
            }
            if (ddlPaymentType.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select Payment Type');", true);
                return;
            }

            Li_DonBasicLetter donBasicLetter = new Li_DonBasicLetter();
            donBasicLetter.DoDesId = int.Parse(ddlDonationType.SelectedValue);
            donBasicLetter.LetterAmount = Convert.ToDecimal(txtLetterAmount.Text);
            donBasicLetter.CreatedBy = int.Parse(Session["UserID"].ToString());
            donBasicLetter.CreatedDate = DateTime.Now;
            Session["letterNo"] = Li_DonLetterManager.InsertLi_DonBasicLetter(donBasicLetter);


            DataTable dtLetterTable = (DataTable)ViewState["tblLetter"];
            if (dtLetterTable.Rows.Count > 0)
            {
                for (int i = 0; i < dtLetterTable.Rows.Count; i++)
                {
                    Li_DonLetter DonLetter = new Li_DonLetter();
                    DonLetter.LetterNo = Session["letterNo"].ToString();
                    DonLetter.PSId = int.Parse(dtLetterTable.Rows[i]["PSId"].ToString());
                    DonLetter.DonationAmnt = decimal.Parse(dtLetterTable.Rows[i]["DonationAmnt"].ToString());
                    DonLetter.PrevPayment = decimal.Parse(dtLetterTable.Rows[i]["PrevPayment"].ToString());
                    DonLetter.DemandAmnt = decimal.Parse(dtLetterTable.Rows[i]["CurDemandAmnt"].ToString());
                    DonLetter.DueAmnt = decimal.Parse(dtLetterTable.Rows[i]["DueAmnt"].ToString());
                    DonLetter.CreatedBy = int.Parse(Session["UserID"].ToString());
                    DonLetter.CreatedDate = DateTime.Now;
                    Li_DonLetterManager.InsertLi_DonLetterDetail(DonLetter);
                }
            }

            string message = "Saved successfully.";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            script += Request.Url.AbsoluteUri;
            script += "'; }";
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);




        }

        protected void lbDeleteLetter_Click(object sender, EventArgs e)
        {
            try
            {

                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                DataTable dtLetterTable = (DataTable)ViewState["tblLetter"];
                dtLetterTable.Rows[Convert.ToInt32(linkButton.CommandArgument) - 1].Delete();
                dtLetterTable.AcceptChanges();
                ViewState["LinkClick"] = true;
                AddNewRecordRowToGrid_Letter();

            }
            catch (Exception)
            {


            }
        }

        DataTable dtGetOneShedAmnt;
        string PaymentType;
        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                decimal OneShedTotalAmt = 0.00m;
                for (int i = 0; i < gvwPaymentSchedule.Rows.Count; i++)
                {
                    CheckBox chkRow = (gvwPaymentSchedule.Rows[i].Cells[0].FindControl("chkDonSelect") as CheckBox);

                    if (chkRow.Checked == true)
                    {
                        dtGetOneShedAmnt = Li_DonPaymentManager.GetLi_DonOneShedTotalAmtSheID(int.Parse(gvwPaymentSchedule.Rows[i].Cells[1].Text)).Tables[0];
                        PaymentType = gvwPaymentSchedule.Rows[i].Cells[2].Text;
                    }
                    if (chkRow.Checked == false && PaymentType == (gvwPaymentSchedule.Rows[i].Cells[2].Text).ToString())
                    {
                        decimal unitTotal = decimal.Parse(gvwPaymentSchedule.Rows[i].Cells[3].Text);
                        OneShedTotalAmt += unitTotal;
                    }
                }
                if ((OneShedTotalAmt + decimal.Parse(txtAmount.Text)) > decimal.Parse(dtGetOneShedAmnt.Rows[0]["Amount"].ToString()))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Amount is greater than for this payment');", true);
                    return;
                }

                Li_DonPaymentShedule DonPaySchedule = new Li_DonPaymentShedule();

                DonPaySchedule.PSId = int.Parse(lblShedPaySerial.Text);
                DonPaySchedule.Amount = decimal.Parse(txtAmount.Text);
                DonPaySchedule.StartingDate = DateTime.Parse(txtStartingDate.Text);
                DonPaySchedule.EndingDate = DateTime.Parse(txtEndingDate.Text);
                Li_DonPaymentSheduleManager.UpdateLi_DonPaymentShedule(DonPaySchedule);

                Li_DonPayment donpayment = new Li_DonPayment();
                donpayment.PSId = int.Parse(lblShedPaySerial.Text); //int.Parse(dtCurrentTable.Rows[i]["ShedId"].ToString());
                donpayment.AcName = txtAcountName.Text;
                donpayment.AcName_bn = txtAcountName_bn.Text;
                donpayment.AcMemNo = txtAccountNo.Text;
                donpayment.BankCof = txtBankName.Text;
                donpayment.AcAddress = txtBranchAddress.Text;
                donpayment.ThanaId = int.Parse(ddlThana.SelectedValue);
                donpayment.ContactNo = txtContactNo.Text;
                donpayment.IsBankPay = chkIsBankPay.Checked ? true : false;
                donpayment.AccTypId = int.Parse(ddlAcountType.SelectedValue);
                donpayment.PayTypId = int.Parse(ddlPaymentType.SelectedValue);
                donpayment.TransportID = ddlTransportID.SelectedValue;
                donpayment.IsRecAckNo = false;
                donpayment.AckNo = "";
                donpayment.Remarks = txtRemarks.Text;
                donpayment.CreatedBy = int.Parse(Session["UserID"].ToString());
                donpayment.CreatedDate = DateTime.Now;
                Li_DonPaymentManager.UpdateLi_DonPayment(donpayment);

                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Update Successfully');", true);

                DataTable dtAmntShed = Li_DonPaymentSheduleManager.GetAmntSheduleBy_DonFor(int.Parse(ddlMadSomPer.SelectedValue)).Tables[0];
                if (dtAmntShed.Rows.Count > 0)
                {
                    gvwPaymentSchedule.DataSource = dtAmntShed;
                    gvwPaymentSchedule.DataBind();
                }
                ClearPayInfo();
            }
            catch (Exception)
            {

            }

        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {

                Response.Write("<script>window.open('Mkt_Rpt_DonationLetter.aspx?No= ca-0318','_blank')</script>");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}