using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lager_dal
{
    public class Kundedata
    {
        internal string _ip = "10.130.54.80";
        internal string _password = "S3cur3P@ssW0rd!";
        internal string _user = "SA";
        internal string _initialCatalog = "Lager";
        internal string _tabel = "Kunde";

        //columns
        internal string _nameColumn = "Navn";
        internal string _adresseColumn = "Adresse";
        internal string _kundeIDColumn = "KundeID";

        public void AddCostummer(string name, string adresse)
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
                String sql = $"INSERT INTO {_tabel} ([{_nameColumn}], [{_adresseColumn}]) VALUES ('{name}', '{adresse}');";

                using SqlCommand command = new(sql, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());

            }
        }

        public string GetCustomers()
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
                String sql = $"SELECT TOP (50) [{_kundeIDColumn}], [{_nameColumn}], [{_adresseColumn}] FROM {_tabel} FOR JSON AUTO;";

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

        //Get Customer detail based on Customer id
        public string GetCustomer(int customerId)
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
                String sql = $"SELECT [{_kundeIDColumn}], [{_nameColumn}], [{_adresseColumn}] FROM {_tabel} WHERE {_kundeIDColumn}='{customerId}' FOR JSON AUTO;";

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
        public string UpdateCostumer(string name, string adresse, int kundeId)
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
                String sql = $"UPDATE {_tabel} SET [{_nameColumn}]='{name}', [{_adresseColumn}]='{adresse}' WHERE {_kundeIDColumn}={kundeId};";

                using SqlCommand command = new(sql, connection);

                connection.Open();
                command.ExecuteNonQuery();
                return "success";
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return e.ToString();
            }
        }
    }
}
