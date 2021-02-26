using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Bunk_Mate
{
    class Sorting
    {
        public static string source;
        public static List<string> GetTables(string content)
        {
            List<string> table = new List<string>();
            List<int> a = new List<int>();
            a.Add(0);
            string str = "";
            List<int> b = new List<int>();
            b.Add(0);
            
            int size = content.Length;
            int count = Regex.Matches(content, "</table>").Count;
            for(int i = 0; i < count; i++)
            {
                a.Add(content.IndexOf("<table ", b[i]));
                b.Add(content.IndexOf("</table>", a[i+1]) + "</table>".Length+1);
                str = str + "\n" + content.Substring(a[i + 1], b[i + 1] - a[i + 1]);
                table.Add(content.Substring(a[i + 1], b[i + 1] - a[i + 1]));
            }
            source = str;
            str=GetContent();
            return table;
        }

        public static string GetContent()
        {
           
            
            return source;
        }
        public static string removespan(string spanedHtml)
        {
            string unspanedstring="";
            int count = Regex.Matches(spanedHtml, "span").Count;
            if (count!=0)
            {
                int startingPoint = spanedHtml.IndexOf("<span");
                int endingPointofSpan = spanedHtml.IndexOf(">");
                int startofend = spanedHtml.LastIndexOf("<");
                unspanedstring = spanedHtml.Substring(endingPointofSpan + 1, startofend - endingPointofSpan - 1);
            }
           
            unspanedstring=unspanedstring.Replace("&nbsp;", "");
            unspanedstring = unspanedstring.Replace("&ndash;", "-");
            unspanedstring = unspanedstring.Replace("&amp;", "&");
            unspanedstring = unspanedstring.Replace("&#35;", "#");
            unspanedstring = unspanedstring.Replace("&#40;"," (");
            unspanedstring = unspanedstring.Replace("&#41;",")");
            unspanedstring = unspanedstring.Replace("&#37;", "%");
            unspanedstring= Regex.Replace(unspanedstring, @"^\s*$\n", string.Empty, RegexOptions.Multiline)
         .TrimEnd();
            return unspanedstring;
        }
        
    }
}
