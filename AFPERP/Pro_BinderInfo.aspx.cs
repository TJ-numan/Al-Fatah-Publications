using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Pro_BinderInfo : System.Web.UI.Page
    {
        string FormID = "PF004";
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    getUserAccess();
                    gvwBinderInfoData.DataSource = Li_BookBinderInfoManager.GetAllLi_BookBinderInfos();
                    gvwBinderInfoData.DataBind();
                    txtBinderName.Focus();
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
                        Response.Redirect("~/ProHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtBinderName.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please Type a Supplier Name.');", true);
                    txtBinderName.Focus();
                    return;
                }


                Li_BookBinderInfo BookBindInfo = new Li_BookBinderInfo();

                BookBindInfo.BinderCode = txtBinderID.Text;
                BookBindInfo.BinderName = txtBinderName.Text;
                BookBindInfo.B_Name = txtBinderNameBn.Text;
                BookBindInfo.Address = txtBinderAddress.Text;
                BookBindInfo.B_Add = txtBinderAddressBn.Text;
                BookBindInfo.Phone = txtPhone.Text;
                BookBindInfo.OpennigBalance = txtOppeningBalance.Text != "" ? Decimal.Parse(txtOppeningBalance.Text) : 0.0m;
                BookBindInfo.CreatedDate = DateTime.Now;
                BookBindInfo.CreatedBy = int.Parse(Session["UserID"].ToString());

                string resutl = Li_BookBinderInfoManager.InsertLi_BookBinderInfo(BookBindInfo);
                txtBinderID.Text = resutl;


                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);
                gvwBinderInfoData.DataSource = Li_BookBinderInfoManager.GetAllLi_BookBinderInfos();
                gvwBinderInfoData.DataBind();
                ClearBoxes();
            }
            catch (Exception ex)
            {
                
            }
        }

        private void ClearBoxes()
        {
            txtBinderAddress.Text = "";
            txtBinderAddressBn.Text="";
            txtBinderName.Text = "";
            txtBinderNameBn.Text = "";
            txtOppeningBalance.Text = "";
            txtPhone.Text = "";
        }

        protected void gvwBinderInfoData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
        }

        protected void gvwBinderInfoData_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvwBinderInfoData.SelectedRow;
                ViewState["BinderCode"] = row.Cells[1].Text;

                DataTable dtPartyInfo = Li_BookBinderInfoManager.GetLi_BookBinderSupInfoByID(ViewState["BinderCode"].ToString()).Tables[0];

                txtBinderID.Text = dtPartyInfo.Rows[0]["BinderCode"].ToString();
                txtBinderName.Text = dtPartyInfo.Rows[0]["BinderName"].ToString();
                txtBinderNameBn.Text = dtPartyInfo.Rows[0]["B_Name"].ToString();
                txtBinderAddress.Text = dtPartyInfo.Rows[0]["Address"].ToString();
                txtBinderAddressBn.Text = dtPartyInfo.Rows[0]["B_Add"].ToString();
                txtPhone.Text = dtPartyInfo.Rows[0]["Phone"].ToString();
                txtOppeningBalance.Text = dtPartyInfo.Rows[0]["OpennigBalance"].ToString();
            }
            catch (Exception)
            {

            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtBinderName.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please Type a Supplier Name.');", true);
                    txtBinderName.Focus();
                    return;
                }


                Li_BookBinderInfo BinderInfo = new Li_BookBinderInfo();

                BinderInfo.BinderCode = txtBinderID.Text;
                BinderInfo.BinderName = txtBinderName.Text;
                BinderInfo.B_Name = txtBinderNameBn.Text;
                BinderInfo.Address = txtBinderAddress.Text;
                BinderInfo.B_Add = txtBinderAddressBn.Text;
                BinderInfo.Phone = txtPhone.Text;
                BinderInfo.OpennigBalance = txtOppeningBalance.Text != "" ? Decimal.Parse(txtOppeningBalance.Text) : 0.0m;
                BinderInfo.CreatedDate = DateTime.Now;
                BinderInfo.CreatedBy = int.Parse(Session["UserID"].ToString());

                Li_BookBinderInfoManager.UpdateLi_BookBinderInfo(BinderInfo);
                


                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Update Successfully');", true);
                txtBinderID.Text = "";
                ClearBoxes();
                gvwBinderInfoData.DataSource = Li_BookBinderInfoManager.GetAllLi_BookBinderInfos();
                gvwBinderInfoData.DataBind();
                txtBinderName.Focus();
            }
            catch (Exception ex)
            {

            }
        }
    }
}