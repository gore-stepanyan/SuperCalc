using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Web;
using System.IO;
using System.Xml;

namespace SuperCalc
{
    public static class Data
    {
        public static List<string> tableNames = new List<string>(); // Список имён таблиц
        public static DataSet dataSet = new DataSet();

        public static void Import(string fileName)
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + @";Extended Properties='Excel 12.0 XML;HDR=NO'";

            connection.Open();
            DataTable tables = new DataTable();
            tables = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            // Получение имён таблиц
            tableNames.Clear();
            foreach (DataRow dataRow in tables.Rows)
            {
                tableNames.Add(dataRow["TABLE_NAME"].ToString());
            }

            dataSet.Tables.Clear();
            foreach (string tableName in tableNames)
            {
                DataTable dataTable = new DataTable();
                OleDbDataAdapter adapter = new OleDbDataAdapter("select * from [" + tableName + "]", connection);
                adapter.Fill(dataTable);
                dataTable.TableName = tableName;
                dataSet.Tables.Add(dataTable);

                DataRow dataRow;
                int tempColumnCount = dataTable.Columns.Count;
                int rowColumnCount = dataTable.Rows.Count;
                
                for (int i = 0; i < 26 - tempColumnCount; i++)
                {
                    dataTable.Columns.Add();
                }
                for (int i = 0; i < 1000 - rowColumnCount; i++)
                {
                    dataRow = dataTable.NewRow();
                    dataTable.Rows.Add(dataRow);
                }
                for (int i = tempColumnCount; i < 26; i++)
                {
                    dataTable.Rows[999][i] = "\0";
                }
            }

            connection.Close();
            connection.Dispose();
        }
        public static void AddNewDataTable()
        {
            DataTable newDataTable = new DataTable();
            newDataTable.TableName = "Лист" + (dataSet.Tables.Count + 1).ToString();
            DataRow dataRow;
            for (int i = 0; i < 26; i++)
            {
                newDataTable.Columns.Add();
            }
            for (int i = 0; i < 1000; i++)
            {
                dataRow = newDataTable.NewRow();
                newDataTable.Rows.Add(dataRow);
            }
            for (int i = 0; i < 26; i++)
            {
                newDataTable.Rows[999][i] = "\0";
            }
            if (dataSet.Tables.Contains(newDataTable.TableName))
                newDataTable.TableName += (" (копия)");
            dataSet.Tables.Add(newDataTable);
        }

        public static void Open(string fileName)
        {
            dataSet.Tables.Clear();
            dataSet.ReadXml(fileName);
        }

        public static void Save(string path)
        {
            dataSet.WriteXml(path);
        }
    }
}