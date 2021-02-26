using HtmlAgilityPack;
using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
namespace Bunk_Mate
{
    public class HTMLToDataTable
    {
        private const RegexOptions ExpressionOptions = RegexOptions.Singleline | RegexOptions.Multiline | RegexOptions.IgnoreCase;

        private const string CommentPattern = "<!--(.*?)-->";
        private const string TablePattern = "<table[^>]*>(.*?)</table>";
        private const string HeaderPattern = "<th[^>]*>(.*?)</th>";
        private const string RowPattern = "<tr[^>]*>(.*?)</tr>";
        private const string CellPattern = "<td[^>]*>(.*?)</td>";

        
        public static DataTable ParseTable(string tableHtml)
        {
            string tableHtmlWithoutComments = WithoutComments(tableHtml);

            DataTable dataTable = new DataTable();

            MatchCollection rowMatches = Regex.Matches(
                tableHtmlWithoutComments,
                RowPattern,
                ExpressionOptions);

            dataTable.Columns.AddRange(tableHtmlWithoutComments.Contains("<th")
                                           ? ParseColumns(tableHtml)
                                           : GenerateColumns(rowMatches));

            ParseRows(rowMatches, dataTable);
            int rowscount = dataTable.Rows.Count;
            int coloumnscount = dataTable.Columns.Count;
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(tableHtml);
            string[] colounmnNames = new string[coloumnscount];
            int k = 0;
            var headers = doc.DocumentNode.SelectNodes("//tr/th");



           
            { 
                foreach (var header in headers)
                {
                    string a = header.InnerText.Remove(0, 2);
                    a = a.Remove(a.Length - 4);
                    colounmnNames[k] = a;
                    k = k + 1;
                }
            }
           

            for (int i = 0; i <= dataTable.Rows.Count-1; i++)
                
            { for (int j = 0; j <= dataTable.Columns.Count-1; j++)
                {
                    double result;
                    
                    if (double.TryParse(dataTable.Rows[i][j].ToString(), out result))
                    {
                        dataTable.Columns[j].DataType = typeof(double);
                        dataTable.Rows[i][j] = Sorting.removespan(result.ToString());

                    }
                    else
                    {
                        dataTable.Rows[i][j] = Sorting.removespan(dataTable.Rows[i][j].ToString());
                    }

                 }

            }
            
            for (int l = 0; l <= dataTable.Columns.Count - 1; l++)
            {
              

                    dataTable.Columns[l].ColumnName = colounmnNames[l];
             
               
                dataTable.Columns[l].ReadOnly = true;
                bool equls = (Regex.Matches(colounmnNames[l], "#37;").Count > 0);
                if (equls)
                {
                    dataTable.Columns[l].ColumnName = "%";
                }
              
                dataTable.Columns[l].ReadOnly = true;
            }
                return dataTable;
        }

      private static string WithoutComments(string html)
        {
            return Regex.Replace(html, CommentPattern, string.Empty, ExpressionOptions);
        }

         private static void ParseRows(MatchCollection rowMatches, DataTable dataTable)
        {
            foreach (Match rowMatch in rowMatches)
            {
                
                if (!rowMatch.Value.Contains("<th"))
                {
                    DataRow dataRow = dataTable.NewRow();

                    MatchCollection cellMatches = Regex.Matches(
                        rowMatch.Value,
                        CellPattern,
                        ExpressionOptions);

                    for (int columnIndex = 0; columnIndex < cellMatches.Count; columnIndex++)
                    {
                        dataRow[columnIndex] = cellMatches[columnIndex].Groups[1].ToString();
                    }

                    dataTable.Rows.Add(dataRow);
                }
            }
        }

        private static DataColumn[] ParseColumns(string tableHtml)
        {
            MatchCollection headerMatches = Regex.Matches(
                tableHtml,
                HeaderPattern,
                ExpressionOptions);

            return (from Match headerMatch in headerMatches
                    select new DataColumn(headerMatch.Groups[1].ToString())).ToArray();
        }
  private static DataColumn[] GenerateColumns(MatchCollection rowMatches)
        {
            int columnCount = Regex.Matches(
                rowMatches[0].ToString(),
                CellPattern,
                ExpressionOptions).Count;

            return (from index in Enumerable.Range(0, columnCount)
                    select new DataColumn("Column " + Convert.ToString(index))).ToArray();
        }
    }
}