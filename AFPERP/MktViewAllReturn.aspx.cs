using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class MktViewAllReturn : System.Web.UI.Page
    {
        string FormID = "MF011";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    getUserAccess();
                    AddDefaultFirstRecord();
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
                        Response.Redirect("~/MarketingHome.aspx");
                    }
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
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }
        private void AddDefaultFirstRecord()
        {
      
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "tblViewReturn";
            dt.Columns.Add("ReturnId", typeof(string));
            dt.Columns.Add("LibraryName", typeof(string));
            dt.Columns.Add("LibraryAddress", typeof(string));
            dt.Columns.Add("MemoNo", typeof(string));
            dt.Columns.Add("TotalAmount", typeof (decimal));
            dt.Columns.Add("PacketNo", typeof(int));
            dt.Columns.Add("PerPacketCost", typeof(decimal));
            dt.Columns.Add("AmountReceivable", typeof(decimal));
            dt.Columns.Add("SerialNo", typeof(int));
            dt.Columns.Add("BookReceivedBy", typeof (Int32));
            dr = dt.NewRow();
            dt.Rows.Add(dr);
            ViewState["tblViewReturn"] = dt;
            gvReturn.DataSource = dt;
            gvReturn.DataBind();
           
        }

        protected void btnShow_OnClick(object sender, EventArgs e)
        {
            DateTime dt1 = DateTime.Parse(txtFromDate.Text);
            DateTime dt2 = DateTime.Parse(txtToDate.Text);

            if (dt1.Date > dt2.Date || dt1.Date < dt2.Date)
            {
                string message = "Please select daterange between one day range.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += Request.Url.AbsoluteUri;
                script += "'; }";               
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);
            }
            else
            {
                string fromdate = dt1.ToString("d",
                          DateTimeFormatInfo.InvariantInfo);

                string todate = dt1.ToString("d",
                                 DateTimeFormatInfo.InvariantInfo);


                gvReturn.DataSource = li_ReturnManager.Get_AllReturn(fromdate, todate).Tables[0];
                gvReturn.DataBind();
            }


         
        }
    }
}