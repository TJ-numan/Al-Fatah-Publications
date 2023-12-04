using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using BLL.Classes;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace BLL
{
    public partial class MktCollectionDeposit : System.Web.UI.Page
    {
        DataAccessObject DAO = new DataAccessObject();

        string FormID = "MF007";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    getUserAccess();
               
                    txtMemoDate.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
                    txtDepositedDate.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
                    txtClearanceDate.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
                    LoadLibrary();
                    LoadComboData . LoadBank( ddlBankName);
                    LoadComboData .   LoadTransactionTypes(  ddlDepositeType); 
                    LoadComboData .   LoadDepositFor(ddlDepositFor);
                  
                }

                if (Session["MRNO"]  != null)
                {
                    txtMemoNo.Text = Session["MRNO"].ToString();
                }


                Calender1.StartDate = DateTime.Now.AddMonths(-2);
                Calender2.StartDate = DateTime.Now.AddMonths(-2);
                Calender3.StartDate = DateTime.Now.AddMonths(-2);
                Calender1.EndDate = DateTime.Now;
                Calender2.EndDate = DateTime.Now;
                Calender3.EndDate = DateTime.Now;
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
                    if (Boolean.Parse(dt.Rows[0]["View_"].ToString()) == false)
                    {
                        Response.Redirect("~/MarketingHome.aspx");
                    }
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
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }
        private void LoadLibrary()
        {

            try
            {
                lblAssetList.Visible = false;
                ddlAssetList.Visible = false;

                if (ddlLibraryName.Items.Count > 0)
                {
                    ddlLibraryName.Items.Clear();
                    ddlAssetList.Items.Clear();

                }


                if (ddlDepositFor.SelectedValue == "6")
                {
                    ddlLibraryName.DataSource = Li_Dam_PartyManager.GetAllLi_Dam_Parties();
                    ddlLibraryName.DataTextField = "PartName";
                    ddlLibraryName.DataValueField = "PartyID";
                    ddlLibraryName.DataBind();
                    ddlLibraryName.Items.Insert(0, new ListItem("--select--", "0"));
                    return;

                }

                if (ddlDepositFor.SelectedValue == "7")
                {

                    ddlLibraryName.DataSource = Li_Dam_Oth_PartyManager.GetAllLi_Dam_Oth_Parties();
                    ddlLibraryName.DataTextField = "PartName";
                    ddlLibraryName.DataValueField = "PartyID";
                    ddlLibraryName.DataBind();
                    ddlLibraryName.Items.Insert(0, new ListItem("--select--", "0"));
                    return;
                }



                if (ddlDepositFor.SelectedValue == "8")
                {
                    lblAssetList.Visible = true;
                    ddlAssetList.Visible = true;

                    ddlLibraryName.DataSource = Li_HouseRent_PartyManager.GetAllLi_HouseRent_Parties();
                    ddlLibraryName.DataTextField = "PartName";
                    ddlLibraryName.DataValueField = "PartyID";
                    ddlLibraryName.DataBind();
                    ddlLibraryName.Items.Insert(0, new ListItem("--select--", "0"));
                    LoadComboData.LaodAssetList(ddlAssetList);
                    return;


                }

                List<li_LibraryInformation> li_LibraryInformation = new List<li_LibraryInformation>();
                li_LibraryInformation = li_LibraryInformationManager.GetAll_ComboBox_LibraryInformations();
                ddlLibraryName.DataSource = li_LibraryInformation;
                ddlLibraryName.DataTextField = "LibraryName";
                ddlLibraryName.DataValueField = "LibraryID";
                ddlLibraryName.DataBind();
                ddlLibraryName.Items.Insert(0, new ListItem("--select--", "0"));

            }
            catch (Exception rt)
            {
            }
        }

        
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (ddlLibraryName.SelectedIndex==0)
                {
                     ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please Select a Library!');", true);
            }
            else{
                try
                {
                
                    {
                        Li_Deposit deposit = new Li_Deposit();
                        deposit.Alim =  false;
                        deposit.AmountOfMoney = txtAmount.Text != "" ? decimal.Parse(txtAmount.Text) : 0.0m;
                        deposit.BankAddress = txtBankAddress.Text;
                        deposit.BankCode = ddlBankName.SelectedValue.ToString();
                        deposit.BankSlipNo = txtDDNo.Text;
                        deposit.Boishaki =false;
                        deposit.CauseOfDelete = "";
                        deposit.ClearDate = Convert.ToDateTime(txtClearanceDate.Text);
                        deposit.CreatedBy = int.Parse(Session["UserID"].ToString());
                        deposit.Dele_By = 0;
                        deposit.Deledate = DateTime.Now;
                        deposit.DepositedDate = Convert.ToDateTime(txtDepositedDate.Text);
                        deposit.DepositeTpe = Int32.Parse(ddlDepositeType.SelectedValue.ToString());
                        deposit.LibraryID = ddlLibraryName.SelectedValue.ToString();
                        deposit.MRDate = Convert.ToDateTime(txtMemoDate.Text);
                        deposit.Remark = txtRemarks.Text;
                        deposit.Status_D = 'C';
                        deposit.VrifiedBy = txtVerifiedBy.Text;
                        deposit.Dam_BookSale =  false;
                        deposit.Dam_Other = false;
                        deposit.HouseRent = false;
                        deposit.Others = false;
                        deposit.Comp = ddlCom.SelectedIndex == 0 ? "A" : "Q";
                        deposit.DepositForId = Int32.Parse( ddlDepositFor.SelectedValue);
                        deposit.AssetList = Int32.Parse(ddlDepositFor.SelectedValue) == 8 ? Int32.Parse(ddlAssetList.SelectedValue) : 0;
                        string mrNo = Li_DepositManager.InsertLi_Deposit(deposit);
                        Session["MRNO"] = mrNo;
                   
                    

                        //if (mrNo != string.Empty)
                        //{
                        //    string message = "Saved successfully.";
                        //    string script = "window.onload = function(){ alert('";
                        //    script += message;
                        //    script += "');";
                        //    script += "window.location = '";
                        //    script += Request.Url.AbsoluteUri;
                        //    script += "'; }";
                        //    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",
                        //    script, true);
                        //}



                        txtMemoNo.Text =  Session["MRNO"].ToString() ;
                        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved successfully.');", true);


                        txtAmount.Text  = "0.0";
                        txtBankAddress.Text  = "";
                        txtDDNo.Text = "";
                        ddlLibraryName.Focus();

                    }
                             
                }
                catch (Exception ex)
                {
                    throw ex;
                
                }
            }
        }
        protected void btnUpdate_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("MktCollectionDepositUpdate.aspx");
        }
        
        ReportDocument rd = new ReportDocument();
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddlDepositFor.SelectedValue == "8")
                {
                    rd.Load(Server.MapPath(@"~/Reports/HRD/rptPrintMoneyReceipt_AssetList.rpt"));
                }
                else
                {
                    if (ddlCom.SelectedValue == "0")
                    {
                        rd.Load(Server.MapPath(@"~/Reports/MKT/rptPrintMoneyReceiptR2.rpt"));
                    }
                    else
                    {
                        rd.Load(Server.MapPath(@"~/Reports/MKT/rptPrintMoneyReceipt_MaktabatulFatah.rpt"));
                    }
                }
                //rd.SetDatabaseLogon(DAO.UserID, DAO.Password, DAO.ServerName, DAO.DatabaseName);
                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@MRno", txtMemoNo.Text);
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Deposit Money Report");
            }
            catch (Exception)
            {

            }
        }
        protected void ddlDepositFor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadLibrary();
            }
            catch (Exception)
            {

            }
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            try
            {
                rd.Dispose();
            }
            catch (Exception)
            {


            }
        }
        
    }
}