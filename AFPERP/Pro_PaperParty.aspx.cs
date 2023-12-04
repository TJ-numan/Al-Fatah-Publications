using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Pro_PaperParty : System.Web.UI.Page
    {
        string FormID = "PF016";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserID"] == null)
                Response.Redirect("~/Login.aspx");
            getUserAccess();
            if (!IsPostBack)
            {
                LoadToGridAllPaperPartyInfo();
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
                        btnPaperSave.Enabled = true;
                    }
                    else
                    {
                        btnPaperSave.Enabled = false;
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

        private void LoadToGridAllPaperPartyInfo()
        {
            try
            {
                gvwPaperParty.DataSource = Li_PaperPartyManager.GetAllLi_PaperParties();
                gvwPaperParty.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        protected void gvwPaperParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvwPaperParty.SelectedRow;
                ViewState["PartyID"] = row.Cells[1].Text;

                DataTable dtPartyInfo = Li_PaperPartyManager.GetAllLi_PestingPartyInfoByID(ViewState["PartyID"].ToString()).Tables[0];

                txtPaperPartyID.Text = dtPartyInfo.Rows[0]["ID"].ToString();
                txtPaperPartyName.Text = dtPartyInfo.Rows[0]["Name"].ToString();
                txtPaperPartyName_Bn.Text = dtPartyInfo.Rows[0]["Name_Bn"].ToString();
                txtPaperAddress.Text = dtPartyInfo.Rows[0]["Address"].ToString();
                txtPaperAddress_Bn.Text = dtPartyInfo.Rows[0]["Address_Bn"].ToString();
                txtPaperPhone.Text = dtPartyInfo.Rows[0]["Phone"].ToString();
                txtPaperOpeningBalance.Text = dtPartyInfo.Rows[0]["O_Balance"].ToString();
            }
            catch (Exception)
            {

            }
        }

        protected void gvwPaperParty_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
        }

        protected void btnPaperSave_Click(object sender, EventArgs e)
        {
            try
            {
                Li_PaperParty party = new Li_PaperParty();
                party.Name = txtPaperPartyName.Text;
                party.Name_Bn = txtPaperPartyName_Bn.Text;
                party.Address = txtPaperAddress.Text;
                party.Address_Bn = txtPaperAddress_Bn.Text;
                party.CreatedBy = int.Parse(Session["UserID"].ToString());
                party.CreatedDate = DateTime.Now;
                party.O_Balance = txtPaperOpeningBalance.Text != "" ? decimal.Parse(txtPaperOpeningBalance.Text) : 0.0m;
                party.Phone = txtPaperPhone.Text;
                txtPaperPartyID.Text = Li_PaperPartyManager.InsertLi_PaperParty(party);

                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);
                ClearData();

                gvwPaperParty.DataSource = Li_PaperPartyManager.GetAllLi_PaperParties();
                gvwPaperParty.DataBind();

            }
            catch (Exception ex)
            {
                
            }

        }

        protected void btnPaperUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Li_PaperParty party = new Li_PaperParty();
                party.ID = txtPaperPartyID.Text;
                party.Name = txtPaperPartyName.Text;
                party.Name_Bn = txtPaperPartyName_Bn.Text;
                party.Address = txtPaperAddress.Text;
                party.Address_Bn = txtPaperAddress_Bn.Text;
                party.CreatedBy = int.Parse(Session["UserID"].ToString());
                party.CreatedDate = DateTime.Now;
                party.O_Balance = txtPaperOpeningBalance.Text != "" ? decimal.Parse(txtPaperOpeningBalance.Text) : 0.0m;
                party.Phone = txtPaperPhone.Text;
                Li_PaperPartyManager.UpdateLi_PaperParty(party);

                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Update Successfully');", true);
                ClearData();

                gvwPaperParty.DataSource = Li_PaperPartyManager.GetAllLi_PaperParties();
                gvwPaperParty.DataBind();

            }
            catch (Exception )
            {

            }
        }

        private void ClearData()
        {
            txtPaperPartyName.Text = "";
            txtPaperPartyName_Bn.Text = "";
            txtPaperAddress.Text = "";
            txtPaperAddress_Bn.Text = "";
            txtPaperOpeningBalance.Text = "";
            txtPaperPhone.Text = "";

        }

        protected void gvwPaperParty_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvwPaperParty.PageIndex = e.NewPageIndex;
            gvwPaperParty.DataSource = Li_PaperPartyManager.GetAllLi_PaperParties();
            gvwPaperParty.DataBind();
        }
    }
}