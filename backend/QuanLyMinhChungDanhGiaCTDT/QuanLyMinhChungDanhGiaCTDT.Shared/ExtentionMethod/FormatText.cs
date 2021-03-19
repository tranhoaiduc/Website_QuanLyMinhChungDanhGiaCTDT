using System;

namespace AdminApp.Shared.ExtentionMethod
{
    public static class FormatText
    {
        public static string CapitalizeWord(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return string.Empty;
            }
            string strReturn = "";
            string[] arrayStr = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in arrayStr)
            {
                char[] arrayChar = item.ToCharArray();
                arrayChar[0] = char.ToUpper(arrayChar[0]);
                strReturn += new string(arrayChar) + " ";
            }
            return strReturn.Trim();
        }

        public static string CapitalizeSentences(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return string.Empty;
            }
            string strReturn = "";
            char[] arrayChar = str.ToCharArray();
            arrayChar[0] = char.ToUpper(arrayChar[0]);
            strReturn = new string(arrayChar) + " ";
            return strReturn.Trim();
        }
    }
}