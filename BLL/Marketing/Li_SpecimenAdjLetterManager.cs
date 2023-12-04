using System;
using System.Collections.Generic;
 
using System.Linq; 
public class Li_SpecimenAdjLetterManager
{
	public Li_SpecimenAdjLetterManager()
	{
	}

    public static List<Li_SpecimenAdjLetter> GetAllLi_SpecimenAdjLetters()
    {
        List<Li_SpecimenAdjLetter> li_SpecimenAdjLetters = new List<Li_SpecimenAdjLetter>();
        SqlLi_SpecimenAdjLetterProvider sqlLi_SpecimenAdjLetterProvider = new SqlLi_SpecimenAdjLetterProvider();
        li_SpecimenAdjLetters = sqlLi_SpecimenAdjLetterProvider.GetAllLi_SpecimenAdjLetters();
        return li_SpecimenAdjLetters;
    }


    public static Li_SpecimenAdjLetter GetLi_SpecimenAdjLetterByID(int id)
    {
        Li_SpecimenAdjLetter li_SpecimenAdjLetter = new Li_SpecimenAdjLetter();
        SqlLi_SpecimenAdjLetterProvider sqlLi_SpecimenAdjLetterProvider = new SqlLi_SpecimenAdjLetterProvider();
        li_SpecimenAdjLetter = sqlLi_SpecimenAdjLetterProvider.GetLi_SpecimenAdjLetterByID(id);
        return li_SpecimenAdjLetter;
    }


    public static int InsertLi_SpecimenAdjLetter(Li_SpecimenAdjLetter li_SpecimenAdjLetter)
    {
        SqlLi_SpecimenAdjLetterProvider sqlLi_SpecimenAdjLetterProvider = new SqlLi_SpecimenAdjLetterProvider();
        return sqlLi_SpecimenAdjLetterProvider.InsertLi_SpecimenAdjLetter(li_SpecimenAdjLetter);
    }


    public static bool UpdateLi_SpecimenAdjLetter(Li_SpecimenAdjLetter li_SpecimenAdjLetter)
    {
        SqlLi_SpecimenAdjLetterProvider sqlLi_SpecimenAdjLetterProvider = new SqlLi_SpecimenAdjLetterProvider();
        return sqlLi_SpecimenAdjLetterProvider.UpdateLi_SpecimenAdjLetter(li_SpecimenAdjLetter);
    }

    public static bool DeleteLi_SpecimenAdjLetter(int li_SpecimenAdjLetterID)
    {
        SqlLi_SpecimenAdjLetterProvider sqlLi_SpecimenAdjLetterProvider = new SqlLi_SpecimenAdjLetterProvider();
        return sqlLi_SpecimenAdjLetterProvider.DeleteLi_SpecimenAdjLetter(li_SpecimenAdjLetterID);
    }
}
