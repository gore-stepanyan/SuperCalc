using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SuperCalc
{
    public static class Expression
    {
        public static string Evaluate(string expression, int table)
        {
            if (expression.Contains("СУММА:"))
            {
                return Sum(expression, table);
            }
            if (expression.Contains("СЧЁТ:"))
            {
                return Count(expression, table);
            }
            if (expression.Contains("МАКС:"))
            {
                return Max(expression, table);
            }
            if (expression.Contains("МИН:"))
            {
                return Min(expression, table);
            }

            Replace(ref expression, table);
            object result;
            using (var dataTable = new DataTable())
            {
                try
                {
                    expression = expression.Replace(',', '.'); // Культурные особенности
                    result = dataTable.Compute(expression, null);
                }
                catch 
                {
                    result = null;
                }
            }
            if (result == null)
                return null;

            return result.ToString().Replace('.', ','); // Культурные особенности
        }

        private static void Replace(ref string expression, int table)
        {
            List<string> adressList = expression.Split('%', '&' , '*', ' ', '(', ')', '-', '+', '=', '/').ToList();
            foreach (string adress in adressList)
            {
                if (adress == "")
                    continue;
                if (char.IsLetter(adress[0]))
                    expression = expression.Replace(adress, Find(adress, table));
            }
        }

        private static string Find(string adress, int table)
        {
            int columnIndex = adress[0] - 'A' + 1;
            int rowIndex;
            if (!int.TryParse(adress.Remove(0, 1), out rowIndex))
            {
                return null;
            }
            else 
            {
                return Data.dataSet.Tables[table].Rows[rowIndex - 1][columnIndex - 1].ToString();
            }
        }

        private static string Sum(string expression, int table)
        {
            int columnIndex = expression[6] - 'A' + 1;

            double result = 0;
            double temp;
            try
            {
                foreach (DataRow dataRow in Data.dataSet.Tables[table].Rows)
                {

                    double.TryParse(dataRow[columnIndex - 1].ToString(), out temp);
                    result += temp;
                }
            }
            catch
            {
                return null;
            }
            return result.ToString().Replace('.', ',');
        }

        private static string Count(string expression, int table)
        {
            int columnIndex = expression[5] - 'A' + 1;

            double result = 0;
            foreach (DataRow dataRow in Data.dataSet.Tables[table].Rows)
            {

                if (dataRow[columnIndex - 1].ToString() == "" || dataRow[columnIndex - 1].ToString() == "\0")
                    continue;
                result++;
            }
            return result.ToString();
        }

        private static string Max(string expression, int table)
        {
            int columnIndex = expression[5] - 'A' + 1;

            double result = 0;
            double temp;
            try
            {
                foreach (DataRow dataRow in Data.dataSet.Tables[table].Rows)
                {
                    double.TryParse(dataRow[columnIndex - 1].ToString(), out temp);
                    if (temp > result)
                        result = temp;
                }
            }
            catch
            {
                return null;
            }
            return result.ToString().Replace('.', ',');
        }

        private static string Min(string expression, int table)
        {
            int columnIndex = expression[4] - 'A' + 1;

            double result = double.MaxValue;
            double temp;
            try
            {
                foreach (DataRow dataRow in Data.dataSet.Tables[table].Rows)
                {
                    if (dataRow[columnIndex - 1].ToString() == "" || dataRow[columnIndex - 1].ToString() == "\0")
                        continue;
                    double.TryParse(dataRow[columnIndex - 1].ToString(), out temp);
                    if (temp < result)
                        result = temp;
                }
            }
            catch
            {
                return null;
            }
            return result.ToString().Replace('.', ',');
        }
    }
}
