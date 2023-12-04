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
    public partial class Mkt_ChalanDelivery : System.Web.UI.Page
    {
        string FormID = "MF035";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("~/Login.aspx");
            getUserAccess();
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

       
        protected void btnShow_OnClick(object sender, EventArgs e)
        {
            try
            {
               

                DateTime d1 = Convert.ToDateTime(dtpFromDate.Text);
                DateTime d2 = Convert.ToDateTime(dtpToDate.Text);



                int dateDiff = (int)Math.Truncate((d2 - d1).TotalDays);

                if (dateDiff >= 1)
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


                if (dateDiff < 0)
                {
                    string message = "From date cannot be greater than To date.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "');";
                    script += "window.location = '";
                    script += Request.Url.AbsoluteUri;
                    script += "'; }";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);

                }

                string fromdate = d1.ToString("d",
                                 DateTimeFormatInfo.InvariantInfo);

                string todate = d2.ToString("d",
                                 DateTimeFormatInfo.InvariantInfo);

                gvAllChalan.DataSource = li_ChallanManager.Get_AllChallanForDelivery(fromdate, todate, txtFromMemo.Text, txtToMemo.Text).Tables[0];
                //PacketBy.DataSource = Li_PktPacketByManager.GetAllLi_PktPacketBies();
                //CheckedBy.DataSource = Li_PktCheckedByManager.GetAllLi_PktCheckedBies();
                //ReceivedBy.DataSource = Li_PktReceivedByManager.GetAllLi_PktReceivedBies();

                //for (int i = 0; i < gvAllChalan.RowCount; i++)
                {
                    //DataGridViewComboBoxCell PktBycell = (DataGridViewComboBoxCell)(gvAllChalan.Rows[i].Cells["PacketBy"]);
                    //PktBycell.DataSource = Li_PktPacketByManager.GetAllLi_PktPacketBies();
                    //PktBycell.DisplayMember = "PackedBy";

                    //DataGridViewComboBoxCell PktChkcell = (DataGridViewComboBoxCell)(gvAllChalan.Rows[i].Cells["CheckedBy"]);
                    //PktChkcell.DataSource = Li_PktCheckedByManager.GetAllLi_PktCheckedBies();
                    //PktChkcell.DisplayMember = "CheckedBy";

                    //DataGridViewComboBoxCell PktDelicell = (DataGridViewComboBoxCell)(gvAllChalan.Rows[i].Cells["ReceivedBy"]);
                    //PktDelicell.DataSource = Li_PktReceivedByManager.GetAllLi_PktReceivedBies();
                    //PktDelicell.DisplayMember = "ReceivedBy";
                }

                //decimal originalPktQty = 0.0m;
                //decimal originalPktCost = 0.0m;
                //for (int i = 0; i < gvAllChalan.RowCount; i++)
                //{
                //    originalPktQty += decimal.Parse(gvAllChalan.Rows[i].Cells["PacketNo"].Value.ToString());
                //    originalPktCost += (decimal.Parse(gvAllChalan.Rows[i].Cells["PerPacketCost"].Value.ToString()) * decimal.Parse(gvAllChalan.Rows[i].Cells["PacketNo"].Value.ToString()));
                //}


                //txtChalanQty.Text = gvAllChalan.Rows.Count.ToString();
                //txtOriginalPktQty.Text = originalPktQty.ToString();
                //txtOriginalPktCost.Text = originalPktCost.ToString();
              
            }
            catch (Exception ex)
            {
              
            }
        }
    }
}