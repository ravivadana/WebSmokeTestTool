using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeTestTool
{
    public static class Extensions
    {
        public static List<string> ExtractFromString(this string text, string startString, string endString)
        {
            List<string> matched = new List<string>();
            int indexStart = 0, indexEnd = 0;
            bool exit = false;
            while (!exit)
            {
                indexStart = text.IndexOf(startString);
                indexEnd = text.IndexOf(endString);
                if (indexStart != -1 && indexEnd != -1)
                {
                    if (indexStart + startString.Length< (indexStart + startString.Length)+(indexEnd - indexStart - startString.Length))
                    {
                        matched.Add(text.Substring(indexStart + startString.Length,
                       indexEnd - indexStart - startString.Length));
                    }
                   
                    text = text.Substring(indexEnd + endString.Length);
                }
                else
                    exit = true;
            }
            return matched;
        }
    }
}
