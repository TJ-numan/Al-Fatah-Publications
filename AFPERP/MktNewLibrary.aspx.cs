using System;
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using Common.Marketing;
using BLL.Classes;

namespace BLL
{
    public partial class MktNewLibrary : System.Web.UI.Page
    {
        DataAccessObject DAO = new DataAccessObject();
        string FormID = "MF001";
        public string LibraryIDforReport;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    textSquirefoot.Enabled = chkGodown.Checked;
                    GetAllOrganization();
                    // LoadOrganizationInformation_ForGVW();
                    LoadTerritory();
                    getUserAccess();
                    GetAllDistrict();
                    AddDefaultFirstRecord();
                    AddDefaultFirstOrganization();

                    AddDefaultFirstBank();


                    GetAllLi_TransportInfo();
                    LoadLibraryInformation_ForGVW();
                    //LoadSelectedOrganizationItems();
                    gvwOrganization.Visible = true;
                    btnLibraryUpdate.Enabled = true;
                }
            }
            catch (Exception)
            {
            }
        }
        protected void chkGodown_CheckedChanged(object sender, EventArgs e)
        {// Enable or disable textSquirefoot based on the checked state of chkGodown
            if (chkGodown.Checked)
            {
                textSquirefoot.Enabled = true;
            }
            else
            {
                textSquirefoot.Text = string.Empty;
                textSquirefoot.Enabled = false;
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
                        btnLibrarySave.Enabled = true;
                    }
                    else
                    {
                        btnLibrarySave.Enabled = false;
                    }
                    if (Boolean.Parse(dt.Rows[0]["Update_"].ToString()) == true)
                    {
                        btnLibraryUpdate.Enabled = true;
                    }
                    else
                    {
                        btnLibraryUpdate.Enabled = false;
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
                ddlDristrict.Items.Insert(0, new ListItem("--Select District--", "0"));
            }
            catch (Exception)
            {
            }
        }
        private void GetAllOrganization()
        {
            try
            {
                ddlOrganization.DataSource = li_OrganizationManager.GetAll_Organization();
                ddlOrganization.DataTextField = "Organization";
                ddlOrganization.DataValueField = "ID";
                ddlOrganization.DataBind();
                ddlOrganization.Items.Insert(0, new ListItem("--Select Organization that you also member of--", "0"));
            }
            catch (Exception)
            {
            }
        }
        private void LoadSelectedOrganizationItems()
        {
            // Check if there are selected items stored in session
            if (Session["SelectedOrganizationItems"] != null)
            {
                List<DataSet> selectedItems = (List<DataSet>)Session["SelectedOrganizationItems"];
                gvwOrganization.DataSource = selectedItems;
                gvwOrganization.DataBind();
            }
        }
        protected void ddlOrganization_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AddNewRecordRowToGridforOrganization();
                // LoadOrganizationInformation_ForGVW();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "RefreshGridView", "__doPostBack('" + ddlOrganization.ID + "', '');", true);
            }
            catch (Exception)
            {
            }
        }
        protected void ddlDristrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlThana.DataSource = li_ThanaManager.Get_ThanaByDistrictID(int.Parse(ddlDristrict.SelectedValue));
                ddlThana.DataTextField = "ThanaName";
                ddlThana.DataValueField = "ThanaID";
                ddlThana.DataBind();
            }
            catch (Exception)
            {
            }
        }
        private void LoadTerritory()
        {
            try
            {
                ddlTerritory.DataSource = Li_TeritoryManager.GetAllLi_Teritories();
                ddlTerritory.DataTextField = "TeritoryName";
                ddlTerritory.DataValueField = "TeritoryCode";
                ddlTerritory.DataBind();
                ddlTerritory.Items.Insert(0, new ListItem("-Select-", "0"));
            }
            catch (Exception)
            {
            }
        }
        private void GetAllLi_TransportInfo()
        {
            try
            {
                ddlTransportMain.DataSource = Li_TransportInfoManager.GetAllLi_TransportInfos();
                ddlTransportMain.DataTextField = "TransportName";
                ddlTransportMain.DataValueField = "TransportID";
                ddlTransportMain.DataBind();
                ddlTransportMain.Items.Insert(0, new ListItem("--Select Primary Transport--", "0"));
                ddlTransportAlter.DataSource = Li_TransportInfoManager.GetAllLi_TransportInfos();
                ddlTransportAlter.DataTextField = "TransportName";
                ddlTransportAlter.DataValueField = "TransportID";
                ddlTransportAlter.DataBind();
                ddlTransportAlter.Items.Insert(0, new ListItem("--Select Alternative Transport --", "0"));
            }
            catch (Exception)
            {
            }
        }
        protected void btn_addanother(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AssociateName.Text) || string.IsNullOrEmpty(AssociateResponisbility.Text) || string.IsNullOrEmpty(AssociatePhone.Text))
            {
                string message = "Associate Fields can not be empty.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                // Remove the following line to prevent page reload
                // script += "window.location = '";
                // script += Request.Url.AbsoluteUri;
                // script += "'; }";
                script += "};";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",
                script, true);
            }
            else
            {
                AddNewRecordRowToGrid();
                AssociateResponisbility.Text = string.Empty;
                AssociateName.Text = string.Empty;
                AssociatePhone.Text = string.Empty;
            }
        }
        protected void btn_AddBank(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(BankName.Text) || string.IsNullOrEmpty(BankBranch.Text) || string.IsNullOrEmpty(BankAccount.Text) || string.IsNullOrEmpty(BankType.Text))
            {

                string message = "Bank Information Fields can not be empty.";

                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                // Remove the following line to prevent page reload
                // script += "window.location = '";
                // script += Request.Url.AbsoluteUri;
                // script += "'; }";
                script += "};";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",
                script, true);

            }
            else
            {
                AddNewRecordRowToGridforBank();
                BankName.Text = string.Empty;
                BankBranch.Text = string.Empty;
                BankAccount.Text = string.Empty;
                BankType.Text = string.Empty;
            }
        }
        protected void lbDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLibraryID.Text))
            {
                try
                {
                    LinkButton linkButton = new LinkButton();
                    linkButton = (LinkButton)sender;
                    DataTable dtCurrentTable = (DataTable)ViewState["tblAssociate"];
                    li_AssociateManager.DeleteAssociateFromDatabase(txtLibraryID.Text.ToString(), Convert.ToInt32(linkButton.CommandArgument));
                    gvwAssociate.DataSource = li_AssociateManager.GetALLLibraryWiseAssociateInformation(txtLibraryID.Text.ToString()).Tables[0];
                    gvwAssociate.DataBind();
                }
                catch (Exception)
                {
                }
            }
            else
            {
                try
                {
                    LinkButton linkButton = new LinkButton();
                    linkButton = (LinkButton)sender;
                    DataTable dtCurrentTable = (DataTable)ViewState["tblAssociate"];
                    dtCurrentTable.Rows[Convert.ToInt32(linkButton.CommandArgument) - 1].Delete();
                    dtCurrentTable.AcceptChanges();
                    ViewState["LinkClick"] = true;
                    gvwAssociate.DataSource = dtCurrentTable;
                    gvwAssociate.DataBind();
                }
                catch (Exception)
                {
                }
            }
        }
        protected void lbDelete_ClickOrganization(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLibraryID.Text))
            {
                try
                {
                    LinkButton linkButton = new LinkButton();
                    linkButton = (LinkButton)sender;
                    DataTable dtCurrentTable = (DataTable)ViewState["tblOrganization"];
                    li_OrganizationManager.DeleteOrganizationFromDatabase(txtLibraryID.Text.ToString(), Convert.ToInt32(linkButton.CommandArgument));
                    gvwOrganization.DataSource = li_OrganizationManager.GetALLLibraryWiseOrganizationInformation(txtLibraryID.Text.ToString()).Tables[0];
                    gvwOrganization.DataBind();
                }
                catch (Exception)
                {
                }
            }
            else
            {
                try
                {
                    LinkButton linkButton = new LinkButton();
                    linkButton = (LinkButton)sender;
                    DataTable dtCurrentTable = (DataTable)ViewState["tblOrganization"];
                    dtCurrentTable.Rows[Convert.ToInt32(linkButton.CommandArgument) - 1].Delete();
                    dtCurrentTable.AcceptChanges();
                    ViewState["LinkClickorg"] = true;
                    AddNewRecordRowToGridforOrganization();
                    gvwOrganization.DataSource = dtCurrentTable;
                    gvwOrganization.DataBind();
                }
                catch (Exception)
                {
                }
            }
        }
        protected void lbDelete_ClickBank(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLibraryID.Text))
            {
                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                DataTable dtCurrentTable = (DataTable)ViewState["tblBank"];
                li_LibraryWiseBankManager.DeleteBankFromDatabase(txtLibraryID.Text.ToString(), Convert.ToInt32(linkButton.CommandArgument));
                grvwBank.DataSource = li_LibraryWiseBankManager.GetALLLibraryWiseBankInformation(txtLibraryID.Text.ToString()).Tables[0];
                grvwBank.DataBind();
            }
            else
            {
                try
                {
                    LinkButton linkButton = new LinkButton();
                    linkButton = (LinkButton)sender;
                    DataTable dtCurrentTable = (DataTable)ViewState["tblBank"];
                    dtCurrentTable.Rows[Convert.ToInt32(linkButton.CommandArgument) - 1].Delete();
                    dtCurrentTable.AcceptChanges();
                    ViewState["LinkClickbnk"] = true;
                    grvwBank.DataSource = dtCurrentTable;
                    grvwBank.DataBind();
                }
                catch (Exception)
                {
                }
            }
        }
        protected void btnLibrarySave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtNID.Text))
            {
                string message = "NID Fields can not be empty.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                // Remove the following line to prevent page reload
                // script += "window.location = '";
                // script += Request.Url.AbsoluteUri;
                // script += "'; }";
                script += "};";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "NID Warning", script, true);


            }
            else
            {
                try
                {
                    li_LibraryInformation Library = new li_LibraryInformation();


                    Library.LibraryName = txtLibraryName.Text;
                    Library.Lib_Bn = txtLibraryNameB.Text;
                    Library.LibraryAddress = txtLibraryAddress.Text;
                    Library.AddressforGettingBook = txtAddressforGettingBook.Text;
                    Library.Sustainability = textSustainability.Text;
                    Library.ShopNumber = txtshopNumber.Text;
                    Library.BuildingName = textBuldingName.Text;
                    Library.HoldingNo = textholdingNo.Text;
                    Library.MarketName = txtMarketName.Text;
                    Library.PostOffice = txtPostOffice.Text;
                    Library.SquireFoot = textSquirefoot.Text;
                    Library.LibAdd_Bn = txtLibraryAddressB.Text;
                    Library.CashParty = false;
                    Library.Type = ddlType.SelectedIndex;
                    Library.Category = ddlCategory.Text;
                    Library.DeliveryType = DeliveryType.Text;
                    Library.Ownership = Ownership.Text;
                    Library.Partnership = txtPartnership.Text;
                    Library.ResponsiblePersonName = txtresponsiblePersonName.Text;
                    Library.RpPhoneNo = txtRpPhoneNo.Text;
                    Library.Telephone = txtPhoneNo.Text;
                    Library.EmailID = txtEmail.Text;
                    Library.RegionID = 0;
                    Library.AreaID = 0;
                    Library.TeritoryID = ddlTerritory.SelectedValue.ToString();
                    Library.LibraryOwnerID = txtLibraryOwnerName.Text;
                    Library.OwnerPermanentAddress = txtLibraryOwnerPermanentAddress.Text;
                    Library.OwnerPresentAddress = txtLibraryOwnerPresentAddress.Text;
                    Library.OwnerEducation = txtEducationalQualification.Text;
                    Library.SalesPersonID = "";
                    Library.DistrictID = Int32.Parse(ddlDristrict.SelectedValue.ToString());
                    Library.ThanaID = Int32.Parse(ddlThana.SelectedValue.ToString());
                    Library.TransportID = ddlTransportMain.Text;
                    Library.TransportID2 = ddlTransportAlter.Text;
                    Library.CreatedDate = DateTime.Now;
                    Library.AddedBy = int.Parse(Session["UserID"].ToString());
                    Library.ModifiedBy = int.Parse(Session["UserID"].ToString());
                    Library.ModefiedDate = DateTime.Now;
                    Library.ShortAddress = txtShortAddress.Text;
                    Library.ShAdd_Bn = txtShortAddressB.Text;
                    Library.IsQawmi = chkIsQawmi.Checked;
                    Library.IsBoth = chkIsBoth.Checked;
                    Library.IsSMS = chkIsSMS.Checked;
                    Library.IsOwned = rbtnOwnShop.Checked;
                    Library.IsGodown = chkGodown.Checked;
                    Library.Code  = txtUniqueCode.Text;
                    Library.TradeLicense = txtTradeLicense.Text;

                    Library.NID = txtNID.Text;
                    Library.BapusCard = txtBapusCardNo.Text;
                    Library.AmountofMoney = AmountofMoney.Text;
                    Library.MoneyInWord = MoneyInWord.Text;
                    Library.WayofPayment = WayofPayment.Text;
                    try
                    {
                        string libraryID = li_LibraryInformationManager.Insert_LibraryInformation(Library);
                        txtLibraryID.Text = libraryID;
                        if (libraryID != string.Empty)
                        {
                            //// saving organization               
                            DataTable dtCurrentTablefororg = (DataTable)ViewState["tblOrganization"];

                            if (dtCurrentTablefororg.Rows.Count > 0)
                            {
                                for (int i = 0; i < dtCurrentTablefororg.Rows.Count; i++)
                                {
                                    li_LibraryWiseOrganizationInformation LibraryWiseOrganization = new li_LibraryWiseOrganizationInformation();
                                    LibraryWiseOrganization.LibraryID = libraryID;
                                    LibraryWiseOrganization.ID = Convert.ToInt32(dtCurrentTablefororg.Rows[i]["ID"]);
                                    li_OrganizationManager.InsertOrganizationInformation(LibraryWiseOrganization);
                                }
                            }
                            ///// saving Associate Person
                            DataTable dtCurrentTableas = (DataTable)ViewState["tblAssociate"];

                            if (dtCurrentTableas.Rows.Count > 0)
                            {
                                for (int j = 0; j < dtCurrentTableas.Rows.Count; j++)
                                {
                                    li_LibraryWiseAssociate li_LibraryWiseAssociate = new li_LibraryWiseAssociate();
                                    li_LibraryWiseAssociate.LibraryID = libraryID;
                                    li_LibraryWiseAssociate.NameAssociate = dtCurrentTableas.Rows[j]["NameAssociate"].ToString();
                                    li_LibraryWiseAssociate.ResponsiblityAssociate = dtCurrentTableas.Rows[j]["ResponsiblityAssociate"].ToString();
                                    li_LibraryWiseAssociate.PhoneAssociate = dtCurrentTableas.Rows[j]["PhoneAssociate"].ToString();
                                    li_AssociateManager.InsertAssociate(li_LibraryWiseAssociate);
                                }
                            }
                            //// saving bank information
                            DataTable dtCurrentTableasforbank = (DataTable)ViewState["tblBank"];
                            if (dtCurrentTableasforbank.Rows.Count > 0)
                            {
                                for (int k = 0; k < dtCurrentTableasforbank.Rows.Count; k++)
                                {
                                    li_LibraryWiseBankInformation li_LibraryWiseBankInformation = new li_LibraryWiseBankInformation();
                                    li_LibraryWiseBankInformation.LibraryID = libraryID;
                                    li_LibraryWiseBankInformation.BankName = dtCurrentTableasforbank.Rows[k]["BankName"].ToString();
                                    li_LibraryWiseBankInformation.BankBranch = dtCurrentTableasforbank.Rows[k]["BankBranch"].ToString();
                                    li_LibraryWiseBankInformation.BankAccount = dtCurrentTableasforbank.Rows[k]["BankAccount"].ToString();
                                    li_LibraryWiseBankInformation.BankType = dtCurrentTableasforbank.Rows[k]["BankType"].ToString();
                                    li_LibraryWiseBankManager.InsertBank(li_LibraryWiseBankInformation);
                                }
                            }
                            string message = "Library Information Saved Successfully.";
                            string script = "window.onload = function(){ alert('";
                            script += message;
                            script += "');";
                            script += "window.location = '";
                            script += Request.Url.AbsoluteUri;
                            script += "'; }";
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",
                            script, true);
                            //LibraryWiseOrganization.LibraryID = libraryID;
                            //LibraryWiseOrganization.ID = int.Parse(ddlOrganization.SelectedValue);
                        }
                    }
                    catch (Exception)
                    {
                    }
                    LoadLibraryInformation();
                    ClearLibraryData();
                }
                catch (Exception)
                {
                }
            }
        }


        protected void btnLibraryUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                li_LibraryInformation Library = new li_LibraryInformation();
                Library.LibraryID = txtLibraryID.Text;
                Library.LibraryName = txtLibraryName.Text;
                Library.Lib_Bn = txtLibraryNameB.Text;
                Library.LibraryAddress = txtLibraryAddress.Text;
                Library.AddressforGettingBook = txtAddressforGettingBook.Text;
                Library.Sustainability = textSustainability.Text;
                Library.ShopNumber = txtshopNumber.Text;
                Library.BuildingName = textBuldingName.Text;
                Library.HoldingNo = textholdingNo.Text;
                Library.MarketName = txtMarketName.Text;
                Library.PostOffice = txtPostOffice.Text;
                Library.SquireFoot = textSquirefoot.Text;
                Library.LibAdd_Bn = txtLibraryAddressB.Text;
                Library.CashParty = false;
                Library.Type = ddlType.SelectedIndex;
                Library.Category = ddlCategory.Text;
                Library.DeliveryType = DeliveryType.Text;
                Library.Ownership = Ownership.Text;
                Library.Partnership = txtPartnership.Text;
                Library.ResponsiblePersonName = txtresponsiblePersonName.Text;
                Library.RpPhoneNo = txtRpPhoneNo.Text;
                Library.Telephone = txtPhoneNo.Text;
                Library.EmailID = txtEmail.Text;
                Library.RegionID = 0;
                Library.AreaID = 0;
                Library.TeritoryID = ddlTerritory.SelectedValue.ToString();
                Library.LibraryOwnerID = txtLibraryOwnerName.Text;
                Library.OwnerPermanentAddress = txtLibraryOwnerPermanentAddress.Text;
                Library.OwnerPresentAddress = txtLibraryOwnerPresentAddress.Text;
                Library.OwnerEducation = txtEducationalQualification.Text;
                Library.SalesPersonID = "";
                Library.DistrictID = Int32.Parse(ddlDristrict.SelectedValue.ToString());
                Library.ThanaID = Int32.Parse(ddlThana.SelectedValue.ToString());
                Library.TransportID = ddlTransportMain.Text;
                Library.TransportID2 = ddlTransportAlter.Text;
                Library.CreatedDate = DateTime.Now;
                Library.AddedBy = int.Parse(Session["UserID"].ToString());
                Library.ModifiedBy = int.Parse(Session["UserID"].ToString());
                Library.ModefiedDate = DateTime.Now;
                Library.ShortAddress = txtShortAddress.Text;
                Library.ShAdd_Bn = txtShortAddressB.Text;
                Library.IsQawmi = chkIsQawmi.Checked;
                Library.IsBoth = chkIsBoth.Checked;
                Library.IsSMS = chkIsSMS.Checked;
                Library.IsOwned = rbtnOwnShop.Checked;
                Library.IsGodown = chkGodown.Checked;
                Library.Code = txtUniqueCode.Text;
                Library.TradeLicense = txtTradeLicense.Text;
                Library.NID = txtNID.Text;
                Library.BapusCard = txtBapusCardNo.Text;
                Library.AmountofMoney = AmountofMoney.Text;
                Library.MoneyInWord = MoneyInWord.Text;
                Library.WayofPayment = WayofPayment.Text;
                li_LibraryInformationManager.Update_LibraryInformation(Library);
                DataTable dtCurrentTablefororg = (DataTable)ViewState["tblOrganization"];
                if (dtCurrentTablefororg.Rows[0]["ID"] != DBNull.Value)
                {
                    if (dtCurrentTablefororg.Rows.Count > 0)
                    {

                        for (int i = 0; i < dtCurrentTablefororg.Rows.Count; i++)
                        {

                            li_LibraryWiseOrganizationInformation LibraryWiseOrganization = new li_LibraryWiseOrganizationInformation();
                            LibraryWiseOrganization.LibraryID = txtLibraryID.Text;
                            LibraryWiseOrganization.ID = Convert.ToInt32(dtCurrentTablefororg.Rows[i]["ID"]);

                            if (LibraryWiseOrganization.ID != 0)
                            {
                                li_OrganizationManager.InsertOrganizationInformation(LibraryWiseOrganization);
                            }
                        }
                    }
                }
                ///// updating Associate Person
                DataTable dtCurrentTableas = (DataTable)ViewState["tblAssociate"];
                if (dtCurrentTableas.Rows.Count > 0)
                {
                    for (int j = 0; j < dtCurrentTableas.Rows.Count; j++)
                    {

                        li_LibraryWiseAssociate li_LibraryWiseAssociate = new li_LibraryWiseAssociate();
                        li_LibraryWiseAssociate.LibraryID = txtLibraryID.Text;
                        li_LibraryWiseAssociate.NameAssociate = dtCurrentTableas.Rows[j]["NameAssociate"].ToString();
                        li_LibraryWiseAssociate.ResponsiblityAssociate = dtCurrentTableas.Rows[j]["ResponsiblityAssociate"].ToString();
                        li_LibraryWiseAssociate.PhoneAssociate = dtCurrentTableas.Rows[j]["PhoneAssociate"].ToString();

                        if (!string.IsNullOrWhiteSpace(li_LibraryWiseAssociate.NameAssociate) || !string.IsNullOrWhiteSpace(li_LibraryWiseAssociate.ResponsiblityAssociate) || !string.IsNullOrWhiteSpace(li_LibraryWiseAssociate.PhoneAssociate))
                        {
                            li_AssociateManager.InsertAssociate(li_LibraryWiseAssociate);
                        }
                    }
                }
                //// updating bank information
                DataTable dtCurrentTableasforbank = (DataTable)ViewState["tblBank"];

                if (dtCurrentTableasforbank.Rows.Count > 0)
                {
                    for (int k = 0; k < dtCurrentTableasforbank.Rows.Count; k++)
                    {

                        li_LibraryWiseBankInformation li_LibraryWiseBankInformation = new li_LibraryWiseBankInformation();
                        li_LibraryWiseBankInformation.LibraryID = txtLibraryID.Text;

                        li_LibraryWiseBankInformation.BankName = dtCurrentTableasforbank.Rows[k]["BankName"].ToString();
                        li_LibraryWiseBankInformation.BankBranch = dtCurrentTableasforbank.Rows[k]["BankBranch"].ToString();
                        li_LibraryWiseBankInformation.BankAccount = dtCurrentTableasforbank.Rows[k]["BankAccount"].ToString();
                        li_LibraryWiseBankInformation.BankType = dtCurrentTableasforbank.Rows[k]["BankType"].ToString();
                        if (!string.IsNullOrWhiteSpace(li_LibraryWiseBankInformation.BankName) || !string.IsNullOrWhiteSpace(li_LibraryWiseBankInformation.BankBranch) || !string.IsNullOrWhiteSpace(li_LibraryWiseBankInformation.BankAccount) || !string.IsNullOrWhiteSpace(li_LibraryWiseBankInformation.BankType))
                        {
                            li_LibraryWiseBankManager.InsertBank(li_LibraryWiseBankInformation);
                        }


                    }
                }
                string message = "Library Information Update Successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += Request.Url.AbsoluteUri;
                script += "'; }";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",
                script, true);
                LoadLibraryInformation();
                //ClearLibraryData();
                //btnLibraryUpdate.Enabled = false;  
            }
            catch (Exception)
            {
            }
        }

        private void ClearLibraryData()
        {
            txtLibraryName.Text = string.Empty;
            txtLibraryAddress.Text = string.Empty;
            txtShortAddress.Text = string.Empty;
            txtLibraryNameB.Text = string.Empty;
            txtLibraryAddressB.Text = string.Empty;
            txtShortAddressB.Text = string.Empty;
            txtPhoneNo.Text = string.Empty;
            txtUniqueCode.Text = string.Empty;
            txtTradeLicense.Text = string.Empty;
            txtNID.Text = string.Empty;
            txtBapusCardNo.Text = string.Empty;
            ddlCategory.SelectedIndex = -1;
            DeliveryType.SelectedIndex = -1;
            ddlType.SelectedIndex = -1;
            ddlThana.SelectedIndex = 0;
            ddlDristrict.SelectedIndex = 0;
            ddlOrganization.SelectedIndex = 0;
            ddlTransportMain.SelectedIndex = 0;
            ddlTransportAlter.SelectedIndex = 0;
        }
        private void LoadLibraryInformation()
        {
            try
            {
                List<LibraryInformation> informations = li_LibraryInformationManager.GetALLLibraryInformation();
            }
            catch (Exception ex)
            {
            }
        }
        public int pageNumber;
        public int pageSize = 10;
        public int totalPages;
        public int count;
        protected void btnPrevious_Click(object sender, EventArgs e)
        {

            int count = Convert.ToInt32(pagetext.Text);
            int pageSize = Convert.ToInt32(idPageSize.SelectedValue);

            if (count >= 0)
            {
                pageNumber--;
                count--;
                idPageSize.SelectedValue = pageSize.ToString();
                pagetext.Text = count.ToString();
                lblPageNo.Text = "Page " + count + " of " + totalPages;



                LoadLibraryInformation_ForGVW();
            }
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {

            count = Convert.ToInt32(pagetext.Text);
            int pageSize = Convert.ToInt32(idPageSize.SelectedValue);

            if (count >= 0)
            {
                count++;
                idPageSize.SelectedValue = pageSize.ToString();
                pagetext.Text = count.ToString();
                pageNumber++;
                lblPageNo.Text = "Page " + count + " of " + totalPages;


                LoadLibraryInformation_ForGVW();
            }
        }
        private void LoadLibraryInformation_ForGVW()
        {
            try
            {

                string LibraryName = txtSearchLibraryName.Text;
                string LibID = txtLibraryID.Text;

                var at = Li_LibraryInformationManager.GetALLLibraryInformation(LibraryName, LibID).Tables[0];


                pageSize = Convert.ToInt32(idPageSize.Text);

                int totalElements = at.Rows.Count;
                count = Convert.ToInt32(pagetext.Text);
                totalPages = (int)Math.Ceiling((double)totalElements / pageSize);


                if (count == null || count == 0)
                {
                    count = 1;
                    pagetext.Text = count.ToString();
                }
                else
                {
                    lblPageNo.Text = "Page " + count + " of " + totalPages;


                }


                lblTotalData.Text = "Total Data: " + totalElements;

                var paginatedData = at.AsEnumerable()
                    .Skip((count - 1) * pageSize)
                    .Take(pageSize)
                    .Select((dt, index) => new
                    {
                        sl = index + 1 + (count - 1) * pageSize,
                        Edit = dt.Field<string>("Edit") == null ? "" : dt.Field<string>("Edit"),
                        LibraryName = dt.Field<string>("LibraryName") == null ? "NameNotFound" : dt.Field<string>("LibraryName"),
                        ShortAddress = dt.Field<string>("ShortAddress") == null ? "" : dt.Field<string>("ShortAddress"),
                        LibraryAddress = dt.Field<string>("LibraryAddress") == null ? "" : dt.Field<string>("LibraryAddress"),
                        ShopNumber = dt.Field<string>("ShopNumber") == null ? "" : dt.Field<string>("ShopNumber"),
                        NID = dt.Field<string>("NID") == null ? "" : dt.Field<string>("NID"),
                        Telephone = dt.Field<string>("Telephone") == null ? "" : dt.Field<string>("Telephone"),
                        RegionMainName = dt.Field<string>("RegionMainName") == null ? "" : dt.Field<string>("RegionMainName"),
                        RegionName = dt.Field<string>("RegionName") == null ? "" : dt.Field<string>("RegionName"),
                        DivName = dt.Field<string>("DivName") == null ? "" : dt.Field<string>("DivName"),
                        ZonName = dt.Field<string>("ZonName") == null ? "" : dt.Field<string>("ZonName"),
                        TeritoryName = dt.Field<string>("TeritoryName") == null ? "" : dt.Field<string>("TeritoryName"),
                        DistrictName = dt.Field<string>("DistrictName") == null ? "" : dt.Field<string>("DistrictName"),
                        ThanaName = dt.Field<string>("ThanaName") == null ? "" : dt.Field<string>("ThanaName"),


                    })
                    .ToList();


                gvwLibraryInformation.DataSource = paginatedData;
                gvwLibraryInformation.DataBind();


            }
            catch (Exception ex)
            {

            }
        }
        protected void pageSizeChange(object sender, EventArgs e)
        {

            pageSize = Convert.ToInt32(idPageSize.Text);
            LoadLibraryInformation_ForGVW();
        }



        private void LoadLibraryInformation_ForBankGVW(string LibID)
        {
            try
            {

                grvwBank.DataSource = li_LibraryWiseBankManager.GetALLLibraryWiseBankInformation(LibID).Tables[0];
                grvwBank.DataBind();


            }
            catch (Exception ex)
            {

            }
        }

        private void LoadLibraryInformation_ForAssociateGVW(string LibID)
        {
            try
            {
                gvwAssociate.DataSource = li_AssociateManager.GetALLLibraryWiseAssociateInformation(LibID).Tables[0];
                gvwAssociate.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        private void LoadLibraryInformation_ForORganizationGVW(string LibID)
        {
            try
            {
                gvwOrganization.DataSource = li_OrganizationManager.GetALLLibraryWiseOrganizationInformation(LibID).Tables[0];
                gvwOrganization.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        //private void LoadOrganizationInformation_ForGVW()
        //{

        //    try
        //    {

        //    string selectedOrganization = ddlOrganization.SelectedValue;
        //    gvwOrganization.DataSource = li_OrganizationManager.GetALLOrganizationInformation(int.Parse(selectedOrganization));
        //    gvwOrganization.DataBind();
        //    }
        //    catch (Exception ex)
        //    {

        //    }


        //    //List<DataSet> selectedItems;

        //    //selectedItems = (List<DataSet>)Session["SelectedOrganizationItems"];


        //    //DataSet newItem = li_OrganizationManager.GetALLOrganizationInformation(int.Parse(selectedOrganization));


        //    //selectedItems.Add(newItem);


        //    //Session["SelectedOrganizationItems"] = selectedItems;


        //    //gvwOrganization.DataBind();

        //    //// Clear the selection in the DropDownList (if desired)
        //    ////ddlOrganization.SelectedIndex = -1;
        //}



        private void AddDefaultFirstRecord()
        {
            bool fromLinkButton = false;
            int result = 0;
            //creating dataTable   
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "tblAssociate";
            dt.Columns.Add("Serial", typeof(string));
            dt.Columns.Add("NameAssociate", typeof(string));
            dt.Columns.Add("ResponsiblityAssociate", typeof(string));
            dt.Columns.Add("PhoneAssociate", typeof(string));

            dr = dt.NewRow();
            dt.Rows.Add(dr);
            //saving databale into viewstate   
            ViewState["tblAssociate"] = dt;
            //bind Gridview  
            gvwAssociate.DataSource = dt;
            gvwAssociate.DataBind();
            ViewState["LinkClick"] = fromLinkButton;
            Session["ResultMemo"] = result;
        }
        private void AddNewRecordRowToGrid()
        {
            // check view state is not null  
            if (ViewState["tblAssociate"] != null)
            {
                // get datatable from view state
                DataTable dtCurrentTable = (DataTable)ViewState["tblAssociate"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count == 0)
                {
                    AddDefaultFirstRecord();
                }
                else
                {
                    // Check for duplicate data
                    bool isDuplicate = false;
                    foreach (DataRow row in dtCurrentTable.Rows)
                    {
                        if (row["NameAssociate"].ToString() == AssociateName.Text &&

                            row["PhoneAssociate"].ToString() == AssociatePhone.Text)
                        {
                            isDuplicate = true;
                            //break;
                        }
                    }

                    if (!isDuplicate)
                    {
                        // New row for data table
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["Serial"] = dtCurrentTable.Rows.Count + 1;
                        drCurrentRow["NameAssociate"] = AssociateName.Text;
                        drCurrentRow["ResponsiblityAssociate"] = AssociateResponisbility.Text;
                        drCurrentRow["PhoneAssociate"] = AssociatePhone.Text;

                        // Remove initial blank row  
                        if (dtCurrentTable.Rows[0][0].ToString() == "")
                        {
                            drCurrentRow["Serial"] = dtCurrentTable.Rows.Count;
                            dtCurrentTable.Rows[0].Delete();
                            dtCurrentTable.AcceptChanges();
                        }

                        // Add created Rows into dataTable  
                        dtCurrentTable.Rows.Add(drCurrentRow);

                        // Save DataTable into view state after creating each row  
                        ViewState["tblAssociate"] = dtCurrentTable;
                        // Bind Gridview with latest Row  
                        gvwAssociate.DataSource = dtCurrentTable;
                        gvwAssociate.DataBind();
                    }
                    else
                    {


                        string message = "You can not add duplicate data";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "');";
                        // Remove the following line to prevent page reload
                        // script += "window.location = '";
                        // script += Request.Url.AbsoluteUri;
                        // script += "'; }";
                        script += "};";
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",
                        script, true);

                    }
                }
            }
        }


        private void AddDefaultFirstOrganization()
        {
            bool fromLinkButtonorg = false;
            int resultorg = 0;
            //creating dataTable   
            DataTable dtorg = new DataTable();
            DataRow drorg;
            dtorg.TableName = "tblOrganization";
            dtorg.Columns.Add("Serialorg", typeof(string));
            dtorg.Columns.Add("Organization", typeof(string));
            dtorg.Columns.Add("ID", typeof(int));

            drorg = dtorg.NewRow();
            dtorg.Rows.Add(drorg);
            //saving databale into viewstate   
            ViewState["tblOrganization"] = dtorg;
            //bind Gridview  
            gvwOrganization.DataSource = dtorg;
            gvwOrganization.DataBind();
            ViewState["LinkClickorg"] = fromLinkButtonorg;
            Session["ResultMemoorg"] = resultorg;
        }
        private void AddNewRecordRowToGridforOrganization()
        {
            // check view state is not null  
            if (ViewState["tblOrganization"] != null)
            {
                //get datatable from view state

                DataTable dtCurrentTableorg = (DataTable)ViewState["tblOrganization"];
                DataRow drCurrentRoworg = null;


                if (dtCurrentTableorg.Rows.Count == 0)
                {
                    AddDefaultFirstOrganization();
                }
                else
                {
                    if ((bool)ViewState["LinkClickorg"] == true)
                    {


                        for (int i = 0; i < dtCurrentTableorg.Rows.Count; i++)
                        {
                            dtCurrentTableorg.Rows[i][0] = i + 1;
                            dtCurrentTableorg.AcceptChanges();
                        }

                        ViewState["LinkClickorg"] = false;
                    }
                    else
                    {
                        bool sisDuplicate = false;
                        foreach (DataRow row in dtCurrentTableorg.Rows)
                        {
                            if (row["Organization"].ToString() == ddlOrganization.SelectedItem.Text)
                            {
                                sisDuplicate = true;
                                break;
                            }
                        }

                        if (!sisDuplicate)
                        {
                            for (int i = 1; i <= dtCurrentTableorg.Rows.Count; i++)
                            {
                                //add each row into data table  
                                drCurrentRoworg = dtCurrentTableorg.NewRow();
                                drCurrentRoworg["Serialorg"] = dtCurrentTableorg.Rows.Count + 1;
                                drCurrentRoworg["Organization"] = ddlOrganization.SelectedItem.Text;
                                drCurrentRoworg["ID"] = int.Parse(ddlOrganization.SelectedValue);



                            }


                            // New row for data table

                            //drCurrentRoworg["Organization"] = ddlOrganization.SelectedItem.Text;
                            //drCurrentRoworg["ID"] = int.Parse(ddlOrganization.SelectedValue);




                            //Remove initial blank row  
                            if (dtCurrentTableorg.Rows[0][0].ToString() == "")
                            {
                                drCurrentRoworg["Serialorg"] = dtCurrentTableorg.Rows.Count;
                                dtCurrentTableorg.Rows[0].Delete();
                                dtCurrentTableorg.AcceptChanges();

                            }

                            //add created Rows into dataTable  
                            dtCurrentTableorg.Rows.Add(drCurrentRoworg);

                            ViewState["tblOrganization"] = dtCurrentTableorg;
                            //Bind Gridview with latest Row  
                            ddlOrganization.SelectedIndex = 0;
                            gvwOrganization.DataSource = dtCurrentTableorg;
                            gvwOrganization.DataBind();

                        }
                        else
                        {


                            //Save Data table into view state after creating each row  

                            string message = "You can not add duplicate organization name";
                            string script = "window.onload = function(){ alert('";
                            script += message;
                            script += "');";
                            // Remove the following line to prevent page reload
                            // script += "window.location = '";
                            // script += Request.Url.AbsoluteUri;
                            // script += "'; }";
                            script += "};";
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",
                            script, true);
                        }
                    }
                }
            }

        }




        private void AddDefaultFirstBank()
        {
            bool fromLinkButtonbnk = false;
            int resultbnk = 0;

            // creating dataTable   
            DataTable dtbnk = new DataTable();
            DataRow drbnk;
            dtbnk.TableName = "tblBank";
            dtbnk.Columns.Add("Serialbnk", typeof(string));
            dtbnk.Columns.Add("BankName", typeof(string));
            dtbnk.Columns.Add("BankBranch", typeof(string));
            dtbnk.Columns.Add("BankAccount", typeof(string));
            dtbnk.Columns.Add("BankType", typeof(string));

            drbnk = dtbnk.NewRow();
            dtbnk.Rows.Add(drbnk);

            // saving databale into viewstate   
            ViewState["tblBank"] = dtbnk;

            // bind Gridview  
            grvwBank.DataSource = dtbnk;
            grvwBank.DataBind();
            ViewState["LinkClickbnk"] = fromLinkButtonbnk;
            Session["ResultMemobnk"] = resultbnk;
        }

        private void AddNewRecordRowToGridforBank()
        {
            // check view state is not null  
            if (ViewState["tblBank"] != null)
            {
                // get datatable from view state
                DataTable dtCurrentTablebnk = (DataTable)ViewState["tblBank"];
                DataRow drCurrentRowbnk = null;

                if (dtCurrentTablebnk.Rows.Count == 0)
                {
                    AddDefaultFirstBank();
                }
                else
                {
                    if ((bool)ViewState["LinkClickbnk"] == true)
                    {
                        for (int k = 0; k < dtCurrentTablebnk.Rows.Count; k++)
                        {
                            dtCurrentTablebnk.Rows[k][0] = k + 1;
                            dtCurrentTablebnk.AcceptChanges();
                        }

                        ViewState["LinkClickbnk"] = false;
                    }
                    else
                    {
                        //Check for duplicate data
                        bool isDuplicate = false;
                        foreach (DataRow row in dtCurrentTablebnk.Rows)
                        {
                            if (row["BankName"].ToString() == BankName.Text &&

                                row["BankAccount"].ToString() == BankAccount.Text &&
                                row["BankType"].ToString() == BankType.Text)
                            {
                                isDuplicate = true;

                            }
                        }

                        if (!isDuplicate)
                        {
                            // New row for data table
                            drCurrentRowbnk = dtCurrentTablebnk.NewRow();
                            drCurrentRowbnk["Serialbnk"] = dtCurrentTablebnk.Rows.Count + 1;
                            drCurrentRowbnk["BankName"] = BankName.Text;
                            drCurrentRowbnk["BankBranch"] = BankBranch.Text;
                            drCurrentRowbnk["BankAccount"] = BankAccount.Text;
                            drCurrentRowbnk["BankType"] = BankType.Text;

                            // Remove initial blank row  
                            if (dtCurrentTablebnk.Rows[0][0].ToString() == "")
                            {
                                drCurrentRowbnk["Serialbnk"] = dtCurrentTablebnk.Rows.Count;
                                dtCurrentTablebnk.Rows[0].Delete();
                                dtCurrentTablebnk.AcceptChanges();
                            }

                            // Add created Rows into dataTable  
                            dtCurrentTablebnk.Rows.Add(drCurrentRowbnk);

                            // Save DataTable into view state after creating each row  
                            ViewState["tblBank"] = dtCurrentTablebnk;

                            // Bind Gridview with latest Row  
                            grvwBank.DataSource = dtCurrentTablebnk;
                            grvwBank.DataBind();
                        }
                        else
                        {


                            string message = "You can not add duplicate data";

                            string script = "window.onload = function(){ alert('";
                            script += message;
                            script += "');";
                            // Remove the following line to prevent page reload
                            // script += "window.location = '";
                            // script += Request.Url.AbsoluteUri;
                            // script += "'; }";
                            script += "};";
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",
                            script, true);
                        }
                    }
                }
            }
        }


        protected void txtSearchLibraryName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadLibraryInformation_ForGVW();
            }
            catch (Exception)
            {

            }
        }

        protected void gvwLibraryInformation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                GridViewRow row = gvwLibraryInformation.SelectedRow;
                ViewState["LibraryID"] = row.Cells[1].Text;

                DataTable dtLibrary = Li_LibraryInformationManager.GetLibraryInformationByLibraryIDForEdit(ViewState["LibraryID"].ToString()).Tables[0];
                //DataTable organizationlist = li_OrganizationManager.Get_OrganizationByIDforEdit(int.Parse(ViewState["ID"].ToString())).Tables[0];
                txtLibraryID.Text = dtLibrary.Rows[0]["Edit"].ToString();
                LibraryIDforReport = dtLibrary.Rows[0]["Edit"].ToString();
                txtLibraryName.Text = dtLibrary.Rows[0]["LibraryName"].ToString();
                txtLibraryOwnerName.Text = dtLibrary.Rows[0]["LibraryOwnerID"].ToString();
                txtLibraryOwnerPermanentAddress.Text = dtLibrary.Rows[0]["OwnerPermanentAddress"].ToString();
                txtLibraryOwnerPresentAddress.Text = dtLibrary.Rows[0]["OwnerPresentAddress"].ToString();
                txtEducationalQualification.Text = dtLibrary.Rows[0]["OwnerEducation"].ToString();
                txtShortAddress.Text = dtLibrary.Rows[0]["ShortAddress"].ToString();
                txtLibraryAddress.Text = dtLibrary.Rows[0]["LibraryAddress"].ToString();
                txtLibraryNameB.Text = dtLibrary.Rows[0]["Lib_Bn"].ToString();
                txtShortAddressB.Text = dtLibrary.Rows[0]["ShAdd_Bn"].ToString();
                txtLibraryAddressB.Text = dtLibrary.Rows[0]["LibAdd_Bn"].ToString();
                txtshopNumber.Text = dtLibrary.Rows[0]["ShopNumber"].ToString();
                txtUniqueCode.Text = dtLibrary.Rows[0]["Code"].ToString();
                txtTradeLicense.Text = dtLibrary.Rows[0]["Trade_License"].ToString();
                txtNID.Text = dtLibrary.Rows[0]["NID"].ToString();
                txtEmail.Text = dtLibrary.Rows[0]["EmailID"].ToString();
                txtBapusCardNo.Text = dtLibrary.Rows[0]["BapusCard"].ToString();
                textBuldingName.Text = dtLibrary.Rows[0]["BuildingName"].ToString();
                textholdingNo.Text = dtLibrary.Rows[0]["HoldingNo"].ToString();
                txtPostOffice.Text = dtLibrary.Rows[0]["PostOffice"].ToString();
                txtMarketName.Text = dtLibrary.Rows[0]["MarketName"].ToString();
                rbtnOwnShop.Checked = bool.Parse(dtLibrary.Rows[0]["isOwn"].ToString()) == false ? false : true;
                textSustainability.Text = dtLibrary.Rows[0]["Sustainability"].ToString();
                chkGodown.Checked = bool.Parse(dtLibrary.Rows[0]["isGodown"].ToString()) == false ? false : true;
                chkIsBoth.Checked = bool.Parse(dtLibrary.Rows[0]["IsBoth"].ToString()) == false ? false : true;
                chkIsSMS.Checked = bool.Parse(dtLibrary.Rows[0]["IsSMS"].ToString()) == false ? false : true;


                textSquirefoot.Text = dtLibrary.Rows[0]["SquireFoot"].ToString();
                txtAddressforGettingBook.Text = dtLibrary.Rows[0]["AddressforGettingBook"].ToString();

                Ownership.Text = dtLibrary.Rows[0]["Ownership"].ToString();
                txtPartnership.Text = dtLibrary.Rows[0]["Partnership"].ToString();
                txtresponsiblePersonName.Text = dtLibrary.Rows[0]["ResponsiblePersonName"].ToString();
                txtRpPhoneNo.Text = dtLibrary.Rows[0]["RpPhoneNo"].ToString();
                AmountofMoney.Text = dtLibrary.Rows[0]["AmountofMoney"].ToString();
                MoneyInWord.Text = dtLibrary.Rows[0]["MoneyInWord"].ToString();
                WayofPayment.Text = dtLibrary.Rows[0]["WayofPayment"].ToString();

                ddlDristrict.SelectedValue = dtLibrary.Rows[0]["DistrictID"].ToString();
                ddlThana.DataSource = li_ThanaManager.Get_ThanaByDistrictID(int.Parse(dtLibrary.Rows[0]["DistrictID"].ToString()));
                ddlThana.DataTextField = "ThanaName";
                ddlThana.DataValueField = "ThanaID";
                ddlThana.DataBind();
                ddlThana.SelectedValue = dtLibrary.Rows[0]["ThanaID"].ToString();

                //ddlTerritory.SelectedValue = dtLibrary.Rows[0]["TeritoryID"].ToString();
                //ddlTerritory.DataSource = Li_TeritoryManager.get
                ddlType.SelectedValue = dtLibrary.Rows[0]["Type"].ToString();
                ddlCategory.SelectedValue = dtLibrary.Rows[0]["Category"].ToString();
                Ownership.SelectedValue = dtLibrary.Rows[0]["Ownership"].ToString();
                WayofPayment.SelectedValue = dtLibrary.Rows[0]["WayofPayment"].ToString();
                DeliveryType.SelectedValue = dtLibrary.Rows[0]["DeliveryType"].ToString();
                //DeliveryType.SelectedValue = dtLibrary.Rows[0]["DeliveryType"].ToString();
                txtPhoneNo.Text = dtLibrary.Rows[0]["Telephone"].ToString();
                ddlTransportMain.SelectedValue = dtLibrary.Rows[0]["TransportID"].ToString() == "" ? "0" : dtLibrary.Rows[0]["TransportID"].ToString();
                ddlTransportAlter.SelectedValue = dtLibrary.Rows[0]["TransportID2"].ToString() == "" ? "0" : dtLibrary.Rows[0]["TransportID2"].ToString();

                //ddlOrganization.SelectedValue = dtLibrary.Rows[0]["ID"].ToString() == "" ? "0" : dtLibrary.Rows[0]["TransportID2"].ToString();
                chkIsQawmi.Checked = bool.Parse(dtLibrary.Rows[0]["IsQawmi"].ToString()) == false ? false : true;
                //chkGodown.Checked = bool.Parse(dtLibrary.Rows[0]["IsGodown"].ToString()) == false ? false : true;
                LoadLibraryInformation_ForORganizationGVW(dtLibrary.Rows[0]["Edit"].ToString());
                LoadLibraryInformation_ForAssociateGVW(dtLibrary.Rows[0]["Edit"].ToString());
                LoadLibraryInformation_ForBankGVW(dtLibrary.Rows[0]["Edit"].ToString());



                btnLibraryUpdate.Enabled = true;
                btnLibrarySave.Enabled = false;
            }
            catch (Exception)
            {

            }
        }

        protected void gvwLibraryInformation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));

        }

        protected void gvwLibraryInformation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvwLibraryInformation.PageIndex = e.NewPageIndex;

                string LibraryName = txtSearchLibraryName.Text;
                string LibID = ""; //= txtLibraryID.Text;
                gvwLibraryInformation.DataSource = Li_LibraryInformationManager.GetALLLibraryInformation(LibraryName, LibID).Tables[0];
                gvwLibraryInformation.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        ReportDocument rd = new ReportDocument();
        protected void libraryReport(object sender, EventArgs e)
        {
            try
            {

                rd.Load(Server.MapPath(@"~/Reports/rptNumanCrystalReport.rpt"));

                //rd.SetDatabaseLogon(DAO.UserID, DAO.Password, DAO.ServerName, DAO.DatabaseName);
                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@LibraryID", txtLibraryID.Text.ToString());
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Library Report");

                rd.Close();
                rd.Dispose();

            }
            catch (Exception ex)
            {


            }
        }



    }
}
