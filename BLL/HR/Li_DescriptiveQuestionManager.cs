using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_DescriptiveQuestionManager
{
	public Li_DescriptiveQuestionManager()
	{
	}

    public static List<Li_DescriptiveQuestion> GetAllLi_DescriptiveQuestions()
    {
        List<Li_DescriptiveQuestion> li_DescriptiveQuestions = new List<Li_DescriptiveQuestion>();
        SqlLi_DescriptiveQuestionProvider sqlLi_DescriptiveQuestionProvider = new SqlLi_DescriptiveQuestionProvider();
        li_DescriptiveQuestions = sqlLi_DescriptiveQuestionProvider.GetAllLi_DescriptiveQuestions();
        return li_DescriptiveQuestions;
    }


    public static Li_DescriptiveQuestion GetLi_DescriptiveQuestionByID(int id)
    {
        Li_DescriptiveQuestion li_DescriptiveQuestion = new Li_DescriptiveQuestion();
        SqlLi_DescriptiveQuestionProvider sqlLi_DescriptiveQuestionProvider = new SqlLi_DescriptiveQuestionProvider();
        li_DescriptiveQuestion = sqlLi_DescriptiveQuestionProvider.GetLi_DescriptiveQuestionByID(id);
        return li_DescriptiveQuestion;
    }


    public static int InsertLi_DescriptiveQuestion(Li_DescriptiveQuestion li_DescriptiveQuestion)
    {
        SqlLi_DescriptiveQuestionProvider sqlLi_DescriptiveQuestionProvider = new SqlLi_DescriptiveQuestionProvider();
        return sqlLi_DescriptiveQuestionProvider.InsertLi_DescriptiveQuestion(li_DescriptiveQuestion);
    }


    public static bool UpdateLi_DescriptiveQuestion(Li_DescriptiveQuestion li_DescriptiveQuestion)
    {
        SqlLi_DescriptiveQuestionProvider sqlLi_DescriptiveQuestionProvider = new SqlLi_DescriptiveQuestionProvider();
        return sqlLi_DescriptiveQuestionProvider.UpdateLi_DescriptiveQuestion(li_DescriptiveQuestion);
    }

    public static bool DeleteLi_DescriptiveQuestion(int li_DescriptiveQuestionID)
    {
        SqlLi_DescriptiveQuestionProvider sqlLi_DescriptiveQuestionProvider = new SqlLi_DescriptiveQuestionProvider();
        return sqlLi_DescriptiveQuestionProvider.DeleteLi_DescriptiveQuestion(li_DescriptiveQuestionID);
    }
}
