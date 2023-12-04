using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class RndDatewiseWorkOrderBillGenerate : System.Web.UI.Page
    {
        string FormID = "MF036";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");

                if (!IsPostBack)
                {
                    getUserAccess();
                    string toDay = DateTime.Now.ToString("yyyy-MM-dd");
                    dtpFromDate.Text = toDay;
                    dtpToDate.Text = toDay;
                    gvDateWiseMRSheet.DataSource = Li_MRSheetManager.Get_DateWiseMRSheet(dtpFromDate.Text, dtpToDate.Text, false);
                    gvDateWiseMRSheet.DataBind();

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
                        btnShow.Enabled = true;
                    }
                    else
                    {
                        btnShow.Enabled = false;
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

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                //gvDateWiseMRSheet.DataSource = Li_MRSheetManager.Get_DateWiseMRSheet(dtpFromDate.Text, dtpToDate.Text,false);
                gvDateWiseMRSheet.DataBind();



            }
            catch (Exception)
            {

            }
        }

        protected void gvDateWiseMRSheet_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
        }

        protected void gvDateWiseMRSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvDateWiseMRSheet.SelectedRow;

                string MRId = row.Cells[0].Text;
                bool isSend = Convert.ToBoolean(row.Cells[6].Text);
                //Response.Redirect("~/MktMRSheetUpdate.aspx?SheetNo=" + MRId + "&SendBefore=" + isSend + "&HeldUp=" + false);
            }
            catch (Exception)
            {


            }

        }
    }
}