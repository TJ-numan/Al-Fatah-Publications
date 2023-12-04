using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Pro_PlateProcessParty : System.Web.UI.Page
    {
        string FormID = "PF025";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                getUserAccess();
                if (!IsPostBack)
                {
                    gvwAllProcessPartyInfo.DataSource = Li_PlateProcessPartyManager.GetAllLi_PlateProcessParties();
                    gvwAllProcessPartyInfo.DataBind();
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
                        btnProcessSave.Enabled = true;
                    }
                    else
                    {
                        btnProcessSave.Enabled = false;
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

        protected void gvwAllProcessPartyInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row1 = gvwAllProcessPartyInfo.SelectedRow;
                ViewState["Process_PartyID"] = row1.Cells[1].Text;

                DataTable dtPartyInfo = Li_PlateProcessPartyManager.GetLi_PlateProcessPartiesByID(ViewState["Process_PartyID"].ToString()).Tables[0];

                txtProcessID.Text = dtPartyInfo.Rows[0]["ID"].ToString();
                txtProcessPartyName.Text = dtPartyInfo.Rows[0]["Name"].ToString();
                txtProcessPartyName_Bn.Text = dtPartyInfo.Rows[0]["B_Name"].ToString();
                txtProcessPartyAddress.Text = dtPartyInfo.Rows[0]["Address"].ToString();
                txtProcessPartyAddress_Bn.Text = dtPartyInfo.Rows[0]["B_Add"].ToString();
                txtProcessPartyPhone.Text = dtPartyInfo.Rows[0]["Phone"].ToString();
                txtProcessParty_Open_Bal.Text = dtPartyInfo.Rows[0]["O_Balance"].ToString();
                
            }
            catch (Exception)
            {

            }
        }

        protected void gvwAllProcessPartyInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
        }

        protected void btnProcessSave_Click(object sender, EventArgs e)
        {
            try
            {

                Li_PlateProcessParty plateProcess = new Li_PlateProcessParty();
                plateProcess.Address = txtProcessPartyAddress.Text;
                plateProcess.B_Add = txtProcessPartyAddress_Bn.Text;
                plateProcess.CreatedBy = int.Parse(Session["UserID"].ToString()); ;
                plateProcess.CreatedDate = DateTime.Now;
                plateProcess.Name = txtProcessPartyName.Text;
                plateProcess.B_Name = txtProcessPartyName_Bn.Text;
                plateProcess.O_Balance = txtProcessParty_Open_Bal.Text != "" ? decimal.Parse(txtProcessParty_Open_Bal.Text) : 0.0m;
                plateProcess.Phone = txtProcessPartyPhone.Text;
                txtProcessID.Text = Li_PlateProcessPartyManager.InsertLi_PlateProcessParty(plateProcess);

                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);


                gvwAllProcessPartyInfo.DataSource = Li_PlateProcessPartyManager.GetAllLi_PlateProcessParties();
                gvwAllProcessPartyInfo.DataBind();

                txtProcessPartyAddress.Text = "";
                txtProcessPartyAddress_Bn.Text = "";
                txtProcessParty_Open_Bal.Text = "";
                txtProcessPartyPhone.Text = "";
                txtProcessPartyName.Text = "";
                txtProcessPartyName_Bn.Text = "";

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnProcessUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                Li_PlateProcessParty plateProcess = new Li_PlateProcessParty();
                plateProcess.ID = txtProcessID.Text;
                plateProcess.Address = txtProcessPartyAddress.Text;
                plateProcess.B_Add = txtProcessPartyAddress_Bn.Text;
                plateProcess.CreatedBy = int.Parse(Session["UserID"].ToString()); ;
                plateProcess.CreatedDate = DateTime.Now;
                plateProcess.Name = txtProcessPartyName.Text;
                plateProcess.B_Name = txtProcessPartyName_Bn.Text;
                plateProcess.O_Balance = txtProcessParty_Open_Bal.Text != "" ? decimal.Parse(txtProcessParty_Open_Bal.Text) : 0.0m;
                plateProcess.Phone = txtProcessPartyPhone.Text;

                Li_PlateProcessPartyManager.UpdateLi_PlateProcessParty(plateProcess);

                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Update Successfully');", true);


                gvwAllProcessPartyInfo.DataSource = Li_PlateProcessPartyManager.GetAllLi_PlateProcessParties();
                gvwAllProcessPartyInfo.DataBind();

                txtProcessID.Text = "";
                txtProcessPartyAddress.Text = "";
                txtProcessPartyAddress_Bn.Text = "";
                txtProcessParty_Open_Bal.Text = "";
                txtProcessPartyPhone.Text = "";
                txtProcessPartyName.Text = "";
                txtProcessPartyName_Bn.Text = "";

            }
            catch (Exception ex)
            {

            }
        }

    }
}