using BLL.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

namespace BLL
{
    public partial class HrmEmployeeInfo : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                    LoadComboData.LoadDepartments(ddlDepartment);
                    LoadComboData.LoadDesignation(ddlDesignation);
                    LoadComboData.LoadSection(ddlSection);
                    LoadComboData.LoadGender(ddlGender);
                    LoadComboData.LaodBloodGroup(ddlBloodGroup);
                    LoadComboData.LoadReligion(ddlReligion);
                    LoadComboData.LoadJobCategory(ddlJobCategory);
                    LoadComboData.LoadMaritalStatus(ddlMaritalSt);
                    LoadComboData.LoadJobTitle(ddlReportTo);
                    LoadComboData.LoadNationality(ddlNationality);
                    LoadComboData.LoadJobTitle(ddlJobTitle);
                    GetAllPresentDistrict();
                    GetAllPermanentDistrict();
                    AddEmployeeRecords();

                    
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void AddEmployeeRecords()
        {
            try
            {
                DataTable dt = new DataTable();
                DataRow dr = null;

                dt.TableName = "tblEmployeeView";
                dt.Columns.Add("EmpSl", typeof(int));
                dt.Columns.Add("IDNo", typeof(string));
                dt.Columns.Add("EmpName", typeof(string));
                dt.Columns.Add("ImgPath", typeof(string));
                dt.Columns.Add("JobTiName", typeof(string));
                dt.Columns.Add("DepName", typeof(string));
                dt.Columns.Add("JoiningDate", typeof(DateTime));
                dt.Columns.Add("JobCatName", typeof(string));
                dt.Columns.Add("PhoneNo", typeof(string));
                dt.Columns.Add("DateOfBirth", typeof(DateTime));
                dt.Columns.Add("PresAdd", typeof(string));
                dt.Columns.Add("PerAdd", typeof(string));
                dt.Columns.Add("NID", typeof(string));
                dt.Columns.Add("SignPath", typeof(string));

                DataTable empdt = new DataTable();
                empdt = Li_EmployeeInfoManager.LoadGvEmployeeInfo();

                if (empdt.Rows.Count > 0)
                {
 
                        for (int i = 0; i < empdt.Rows.Count; i++)
                        {
                            dr = dt.NewRow();
                            dr["EmpSl"] = Int32.Parse(empdt.Rows[i]["EmpSl"].ToString());
                            dr["IDNo"] = empdt.Rows[i]["IDNo"].ToString();
                            dr["EmpName"] = empdt.Rows[i]["EmpName"].ToString();
                            byte[] bytes = (byte[])empdt.Rows[i]["ImgPath"];
                            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);

                            dr["JobTiName"] = empdt.Rows[i]["JobTiName"].ToString();
                            dr["DepName"] = empdt.Rows[i]["DepName"].ToString();
                            dr["JoiningDate"] = DateTime.Parse(empdt.Rows[i]["JoiningDate"].ToString());
                            dr["JobCatName"] = empdt.Rows[i]["JobCatName"].ToString();
                            dr["PhoneNo"] = empdt.Rows[i]["PhoneNo"].ToString();
                            dr["DateOfBirth"] = DateTime.Parse(empdt.Rows[i]["DateOfBirth"].ToString());
                            dr["PresAdd"] = empdt.Rows[i]["PresAdd"].ToString();
                            dr["PerAdd"] = empdt.Rows[i]["PerAdd"].ToString();
                            dr["NID"] = empdt.Rows[i]["NID"].ToString();
                            byte[] byteSign = (byte[])empdt.Rows[i]["SignPath"];
                            string base64String2 = Convert.ToBase64String(byteSign, 0, byteSign.Length);

                            //  dt.Rows.Add(dr);
                            gvEmployeeInfo.DataSource = empdt;
                            gvEmployeeInfo.DataBind();


                        }
                      
                }

            }
            catch (Exception)
            {


            }
        }

    

        private void GetAllPresentDistrict()
        {
            try
            {
                ddlPresDistrict.DataSource = li_DistrictManager.GetAll_Districts();
                ddlPresDistrict.DataTextField = "DistrictName";
                ddlPresDistrict.DataValueField = "DistrictID";
                ddlPresDistrict.DataBind();
                ddlPresDistrict.Items.Insert(0, new ListItem("--select--", "0"));
            }
            catch (Exception)
            {

            }
        }
        private void GetAllPermanentDistrict()
        {
            try
            {
                ddlPermDistrict.DataSource = li_DistrictManager.GetAll_Districts();
                ddlPermDistrict.DataTextField = "DistrictName";
                ddlPermDistrict.DataValueField = "DistrictID";
                ddlPermDistrict.DataBind();
                ddlPermDistrict.Items.Insert(0, new ListItem("--select--", "0"));
            }
            catch (Exception)
            {

            }
        }

        protected void btnImagePrevw_Click(object sender, EventArgs e)
        {

            //Stream strm = EmpImg.PostedFile.InputStream;
            //BinaryReader reader = new BinaryReader(strm);
            //Byte[] bytes = reader.ReadBytes(Convert.ToInt32(strm.Length));
            //imgDetail.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(bytes, 0, bytes.Length);
            //imgDetail.Visible = true;

        }

        protected void btnSignaturePrevw_Click(object sender, EventArgs e)
        {

            //Stream strm = EmpSign.PostedFile.InputStream;
            //BinaryReader reader = new BinaryReader(strm);
            //Byte[] bytes = reader.ReadBytes(Convert.ToInt32(strm.Length));
            //signDetail.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(bytes, 0, bytes.Length);
            //signDetail.Visible = true;

        }

        protected void ddlPresDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlPresThana.DataSource = li_ThanaManager.Get_ThanaByDistrictID(int.Parse(ddlPresDistrict.SelectedValue));
                ddlPresThana.DataTextField = "ThanaName";
                ddlPresThana.DataValueField = "ThanaID";
                ddlPresThana.DataBind();


            }
            catch (Exception)
            {

            }
        }

        protected void ddlPermDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlPermThana.DataSource = li_ThanaManager.Get_ThanaByDistrictID(int.Parse(ddlPermDistrict.SelectedValue));
                ddlPermThana.DataTextField = "ThanaName";
                ddlPermThana.DataValueField = "ThanaID";
                ddlPermThana.DataBind();


            }
            catch (Exception)
            {

            }
        }

        protected System.Web.UI.HtmlControls.HtmlInputFile EmpImg;
        protected System.Web.UI.HtmlControls.HtmlInputFile EmpSign;
        protected System.Web.UI.HtmlControls.HtmlInputFile EmpCv;
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {


                if (

                    Int32.Parse(ddlBloodGroup.SelectedValue) < 1 ||
                    Int32.Parse(ddlDepartment.SelectedValue) < 1 ||
                    Int32.Parse(ddlDesignation.SelectedValue) < 1 ||
                    Int32.Parse(ddlJobCategory.SelectedValue) < 1 ||
                    Int32.Parse(ddlGender.SelectedValue) < 1 ||
                    Int32.Parse(ddlInfoStatus.SelectedValue) < 1 ||
                    Int32.Parse(ddlMaritalSt.SelectedValue) < 1 ||
                    Int32.Parse(ddlPermDistrict.SelectedValue) < 1 ||
                    Int32.Parse(ddlPermThana.SelectedValue) < 1 ||
                    Int32.Parse(ddlPresDistrict.SelectedValue) < 1 ||
                    Int32.Parse(ddlPresThana.SelectedValue) < 1 ||
                    Int32.Parse(ddlReligion.SelectedValue) < 1 ||
                    Int32.Parse(ddlReportTo.SelectedValue) < 1 ||
                    Int32.Parse(ddlSection.SelectedValue) < 1

                    )
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Information.');", true);
                    //return;
                }


                DataTable dt = new DataTable();
                dt = Li_EmployeeInfoManager.GetEmployeeNextSL();
                ViewState["EmpNextSl"] = dt.Rows[0][0].ToString();


                Li_EmployeeInfo empInfo = new Li_EmployeeInfo();
                empInfo.BGId = Int32.Parse(ddlBloodGroup.SelectedValue);
                empInfo.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                empInfo.CreatedDate = DateTime.Now;


                if (EmpCv.PostedFile.FileName == "")
                {
                    string fn = ViewState["EmpNextSl"] + "-" + System.IO.Path.GetFileName("CV not given");
                    string SaveLocation = Server.MapPath("EmpCv") + "\\" + fn;
                    try
                    {
                        EmpCv.PostedFile.SaveAs(SaveLocation);

                        FileStream fsCv = new FileStream(SaveLocation, FileMode.Open, FileAccess.Read);
                        BinaryReader brCv = new BinaryReader(fsCv);
                        Byte[] bytesCv = brCv.ReadBytes((Int32)fsCv.Length);
                        brCv.Close();
                        fsCv.Close();
                        empInfo.CvPath = bytesCv;
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('File already exist.');", true);

                    }
                }
                else
                {
                    if (EmpCv.PostedFile.ContentLength > 0 && EmpCv.PostedFile.ContentLength <= 1024000)
                    {
                        string fn = ViewState["EmpNextSl"] + "-" + System.IO.Path.GetFileName(EmpCv.PostedFile.FileName);
                        string SaveLocation = Server.MapPath("EmpCv") + "\\" + fn;
                        try
                        {
                            EmpCv.PostedFile.SaveAs(SaveLocation);

                            FileStream fsCv = new FileStream(SaveLocation, FileMode.Open, FileAccess.Read);
                            BinaryReader brCv = new BinaryReader(fsCv);
                            Byte[] bytesCv = brCv.ReadBytes((Int32)fsCv.Length);
                            brCv.Close();
                            fsCv.Close();
                            empInfo.CvPath = bytesCv;
                        }
                        catch (Exception ex)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('File already exist.');", true);

                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('CV size too large.');", true);
                        return;
                    }
                }



                empInfo.DateOfBirth = Convert.ToDateTime(txtDateofBirth.Text);
                empInfo.DepId = Int32.Parse(ddlDepartment.SelectedValue);
                empInfo.DesId = Int32.Parse(ddlDesignation.SelectedValue);
                empInfo.EmailAdd = txtEmailAdd.Text;
                empInfo.EmpAge = decimal.Parse(txtEmployeeAge.Text);
                empInfo.EmploymentStId = Int32.Parse(ddlJobCategory.SelectedValue);
                empInfo.EmpName = txtEmpName.Text;
                empInfo.EmpNameBn = txtEmpNameBn.Text;
                empInfo.EmpSl = 0;
                empInfo.FName = txtFatherName.Text;
                empInfo.GenId = Int32.Parse(ddlGender.SelectedValue);
                empInfo.IDNo = txtEmpId.Text;

                if (EmpImg.PostedFile.FileName == "")
                {
                    string fn = ViewState["EmpNextSl"] + "-" + System.IO.Path.GetFileName("Image not given");
                    string SaveLocation = Server.MapPath("EmpImg") + "\\" + fn;
                    try
                    {
                        EmpImg.PostedFile.SaveAs(SaveLocation);
                        FileStream fsImg = new FileStream(SaveLocation, FileMode.Open, FileAccess.Read);
                        BinaryReader brImg = new BinaryReader(fsImg);
                        Byte[] bytesImg = brImg.ReadBytes((Int32)fsImg.Length);
                        brImg.Close();
                        fsImg.Close();
                        empInfo.ImgPath = bytesImg;
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('File already exist.');", true);

                    }
                }
                else
                {
                    if (EmpImg.PostedFile.ContentLength > 0 && EmpImg.PostedFile.ContentLength <= 1024000)
                    {
                        string fn = ViewState["EmpNextSl"] + "-" + System.IO.Path.GetFileName(EmpImg.PostedFile.FileName);
                        string SaveLocation = Server.MapPath("EmpImg") + "\\" + fn;
                        try
                        {
                            EmpImg.PostedFile.SaveAs(SaveLocation);
                            FileStream fsImg = new FileStream(SaveLocation, FileMode.Open, FileAccess.Read);
                            BinaryReader brImg = new BinaryReader(fsImg);
                            Byte[] bytesImg = brImg.ReadBytes((Int32)fsImg.Length);
                            brImg.Close();
                            fsImg.Close();
                            empInfo.ImgPath = bytesImg;
                        }
                        catch (Exception ex)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('File already exist.');", true);

                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Image size too large.');", true);
                        return;
                    }
                }

                empInfo.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                empInfo.JoiningDate = Convert.ToDateTime(txtJoiningDate.Text);
                empInfo.MarStId = Int32.Parse(ddlMaritalSt.SelectedValue);
                empInfo.MName = txtMotherName.Text;
                empInfo.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                empInfo.ModifiedDate = DateTime.Now;
                empInfo.NatiId = Int32.Parse(ddlNationality.SelectedValue);
                empInfo.NID = txtNID.Text;
                empInfo.JobTitleId = Int32.Parse(ddlJobTitle.SelectedValue);
                empInfo.NickName = txtNickName.Text;
                empInfo.PerAdd = txtPermanentAddress.Text;
                empInfo.PerDistrictId = Int32.Parse(ddlPermDistrict.SelectedValue);
                empInfo.PerThanaId = Int32.Parse(ddlPermThana.SelectedValue);
                empInfo.PhoneNo = txtPhoneNo.Text;
                empInfo.PreAdd = txtPresentAddress.Text;
                empInfo.PreDistrictId = Int32.Parse(ddlPresDistrict.SelectedValue);
                empInfo.PreThanaId = Int32.Parse(ddlPresThana.SelectedValue);
                empInfo.ProximityNo = txtProxomityNo.Text;
                empInfo.RegId = Int32.Parse(ddlReligion.SelectedValue);
                empInfo.ReportTo = Int32.Parse(ddlReportTo.SelectedValue);
                empInfo.SecId = Int32.Parse(ddlSection.SelectedValue);

                if (EmpSign.PostedFile.FileName == "")
                {
                    string fn = ViewState["EmpNextSl"] + "-" + System.IO.Path.GetFileName("Signature not given");
                    string SaveLocation = Server.MapPath("EmpSign") + "\\" + fn;
                    try
                    {
                        EmpSign.PostedFile.SaveAs(SaveLocation);
                        FileStream fsSign = new FileStream(SaveLocation, FileMode.Open, FileAccess.Read);
                        BinaryReader brSign = new BinaryReader(fsSign);
                        Byte[] bytesSign = brSign.ReadBytes((Int32)fsSign.Length);
                        brSign.Close();
                        fsSign.Close();
                        empInfo.SignPath = bytesSign;
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('File already exist.');", true);

                    }
                }
                else
                {
                    if (EmpSign.PostedFile.ContentLength > 0 && EmpSign.PostedFile.ContentLength <= 102400000)
                    {
                        string fn = ViewState["EmpNextSl"] + "-" + System.IO.Path.GetFileName(EmpSign.PostedFile.FileName);
                        string SaveLocation = Server.MapPath("EmpSign") + "\\" + fn;
                        try
                        {
                            EmpSign.PostedFile.SaveAs(SaveLocation);
                            FileStream fsSign = new FileStream(SaveLocation, FileMode.Open, FileAccess.Read);
                            BinaryReader brSign = new BinaryReader(fsSign);
                            Byte[] bytesSign = brSign.ReadBytes((Int32)fsSign.Length);
                            brSign.Close();
                            fsSign.Close();
                            empInfo.SignPath = bytesSign;
                        }
                        catch (Exception ex)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('File already exist.');", true);

                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Signature size too large.');", true);
                        return;
                    }
                }



                empInfo.SName = txtSpouseName.Text;

                Li_EmployeeInfoManager.InsertLi_EmployeeInfo(empInfo);

                string message = "Saved successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += Request.Url.AbsoluteUri;
                script += "'; }";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",
                script, true);
            }
            catch (Exception)
            {


            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {


                if (

                    Int32.Parse(ddlBloodGroup.SelectedValue) < 1 ||
                    Int32.Parse(ddlDepartment.SelectedValue) < 1 ||
                    Int32.Parse(ddlDesignation.SelectedValue) < 1 ||
                    Int32.Parse(ddlJobCategory.SelectedValue) < 1 ||
                    Int32.Parse(ddlGender.SelectedValue) < 1 ||
                    Int32.Parse(ddlInfoStatus.SelectedValue) < 1 ||
                    Int32.Parse(ddlMaritalSt.SelectedValue) < 1 ||
                    Int32.Parse(ddlPermDistrict.SelectedValue) < 1 ||
                    Int32.Parse(ddlPermThana.SelectedValue) < 1 ||
                    Int32.Parse(ddlPresDistrict.SelectedValue) < 1 ||
                    Int32.Parse(ddlPresThana.SelectedValue) < 1 ||
                    Int32.Parse(ddlReligion.SelectedValue) < 1 ||
                    Int32.Parse(ddlReportTo.SelectedValue) < 1 ||
                    Int32.Parse(ddlSection.SelectedValue) < 1

                    )
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Information.');", true);
                    return;
                }


                Li_EmployeeInfo empInfo = new Li_EmployeeInfo();
                empInfo.BGId = Int32.Parse(ddlBloodGroup.SelectedValue);
                //empInfo.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                //empInfo.CreatedDate = DateTime.Now;


                if (EmpCv.PostedFile.FileName == "")
                {
                    string fn = ViewState["EmpSlId"] + "-" + System.IO.Path.GetFileName("CV not given");
                    string SaveLocation = Server.MapPath("EmpCv") + "\\" + fn;
                    try
                    {
                        EmpCv.PostedFile.SaveAs(SaveLocation);

                        FileStream fsCv = new FileStream(SaveLocation, FileMode.Open, FileAccess.Read);
                        BinaryReader brCv = new BinaryReader(fsCv);
                        Byte[] bytesCv = brCv.ReadBytes((Int32)fsCv.Length);
                        brCv.Close();
                        fsCv.Close();
                        empInfo.CvPath = bytesCv;
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('File already exist.');", true);

                    }
                }
                else
                {
                    if (EmpCv.PostedFile.ContentLength > 0 && EmpCv.PostedFile.ContentLength <= 1024000)
                    {
                        string fn = ViewState["EmpSlId"] + "-" + System.IO.Path.GetFileName(EmpCv.PostedFile.FileName);
                        string SaveLocation = Server.MapPath("EmpCv") + "\\" + fn;
                        try
                        {
                            EmpCv.PostedFile.SaveAs(SaveLocation);

                            FileStream fsCv = new FileStream(SaveLocation, FileMode.Open, FileAccess.Read);
                            BinaryReader brCv = new BinaryReader(fsCv);
                            Byte[] bytesCv = brCv.ReadBytes((Int32)fsCv.Length);
                            brCv.Close();
                            fsCv.Close();
                            empInfo.CvPath = bytesCv;
                        }
                        catch (Exception ex)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('File already exist.');", true);

                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('CV size too large.');", true);
                        return;
                    }
                }



                empInfo.DateOfBirth = Convert.ToDateTime(txtDateofBirth.Text);
                empInfo.DepId = Int32.Parse(ddlDepartment.SelectedValue);
                empInfo.DesId = Int32.Parse(ddlDesignation.SelectedValue);
                empInfo.EmailAdd = txtEmailAdd.Text;
                empInfo.EmpAge = decimal.Parse(txtEmployeeAge.Text);
                empInfo.EmploymentStId = Int32.Parse(ddlJobCategory.SelectedValue);
                empInfo.EmpName = txtEmpName.Text;
                empInfo.EmpNameBn = txtEmpNameBn.Text;
                empInfo.EmpSl = Int32.Parse(ViewState["EmpSlId"].ToString());
                empInfo.FName = txtFatherName.Text;
                empInfo.GenId = Int32.Parse(ddlGender.SelectedValue);
                empInfo.IDNo = txtEmpId.Text;

                if (EmpImg.PostedFile.FileName == "")
                {
                    //string fn = ViewState["EmpSlId"] + "-" + System.IO.Path.GetFileName("Image not given");
                    //string SaveLocation = Server.MapPath("EmpImg") + "\\" + fn;
                    try
                    {
                        //EmpImg.PostedFile.SaveAs(SaveLocation);
                        //FileStream fsImg = new FileStream(SaveLocation, FileMode.Open, FileAccess.Read);
                        //BinaryReader brImg = new BinaryReader(fsImg);
                        //Byte[] bytesImg = brImg.ReadBytes((Int32)fsImg.Length);
                        //brImg.Close();
                        //fsImg.Close();
                        //empInfo.ImgPath = bytesImg;

                        Byte[] bytesImg = (byte[])ViewState["imgDet"];
                        empInfo.ImgPath = bytesImg;
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('File already exist.');", true);

                    }
                }
                else
                {
                    if (EmpImg.PostedFile.ContentLength > 0 && EmpImg.PostedFile.ContentLength <= 1024000)
                    {
                        string fn = ViewState["EmpSlId"] + "-" + System.IO.Path.GetFileName(EmpImg.PostedFile.FileName);
                        string SaveLocation = Server.MapPath("EmpImg") + "\\" + fn;
                        try
                        {
                            EmpImg.PostedFile.SaveAs(SaveLocation);
                            FileStream fsImg = new FileStream(SaveLocation, FileMode.Open, FileAccess.Read);
                            BinaryReader brImg = new BinaryReader(fsImg);
                            Byte[] bytesImg = brImg.ReadBytes((Int32)fsImg.Length);
                            brImg.Close();
                            fsImg.Close();
                            empInfo.ImgPath = bytesImg;
                        }
                        catch (Exception ex)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('File already exist.');", true);

                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Image size too large.');", true);
                        return;
                    }
                }

                empInfo.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                empInfo.JoiningDate = Convert.ToDateTime(txtJoiningDate.Text);
                empInfo.MarStId = Int32.Parse(ddlMaritalSt.SelectedValue);
                empInfo.MName = txtMotherName.Text;
                empInfo.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                empInfo.ModifiedDate = DateTime.Now;
                empInfo.NatiId = Int32.Parse(ddlNationality.SelectedValue);
                empInfo.NID = txtNID.Text;
                empInfo.JobTitleId = Int32.Parse(ddlJobTitle.SelectedValue);
                empInfo.NickName = txtNickName.Text;
                empInfo.PerAdd = txtPermanentAddress.Text;
                empInfo.PerDistrictId = Int32.Parse(ddlPermDistrict.SelectedValue);
                empInfo.PerThanaId = Int32.Parse(ddlPermThana.SelectedValue);
                empInfo.PhoneNo = txtPhoneNo.Text;
                empInfo.PreAdd = txtPresentAddress.Text;
                empInfo.PreDistrictId = Int32.Parse(ddlPresDistrict.SelectedValue);
                empInfo.PreThanaId = Int32.Parse(ddlPresThana.SelectedValue);
                empInfo.ProximityNo = txtProxomityNo.Text;
                empInfo.RegId = Int32.Parse(ddlReligion.SelectedValue);
                empInfo.ReportTo = Int32.Parse(ddlReportTo.SelectedValue);
                empInfo.SecId = Int32.Parse(ddlSection.SelectedValue);

                if (EmpSign.PostedFile.FileName == "")
                {
                    //string fn = ViewState["EmpSlId"] + "-" + System.IO.Path.GetFileName("Signature not given");
                    //string SaveLocation = Server.MapPath("EmpSign") + "\\" + fn;
                    try
                    {
                        //EmpSign.PostedFile.SaveAs(SaveLocation);
                        //FileStream fsSign = new FileStream(SaveLocation, FileMode.Open, FileAccess.Read);
                        //BinaryReader brSign = new BinaryReader(fsSign);
                        //Byte[] bytesSign = brSign.ReadBytes((Int32)fsSign.Length);
                        //brSign.Close();
                        //fsSign.Close();
                        //empInfo.SignPath = bytesSign;

                        Byte[] bytesSign = (byte[])ViewState["SignDet"];
                        empInfo.SignPath = bytesSign;
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('File already exist.');", true);

                    }
                }
                else
                {
                    if (EmpSign.PostedFile.ContentLength > 0 && EmpSign.PostedFile.ContentLength <= 102400000)
                    {
                        string fn = ViewState["EmpSlId"] + "-" + System.IO.Path.GetFileName(EmpSign.PostedFile.FileName);
                        string SaveLocation = Server.MapPath("EmpSign") + "\\" + fn;
                        try
                        {
                            EmpSign.PostedFile.SaveAs(SaveLocation);
                            FileStream fsSign = new FileStream(SaveLocation, FileMode.Open, FileAccess.Read);
                            BinaryReader brSign = new BinaryReader(fsSign);
                            Byte[] bytesSign = brSign.ReadBytes((Int32)fsSign.Length);
                            brSign.Close();
                            fsSign.Close();
                            empInfo.SignPath = bytesSign;
                        }
                        catch (Exception ex)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('File already exist.');", true);

                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Signature size too large.');", true);
                        return;
                    }
                }



                empInfo.SName = txtSpouseName.Text;

                Li_EmployeeInfoManager.UpdateLi_EmployeeInfo(empInfo);

                string message = "Update successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += Request.Url.AbsoluteUri;
                script += "'; }";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",
                script, true);
            }
            catch (Exception)
            {


            }
        }


        protected void gvEmployeeInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvEmployeeInfo.SelectedRow;
                ViewState["EmpSlId"] = row.Cells[1].Text;

                DataTable dtTable = Li_EmployeeInfoManager.LoadGvEmployeeInfoByEmpId(Int32.Parse(ViewState["EmpSlId"].ToString()));


               txtEmpId.Text = dtTable.Rows[0]["IDNo"].ToString();
               txtProxomityNo.Text = dtTable.Rows[0]["ProximityNo"].ToString();
               txtEmpName.Text = dtTable.Rows[0]["EmpName"].ToString();
               txtEmpNameBn.Text = dtTable.Rows[0]["EmpNameBn"].ToString();
               txtNickName.Text = dtTable.Rows[0]["NickName"].ToString();
               ddlDepartment.SelectedValue = dtTable.Rows[0]["DepId"].ToString();
               ddlDesignation.SelectedValue = dtTable.Rows[0]["DesId"].ToString();
               ddlSection.SelectedValue = dtTable.Rows[0]["SecId"].ToString();
               ddlGender.SelectedValue = dtTable.Rows[0]["GenId"].ToString();
               ddlBloodGroup.SelectedValue = dtTable.Rows[0]["BGId"].ToString();
               ddlReligion.SelectedValue = dtTable.Rows[0]["RegId"].ToString();
               ddlNationality.SelectedValue = dtTable.Rows[0]["NatiId"].ToString();
               ddlJobCategory.SelectedValue = dtTable.Rows[0]["JobCatId"].ToString();
               ddlJobTitle.SelectedValue = dtTable.Rows[0]["JobTiId"].ToString();
               ddlReportTo.SelectedValue = dtTable.Rows[0]["JobTiId"].ToString();

               txtDateofBirth.Text = DateTime.Parse(dtTable.Rows[0]["DateOfBirth"].ToString()).ToString("yyyy-MM-dd");
               txtJoiningDate.Text = DateTime.Parse(dtTable.Rows[0]["JoiningDate"].ToString()).ToString("yyyy-MM-dd");
               //txtDateofBirth.Text = dtTable.Rows[0]["DateOfBirth"].ToString();
               //txtJoiningDate.Text = dtTable.Rows[0]["JoiningDate"].ToString();
               txtEmployeeAge.Text = dtTable.Rows[0]["EmpAge"].ToString();
               txtPhoneNo.Text = dtTable.Rows[0]["PhoneNo"].ToString();
               ddlMaritalSt.SelectedValue = dtTable.Rows[0]["MarStId"].ToString();


               ViewState["imgDet"] = dtTable.Rows[0]["ImgPath"];
               imgDetail.ImageUrl = "data:image/png;base64," + Convert.ToBase64String((byte[])dtTable.Rows[0]["ImgPath"]);

               ViewState["SignDet"] = dtTable.Rows[0]["SignPath"];
               signDetail.ImageUrl = "data:image/png;base64," + Convert.ToBase64String((byte[])dtTable.Rows[0]["SignPath"]);

               txtPresentAddress.Text = dtTable.Rows[0]["PreAdd"].ToString();
               ddlPresDistrict.SelectedValue = dtTable.Rows[0]["PresDistId"].ToString();
               ddlPresThana.DataSource = li_ThanaManager.Get_ThanaByDistrictID(int.Parse(dtTable.Rows[0]["PresDistId"].ToString()));
               ddlPresThana.DataTextField = "ThanaName";
               ddlPresThana.DataValueField = "ThanaID";
               ddlPresThana.DataBind();
               ddlPresThana.SelectedValue = dtTable.Rows[0]["PresThanaId"].ToString();

               txtPermanentAddress.Text = dtTable.Rows[0]["PerAdd"].ToString();
               ddlPermDistrict.SelectedValue = dtTable.Rows[0]["PermDistId"].ToString();
               ddlPermThana.DataSource = li_ThanaManager.Get_ThanaByDistrictID(int.Parse(dtTable.Rows[0]["PermDistId"].ToString()));
               ddlPermThana.DataTextField = "ThanaName";
               ddlPermThana.DataValueField = "ThanaID";
               ddlPermThana.DataBind();
               ddlPermThana.SelectedValue = dtTable.Rows[0]["PermThanaId"].ToString();


               txtNID.Text = dtTable.Rows[0]["NID"].ToString();
               txtEmailAdd.Text = dtTable.Rows[0]["EmailAdd"].ToString();

            }
            catch (Exception)
            {

            }
        }

        protected void gvEmployeeInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
        }

        protected void lblCv_Click(object sender, EventArgs e)
        {

        }
    }
}