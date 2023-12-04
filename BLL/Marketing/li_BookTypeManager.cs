using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;



public class li_BookTypeManager
{
	public li_BookTypeManager()
	{
	}

    public static List<li_BookType> GetAll_BookTypes()
    {
        List<li_BookType> li_BookTypes = new List<li_BookType>();
        Sqlli_BookTypeProvider sql_BookTypeProvider = new Sqlli_BookTypeProvider();
        li_BookTypes = sql_BookTypeProvider.GetAll_BookTypes();
        return li_BookTypes;
    }


    public static li_BookType Get_BookTypeByBookTypeID(int BookTypeID)
    {
        li_BookType li_BookType = new li_BookType();
        Sqlli_BookTypeProvider sqlli_BookTypeProvider = new Sqlli_BookTypeProvider();
        li_BookType = sqlli_BookTypeProvider.Get_BookTypeByBookTypeID(BookTypeID);
        return li_BookType;
    }


    public static int Insert_BookType(li_BookType li_BookType)
    {
        Sqlli_BookTypeProvider sqlli_BookTypeProvider = new Sqlli_BookTypeProvider();
        return sqlli_BookTypeProvider.Insert_BookType(li_BookType);
    }


    public static bool Updateli_BookType(li_BookType li_BookType)
    {
        Sqlli_BookTypeProvider sql_BookTypeProvider = new Sqlli_BookTypeProvider();
        return sql_BookTypeProvider.Update_BookType(li_BookType);
    }

    public static bool Deleteli_BookType(int li_BookTypeID)
    {
        Sqlli_BookTypeProvider sql_BookTypeProvider = new Sqlli_BookTypeProvider();
        return sql_BookTypeProvider.Delete_BookType(li_BookTypeID);
    }


    public static  DataSet GetBookTypeByGroupNClass(string  CatID, int ClassID)
    {
        DataSet ds = new DataSet();
        Sqlli_BookTypeProvider sql_BookTypeProvider = new Sqlli_BookTypeProvider();
        ds = sql_BookTypeProvider.GetBookTypeByGroupNClass(CatID, ClassID);
        return ds;

    }
    
    public static  DataSet GetBookTypeBySessionNClass(int SessionID, int SectionID,int ClassID)
    {
        DataSet ds = new DataSet();
        Sqlli_BookTypeProvider sql_BookTypeProvider = new Sqlli_BookTypeProvider();
        ds = sql_BookTypeProvider. GetBookTypeBySessionNClass(  SessionID,   SectionID,  ClassID) ;
        return ds;

    }
}

