using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Marketing;
using Common.Marketing;
using System.Data;
using BLL.Classes;

namespace BLL
{
    public partial class Dist_UpdateChalanPacket : System.Web.UI.Page
    {
        string FormID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    getUserAccess();
                    LoadLibrary();
                   
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
                    if (Boolean.Parse(dt.Rows[0]["View_"].ToString()) == false)
                    {
                        Response.Redirect("~/DistributionHome.aspx");
                    }
                    if (Boolean.Parse(dt.Rows[0]["Insert_"].ToString()) == true)
                    {
                        //btnPrint.Enabled = true;
                    }
                    else
                    {
                        //btnPrint.Enabled = false;
                    }
                    if (Boolean.Parse(dt.Rows[0]["Update_"].ToString()) == true)
                    {
                        btnUpdate.Enabled = true;
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
                //Response.Redirect("~/DistributionHome.aspx");
            }
        }
        private void LoadLibrary()
        {

            try
            {
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
        protected void txtMemoNo_OnSelectedTextChanged(object sender, EventArgs e)
                {
                    try
                    {
                        if (ddlCom.SelectedValue == "A")
                        {
                            if (txtMemoNo.Text != string.Empty)
                            {
                                string memoNo = txtMemoNo.Text;
                                List<li_Challan> challanInfo = li_ChallanManager.GetChallanInformationByMemoNo(memoNo);
                                if (challanInfo.Count == 0)
                                {
                                    string message = "Memo No is not valid for Alia or 7 Days Over";
                                    string script = "window.onload = function(){ alert('";
                                    script += message;
                                    script += "');";
                                    script += "window.location = '";
                                    script += Request.Url.AbsoluteUri;
                                    script += "'; }";
                                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",
                                    script, true);
                                }
                                else
                                {
                                    foreach (var information in challanInfo)
                                    {
                                        txtMemoDate.Text = string.Format("{0:yyyy-MM-dd}", information.CreatedDate);
                                        TotalAmount.Text = information.TotalAmount.ToString();
                                        PacketNo.Text = information.PacketNo.ToString();
                                        PerPacketCost.Text = information.PerPacketCost.ToString();
                                        ReceivableAmount.Text = information.AmountReceivable.ToString();
                                        ddlLibraryName.SelectedValue = information.LibraryID;
                                    }
                                }
                            }
                        }
                        else if (ddlCom.SelectedValue == "Q") 
                        {
                            if (txtMemoNo.Text != string.Empty)
                            {
                                string memoNo = txtMemoNo.Text;
                                List<li_Challan> challanInfo = li_ChallanManager.GetChallanInformationByMemoNoQ(memoNo);
                                if (challanInfo.Count == 0)
                                {
                                    string message = "Memo No is not valid for Qawmi or 7 Days Over";
                                    string script = "window.onload = function(){ alert('";
                                    script += message;
                                    script += "');";
                                    script += "window.location = '";
                                    script += Request.Url.AbsoluteUri;
                                    script += "'; }";
                                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",
                                    script, true);
                                }
                                else
                                {
                                    foreach (var information in challanInfo)
                                    {
                                        txtMemoDate.Text = string.Format("{0:yyyy-MM-dd}", information.CreatedDate);
                                        TotalAmount.Text = information.TotalAmount.ToString();
                                        PacketNo.Text = information.PacketNo.ToString();
                                        PerPacketCost.Text = information.PerPacketCost.ToString();
                                        ReceivableAmount.Text = information.AmountReceivable.ToString();
                                        ddlLibraryName.SelectedValue = information.LibraryID;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {


                    }
              }
        protected void btnUpdate_OnClick(object sender, EventArgs e)
        {
            if (ddlCom.SelectedValue == "A")
            { 
                if (txtMemoNo.Text != string.Empty)
                {
                    li_Challan challaninfo = new li_Challan();
                    //challaninfo.TotalAmount = TotalAmount.Text != "" ? decimal.Parse(TotalAmount.Text) : 0.0m;
                    challaninfo.PerPacketCost = PerPacketCost.Text != "" ? decimal.Parse(PerPacketCost.Text) : 0.0m;
                    challaninfo.ModifiedBy = int.Parse(Session["UserID"].ToString());
                    challaninfo.ModifiedDate = DateTime.Now;
                    challaninfo.PacketNo = PacketNo.Text != "" ? int.Parse(PacketNo.Text) : 0;
                    challaninfo.AmountReceivable = challaninfo.PacketNo * challaninfo.PerPacketCost;
                    challaninfo.MemoNo = txtMemoNo.Text;

                    li_ChallanManager.UpdateLi_Challan(challaninfo);

                    string message = "Updated successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "');";
                    script += "window.location = '";
                    script += Request.Url.AbsoluteUri;
                    script += "'; }";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",
                    script, true);

                }
            }
            else if (ddlCom.SelectedValue == "Q")
            {
                if (txtMemoNo.Text != string.Empty)
                {
                    li_Challan challaninfo = new li_Challan();
                    //challaninfo.TotalAmount = TotalAmount.Text != "" ? decimal.Parse(TotalAmount.Text) : 0.0m;
                    challaninfo.PerPacketCost = PerPacketCost.Text != "" ? decimal.Parse(PerPacketCost.Text) : 0.0m;
                    challaninfo.ModifiedBy = int.Parse(Session["UserID"].ToString());
                    challaninfo.ModifiedDate = DateTime.Now;
                    challaninfo.PacketNo = PacketNo.Text != "" ? int.Parse(PacketNo.Text) : 0;
                    challaninfo.AmountReceivable = challaninfo.PacketNo * challaninfo.PerPacketCost;
                    challaninfo.MemoNo = txtMemoNo.Text;

                    li_ChallanManager.UpdateLi_ChallanQ(challaninfo);

                    string message = "Updated successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "');";
                    script += "window.location = '";
                    script += Request.Url.AbsoluteUri;
                    script += "'; }";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",
                    script, true);

                }
            }
        }

        //protected void changeAmountReceivable(object sender, EventArgs e)
        //{
        //    var a = decimal.Parse(TotalAmount.Text);
        //    var v = int.Parse(PacketNo.Text);
        //    var m = decimal.Parse(PerPacketCost.Text);
        //    var s = a + (v * m);
        //    ReceivableAmount.Text = s.ToString();

        //}
    
    }
}