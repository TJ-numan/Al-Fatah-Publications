using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Pro_PressInfo : System.Web.UI.Page
    {
        string FormID = "PF030";
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["UserID"] == null)
                Response.Redirect("~/Login.aspx");
            getUserAccess();
            gvwPrintingPressInfoData.DataSource = Li_PressInfoManager.GetAllLi_PressInfos();
            gvwPrintingPressInfoData.DataBind();
            txtPrintingPressName.Focus();
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
                        btnPrintingSave.Enabled = true;
                    }
                    else
                    {
                        btnPrintingSave.Enabled = false;
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

        protected void gvwPrintingPressInfoData_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvwPrintingPressInfoData.SelectedRow;
                ViewState["PressID"] = row.Cells[1].Text;

                DataTable dtPartyInfo = Li_PressInfoManager.GetLi_PressPartyInfoByID(ViewState["PressID"].ToString()).Tables[0];

                txtPrintingPressID.Text = dtPartyInfo.Rows[0]["PressID"].ToString();
                txtPrintingPressName.Text = dtPartyInfo.Rows[0]["PressName"].ToString();
                txtPrintingPressNameBn.Text = dtPartyInfo.Rows[0]["Name_Bn"].ToString();
                txtPrintingPressAddress.Text = dtPartyInfo.Rows[0]["Address"].ToString();
                txtPrintingPressAddressBn.Text = dtPartyInfo.Rows[0]["Add_bn"].ToString();
                txtPrintingPressPhone.Text = dtPartyInfo.Rows[0]["Phone"].ToString();
                txtPrintingPressOpBal.Text = dtPartyInfo.Rows[0]["OpeningBalance"].ToString();
            }
            catch (Exception)
            {

            }
        }

        protected void gvwPrintingPressInfoData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));

        }

        protected void btnPrintingSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtPrintingPressName.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please type a Press name.');", true);
                    txtPrintingPressName.Focus();
                    return;
                }

                Li_PressInfo pressinfo = new Li_PressInfo();
                pressinfo.Address = txtPrintingPressAddress.Text;
                pressinfo.CreatedBy = int.Parse(Session["UserID"].ToString());
                pressinfo.CrteatedDate = DateTime.Now;
                pressinfo.OpeningBalance = txtPrintingPressOpBal.Text != "" ? decimal.Parse(txtPrintingPressOpBal.Text) : 0.0m;
                pressinfo.Phone = txtPrintingPressPhone.Text;
                pressinfo.PressName = txtPrintingPressName.Text;
                pressinfo.Add_Bn = txtPrintingPressAddressBn.Text;
                pressinfo.Name_Bn = txtPrintingPressNameBn.Text;
                string result = Li_PressInfoManager.InsertLi_PressInfo(pressinfo);
                txtPrintingPressID.Text = result;

                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);

                ClearData();
                gvwPrintingPressInfoData.DataSource = Li_PressInfoManager.GetAllLi_PressInfos();
                gvwPrintingPressInfoData.DataBind();
                txtPrintingPressName.Focus();
            }
            catch (Exception ex)
            {
                
            }


        }

        private void ClearData()
        {
            txtPrintingPressAddress.Text = "";
            txtPrintingPressAddressBn.Text = "";
            txtPrintingPressOpBal.Text = "";
            txtPrintingPressPhone.Text = "";
            txtPrintingPressName.Text = "";
            txtPrintingPressNameBn.Text = "";
        }

        protected void btnPrintingUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPrintingPressName.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please type a Press name.');", true);
                    txtPrintingPressName.Focus();
                    return;
                }

                Li_PressInfo pressinfo = new Li_PressInfo();
                pressinfo.PressID = txtPrintingPressID.Text;
                pressinfo.Address = txtPrintingPressAddress.Text;
                pressinfo.CreatedBy = int.Parse(Session["UserID"].ToString());
                pressinfo.CrteatedDate = DateTime.Now;
                pressinfo.OpeningBalance = txtPrintingPressOpBal.Text != "" ? decimal.Parse(txtPrintingPressOpBal.Text) : 0.0m;
                pressinfo.Phone = txtPrintingPressPhone.Text;
                pressinfo.PressName = txtPrintingPressName.Text;
                pressinfo.Add_Bn = txtPrintingPressAddressBn.Text;
                pressinfo.Name_Bn = txtPrintingPressNameBn.Text;
                Li_PressInfoManager.UpdateLi_PressInfo(pressinfo);
                 

                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Update Successfully');", true);
                txtPrintingPressID.Text = "";
                ClearData();
                gvwPrintingPressInfoData.DataSource = Li_PressInfoManager.GetAllLi_PressInfos();
                gvwPrintingPressInfoData.DataBind();
                txtPrintingPressName.Focus();

            }
            catch (Exception ex)
            {

            }
        }

        protected void gvwPrintingPressInfoData_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvwPrintingPressInfoData.PageIndex = e.NewPageIndex;
            gvwPrintingPressInfoData.DataSource = Li_PressInfoManager.GetAllLi_PressInfos();
            gvwPrintingPressInfoData.DataBind();
        }
    }
}