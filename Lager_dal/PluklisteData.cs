using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lager_dal
{
    internal class PluglisteData
    {
        internal string _ip = "10.130.54.117";
        internal string _password = "S3cur3P@ssW0rd!";
        internal string _user = "SA";
        internal string _initialCatalog = "Lager";
        internal string _tabel = "Plukliste";
        internal string _tabel2 = "Ordre";

        //columns Table
        internal string _tableFakturaNummerColumn = "FakturaNummer";
        internal string _tableKundeIdColumn = "KundeID";
        internal string _tableForsendelseColumn = "Forsendelse";
        internal string _tableLabelColumn = "Label";
        internal string _tablePrintColumn = "Print";



        //columns Table 2
        internal string _table2OrdreIdColumn = "OrdreID";
        internal string _table2ProductIdColumn = "ProductID";
        internal string _table2FakturaNummerColumn = "FakturaNummer";
        internal string _table2AntalColumn = "Antal";


        public void AddPlukliste(int fakturaNummer, int kundeId, string transpotor, int label, string print, List<Item> items)
        {
            try
            {
                SqlConnectionStringBuilder builder = new()
                {
                    DataSource = _ip,
                    UserID = _user,
                    Password = _password,
                    InitialCatalog = _initialCatalog
                };

                foreach (Item item in items)
                {
                    AddItemPlukliste(item, fakturaNummer);
                }

                using SqlConnection connection = new(builder.ConnectionString);
                String sql = $"INSERT INTO {_tabel} ([{_tableFakturaNummerColumn}], [{_tableKundeIdColumn}], [{_tableForsendelseColumn}], [{_tableLabelColumn}], [{_tablePrintColumn}])" +
                    $" VALUES ('{fakturaNummer}', {kundeId}, '{transpotor},  {label}, {print}');";

                using SqlCommand command = new(sql, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());

            }
        }

        public void AddItemPlukliste(Item item, int fakturaNummer)
        {
            try
            {
                SqlConnectionStringBuilder builder = new()
                {
                    DataSource = _ip,
                    UserID = _user,
                    Password = _password,
                    InitialCatalog = _initialCatalog
                };

                using SqlConnection connection = new(builder.ConnectionString);
                string sql;
                sql = $"INSERT INTO {_tabel2} ([{_table2ProductIdColumn}], [{_table2AntalColumn}], [{_table2FakturaNummerColumn}]) VALUES ('{item.ProductID}', {fakturaNummer}, {item.Amount});";
                using SqlCommand command = new(sql, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());

            }
        }

        public string GetPlukliste()
        {
            try
            {
                SqlConnectionStringBuilder builder = new()
                {
                    DataSource = _ip,
                    UserID = _user,
                    Password = _password,
                    InitialCatalog = _initialCatalog
                };

                using SqlConnection connection = new(builder.ConnectionString);
                String sql = $"SELECT FOR JSON AUTO;";

                using SqlCommand command = new(sql, connection);
                connection.Open();
                var jsonResult = new StringBuilder();
                SqlDataReader oReader = command.ExecuteReader();
                while (oReader.Read())
                {
                    jsonResult.Append(oReader[0]);
                }
                return jsonResult.ToString();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return "";
            }
        }

        //Get Plukliste detail based on fakturaNummer
        public string GetPluklisteItems(int fakturaNummer)
        {
            try
            {
                SqlConnectionStringBuilder builder = new()
                {
                    DataSource = _ip,
                    UserID = _user,
                    Password = _password,
                    InitialCatalog = _initialCatalog
                };

                using SqlConnection connection = new(builder.ConnectionString);
                String sql = $"SELECT o.[{_table2ProductIdColumn}], l.[Description], o.[{_table2AntalColumn}], l.[Amount] FROM {_tabel2} AS o INNER JOIN Lager AS l ON (o.[{_table2ProductIdColumn}] = l.ProductID) WHERE FakturaNummer={fakturaNummer} FOR JSON AUTO;";


                using SqlCommand command = new(sql, connection);
                connection.Open();
                var jsonResult = new StringBuilder();
                SqlDataReader oReader = command.ExecuteReader();
                while (oReader.Read())
                {
                    int i = 0;
                    jsonResult.Append(oReader[i]);
                    i++;
                }
                return jsonResult.ToString();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return "";
            }
        }

        //Update Customer detail based on Customer id
        //public string UpdateCostumer(string name, string adresse, int kundeId)
        //{
        //    try
        //    {
        //        SqlConnectionStringBuilder builder = new()
        //        {
        //            DataSource = _ip,
        //            UserID = _user,
        //            Password = _password,
        //            InitialCatalog = _initialCatalog
        //        };

        //        using SqlConnection connection = new(builder.ConnectionString);
        //        String sql = $"UPDATE {_tabel} SET [{_nameColumn}]='{name}', [{_adresseColumn}]={adresse} WHERE {_kundeIDColumn}='{kundeId}';";

        //        using SqlCommand command = new(sql, connection);

        //        connection.Open();
        //        command.ExecuteNonQuery();
        //        return "success";
        //    }
        //    catch (SqlException e)
        //    {
        //        Console.WriteLine(e.ToString());
        //        return e.ToString();
        //    }
        //}
    }
}
