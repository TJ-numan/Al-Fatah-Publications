using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace BLL
{
    public partial class Acc_DatewiseReturn : System.Web.UI.Page
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
                    int year = DateTime.Now.Year;
                    int month = DateTime.Now.Month;
                    int day = DateTime.Now.Day;

                    if (month >= 11)
                    {
                        var mydate = new DateTime(year, 11, 01);

                        dtpFromDate.Text = String.Format("{0:yyyy/MM/dd}", mydate);
                    }

                    else
                    {
                        var mydate = new DateTime(year - 1, 11, 01);
                        dtpFromDate.Text = String.Format("{0:yyyy-MM-dd}", mydate);
                    }
                    dtpToDate.Text = String.Format("{0:yyyy-MM-dd}", DateTime.Now);
                }
            }
            catch (Exception)
            {

            }
        }
        DataAccessObject DAO = new DataAccessObject();

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
                        Response.Redirect("~/AccountsHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }

        protected void btnConvertXML_Click(object sender, EventArgs e)
        {
            try
            {
                 
                DataTable dt = new DataTable();
                dt = li_ReturnManager.DatewiseReturn (dtpFromDate.Text, dtpToDate.Text,  txtMemoFrom.Text == "" ? 0 : Int32.Parse(txtMemoFrom.Text),txtMemoTo.Text == "" ? 0 : Int32.Parse(txtMemoTo.Text), chkQawmi.Checked,int.Parse(Session["UserID"].ToString()));
  
                string path = Server.MapPath("~/ReturnJournal.xml");

                using (XmlWriter writer = XmlWriter.Create(path))
                {
                    writer.WriteStartElement("ENVELOPE");

                    writer.WriteStartElement("HEADER");
                    writer.WriteElementString("TALLYREQUEST", "Import Data");
                    writer.WriteEndElement();

                    writer.WriteStartElement("BODY");
                    writer.WriteStartElement("IMPORTDATA");

                    writer.WriteStartElement("REQUESTDESC");
                    writer.WriteElementString("REPORTNAME", "Vouchers");
                    writer.WriteEndElement(); // REQUESTDESC End 	


                    writer.WriteStartElement("REQUESTDATA");


                    writer.WriteStartElement("TALLYMESSAGE");

                    writer.WriteAttributeString("xmlns", "UDF", null, "TallyUDF");

                    if (chkQawmi. Checked  ==  false)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            writer.WriteStartElement("VOUCHER");
                            writer.WriteAttributeString("REMOTEID", dt.Rows[i]["ReturnID"].ToString());
                            writer.WriteAttributeString("VCHTYPE", "RTN");
                            writer.WriteAttributeString("ACTION", "Create");
                            writer.WriteAttributeString("OBJVIEW", "Accounting Voucher View");

                            writer.WriteElementString("DATE", Convert.ToDateTime(dt.Rows[i]["ReturnDate"].ToString()).ToString("yyyyMMdd"));
                            writer.WriteElementString("VOUCHERTYPENAME", "RTN");
                            writer.WriteElementString("VOUCHERNUMBER", dt.Rows[i]["MemoNo"].ToString());

                            writer.WriteElementString("PARTYLEDGERNAME", dt.Rows[i]["LibraryID"].ToString());
                            writer.WriteElementString("PERSISTEDVIEW", "Accounting Voucher View");



                            writer.WriteStartElement("ALLLEDGERENTRIES.LIST");
                            writer.WriteElementString("LEDGERNAME", "11");
                            writer.WriteElementString("ISDEEMEDPOSITIVE", "Yes");
                            writer.WriteElementString("AMOUNT", Math.Round(0 - Convert.ToDecimal(dt.Rows[i]["TotalAmount"].ToString()), 0).ToString());
                            writer.WriteEndElement();// ALLLEDGERENTRIES.LIST End 	


                            writer.WriteStartElement("ALLLEDGERENTRIES.LIST");
                            writer.WriteElementString("LEDGERNAME", "33");
                            writer.WriteElementString("ISDEEMEDPOSITIVE", "No");
                            writer.WriteElementString("AMOUNT", Math.Round(Convert.ToDecimal(dt.Rows[i]["TotalPacCost"].ToString()), 0).ToString());
                            writer.WriteEndElement();// ALLLEDGERENTRIES.LIST End 



                            writer.WriteStartElement("ALLLEDGERENTRIES.LIST");
                            writer.WriteElementString("LEDGERNAME", "13");
                            writer.WriteElementString("ISDEEMEDPOSITIVE", "No");
                            writer.WriteElementString("AMOUNT", Math.Round(Convert.ToDecimal(dt.Rows[i]["TotalDiscount"].ToString()), 0).ToString());
                            writer.WriteEndElement();// ALLLEDGERENTRIES.LIST End 




                            writer.WriteStartElement("ALLLEDGERENTRIES.LIST");
                            writer.WriteElementString("LEDGERNAME", dt.Rows[i]["LibraryID"].ToString());
                            writer.WriteElementString("ISDEEMEDPOSITIVE", "No");
                            writer.WriteElementString("AMOUNT", Math.Round(( Convert.ToDecimal(dt.Rows[i]["AmountReceivable"].ToString())), 0).ToString());
                            writer.WriteEndElement();// ALLLEDGERENTRIES.LIST End 


                            writer.WriteEndElement();// VOUCHER End 	
                        }
                    }
 

                    else 
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            writer.WriteStartElement("VOUCHER");
                            writer.WriteAttributeString("REMOTEID", dt.Rows[i]["ReturnID"].ToString());
                            writer.WriteAttributeString("VCHTYPE", "RTN");
                            writer.WriteAttributeString("ACTION", "Create");
                            writer.WriteAttributeString("OBJVIEW", "Accounting Voucher View");

                            writer.WriteElementString("DATE", Convert.ToDateTime(dt.Rows[i]["ReturnDate"].ToString()).ToString("yyyyMMdd"));
                            writer.WriteElementString("VOUCHERTYPENAME", "RTN");
                            writer.WriteElementString("VOUCHERNUMBER", dt.Rows[i]["MemoNo"].ToString());

                            writer.WriteElementString("PARTYLEDGERNAME", dt.Rows[i]["LibraryID"].ToString() + "Q");
                            writer.WriteElementString("PERSISTEDVIEW", "Accounting Voucher View");





                            writer.WriteStartElement("ALLLEDGERENTRIES.LIST");
                            writer.WriteElementString("LEDGERNAME", "10");
                            writer.WriteElementString("ISDEEMEDPOSITIVE", "Yes");
                            writer.WriteElementString("AMOUNT", Math.Round(0-Convert.ToDecimal(dt.Rows[i]["TotalAmount"].ToString()), 0).ToString());
                            writer.WriteEndElement();// ALLLEDGERENTRIES.LIST End 	



                            writer.WriteStartElement("ALLLEDGERENTRIES.LIST");
                            writer.WriteElementString("LEDGERNAME", "33");
                            writer.WriteElementString("ISDEEMEDPOSITIVE", "No");
                            writer.WriteElementString("AMOUNT", Math.Round(Convert.ToDecimal(dt.Rows[i]["TotalPacCost"].ToString()), 0).ToString());
                            writer.WriteEndElement();// ALLLEDGERENTRIES.LIST End 


                            writer.WriteStartElement("ALLLEDGERENTRIES.LIST");
                            writer.WriteElementString("LEDGERNAME", "13");
                            writer.WriteElementString("ISDEEMEDPOSITIVE", "No");
                            writer.WriteElementString("AMOUNT", Math.Round(Convert.ToDecimal(dt.Rows[i]["TotalDiscount"].ToString()), 0).ToString());
                            writer.WriteEndElement();// ALLLEDGERENTRIES.LIST End 


                            writer.WriteStartElement("ALLLEDGERENTRIES.LIST");
                            writer.WriteElementString("LEDGERNAME", dt.Rows[i]["LibraryID"].ToString() + "Q");
                            writer.WriteElementString("ISDEEMEDPOSITIVE", "No");
                            writer.WriteElementString("AMOUNT", Math.Round((Convert.ToDecimal(dt.Rows[i]["AmountReceivable"].ToString())), 0).ToString());
                            writer.WriteEndElement();// ALLLEDGERENTRIES.LIST End 
                            writer.WriteEndElement();// VOUCHER End 	
                        }
                    }



                     



                    writer.WriteEndElement();// TALLYMESSAGE End 		
                    writer.WriteEndElement();// REQUESTDATA End 	
                    writer.WriteEndElement();// IMPORTDATA End 		
                    writer.WriteEndElement();// Body End 
                    writer.WriteEndElement();// ENVELOPE End 
                    writer.Flush();

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

            }
            catch (Exception)
            {


            }
        }

        protected void btnDownloadXML_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Server.MapPath("~/ReturnJournal.xml");
                System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                response.ClearContent();
                response.Clear();
                response.ContentType = "text/xml";
                response.AddHeader("Content-Disposition", "attachment; filename=" + path + ";");
                response.TransmitFile(path);
                response.Flush();
                response.End();
            }
            catch (Exception)
            {
            }

        }

        ReportDocument rd = new ReportDocument();
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                rd.Load(Server.MapPath(@"~/Reports/MKT/rptDatewiseReturnByDateRange.rpt"));
                //rd.SetDatabaseLogon(DAO.UserID, DAO.Password, DAO.ServerName, DAO.DatabaseName);
                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@fromdate", dtpFromDate.Text);
                rd.SetParameterValue("@todate", dtpToDate.Text);
                rd.SetParameterValue("@MemoFrom", txtMemoFrom.Text == "" ? 0 : Int32.Parse(txtMemoFrom.Text));
                rd.SetParameterValue("@MemoTo", txtMemoTo.Text == "" ? 0 : Int32.Parse(txtMemoTo.Text));
                rd.SetParameterValue("@IsQawmi", chkQawmi.Checked);
                rd.SetParameterValue("@userID", int.Parse(Session["UserID"].ToString()));
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "DatewiseReturnReport");
                rd.Close();
                rd.Dispose();
            }
            catch (Exception ex)
            {


            }
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            try
            {
                rd.Dispose();
            }
            catch (Exception)
            {


            }
        }
    }
}