using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace BLL
{
    public partial class ACC_MonthlyPF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        string ConnectionStringDB = @"Data Source= 192.168.1.111;
         Initial Catalog=ALFDB_13;
         Persist Security Info=True;
         User ID=sa;Password=12345";
        public DataSet GetAll_EmployeeProvidentFundByCompany(string CompanyId)
        {
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(this.ConnectionStringDB))
            {
                SqlCommand command = new SqlCommand("", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@ID", SqlDbType.VarChar).Value = CompanyId;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();

                return ds;
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = GetAll_EmployeeProvidentFundByCompany("4077").Tables[0];
                gvDatewiseChallan.DataSource = dt;
                gvDatewiseChallan.DataBind();
            }
            catch (Exception)
            {


            }

        }

        protected void btnConvertXML_Click(object sender, EventArgs e)
        {
            try
            {
                gvDatewiseChallan.DataSource = null;
                DataTable dt = new DataTable();
                dt = li_ChallanManager.DatewiseChallan(dtpFromDate.Text, dtpToDate.Text, ddlVoucherType.SelectedIndex == 1 ? true : false, ddlVoucherType.SelectedIndex == 2 ? true : false, ddlVoucherType.SelectedIndex == 3 ? true : false, int.Parse(Session["UserID"].ToString()));
                gvDatewiseChallan.DataSource = dt;
                gvDatewiseChallan.DataBind();

                string ChallanID = dt.Rows[0]["ChallanID"].ToString();
                string memo = dt.Rows[0]["MemoNo"].ToString();
                string LibraryID = dt.Rows[0]["LibraryID"].ToString();
                string amount = Math.Round((0 - Convert.ToDecimal(dt.Rows[0]["AmountReceivable"].ToString())), 0).ToString();

                string TotalAmount = Math.Round(Convert.ToDecimal(dt.Rows[0]["TotalAmount"].ToString()), 0).ToString();

                string TotalPacCost = Math.Round(Convert.ToDecimal(dt.Rows[0]["TotalPacCost"].ToString()), 0).ToString();

                string path = Server.MapPath("~/SalesJournal.xml");

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



                    if (ddlVoucherType.SelectedIndex == 1)
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            writer.WriteStartElement("VOUCHER");
                            writer.WriteAttributeString("REMOTEID", dt.Rows[i]["ChallanID"].ToString());
                            writer.WriteAttributeString("VCHTYPE", "Payroll");
                            writer.WriteAttributeString("ACTION", "Create");
                            writer.WriteAttributeString("OBJVIEW", "Accounting Voucher View");

                            writer.WriteElementString("DATE", Convert.ToDateTime(dt.Rows[i]["CreatedDate"].ToString()).ToString("yyyyMMdd"));
                            writer.WriteElementString("VOUCHERTYPENAME", "Payroll");
                            writer.WriteElementString("VOUCHERNUMBER", dt.Rows[i]["MemoNo"].ToString());

                            writer.WriteElementString("PARTYLEDGERNAME", "Islami Bank Bangladesh Limited");
                            writer.WriteElementString("PERSISTEDVIEW", "Accounting Voucher View");


                            writer.WriteStartElement("ALLLEDGERENTRIES.LIST");
                            writer.WriteElementString("LEDGERNAME", "Islami Bank Bangladesh Limited");
                            writer.WriteElementString("ISDEEMEDPOSITIVE", "Yes");
                            writer.WriteElementString("AMOUNT", "-500");
                            writer.WriteEndElement();// ALLLEDGERENTRIES.LIST End 


                            writer.WriteStartElement("ALLLEDGERENTRIES.LIST");
                            writer.WriteElementString("LEDGERNAME", "G. Contribution of Employee");
                            writer.WriteElementString("ISDEEMEDPOSITIVE", "No");
                            writer.WriteElementString("AMOUNT", "500");
                            writer.WriteStartElement("CATEGORYALLOCATIONS.LIST");
                            writer.WriteElementString("CATEGORY", "Employees");
                            writer.WriteElementString("ISDEEMEDPOSITIVE", "No");
                            writer.WriteStartElement("COSTCENTREALLOCATIONS.LIST");
                            writer.WriteElementString("NAME", "Abdul Aowal");
                            writer.WriteElementString("AMOUNT", "500");
                            writer.WriteEndElement();//COSTCENTREALLOCATIONS.LIST
                            writer.WriteEndElement();// CATEGORYALLOCATIONS.LIST End 
                            writer.WriteEndElement();// ALLLEDGERENTRIES.LIST End 	

                            writer.WriteEndElement();// VOUCHER End 	
                        }
                    }



                    else
                    {

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

        protected void DownloadXML_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Server.MapPath("~/SalesJournal.xml");
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
    }
}