using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Common.Marketing;


public class Sql_li_BookInformationProvider:DataAccessObject
{
	public Sql_li_BookInformationProvider()
    {
    }


    public DataSet GetAll_BookInformationsByClassTyGroupRz(string CategoryID, int ClassID, int TypeID, int UserID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("Web_SMPM_li_GetALLBookByGroupClassTypeRz", connection);
            command.CommandType = CommandType.StoredProcedure;



            command.Parameters.Add("@CatID", SqlDbType.VarChar).Value = CategoryID;



            if (ClassID > 0)
            {
                command.Parameters.Add("@ClassID", SqlDbType.Int).Value = ClassID;
            }
            if (ClassID == 0)
            {
                command.Parameters.Add("@ClassID", SqlDbType.Int).Value = DBNull.Value;
            }


            if (TypeID > 0)
            {

                command.Parameters.Add("@TypeID", SqlDbType.Int).Value = TypeID;
            }
            if (TypeID == 0)
            {
                command.Parameters.Add("@TypeID", SqlDbType.Int).Value = DBNull.Value;
            }
            command.Parameters.Add("@UserID", SqlDbType.VarChar).Value = UserID;



            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }
    public DataSet GetAll_BookInformationsByClassTyGroup(string  CategoryID,int ClassID,int TypeID)
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetALLBookByGroupClassType", connection);
            command.CommandType = CommandType.StoredProcedure;



            command.Parameters.Add("@CatID", SqlDbType.VarChar).Value = CategoryID;
           


            if (ClassID  > 0)
            {
                command.Parameters.Add("@ClassID", SqlDbType.Int).Value = ClassID;
            }
            if ( ClassID == 0)
            {
                command.Parameters.Add("@ClassID", SqlDbType.Int).Value = DBNull.Value;
            }


            if (TypeID > 0)
            {
                   
            command.Parameters.Add("@TypeID", SqlDbType.Int).Value =   TypeID ;
            }
            if (TypeID == 0)
            {
              command.Parameters.Add("@TypeID", SqlDbType.Int).Value    = DBNull.Value;
            }

            
           

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }
    public DataSet GetAll_BookInformations(string BookID,string BookName)
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_BookInformations", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookID", SqlDbType.VarChar).Value = BookID;
            command.Parameters.Add("@BookName", SqlDbType.VarChar).Value = BookName ;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }
    public DataSet GetEditionByBookID(string BookID)
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetEditionByBookID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookID", SqlDbType.VarChar).Value = BookID;
     
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }
    public DataSet GetEditionByBookIDForRnDWorkOrderAlia(string BookID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetEditionByBookIDForRnDWorkOrderAlia", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookID", SqlDbType.VarChar).Value = BookID;

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }

    public DataSet GetEdition()
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetEdition", connection);
            command.CommandType = CommandType.StoredProcedure;
            //command.Parameters.Add("@BookID", SqlDbType.VarChar).Value = BookID;

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }
    public DataSet GetAll_BookInformationsForEdit(string BookID)
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_Li_BookInformationsForEdit", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookID", SqlDbType.VarChar).Value = BookID;

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public DataSet   GetAll_BookInformationsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_BookInformationsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public DataSet GetBookInByCode(string BookCode)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_BookInfoByBookCode", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode ;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }
    

  public List<li_BookInformation> Get_ComboSourceData_BookInformationsFromReader(IDataReader reader)
    {
        List<li_BookInformation> li_BookInformations = new List<li_BookInformation>();

        while (reader.Read())
        {
            li_BookInformations.Add(Get_ComboSourceData_BookInformationFromReader(reader));
        }
        return li_BookInformations;
    }

    

    public List<li_BookInformation> Get_BookInformationsFromReader(IDataReader reader)
    {
        List<li_BookInformation> li_BookInformations = new List<li_BookInformation>();

        while (reader.Read())
        {
            li_BookInformations.Add(Get_BookInformationFromReader(reader));
        }
        return li_BookInformations;
    }


    public li_BookInformation Get_ComboSourceData_BookInformationFromReader(IDataReader reader)
    {
        try
        {
            li_BookInformation li_BookInformation = new li_BookInformation
                (

                    reader["BookID"].ToString(),
                    reader["BookName"].ToString() 
                     
                );
             return li_BookInformation;
        }
        catch(Exception ex)
        {
            return null;
        }
    }


    public  li_BookInformation Get_BookInformationFromReader(IDataReader reader)
    {
        try
        {
            li_BookInformation li_BookInformation = new li_BookInformation
                (

                    reader["BookID"].ToString(),
                    reader["BookName"].ToString(),
                    
                    (int)reader["ClassID"],
                   
                    (int)  reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)   reader["ModifiedBy"],
                    (DateTime )reader["ModifiedDate"],
                    
                    
                    (int)reader ["BookType"] ,
                    (char )reader ["Group"],
                    reader ["B_Name"].ToString (),
                     (int)reader["Book_Session"] 
                );
             return li_BookInformation;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public li_BookInformation Get_BookInformationByBookID(string  bookID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_BookInformationByBookID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookID", SqlDbType.VarChar).Value = bookID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return Get_BookInformationFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }



    public li_BookInformation Get_BookInformationByBookName(string bookName)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_BookInformationByBookID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookID", SqlDbType.VarChar).Value = bookName;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return Get_BookInformationFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }


    public List<li_BookInformation> Get_BookInformations_ComboSourceDataByBookACCode(string BookAcCode)
 {
     using (SqlConnection connection = new SqlConnection(this.ConnectionString))
     {
         SqlCommand command = new SqlCommand("SMPM_li_GetComboSourceData_BookInformationsByBookAcCode", connection);
         command.CommandType = CommandType.StoredProcedure;
         command.Parameters.Add("@BookAcCode", SqlDbType.VarChar).Value = BookAcCode;
    
         connection.Open();
         IDataReader reader = command.ExecuteReader(CommandBehavior.Default);


         return Get_ComboSourceData_BookInformationsFromReader(reader);
     }
 }

public List<li_BookInformation> Get_BookInformations_ComboSourceData()
 {
     using (SqlConnection connection = new SqlConnection(this.ConnectionString))
     {
         SqlCommand command = new SqlCommand("SMPM_li_GetComboSourceData_BookInformations", connection);
         command.CommandType = CommandType.StoredProcedure;
   
    
         connection.Open();
         IDataReader reader = command.ExecuteReader(CommandBehavior.Default);


         return Get_ComboSourceData_BookInformationsFromReader(reader);
     }
 }
public List<li_BookInformation> Get_BookInformations_ComboSourceData_BySession(string BookGroup, int B_SessionId)
 {
     using (SqlConnection connection = new SqlConnection(this.ConnectionString))
     {
         SqlCommand command = new SqlCommand("SMPM_li_GetComboSourceData_BookInformations_BySession", connection);
         command.CommandType = CommandType.StoredProcedure;
         command.Parameters.Add("@BookGroup", SqlDbType.Char).Value = BookGroup;
         command.Parameters.Add("@B_Session", SqlDbType.Int).Value = B_SessionId;
    
         connection.Open();
         IDataReader reader = command.ExecuteReader(CommandBehavior.Default);


         return Get_ComboSourceData_BookInformationsFromReader(reader);
     }
 }


public List<li_BookInformation> Get_BookInformations_Combo_BySection(int SectionID)
 {
     using (SqlConnection connection = new SqlConnection(this.ConnectionString))
     {
         SqlCommand command = new SqlCommand("SMPM_li_GetComboSourceData_BookInformations_BySection", connection);
         command.CommandType = CommandType.StoredProcedure;
         command.Parameters.Add("@SectionID", SqlDbType.VarChar).Value = SectionID;
    
         connection.Open();
         IDataReader reader = command.ExecuteReader(CommandBehavior.Default);


         return Get_ComboSourceData_BookInformationsFromReader(reader);
     }
 }





 public List<li_BookInformation> Get_BookInformationByCategory(string category)
 {
     using (SqlConnection connection = new SqlConnection(this.ConnectionString))
     {
         SqlCommand command = new SqlCommand("SMPM_li_Get_BookInformationByCategory", connection);
         command.CommandType = CommandType.StoredProcedure;
         command.Parameters.Add("@category", SqlDbType.VarChar).Value = category;
         connection.Open();
         IDataReader reader = command.ExecuteReader(CommandBehavior.Default);
         return Get_BookInformationsFromReader(reader);
     }
 }
 public List<li_BookInformation> Get_BookInformationForRND()
 {
     using (SqlConnection connection = new SqlConnection(this.ConnectionString))
     {
         SqlCommand command = new SqlCommand("SMPM_li_GetBookInfoForRND", connection);
         command.CommandType = CommandType.StoredProcedure;
         
         connection.Open();
         IDataReader reader = command.ExecuteReader(CommandBehavior.Default);


         return Get_BookInformationsFromReader(reader);
     }
 }
 public List<li_BookInformation> Get_BookInformationByCategory_ComboSourceData(string category)
 {
     using (SqlConnection connection = new SqlConnection(this.ConnectionString))
     {
         SqlCommand command = new SqlCommand("SMPM_li_ComboBox_Get_BookInformationByCategory", connection);
         command.CommandType = CommandType.StoredProcedure;
         command.Parameters.Add("@category", SqlDbType.VarChar).Value = category;
         connection.Open();
         IDataReader reader = command.ExecuteReader(CommandBehavior.Default);
         return Get_ComboSourceData_BookInformationsFromReader(reader);
     }
 }



    public void  Insert_BookInformation(li_BookInformation li_BookInformation)
    {

        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Insert_BookInformation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@BookID", SqlDbType.VarChar).Value = li_BookInformation.BookID;
            cmd.Parameters.Add("@BookName", SqlDbType.VarChar).Value = li_BookInformation.BookName;
            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = li_BookInformation.ClassID;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = li_BookInformation.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_BookInformation.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.VarChar).Value = li_BookInformation.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_BookInformation.ModifiedDate;        
            cmd.Parameters.Add("@BookType", SqlDbType.VarChar).Value = li_BookInformation.BookType;
            cmd.Parameters.Add("@BookGroup", SqlDbType.Char).Value = li_BookInformation.BookGroup;
            cmd.Parameters.Add("@B_Name", SqlDbType.Text).Value = li_BookInformation. B_Name ;
            cmd.Parameters.Add("@Book_Session", SqlDbType.Int).Value = li_BookInformation.Book_Session;         
            
            connection.Open();
            cmd.ExecuteNonQuery();
           
        }
    }

    public void Insert_BookInformation_Bangla(li_BookInformation li_BookInformation)
    {




        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Insert_BookInformation_Bangla", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@BookID", SqlDbType.VarChar).Value = li_BookInformation.BookID;//Direction ParameterDirection.Output;
            cmd.Parameters.Add("@BookName", SqlDbType. Text ).Value = li_BookInformation.BookName;           
            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = li_BookInformation.ClassID;     
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = li_BookInformation.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_BookInformation.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.VarChar).Value = li_BookInformation.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_BookInformation.ModifiedDate;
            cmd.Parameters.Add("@BookType", SqlDbType.VarChar).Value = li_BookInformation.BookType;
            cmd.Parameters.Add("@BookGroup", SqlDbType.Char).Value = li_BookInformation.BookGroup;                     
            connection.Open();
            cmd.ExecuteNonQuery();
           
        }
    }

    public bool Update_BookInformation(li_BookInformation li_BookInformation)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Update_BookInformation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BookID", SqlDbType.VarChar).Value = li_BookInformation.BookID;//Direction ParameterDirection.Output;
            cmd.Parameters.Add("@BookName", SqlDbType.VarChar).Value = li_BookInformation.BookName;               
            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = li_BookInformation.ClassID;        
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.VarChar).Value = li_BookInformation.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_BookInformation.ModifiedDate;  
            cmd.Parameters.Add("@BookType", SqlDbType.VarChar).Value = li_BookInformation.BookType;
            cmd.Parameters.Add("@BookGroup", SqlDbType.Char).Value = li_BookInformation.BookGroup;
            cmd.Parameters.Add("@B_Name", SqlDbType.Text).Value = li_BookInformation.B_Name;
            cmd.Parameters.Add("@B_Session", SqlDbType.Int).Value = li_BookInformation.Book_Session;     
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool Delete_BookInformation(int bookID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Delete_BookInformation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BookID", SqlDbType.VarChar).Value = bookID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<BookInformation> GetAll_BookInformations()
    {
        List<BookInformation> informations = new List<BookInformation>();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllBookInformation",connection);
            command.CommandType= CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                BookInformation aBookInformation = new BookInformation();
                aBookInformation.BookId = (string) reader["BookID"];
                aBookInformation.BookName = (string) reader["BookName"];
                aBookInformation.Class = (string) reader["ClassName"];
                aBookInformation.Type = (string) reader["BookType"];
                aBookInformation.InBangla = (string) reader["InBangla"];
                aBookInformation.SessionId = (int) reader["SessionID"];
                aBookInformation.SessionName = reader["SessionName"];
                informations.Add(aBookInformation);
            }
        }
        return informations;
    }
    public DataSet GetAll_BookInformation(string BookName, string BookID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_AllBookInformation", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookID", SqlDbType.VarChar).Value = BookID;
            command.Parameters.Add("@BookName", SqlDbType.VarChar).Value = BookName;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    //--------------------------------------------rezaul Hossain------------------2021-06-01-----------
    public List<li_BookInformation> Get_BookInformations_Combo_BySectionQawmi(int SectionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetComboSourceData_BookInformations_BySectionQawmi", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SectionID", SqlDbType.VarChar).Value = SectionID;

            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);


            return Get_ComboSourceData_BookInformationsFromReader(reader);
        }
    }

    //public DataSet GetAll_BookInformationsByClassTyGroupRz(string CategoryID, int ClassID, int TypeID, int UserID)
    //{
    //    DataSet ds = new DataSet();
    //    using (SqlConnection connection = new SqlConnection(this.ConnectionString))
    //    {
    //        SqlCommand command = new SqlCommand("Web_SMPM_li_GetALLBookByGroupClassTypeRz", connection);
    //        command.CommandType = CommandType.StoredProcedure;



    //        command.Parameters.Add("@CatID", SqlDbType.VarChar).Value = CategoryID;



    //        if (ClassID > 0)
    //        {
    //            command.Parameters.Add("@ClassID", SqlDbType.Int).Value = ClassID;
    //        }
    //        if (ClassID == 0)
    //        {
    //            command.Parameters.Add("@ClassID", SqlDbType.Int).Value = DBNull.Value;
    //        }


    //        if (TypeID > 0)
    //        {

    //            command.Parameters.Add("@TypeID", SqlDbType.Int).Value = TypeID;
    //        }
    //        if (TypeID == 0)
    //        {
    //            command.Parameters.Add("@TypeID", SqlDbType.Int).Value = DBNull.Value;
    //        }
    //        command.Parameters.Add("@UserID", SqlDbType.VarChar).Value = UserID;



    //        connection.Open();
    //        SqlDataAdapter myadapter = new SqlDataAdapter(command);
    //        myadapter.Fill(ds);
    //        myadapter.Dispose();
    //        connection.Close();
    //        return ds;
    //    }
    //}

    public List<li_BookInformation> Get_BookInformations_Combo_BySectionbyUserAndClassID(int UserID, int ClassID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_BookInformations_Combo_BySectionbyUserAndClassID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.VarChar).Value = UserID;
            command.Parameters.Add("@ClassID", SqlDbType.VarChar).Value = ClassID;

            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);


            return Get_ComboSourceData_BookInformationsFromReader(reader);
        }
    }
    public List<li_BookInformation> Get_BookInformationsByCompany(String Comp, int ClassID, int Type)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetComboSourceData_BookByCompany", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Com", SqlDbType.VarChar).Value = Comp;
            command.Parameters.Add("@ClassID", SqlDbType.Int).Value = ClassID;
            command.Parameters.Add("@Type", SqlDbType.Int).Value = Type;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);
            return Get_ComboSourceData_BookInformationsFromReader(reader);
        }
    }
    public List<li_BookInformation> Get_BookInformations_Combo_BySectionForUpdate(int SectionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetComboSourceData_BookInformations_BySectionForUpdate", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SectionID", SqlDbType.VarChar).Value = SectionID;

            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);


            return Get_ComboSourceData_BookInformationsFromReader(reader);
        }
    }
    public List<li_BookInformation> Get_BookInformations_Combo_BySectionbyUserAndClassIDQawmi(int UserID, int ClassID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_BookInformations_Combo_BySectionbyUserAndClassIDQawmi", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.VarChar).Value = UserID;
            command.Parameters.Add("@ClassID", SqlDbType.VarChar).Value = ClassID;

            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);


            return Get_ComboSourceData_BookInformationsFromReader(reader);
        }
    }
    public List<li_BookInformation> Get_BookInformationsByUserAndClassIDForWorkOrderBook(int UserID, int ClassID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_BookInformationsByUserAndClassIDForWorkOrderBookwise", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.VarChar).Value = UserID;
            command.Parameters.Add("@ClassID", SqlDbType.VarChar).Value = ClassID;

            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);


            return Get_ComboSourceData_BookInformationsFromReader(reader);
        }
    }
    //public DataSet GetEditionByBookIDForRnDWorkOrderAlia(string BookID)
    //{
    //    DataSet ds = new DataSet();
    //    using (SqlConnection connection = new SqlConnection(this.ConnectionString))
    //    {
    //        SqlCommand command = new SqlCommand("SMPM_li_GetEditionByBookIDForRnDWorkOrderAlia", connection);
    //        command.CommandType = CommandType.StoredProcedure;
    //        command.Parameters.Add("@BookID", SqlDbType.VarChar).Value = BookID;

    //        connection.Open();
    //        SqlDataAdapter myadapter = new SqlDataAdapter(command);
    //        myadapter.Fill(ds);
    //        myadapter.Dispose();
    //        connection.Close();
    //        return ds;
    //    }
    //}
    public List<li_BookInformation> Get_BookInformations_Combo_ByUserAndClassIDForTeacherEntry(int UserID, int ClassID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("Web_SMPM_li_Get_BookInformations_Combo_ByUserAndClassIDForTeacherEntry", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.VarChar).Value = UserID;
            command.Parameters.Add("@ClassID", SqlDbType.VarChar).Value = ClassID;

            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);


            return Get_ComboSourceData_BookInformationsFromReader(reader);
        }
    }
    public List<li_BookInformation> Get_BookInformations_Combo_BySectionbyUserAndClassIDGraphics(int UserID, int ClassID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("Web_SMPM_li_Get_BookInformations_Combo_BySectionbyUserAndClassIDGraphics", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.VarChar).Value = UserID;
            command.Parameters.Add("@ClassID", SqlDbType.VarChar).Value = ClassID;

            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);


            return Get_ComboSourceData_BookInformationsFromReader(reader);
        }
    }

}

