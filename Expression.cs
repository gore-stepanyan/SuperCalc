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
                    result = "ошибка";
                }
            }
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
            int columntable = adress[0] - 'A' + 1;
            int rowtable;
            if (!int.TryParse(adress.Remove(0, 1), out rowtable))
            {
                return null;
            }
            else 
            {
                return Data.dataSet.Tables[table].Rows[rowtable - 1][columntable - 1].ToString();
            }
        }

        private static void Sum()
        {
            
        }
    }
}
