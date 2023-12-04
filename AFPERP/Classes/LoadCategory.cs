using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;


namespace BLL.Classes
{
  public   class LoadCategory
    {
      public LoadCategory()
      {
      }

      public static void  LoadBookCategory( DropDownList ddlCategory )
      {

          //DataSet dsLoadCategory = new DataSet();

          //try
          //{


          //    dsLoadCategory.ReadXml("..//" + "PublisherName.xml");
          //}
          //catch (Exception ex)
          //{

          //    dsLoadCategory.ReadXml(System.IO.Path.GetFullPath(Application.StartupPath.ToString() + "//PublisherName.xml"));

          //}
          //cmbCategory.DataSource = dsLoadCategory.Tables[0];
          //cmbCategory.DisplayMember = "publishername";
          //cmbCategory.ValueMember = "publisherid";

      }

      public static void LoadBookGroupBycategory(DropDownList ddlbookGroup, DropDownList ddlbookCategory)
      {
          ddlbookGroup.DataSource = Li_Book_GManager.GetLi_Book_GByID(ddlbookCategory.SelectedValue.ToString());
          ddlbookGroup.DataTextField = "GName";
          ddlbookGroup.DataValueField = "GID";
          ddlbookGroup.DataBind();
      }

      public static void LoadBookCalssByBookGroup(DropDownList ddlClass, DropDownList ddlCategory, DropDownList ddlBookGroup)
      {

          ddlClass.DataSource = Li_ClassesManager.GetAllLi_ClassessByGroup(ddlCategory.SelectedValue.ToString(), Int32.Parse(ddlBookGroup.SelectedValue.ToString()));
          ddlClass.DataTextField = "ClassName";
          ddlClass.DataValueField = "ClassID";
          ddlClass.SelectedIndex = -1;

      }


      public static void LoadBookTypeByClass(DropDownList ddlBookType, DropDownList ddlClass, DropDownList ddlCategory)
      {

          DataSet ds = new DataSet();
          ds = li_BookTypeManager.GetBookTypeByGroupNClass(ddlCategory.SelectedValue.ToString(), ddlClass.SelectedValue != null ? Int32.Parse(ddlClass.SelectedValue.ToString()) : 0);

          Dictionary<string, string> dictionary = new Dictionary<string, string>();


          for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
          {
              dictionary.Add(ds.Tables[0].Rows[i]["BookTypeID"].ToString(), ds.Tables[0].Rows[i]["BookType"].ToString());
          }

          //ddlBookType.DataSource = new ListItem(dictionary, null);
          ddlBookType.DataSource = dictionary;
          ddlBookType.DataTextField = "Value";
          ddlBookType.DataValueField = "Key";
          ddlBookType.SelectedIndex = -1;


      }

      public static void LoadBookByType(DropDownList ddlBookName, DropDownList ddlCategory, DropDownList ddlClass, DropDownList ddlBookType)
      {
          DataSet ds = new DataSet();
          ds = li_BookInformationManager.GetAll_BookInformationsByClassTyGroup(ddlCategory.SelectedValue.ToString(), ddlClass.SelectedIndex < 0 ? 0 : Int32.Parse(ddlClass.SelectedValue.ToString()), ddlBookType.SelectedIndex < 0 ? 0 : Int32.Parse(ddlBookType.SelectedValue.ToString()));

          Dictionary<string, string> dls = new Dictionary<string, string>();

          if (ds.Tables[0].Rows.Count > 0)
          {

              for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
              {
                  dls.Add(ds.Tables[0].Rows[i]["BookID"].ToString(), ds.Tables[0].Rows[i]["BookName"].ToString());
              }

              //ddlBookName.DataSource = new BindingSource(dls, null);
              ddlBookName.DataSource = dls;
              ddlBookName.DataTextField = "Value";
              ddlBookName.DataValueField = "Key";
              ddlBookName.SelectedIndex = -1;

          }

      }

    
      public static void LoadEditionByBookID(DropDownList ddlEdition, DropDownList ddlBookName)
      {
          DataSet ds = new DataSet();
          ds = li_BookInformationManager.GetEditionByBookID(ddlBookName.SelectedValue.ToString());

          Dictionary<string, string> dls = new Dictionary<string, string>();

          if (ds.Tables[0].Rows.Count > 0)
          {

              for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
              {
                  dls.Add(ds.Tables[0].Rows[i]["Edition"].ToString(), ds.Tables[0].Rows[i]["Edition"].ToString());
              }

              //ddlEdition.DataSource = new BindingSource(dls, null);
              ddlEdition.DataSource = dls;
              ddlEdition.DataTextField = "Value";
              ddlEdition.DataValueField = "Key";
              ddlEdition.SelectedIndex = -1;

          }
      }
      public static void LoadBookByTypeRz(DropDownList ddlBookName, DropDownList ddlCategory, DropDownList ddlClass, DropDownList ddlBookType, int UserID)
      {
          DataSet ds = new DataSet();
          ds = li_BookInformationManager.GetAll_BookInformationsByClassTyGroupRz(ddlCategory.SelectedValue.ToString(), ddlClass.SelectedIndex < 0 ? 0 : Int32.Parse(ddlClass.SelectedValue.ToString()), ddlBookType.SelectedIndex < 0 ? 0 : Int32.Parse(ddlBookType.SelectedValue.ToString()), UserID);

          Dictionary<string, string> dls = new Dictionary<string, string>();

          if (ds.Tables[0].Rows.Count > 0)
          {

              for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
              {
                  dls.Add(ds.Tables[0].Rows[i]["BookID"].ToString(), ds.Tables[0].Rows[i]["BookName"].ToString());
              }

              //ddlBookName.DataSource = new BindingSource(dls, null);
              ddlBookName.DataSource = dls;
              ddlBookName.DataTextField = "Value";
              ddlBookName.DataValueField = "Key";
              ddlBookName.SelectedIndex = -1;

          }

      }
      public static void LoadEditionByBookIDForRnDWorkOrderAia(DropDownList ddlEdition, DropDownList ddlBookName)
      {
          DataSet ds = new DataSet();
          ds = li_BookInformationManager.GetEditionByBookIDForRnDWorkOrderAlia(ddlBookName.SelectedValue.ToString());

          Dictionary<string, string> dls = new Dictionary<string, string>();

          if (ds.Tables[0].Rows.Count > 0)
          {

              for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
              {
                  dls.Add(ds.Tables[0].Rows[i]["Edition"].ToString(), ds.Tables[0].Rows[i]["Edition"].ToString());
              }

              //ddlEdition.DataSource = new BindingSource(dls, null);
              ddlEdition.DataSource = dls;
              ddlEdition.DataTextField = "Value";
              ddlEdition.DataValueField = "Key";
              ddlEdition.SelectedIndex = -1;

          }
      }

    }
}
