using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.Classes
{
    public class CommonCode
    {
        /*
         LoadComboData.LoadHRInfoStatus(ddlInfoStatus);

        				Int32.Parse(Session["UserID"].ToString());

         * 
         * 
         * 
         * 

                 ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Class');", true);
           
         * 
         * 
         * 
         * 

                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);
				
         * 
         * 
         * 
         * 
				
				    string message = "Saved successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "');";
                    script += "window.location = '";
                    script += Request.Url.AbsoluteUri;
                    script += "'; }";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",
                    script, true);

         * 
         * 
         * 
         * 
         * 
         * 
                             <div class="form-group">
                        <asp:Label AssociatedControlID="ddlViewers" runat="server" CssClass="col-md-4 control-label" Text="View Option" />
                        <div class="dropdown col-md-5">
                            <asp:DropDownList ID="ddlViewers" runat="server" CssClass="form-control">
                                <asp:ListItem Value="0"> Select any type</asp:ListItem>
                                <asp:ListItem Value="1"> View as Pdf File</asp:ListItem>
                                <asp:ListItem Value="2"> View as Excel File</asp:ListItem>
                                <asp:ListItem Value="3"> View as Word File</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
         * 
         * 
         * 
         * 
          
           
           if (ddlViewers.SelectedValue == "0")
                {

                }

                else if (ddlViewers.SelectedValue == "1")
                {
                    rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "AgentStatementReport");
                }

                else if (ddlViewers.SelectedValue == "2")
                {
                    rd.ExportToHttpResponse(ExportFormatType.Excel, Response, false, "AgentStatementReport");
                }


                else if (ddlViewers.SelectedValue == "3")
                {
                    rd.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, false, "AgentStatementReport");
                }

                else
                {

                }

                rd.Close();
                rd.Dispose();
 
         */
    }
}