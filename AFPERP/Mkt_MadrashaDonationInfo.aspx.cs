using BLL.Marketing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Classes;
using Common.Marketing;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace BLL
{
    public partial class Mkt_MadrashaDonationInfo : System.Web.UI.Page
    {
        string FormID = "MF023";
        DataAccessObject DAO = new DataAccessObject();
        ReportDocument rd = new ReportDocument();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    getUserAccess();

                    LoadComboData.LoadTeritoryR2(ddlTerritory);

                    LoadComboData.LoadDonYear(ddlAgreementYear);

                    ddlAgreementYear.SelectedValue = "2022-2023";




                    GetAllDonationType();

                    GetAllDonationFor();
                    GetAllMadrashaLevel();
                    AddDefaultFirstRecord();
                    //AddDefaultFirstRecordInformer();
                    txtPerStudentCost.Text = "0";
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
                        Response.Redirect("~/MarketingHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }

        private void GetAllDonationType()
        {
            try
            {
                ddlDonationType.DataSource = Li_DonationDesManager.GetAllLi_DonationDess();
                ddlDonationType.DataTextField = "DoDescription";
                ddlDonationType.DataValueField = "DoDesId";
                ddlDonationType.DataBind();
                ddlDonationType.Items.Insert(0, new ListItem("--select--", "0"));
            }
            catch (Exception)
            {

            }
        }

        private void GetAllDonationFor()
        {
            try
            {
                ddlDonationFor.DataSource = Li_DonationForManager.GetAllLi_DonationFors();
                ddlDonationFor.DataTextField = "DonationFor";
                ddlDonationFor.DataValueField = "DoFId";
                ddlDonationFor.DataBind();
                ddlDonationFor.Items.Insert(0, new ListItem("--select--", "0"));
            }
            catch (Exception)
            {

            }
        }

        private void GetAllDistrict()
        {
            try
            {
                ddlDistrict.Items.Clear();
                ddlThana.Items.Clear();
                ListItem li = new ListItem("Select Any", "0");

                ddlDistrict.Items.Add(li);

                DataTable dt = new DataTable();
                dt = li_DistrictManager.GetAll_DistrictsByTerritory(ddlTerritory.SelectedValue);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListItem item = new ListItem(dt.Rows[i]["DistrictName"].ToString(), dt.Rows[i]["DistrictID"].ToString());
                    ddlDistrict.Items.Add(item);
                }


            }
            catch (Exception)
            {

            }
        }

        private void GetAllMadrashaLevel()
        {
            try
            {
                ddlMadrashaLevel.DataSource = li_MadrashalevelsManager.GetAllLi_MadrashaLevels();
                ddlMadrashaLevel.DataTextField = "Level_Name";
                ddlMadrashaLevel.DataValueField = "Level_ID";
                ddlMadrashaLevel.DataBind();
            }
            catch (Exception)
            {

            }
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlThana.Items.Clear();
                ListItem li = new ListItem("Select Any", "0");

                ddlThana.Items.Add(li);

                DataTable dt = new DataTable();
                dt = li_ThanaManager.GetThanasByDistrictAndTerritory(Int32.Parse(ddlDistrict.SelectedValue), ddlTerritory.SelectedValue);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListItem item = new ListItem(dt.Rows[i]["ThanaName"].ToString(), dt.Rows[i]["ThanaID"].ToString());
                    ddlThana.Items.Add(item);
                }




            }
            catch (Exception)
            {

            }
        }

        protected void ddlDonationFor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlDonationFor.SelectedValue == "1")
                {
                    txtName.Text = "";
                    txtVillRoBaz.Text = "";
                    txtPostOffice.Text = "";
                    txtPhoneNo.Text = "";
                    plnSecretary.Visible = true;

                    pnlNumofStudent.Visible = true;
                    txtEIINNo.Visible = true;
                    lblEIINNo.Visible = true;

                    //ddlMadrasah.Visible = true;
                    //lblMadrasah.Visible = true;
                    //LoadComboData.LoadMadrasah(ddlMadrasah, Int32.Parse(ddlThana.SelectedValue));

                }
                else if (ddlDonationFor.SelectedValue == "3")
                {
                    txtName.Text = "";
                    txtVillRoBaz.Text = "";
                    txtPostOffice.Text = "";
                    txtPhoneNo.Text = "";
                    pnlNumofStudent.Visible = false;
                    lblMadrasah.Visible = false;
                    ddlMadrasah.Visible = false;
                    ddlMadrasah.Items.Clear();
                    plnSecretary.Visible = false;

                    txtEIINNo.Visible = false;
                    lblEIINNo.Visible = false;

                }
                else
                {
                    txtName.Text = "";
                    txtVillRoBaz.Text = "";
                    txtPostOffice.Text = "";
                    txtPhoneNo.Text = "";
                    pnlNumofStudent.Visible = false;
                    lblMadrasah.Visible = false;
                    ddlMadrasah.Visible = false;
                    ddlMadrasah.Items.Clear();
                    plnSecretary.Visible = true;

                    txtEIINNo.Visible = false;
                    lblEIINNo.Visible = false;
                }
                ddlDonationFor.Focus();

            }
            catch (Exception)
            {


            }

        }

        private void AddDefaultFirstRecord()
        {
            try
            {
                bool fromLinkButton = false;

                DataTable dt = new DataTable();
                DataRow dr;
                dt.TableName = "tblDonationType";
                dt.Columns.Add("Serial", typeof(int));
                dt.Columns.Add("DonDesId", typeof(int));               
                dt.Columns.Add("DonType", typeof(string));
                dt.Columns.Add("Amount", typeof(decimal));
                dr = dt.NewRow();
                dt.Rows.Add(dr);
                GlobalCollections.AddConstraint(dt, "DonDesId");
                ViewState["tblDonationType"] = dt;
                gvwDonationType.DataSource = dt;
                gvwDonationType.DataBind();
                ViewState["LinkClick"] = fromLinkButton;

            }
            catch (Exception)
            {


            }
        }

        private void AddNewRecordRowToGrid()
        {
            // check view state is not null  
            if (ViewState["tblDonationType"] != null)
            {
                //get datatable from view state   
                DataTable dtCurrentTable = (DataTable)ViewState["tblDonationType"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count == 0)
                {
                    AddDefaultFirstRecord();
                    txtTotalAmount.Text = "0";
                    txtCountableAmt.Text = "0";
                    txtPerStudentCost.Text = "0";
                }
                else
                {
                    if (Convert.ToBoolean(ViewState["LinkClick"]) == true)
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
                        drCurrentRow["DonDesId"] = ddlDonationType.SelectedItem.Value.ToString();
                        drCurrentRow["DonType"] = ddlDonationType.SelectedItem.Text;
                        drCurrentRow["Amount"] = decimal.Parse(txtAmount2.Text);

                        ClearTextBoxData();
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


                    ViewState["tblDonationType"] = dtCurrentTable;
                    //Bind Gridview with latest Row  
                    gvwDonationType.DataSource = dtCurrentTable;
                    gvwDonationType.DataBind();
                    decimal subTotal = 0.0m;
                    int donationType = 0;
                    decimal StudCountBudgetAmt = 0.0m;
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                        {
                            decimal unitTotal = decimal.Parse(dtCurrentTable.Rows[i]["Amount"].ToString());
                            donationType = Int32.Parse(dtCurrentTable.Rows[i]["DonDesId"].ToString());
                            subTotal += unitTotal;
                            if (donationType == 1 || donationType == 2 || donationType == 3 || donationType == 4)
                            {
                                StudCountBudgetAmt += unitTotal;
                            }

                           
                        }
                    }

                    txtTotalAmount.Text = subTotal.ToString();
                    txtCountableAmt.Text = StudCountBudgetAmt .ToString();
                    PerStudentCost();
                }



            }

        }

        private void ClearTextBoxData()
        {
            ddlDonationType.SelectedIndex = 0;
            txtAmount2.Text = string.Empty;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = Li_DonationBasicManager.GetDonationExistingAgreementR2(txtAgreementNo.Text, int.Parse(ddlDonationFor.SelectedValue), ddlAgreementYear.SelectedItem.Text.Substring(ddlAgreementYear.SelectedItem.Text.Length - 2, 2)).Tables[0];

                if (txtAgreementNo.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Agreement No missing');", true);
                    return;
                }
                else if (ddlTerritory.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Teritory missing');", true);
                    return;
                }
                else if (ddlThana.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select a Thana');", true);
                    return;
                }
                else if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["DoFId"].ToString() == "3")
                    {

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('This Agreement already exist');", true);
                        return;
                    }
                }


                Li_DonationBasic liDonBasic = new Li_DonationBasic();
                liDonBasic.AgrNo = txtAgreementNo.Text.Trim() + "-" + ddlAgreementYear.SelectedItem.Text.Substring(ddlAgreementYear.SelectedItem.Text.Length - 2, 2);
                liDonBasic.AgrYNo = ddlAgreementYear.SelectedItem.Text.Substring(ddlAgreementYear.SelectedItem.Text.Length - 2, 2);
                liDonBasic.AgrYear = ddlAgreementYear.SelectedItem.Text;
                liDonBasic.ThanaId = int.Parse(ddlThana.SelectedValue);
                liDonBasic.TerritorySl = 0;// int.Parse(ddlTerritory.SelectedValue);
                liDonBasic.DonAmt = decimal.Parse(txtTotalAmount.Text);
                liDonBasic.CreatedBy = int.Parse(Session["UserID"].ToString());
                liDonBasic.CreatedDate = DateTime.Now;
                int DonID = Li_DonationBasicManager.InsertLi_DonationBasic(liDonBasic);


                Li_DonationDetail liDonDetail = new Li_DonationDetail();
                liDonDetail.Dold = DonID;
                liDonDetail.DoFId = int.Parse(ddlDonationFor.SelectedValue);
                liDonDetail.DoName = txtName.Text;
                liDonDetail.VillRoBaz = txtVillRoBaz.Text;
                liDonDetail.PostOff = txtPostOffice.Text;
                liDonDetail.ThanaId = int.Parse(ddlThana.SelectedValue);
                liDonDetail.ContactNo = txtPhoneNo.Text;
                liDonDetail.Chair_Prin = txtChair_Prin.Text;
                liDonDetail.Chair_PrinCont = txtChair_PrinCont.Text;
                liDonDetail.Sec_ViceP = txtSec_ViceP.Text;
                liDonDetail.Sec_VicePCont = txtSec_VicePCont.Text;
                liDonDetail.CreatedBy = int.Parse(Session["UserID"].ToString());
                liDonDetail.CreatedDate = DateTime.Now;
                int DonDetailId = Li_DonationDetailManager.InsertLi_DonationDetail(liDonDetail);

                DataTable dtCurrentTable = (DataTable)ViewState["tblDonationType"];
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                    {

                        Li_DonationAmt DonAmt = new Li_DonationAmt();
                        DonAmt.DetId = DonDetailId;
                        DonAmt.DoDesId = int.Parse(dtCurrentTable.Rows[i]["DonDesId"].ToString());
                        DonAmt.Amount = decimal.Parse(dtCurrentTable.Rows[i]["Amount"].ToString());
                        DonAmt.CreatedBy = int.Parse(Session["UserID"].ToString());
                        DonAmt.CreatedDate = DateTime.Now;
                        Li_DonationAmtManager.InsertLi_DonationAmt(DonAmt);


                    }

                    dtCurrentTable.Rows.Clear();
                }


                if (ddlDonationFor.SelectedValue == "1")
                {
                    Li_MadrasahInfo liMadrasahInf = new Li_MadrasahInfo();
                    liMadrasahInf.DetId = DonDetailId;
                    liMadrasahInf.MadName = txtName.Text;
                    liMadrasahInf.VillRoBaz = txtVillRoBaz.Text;
                    liMadrasahInf.PostOff = txtPostOffice.Text;
                    liMadrasahInf.MadLevelId = int.Parse(ddlMadrashaLevel.SelectedValue);
                    liMadrasahInf.ThanaId = int.Parse(ddlThana.SelectedValue);
                    liMadrasahInf.PrinName = txtChair_Prin.Text;
                    liMadrasahInf.PrinCont = txtChair_PrinCont.Text;
                    liMadrasahInf.CreatedBy = int.Parse(Session["UserID"].ToString());
                    liMadrasahInf.CreatedDate = DateTime.Now;

                    string MadrashaId = Li_MadrasahInfoManager.InsertLi_MadrasahInfo(liMadrasahInf);

                    Li_StudentR2 listudent = new Li_StudentR2();
                    int classNo = 17;
                    for (int i = 0; i <= 17; i++)
                    {
                        classNo = i;

                        switch (classNo)
                        {
                            case 0:
                                listudent.ClassID = classNo;
                                listudent.NoOfStudents = txtChildren.Text.Trim() == "" ? 0 : int.Parse(txtChildren.Text);
                                listudent.MadId = MadrashaId;
                                listudent.CreatedBy = int.Parse(Session["UserID"].ToString());
                                listudent.CreatedDate = DateTime.Now;
                                Li_StudentR2Manager.InsertLi_StudentR2(listudent);
                                break;
                            case 1:
                                listudent.ClassID = classNo;
                                listudent.NoOfStudents = txtClassOne.Text.Trim() == "" ? 0 : int.Parse(txtClassOne.Text);
                                listudent.MadId = MadrashaId;
                                listudent.CreatedBy = int.Parse(Session["UserID"].ToString());
                                listudent.CreatedDate = DateTime.Now;
                                Li_StudentR2Manager.InsertLi_StudentR2(listudent);
                                break;
                            case 2:
                                listudent.ClassID = classNo;
                                listudent.NoOfStudents = txtClassTwo.Text.Trim() == "" ? 0 : int.Parse(txtClassTwo.Text);
                                listudent.MadId = MadrashaId;
                                listudent.CreatedBy = int.Parse(Session["UserID"].ToString());
                                listudent.CreatedDate = DateTime.Now;
                                Li_StudentR2Manager.InsertLi_StudentR2(listudent);
                                break;
                            case 3:
                                listudent.ClassID = classNo;
                                listudent.NoOfStudents = txtClassThree.Text.Trim() == "" ? 0 : int.Parse(txtClassThree.Text);
                                listudent.MadId = MadrashaId;
                                listudent.CreatedBy = int.Parse(Session["UserID"].ToString());
                                listudent.CreatedDate = DateTime.Now;
                                Li_StudentR2Manager.InsertLi_StudentR2(listudent);
                                break;
                            case 4:
                                listudent.ClassID = classNo;
                                listudent.NoOfStudents = txtClassFour.Text.Trim() == "" ? 0 : int.Parse(txtClassFour.Text);
                                listudent.MadId = MadrashaId;
                                listudent.CreatedBy = int.Parse(Session["UserID"].ToString());
                                listudent.CreatedDate = DateTime.Now;
                                Li_StudentR2Manager.InsertLi_StudentR2(listudent);
                                break;
                            case 5:
                                listudent.ClassID = classNo;
                                listudent.NoOfStudents = txtClassFive.Text.Trim() == "" ? 0 : int.Parse(txtClassFive.Text);
                                listudent.MadId = MadrashaId;
                                listudent.CreatedBy = int.Parse(Session["UserID"].ToString());
                                listudent.CreatedDate = DateTime.Now;
                                Li_StudentR2Manager.InsertLi_StudentR2(listudent);
                                break;
                            case 6:
                                listudent.ClassID = classNo;
                                listudent.NoOfStudents = txtClassSix.Text.Trim() == "" ? 0 : int.Parse(txtClassSix.Text);
                                listudent.MadId = MadrashaId;
                                listudent.CreatedBy = int.Parse(Session["UserID"].ToString());
                                listudent.CreatedDate = DateTime.Now;
                                Li_StudentR2Manager.InsertLi_StudentR2(listudent);
                                break;
                            case 7:
                                listudent.ClassID = classNo;
                                listudent.NoOfStudents = txtClassSeven.Text.Trim() == "" ? 0 : int.Parse(txtClassSeven.Text);
                                listudent.MadId = MadrashaId;
                                listudent.CreatedBy = int.Parse(Session["UserID"].ToString());
                                listudent.CreatedDate = DateTime.Now;
                                Li_StudentR2Manager.InsertLi_StudentR2(listudent);
                                break;
                            case 8:
                                listudent.ClassID = classNo;
                                listudent.NoOfStudents = txtClassEight.Text.Trim() == "" ? 0 : int.Parse(txtClassEight.Text);
                                listudent.MadId = MadrashaId;
                                listudent.CreatedBy = int.Parse(Session["UserID"].ToString());
                                listudent.CreatedDate = DateTime.Now;
                                Li_StudentR2Manager.InsertLi_StudentR2(listudent);
                                break;
                            case 9:
                                listudent.ClassID = classNo;
                                listudent.NoOfStudents = txtClassNine.Text.Trim() == "" ? 0 : int.Parse(txtClassNine.Text);
                                listudent.MadId = MadrashaId;
                                listudent.CreatedBy = int.Parse(Session["UserID"].ToString());
                                listudent.CreatedDate = DateTime.Now;
                                Li_StudentR2Manager.InsertLi_StudentR2(listudent);
                                break;
                            case 10:
                                listudent.ClassID = classNo;
                                listudent.NoOfStudents = txtClassTen.Text.Trim() == "" ? 0 : int.Parse(txtClassTen.Text);
                                listudent.MadId = MadrashaId;
                                listudent.CreatedBy = int.Parse(Session["UserID"].ToString());
                                listudent.CreatedDate = DateTime.Now;
                                Li_StudentR2Manager.InsertLi_StudentR2(listudent);
                                break;
                            case 11:
                                listudent.ClassID = classNo;
                                listudent.NoOfStudents = txtAlim_1stY.Text.Trim() == "" ? 0 : int.Parse(txtAlim_1stY.Text);
                                listudent.MadId = MadrashaId;
                                listudent.CreatedBy = int.Parse(Session["UserID"].ToString());
                                listudent.CreatedDate = DateTime.Now;
                                Li_StudentR2Manager.InsertLi_StudentR2(listudent);
                                break;
                            case 12:
                                listudent.ClassID = classNo;
                                listudent.NoOfStudents = txtAlim_2ndY.Text.Trim() == "" ? 0 : int.Parse(txtAlim_2ndY.Text);
                                listudent.MadId = MadrashaId;
                                listudent.CreatedBy = int.Parse(Session["UserID"].ToString());
                                listudent.CreatedDate = DateTime.Now;
                                Li_StudentR2Manager.InsertLi_StudentR2(listudent);
                                break;
                            case 13:
                                listudent.ClassID = classNo;
                                listudent.NoOfStudents = txtFazil_1stY.Text.Trim() == "" ? 0 : int.Parse(txtFazil_1stY.Text);
                                listudent.MadId = MadrashaId;
                                listudent.CreatedBy = int.Parse(Session["UserID"].ToString());
                                listudent.CreatedDate = DateTime.Now;
                                Li_StudentR2Manager.InsertLi_StudentR2(listudent);
                                break;
                            case 14:
                                listudent.ClassID = classNo;
                                listudent.NoOfStudents = txtFazil_2ndY.Text.Trim() == "" ? 0 : int.Parse(txtFazil_2ndY.Text);
                                listudent.MadId = MadrashaId;
                                listudent.CreatedBy = int.Parse(Session["UserID"].ToString());
                                listudent.CreatedDate = DateTime.Now;
                                Li_StudentR2Manager.InsertLi_StudentR2(listudent);
                                break;
                            case 15:
                                listudent.ClassID = classNo;
                                listudent.NoOfStudents = txtFazil_3rdY.Text.Trim() == "" ? 0 : int.Parse(txtFazil_3rdY.Text);
                                listudent.MadId = MadrashaId;
                                listudent.CreatedBy = int.Parse(Session["UserID"].ToString());
                                listudent.CreatedDate = DateTime.Now;
                                Li_StudentR2Manager.InsertLi_StudentR2(listudent);
                                break;
                            case 16:
                                listudent.ClassID = classNo;
                                listudent.NoOfStudents = txtKamil_1stY.Text.Trim() == "" ? 0 : int.Parse(txtKamil_1stY.Text);
                                listudent.MadId = MadrashaId;
                                listudent.CreatedBy = int.Parse(Session["UserID"].ToString());
                                listudent.CreatedDate = DateTime.Now;
                                Li_StudentR2Manager.InsertLi_StudentR2(listudent);
                                break;
                            case 17:
                                listudent.ClassID = classNo;
                                listudent.NoOfStudents = txtKamil_2ndY.Text.Trim() == "" ? 0 : int.Parse(txtKamil_2ndY.Text);
                                listudent.MadId = MadrashaId;
                                listudent.CreatedBy = int.Parse(Session["UserID"].ToString());
                                listudent.CreatedDate = DateTime.Now;
                                Li_StudentR2Manager.InsertLi_StudentR2(listudent);
                                break;
                            default:
                                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Class');", true);
                                break;
                        }

                    }
                    Clear_NoOfStudent();

                }
                //string message = "Saved successfully.";
                //string script = "window.onload = function(){ alert('";
                //script += message;
                //script += "');";
                //script += "window.location = '";
                //script += Request.Url.AbsoluteUri;
                //script += "'; }";
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",
                //script, true);


                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);

                ViewState["tblDonationType"] = null;
                AddDefaultFirstRecord();

                ddlDonationFor.SelectedValue = "0";
                txtName.Text = string.Empty;
                txtPhoneNo.Text = string.Empty;
                txtChair_Prin.Text = string.Empty;
                txtChair_PrinCont.Text = string.Empty;
                txtSec_ViceP.Text = string.Empty;
                txtSec_VicePCont.Text = string.Empty;
                txtTotalAmount.Text = string.Empty;
            }

            catch (Exception ex)
            {
            }
        }

        private void ClearText()
        {

            txtAgreementNo.Text = string.Empty;
            ddlDistrict.SelectedValue = "0";
            ddlThana.SelectedValue = "0";
            ddlDonationFor.SelectedValue = "0";
            txtName.Text = string.Empty;
            txtVillRoBaz.Text = string.Empty;
            txtPostOffice.Text = string.Empty;
            txtPhoneNo.Text = string.Empty;
            txtChair_Prin.Text = string.Empty;
            txtChair_PrinCont.Text = string.Empty;
            txtSec_ViceP.Text = string.Empty;
            txtSec_VicePCont.Text = string.Empty;
            txtTotalAmount.Text = string.Empty;
            txtTerBudgAmt.Text = string.Empty;
            txtTerBudgAmtPaid.Text = string.Empty;
        }

        private void Clear_NoOfStudent()
        {
            ddlMadrashaLevel.SelectedValue = "0";
            txtChildren.Text = string.Empty;
            txtClassOne.Text = string.Empty;
            txtClassTwo.Text = string.Empty;
            txtClassThree.Text = string.Empty;
            txtClassFour.Text = string.Empty;
            txtClassFive.Text = string.Empty;
            txtClassSix.Text = string.Empty;
            txtClassSeven.Text = string.Empty;
            txtClassEight.Text = string.Empty;
            txtClassNine.Text = string.Empty;
            txtClassTen.Text = string.Empty;
            txtAlim_1stY.Text = string.Empty;
            txtAlim_2ndY.Text = string.Empty;
            txtFazil_1stY.Text = string.Empty;
            txtFazil_2ndY.Text = string.Empty;
            txtFazil_3rdY.Text = string.Empty;
            txtKamil_1stY.Text = string.Empty;
            txtKamil_2ndY.Text = string.Empty;
            txtTotalStudent.Text = string.Empty;

            txtCountableAmt.Text = "0.0m";
            txtPerStudentCost.Text = "";
        }

        protected void ddlMadrashaLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMadrashaLevel.SelectedValue == "1")
            {
                txtChildren.Enabled = true;
                txtClassOne.Enabled = true;
                txtClassTwo.Enabled = true;
                txtClassThree.Enabled = true;
                txtClassFour.Enabled = true;
                txtClassFive.Enabled = true;
                txtClassSix.Enabled = false;
                txtClassSeven.Enabled = false;
                txtClassEight.Enabled = false;
                txtClassNine.Enabled = false;
                txtClassTen.Enabled = false;
                txtAlim_1stY.Enabled = false;
                txtAlim_2ndY.Enabled = false;
                txtFazil_1stY.Enabled = false;
                txtFazil_2ndY.Enabled = false;
                txtFazil_3rdY.Enabled = false;
                txtKamil_1stY.Enabled = false;
                txtKamil_2ndY.Enabled = false;
            }
            else if (ddlMadrashaLevel.SelectedValue == "2")
            {
                txtChildren.Enabled = true;
                txtClassOne.Enabled = true;
                txtClassTwo.Enabled = true;
                txtClassThree.Enabled = true;
                txtClassFour.Enabled = true;
                txtClassFive.Enabled = true;
                txtClassSix.Enabled = true;
                txtClassSeven.Enabled = true;
                txtClassEight.Enabled = true;
                txtClassNine.Enabled = false;
                txtClassTen.Enabled = false;
                txtAlim_1stY.Enabled = false;
                txtAlim_2ndY.Enabled = false;
                txtFazil_1stY.Enabled = false;
                txtFazil_2ndY.Enabled = false;
                txtFazil_3rdY.Enabled = false;
                txtKamil_1stY.Enabled = false;
                txtKamil_2ndY.Enabled = false;
            }
            else if (ddlMadrashaLevel.SelectedValue == "3")
            {
                txtChildren.Enabled = true;
                txtClassOne.Enabled = true;
                txtClassTwo.Enabled = true;
                txtClassThree.Enabled = true;
                txtClassFour.Enabled = true;
                txtClassFive.Enabled = true;
                txtClassSix.Enabled = true;
                txtClassSeven.Enabled = true;
                txtClassEight.Enabled = true;
                txtClassNine.Enabled = true;
                txtClassTen.Enabled = true;
                txtAlim_1stY.Enabled = false;
                txtAlim_2ndY.Enabled = false;
                txtFazil_1stY.Enabled = false;
                txtFazil_2ndY.Enabled = false;
                txtFazil_3rdY.Enabled = false;
                txtKamil_1stY.Enabled = false;
                txtKamil_2ndY.Enabled = false;

            }
            else if (ddlMadrashaLevel.SelectedValue == "4")
            {
                txtChildren.Enabled = true;
                txtClassOne.Enabled = true;
                txtClassTwo.Enabled = true;
                txtClassThree.Enabled = true;
                txtClassFour.Enabled = true;
                txtClassFive.Enabled = true;
                txtClassSix.Enabled = true;
                txtClassSeven.Enabled = true;
                txtClassEight.Enabled = true;
                txtClassNine.Enabled = true;
                txtClassTen.Enabled = true;
                txtAlim_1stY.Enabled = true;
                txtAlim_2ndY.Enabled = true;
                txtFazil_1stY.Enabled = false;
                txtFazil_2ndY.Enabled = false;
                txtFazil_3rdY.Enabled = false;
                txtKamil_1stY.Enabled = false;
                txtKamil_2ndY.Enabled = false;
            }
            else if (ddlMadrashaLevel.SelectedValue == "5")
            {
                txtChildren.Enabled = true;
                txtClassOne.Enabled = true;
                txtClassTwo.Enabled = true;
                txtClassThree.Enabled = true;
                txtClassFour.Enabled = true;
                txtClassFive.Enabled = true;
                txtClassSix.Enabled = true;
                txtClassSeven.Enabled = true;
                txtClassEight.Enabled = true;
                txtClassNine.Enabled = true;
                txtClassTen.Enabled = true;
                txtAlim_1stY.Enabled = true;
                txtAlim_2ndY.Enabled = true;
                txtFazil_1stY.Enabled = true;
                txtFazil_2ndY.Enabled = true;
                txtFazil_3rdY.Enabled = true;
                txtKamil_1stY.Enabled = false;
                txtKamil_2ndY.Enabled = false;
            }
            else
            {
                txtChildren.Enabled = true;
                txtClassOne.Enabled = true;
                txtClassTwo.Enabled = true;
                txtClassThree.Enabled = true;
                txtClassFour.Enabled = true;
                txtClassFive.Enabled = true;
                txtClassSix.Enabled = true;
                txtClassSeven.Enabled = true;
                txtClassEight.Enabled = true;
                txtClassNine.Enabled = true;
                txtClassTen.Enabled = true;
                txtAlim_1stY.Enabled = true;
                txtAlim_2ndY.Enabled = true;
                txtFazil_1stY.Enabled = true;
                txtFazil_2ndY.Enabled = true;
                txtFazil_3rdY.Enabled = true;
                txtKamil_1stY.Enabled = true;
                txtKamil_2ndY.Enabled = true;
            }

            ddlMadrashaLevel.Focus();
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            ViewState["tblDonationType"] = null;
            AddDefaultFirstRecord();
            Clear_NoOfStudent();
            ClearText();

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                decimal restAmt = 0.0m;
                decimal restAmt1 = 0.0m;
                decimal restAmt2 = 0.0m;


                if (ddlDonationType.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Select a Donation Type');", true);
                    return;

                }
                if (txtAmount2.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Amount missing');", true);
                    return;

                }

                for (int i = 0; i < gvBudgetAndPaid.Rows.Count; i++)
                {
                    if (ddlDonationType.SelectedItem.Text == gvBudgetAndPaid.Rows[i].Cells[1].Text)
                    {
                        restAmt1 = decimal.Parse(gvBudgetAndPaid.Rows[i].Cells[4].Text);
                    }
                    if (ddlDonationType.SelectedItem.Text == "Entertainment")
                    {
                        if (gvBudgetAndPaid.Rows[i].Cells[1].Text == "Cash")
                        {
                            restAmt1 = decimal.Parse(gvBudgetAndPaid.Rows[i].Cells[4].Text);
                        }
                    }
                }



                for (int i = 0; i < gvwDonationType.Rows.Count; i++)
                {
                    if (ddlDonationType.SelectedItem.Text == gvwDonationType.Rows[i].Cells[1].Text)
                    {
                        restAmt2 = decimal.Parse(gvwDonationType.Rows[i].Cells[2].Text);
                    }
                    if (ddlDonationType.SelectedItem.Text == "Entertainment")
                    {
                        if (gvwDonationType.Rows[i].Cells[1].Text == "Cash")
                        {
                            restAmt2 = decimal.Parse(gvwDonationType.Rows[i].Cells[2].Text);
                        }
                    }
                }


                restAmt = restAmt1 + restAmt2;

                if (Int32.Parse(ddlDonationType.SelectedValue) < 5)// <5 for counting cash gift book entertainment only
                {
                    if (decimal.Parse(txtAmount2.Text) <= restAmt)
                    {
                        AddNewRecordRowToGrid();


                    }

                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Amount is greater than Rest Amount of Budget or wrong selection of donation type ');", true);
                        return;
                    }
                }
                else
                {
                    AddNewRecordRowToGrid();

                }


                //For Per Student Cost Calculation
                //decimal TotalBudgetAmnt=0.0m;
                //decimal amt = decimal.Parse(txtAmount2.Text);
                //TotalBudgetAmnt += amt;
                //txtTotalBudget.Text = TotalBudgetAmnt.ToString();
                //txtPerStudCost.Text = (TotalBudgetAmnt / decimal.Parse(txtTotalStudent.Text)).ToString();
                ddlDonationType.Focus();
            }
            catch (Exception)
            {


            }


        }

        private void PerStudentCost()
        {

            if (ddlDonationFor.SelectedValue == "1")
            {
                decimal PerStuAmt = 0.0m;
                decimal stdentNo = 0.0m;
                decimal countableAmt  = 0.0m;
                if (txtTotalStudent.Text.Trim() == "" || txtTotalAmount.Text == "" || decimal.Parse(txtTotalStudent.Text) == 0.0m ||decimal.Parse( txtTotalAmount.Text) == 0.0m )
                {
                    txtPerStudentCost.Text = "0";
                }
                else
                {

                    stdentNo = decimal.Parse(txtTotalStudent.Text);
                    countableAmt = decimal.Parse(txtCountableAmt.Text);
                            
                    txtPerStudentCost.Text = String.Format("{0:0.##}",  countableAmt / stdentNo);
                     
                }
            }
        }

        protected void lbDelete_Click(object sender, EventArgs e)
        {
            try
            {

                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                DataTable dtCurrentTable = (DataTable)ViewState["tblDonationType"];
                dtCurrentTable.Rows[Convert.ToInt32(linkButton.CommandArgument) - 1].Delete();
                dtCurrentTable.AcceptChanges();
                ViewState["LinkClick"] = true;
                AddNewRecordRowToGrid();

            }
            catch (Exception)
            {


            }
        }

        protected void txtAgreementNo_TextChanged(object sender, EventArgs e)
        {
            txtAgreementNo.Text = txtAgreementNo.Text.PadLeft(4, '0');
            txtAgreementNo.Focus();
        }

        protected void ddlDonationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTerBudgAmt.Text = "0.00";
            txtTerBudgAmtPaid.Text = "0.00";

            if (ddlThana.SelectedValue == "0" || ddlThana.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please, select a Thana');", true);
                return;
            }

            string DoDesId = ddlDonationType.SelectedValue == "4" ? "1" : ddlDonationType.SelectedValue;

            DataTable dtTerBudget = Li_DonationDetailManager.GetTeritoryWiseBudgetAmt(int.Parse(ddlThana.SelectedValue), int.Parse(DoDesId), ddlAgreementYear.SelectedItem.Text).Tables[0];
            if (dtTerBudget.Rows.Count > 0)
            {
                txtTerBudgAmt.Text = dtTerBudget.Rows[0]["Amount"].ToString();
            }
            DataTable dtTerAllocatedBudget = Li_DonationDetailManager.GetTeritoryWiseBudgetAmtPaid(int.Parse(ddlThana.SelectedValue), int.Parse(ddlDonationType.SelectedValue), ddlAgreementYear.SelectedItem.Text).Tables[0];
            if (dtTerAllocatedBudget.Rows.Count > 0)
            {
                txtTerBudgAmtPaid.Text = dtTerAllocatedBudget.Rows[0]["Amount"].ToString();
            }



            txtAmount2.Focus();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAgreementNo.Text.Trim() == string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Agreement no. missing');", true);
                    return;
                }
                if (ddlDonationFor.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please, select Donation For');", true);
                    return;
                }
                DataTable dtEdit = Li_DonationBasicManager.GetMadrashaSomiteePersonInfo_ForEdit(txtAgreementNo.Text, int.Parse(ddlDonationFor.SelectedValue), ddlAgreementYear.SelectedItem.Text.Substring(ddlAgreementYear.SelectedItem.Text.Length - 2, 2)).Tables[0];
                if (dtEdit.Rows.Count > 0)
                {

                    string AgrNo = txtAgreementNo.Text;
                    int DoFId = int.Parse(ddlDonationFor.SelectedValue);
                    string AgrYear = ddlAgreementYear.SelectedValue;
                    Response.Redirect(string.Format("~/Mkt_MadrashaDonationInfoEdit.aspx?AgrNo={0}&DoFId={1}&AgrYear={2}", AgrNo, DoFId, AgrYear));

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('This agreement no. is unvalid');", true);
                    return;
                }


            }
            catch (Exception)
            {

            }
        }

        protected void ddlThana_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                LoadComboData.LoadMadrasah(ddlMadrasah, Int32.Parse(ddlThana.SelectedValue));
                ddlThana.Focus();
            }
            catch (Exception)
            {


            }
        }

        protected void ddlAgreementYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                GetAllDistrict();
                DataSet ds = null;
                if (ddlAgreementYear.SelectedValue != "0" || ddlTerritory.SelectedValue != "0")
                {
                    ds = Li_DonationDetailManager.GetTeritoryWiseBudgetAndPaidR2(ddlAgreementYear.SelectedValue, ddlTerritory.SelectedValue);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvBudgetAndPaid.Visible = true;
                        gvBudgetAndPaid.DataSource = ds.Tables[0];
                        gvBudgetAndPaid.DataBind();
                    }
                    else
                    {

                        gvBudgetAndPaid.Visible = false;
                        gvBudgetAndPaid.DataSource = null;
                    }
                    ddlAgreementYear.Focus();
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        protected void ddlMadrasah_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                Li_MadrasahEntry madrasah = new Li_MadrasahEntry();
                madrasah = Li_MadrasahEntryManager.GetLi_MadrasahEntryByID(ddlMadrasah.SelectedValue);
                txtName.Text = madrasah.Name;
                txtVillRoBaz.Text = madrasah.Address;
                txtPostOffice.Text = madrasah.PostOffice;
                txtPhoneNo.Text = madrasah.Mobile;
                ddlMadrashaLevel.SelectedValue = madrasah.MadLevel.ToString();

                ddlMadrashaLevel_SelectedIndexChanged(sender, e);

                ddlMadrasah.Focus();
            }
            catch (Exception)
            {


            }

        }

        protected void txtEIINNo_TextChanged(object sender, EventArgs e)
        {
            //Clears();

            DataTable dtMadrasahEntry = Li_MadrasahEntryManager.GetAllLi_MadrasahEntryByTerCodeAndEIIN(txtEIINNo.Text, ddlTerritory.SelectedValue).Tables[0];
            if (dtMadrasahEntry.Rows.Count > 0)
            {

                txtEIINNo.Text = dtMadrasahEntry.Rows[0]["Code"].ToString();
                txtName.Text = dtMadrasahEntry.Rows[0]["Name"].ToString();
                txtVillRoBaz.Text = dtMadrasahEntry.Rows[0]["Address"].ToString();
                txtPostOffice.Text = dtMadrasahEntry.Rows[0]["PostOffice"].ToString();
                txtPhoneNo.Text = dtMadrasahEntry.Rows[0]["Mobile"].ToString();
                ddlDistrict.SelectedValue = dtMadrasahEntry.Rows[0]["DistrictID"].ToString();

                ddlThana.DataSource = li_ThanaManager.Get_ThanaByDistrictID(int.Parse(dtMadrasahEntry.Rows[0]["DistrictID"].ToString()));
                ddlThana.DataTextField = "ThanaName";
                ddlThana.DataValueField = "ThanaID";
                ddlThana.DataBind();

                ddlThana.SelectedValue = dtMadrasahEntry.Rows[0]["Th_ID"].ToString();
                ddlMadrashaLevel.SelectedValue = dtMadrasahEntry.Rows[0]["MadLevel"].ToString();
                ddlMadrashaLevel_SelectedIndexChanged(sender, e);


            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('This EIIN is not for the Teritory');", true);
                return;
            }
        }

        private void Clears()
        {

            //txtEIINNo.Text = "";
            txtName.Text = "";
            txtVillRoBaz.Text = "";
            txtPostOffice.Text = "";
            txtPhoneNo.Text = "";
            ddlMadrashaLevel.SelectedValue = "0";
            ddlDistrict.SelectedValue = "0";
            ddlThana.SelectedValue = "0";

        }

        //protected void lblInfoDelete_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        LinkButton linkButton = new LinkButton();
        //        linkButton = (LinkButton)sender;
        //        DataTable dtInformerTable = (DataTable)ViewState["tblInformer"];
        //        dtInformerTable.Rows[Convert.ToInt32(linkButton.CommandArgument) - 1].Delete();
        //        dtInformerTable.AcceptChanges();
        //        ViewState["LinkClickInf"] = true;
        //        AddInformerRowToGrid();

        //    }
        //    catch (Exception)
        //    {


        //    }
        //}


        //private void AddDefaultFirstRecordInformer()
        //{
        //    try
        //    {
        //        bool fromLinkButtonInf = false;

        //        DataTable dt = new DataTable();
        //        DataRow dr;
        //        dt.TableName = "tblInformer";
        //        dt.Columns.Add("Serial", typeof(int));
        //        dt.Columns.Add("InformerName", typeof(string));
        //        dt.Columns.Add("Responsibility", typeof(string));
        //        dt.Columns.Add("Mobile", typeof(string));
        //        dr = dt.NewRow();
        //        dt.Rows.Add(dr);
        //        ViewState["tblInformer"] = dt;
        //        gvwInformer.DataSource = dt;
        //        gvwInformer.DataBind();
        //        ViewState["LinkClickInf"] = fromLinkButtonInf;

        //    }
        //    catch (Exception)
        //    {


        //    }
        //}
        //private void AddInformerRowToGrid()
        //{
        //    // check view state is not null  
        //    if (ViewState["tblInformer"] != null)
        //    {
        //        //get datatable from view state   
        //        DataTable dtInfoTable = (DataTable)ViewState["tblInformer"];
        //        DataRow drCurrRow = null;
        //        if (dtInfoTable.Rows.Count == 0)
        //        {
        //            AddDefaultFirstRecordInformer();
        //            txtTotalAmount.Text = "0";
        //            txtCountableAmt.Text = "0";
        //            txtPerStudentCost.Text = "0";
        //        }
        //        else
        //        {
        //            if (Convert.ToBoolean(ViewState["LinkClickInf"]) == true)
        //            {


        //                for (int i = 0; i < dtInfoTable.Rows.Count; i++)
        //                {
        //                    dtInfoTable.Rows[i][0] = i + 1;
        //                    dtInfoTable.AcceptChanges();
        //                }

        //                ViewState["LinkClickInf"] = false;
        //            }
        //            else
        //            {
        //                for (int i = 1; i <= dtInfoTable.Rows.Count; i++)
        //                {

        //                    //add each row into data table  
        //                    drCurrRow = dtInfoTable.NewRow();
        //                    drCurrRow["Serial"] = dtInfoTable.Rows.Count + 1;

        //                }
        //                drCurrRow["InformerName"] = txtInformerName.Text;
        //                drCurrRow["Responsibility"] = txtResponsibility.Text;
        //                drCurrRow["Mobile"] = txtInformerMobileNo.Text;

        //                ClearInformerText();
        //                //Remove initial blank row  
        //                if (dtInfoTable.Rows[0][0].ToString() == "")
        //                {
        //                    drCurrRow["Serial"] = dtInfoTable.Rows.Count;
        //                    dtInfoTable.Rows[0].Delete();
        //                    dtInfoTable.AcceptChanges();

        //                }

        //                //add created Rows into dataTable  
        //                dtInfoTable.Rows.Add(drCurrRow);
        //            }


        //            ViewState["tblInformer"] = dtInfoTable;
        //            //Bind Gridview with latest Row  
        //            gvwInformer.DataSource = dtInfoTable;
        //            gvwInformer.DataBind();
        //        }



        //    }

        //}

        //private void ClearInformerText()
        //{
        //    txtInformerName.Text = "";
        //    txtResponsibility.Text = "";
        //    txtInformerMobileNo.Text = "";
        //}

        //protected void btnInformerAdd_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        AddInformerRowToGrid();
        //        txtInformerName.Focus();
        //    }
        //    catch (Exception ex)
        //    {
                
                
        //    }
        //}

        //protected void btnSaveInformer_Click(object sender, EventArgs e)
        //{

        //    try
        //    {

        //        DataTable dt = li_PrimaryObservationManager.GetDonationExisting_POR(txtAgreementNo.Text, int.Parse(ddlDonationFor.SelectedValue), ddlAgreementYear.SelectedItem.Text.Substring(ddlAgreementYear.SelectedItem.Text.Length - 2, 2)).Tables[0];

        //        if (txtAgreementNo.Text.Trim() == "")
        //        {
        //            ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Agreement No missing');", true);
        //            return;
        //        }
        //        else if (ddlTerritory.SelectedValue == "0")
        //        {
        //            ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Teritory missing');", true);
        //            return;
        //        }
        //        else if (ddlThana.SelectedValue == "0")
        //        {
        //            ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select a Thana');", true);
        //            return;
        //        }
        //        else if (dt.Rows.Count > 0)
        //        {
        //            if (dt.Rows[0]["DoFId"].ToString() == "3")
        //            {

        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('This Agreement already exist');", true);
        //                return;
        //            }
        //        }

        //        li_DonPrimaryObservation liDonprimaryObser = new li_DonPrimaryObservation();
        //        liDonprimaryObser.AgrNo = txtAgreementNo.Text.Trim() + "-" + ddlAgreementYear.SelectedItem.Text.Substring(ddlAgreementYear.SelectedItem.Text.Length - 2, 2);
        //        liDonprimaryObser.AgrYNo = ddlAgreementYear.SelectedItem.Text.Substring(ddlAgreementYear.SelectedItem.Text.Length - 2, 2);
        //        liDonprimaryObser.AgrYear = ddlAgreementYear.SelectedItem.Text;
        //        liDonprimaryObser.ThanaId = int.Parse(ddlThana.SelectedValue);
        //        liDonprimaryObser.EIIN = txtEIINNo.Text==""?0: Int32.Parse(txtEIINNo.Text);
        //        liDonprimaryObser.DoFId = int.Parse(ddlDonationFor.SelectedValue);
        //        liDonprimaryObser.DoName = txtName.Text;
        //        liDonprimaryObser.VillRoBaz = txtVillRoBaz.Text;
        //        liDonprimaryObser.PostOff = txtPostOffice.Text;
        //        liDonprimaryObser.ContactNo = txtPhoneNo.Text;

        //        //liDonprimaryObser.RecceivedInfo = txtReceivedInfos.Text;
        //        //liDonprimaryObser.Problems = txtProblems.Text;
        //        liDonprimaryObser.CreatedBy = int.Parse(Session["UserID"].ToString());
        //        liDonprimaryObser.CreatedDate = DateTime.Now;
        //        liDonprimaryObser.ModifiedBy = int.Parse(Session["UserID"].ToString());
        //        liDonprimaryObser.ModifiedDate = DateTime.Now;
        //        int DonPORId = li_PrimaryObservationManager.InsertLi_PrimaryObservation(liDonprimaryObser);

        //        DataTable dtPORTable = (DataTable)ViewState["tblInformer"];
        //        if (dtPORTable.Rows.Count > 0)
        //        {
        //            for (int i = 0; i < dtPORTable.Rows.Count; i++)
        //            {

        //                li_DonInformar DonInf = new li_DonInformar();
        //                DonInf.PORId = DonPORId;
        //                DonInf.InformarName = dtPORTable.Rows[i]["InformerName"].ToString();
        //                DonInf.Responsibility = dtPORTable.Rows[i]["Responsibility"].ToString();
        //                DonInf.MobileNo = dtPORTable.Rows[i]["Mobile"].ToString();
        //                DonInf.CreatedBy = int.Parse(Session["UserID"].ToString());
        //                DonInf.CreatedDate = DateTime.Now;
        //                DonInf.ModifiedBy = int.Parse(Session["UserID"].ToString());
        //                DonInf.ModifiedDate = DateTime.Now;
        //                li_PrimaryObservationManager.InsertLi_DonInformarDetails(DonInf);


        //            }

        //            dtPORTable.Rows.Clear();
        //        }

        //        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Information Saved Successfully');", true);
        //    }
        //    catch (Exception ex)
        //    {
                
        //        throw ex;
        //    }

        //}

        //protected void btnPrintPOR_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        rd.Load(Server.MapPath(@"~/Reports/MKT/rptPrimaryObservationReport.rpt"));
        //        rd.DataSourceConnections.Clear();
        //        rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
        //        rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
        //        rd.SetParameterValue("@AgrNo", txtAgreementNo.Text);
        //        rd.SetParameterValue("@AgrYear", ddlAgreementYear.SelectedItem.Text.Substring(ddlAgreementYear.SelectedItem.Text.Length - 2, 2));
        //        rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Primary Observation Report");
        //        rd.Close();
        //        rd.Dispose();
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

    }
}