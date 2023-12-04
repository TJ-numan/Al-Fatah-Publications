using BLL.Classes;
using BLL.Marketing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Mkt_MadrashaInfo : System.Web.UI.Page
    {
        string FormID = "MF024";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {

                    LoadComboData.LoadDonYear(ddlAgreementYear);
                    getUserAccess();
                    GetAllDistrict();
                    GetAllMadrashaLevel();
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


        protected void txtAgreementNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtSomity= li_MadrashalevelsManager.Get_LiMadrasah_Somitee_AgrNo(ddlAgreementYear.SelectedValue,txtAgreementNo.Text.Trim()).Tables[0];
                ddlSomitee.DataSource = dtSomity;
                ddlSomitee.DataTextField = "DoName";
                ddlSomitee.DataValueField = "DetId";
                ddlSomitee.DataBind();

                txtAgreementNo.Focus();
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddlThana.SelectedValue == "0" || ddlThana.SelectedValue == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select a Thana');", true);
                    return;
                }
                else if(ddlSomitee.SelectedValue=="0" || ddlSomitee.SelectedValue=="")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select a Somitee');", true);
                    return;
                }

                Li_MadrasahInfo liMadrasahInf = new Li_MadrasahInfo();
                liMadrasahInf.DetId = int.Parse(ddlSomitee.SelectedValue);
                liMadrasahInf.MadName = txtMadrasahName.Text;
                liMadrasahInf.VillRoBaz = txtVillRoBaz.Text;
                liMadrasahInf.PostOff = txtPostOffice.Text;
                liMadrasahInf.MadLevelId = int.Parse(ddlMadrashaLevel.SelectedValue);
                liMadrasahInf.ThanaId = int.Parse(ddlThana.SelectedValue);
                liMadrasahInf.PrinName = txtChair_Prin.Text;
                liMadrasahInf.PrinCont = txtChair_PrinCont.Text;
                liMadrasahInf.CreatedBy = int.Parse(Session["UserID"].ToString());
                liMadrasahInf.CreatedDate = DateTime.Now;

                string MadrashaId = Li_MadrasahInfoManager.InsertLi_MadrasahInfo(liMadrasahInf);
                txtMadrasahID.Text = MadrashaId;

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

                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);
                ClearText();
                Clear_NoOfStudent();
                txtMadrasahName.Focus();
            }
            catch (Exception ex)
            {
                
            }

        }
        private void ClearText()
        {
            ddlDristrict.SelectedValue = "0";
            ddlThana.SelectedValue = "0";
            txtMadrasahName.Text = string.Empty;
            txtVillRoBaz.Text = string.Empty;
            txtPostOffice.Text = string.Empty;
            txtChair_Prin.Text = string.Empty;
            txtChair_PrinCont.Text = string.Empty;
        }

        private void Clear_NoOfStudent()
        {
            ddlMadrashaLevel.SelectedValue = "0";
            txtChildren.Text = string.Empty;
            txtClassOne.Text= string.Empty;
            txtClassTwo.Text= string.Empty;
            txtClassThree.Text= string.Empty;
            txtClassFour.Text= string.Empty;
            txtClassFive.Text= string.Empty;
            txtClassSix.Text= string.Empty;
            txtClassSeven.Text= string.Empty;
            txtClassEight.Text= string.Empty;
            txtClassNine.Text= string.Empty;
            txtClassTen.Text= string.Empty;
            txtAlim_1stY.Text= string.Empty;
            txtAlim_2ndY.Text = string.Empty;
            txtFazil_1stY.Text= string.Empty;
            txtFazil_2ndY.Text = string.Empty;
            txtFazil_3rdY.Text = string.Empty;
            txtKamil_1stY.Text= string.Empty;
            txtKamil_2ndY.Text = string.Empty;
            txtTotalStudent.Text = string.Empty;
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

        protected void txtEIINNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtMadrasahEntry = Li_MadrasahEntryManager.GetAllLi_MadrasahEntryByEIINandTerritoryID(txtEIINNo.Text, int.Parse(ddlSomitee.SelectedValue.ToString())).Tables[0];
                if (dtMadrasahEntry.Rows.Count > 0)
                {
                    txtEIINNo.Text = dtMadrasahEntry.Rows[0]["Code"].ToString();
                    txtMadrasahName.Text = dtMadrasahEntry.Rows[0]["Name"].ToString();
                    txtVillRoBaz.Text = dtMadrasahEntry.Rows[0]["Address"].ToString();
                    txtPostOffice.Text = dtMadrasahEntry.Rows[0]["PostOffice"].ToString();
                    txtChair_PrinCont.Text = dtMadrasahEntry.Rows[0]["Mobile"].ToString();
                    ddlDristrict.SelectedValue = dtMadrasahEntry.Rows[0]["DistrictID"].ToString();

                    ddlThana.DataSource = li_ThanaManager.Get_ThanaByDistrictID(int.Parse(dtMadrasahEntry.Rows[0]["DistrictID"].ToString()));
                    ddlThana.DataTextField = "ThanaName";
                    ddlThana.DataValueField = "ThanaID";
                    ddlThana.DataBind();

                    ddlThana.SelectedValue = dtMadrasahEntry.Rows[0]["Th_ID"].ToString();
                    ddlMadrashaLevel.SelectedValue = dtMadrasahEntry.Rows[0]["MadLevel"].ToString();
                }
                else 
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('EIIN not in this Somity Territory!');", true);
                    return;
                }
            }
            catch (Exception)
            {
                
            }
        }

    }
}