using System.Text;
using System.Data.SqlClient;

namespace Lager_dal
{
    public class LagerData
    {
        internal string _ip = "10.130.54.80";
        internal string _password = "S3cur3P@ssW0rd!";
        internal string _user = "SA";
        internal string _initialCatalog = "Lager";
        internal string _tabel = "Lager";

        public string AddProduct(string productId, string description, int amount)
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
                String sql = $"INSERT INTO {_tabel} ([ProductID], [Description], [Amount]) VALUES ('{productId}', '{description}', {amount});";

                using SqlCommand command = new(sql, connection);
                connection.Open();
                command.ExecuteNonQuery();
                return "success";
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return "ProductID need to be unique!!";

            }
        }

        public string GetProduct()
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
                String sql = $"SELECT TOP (50) [ProductID], [Description], [Amount] FROM {_tabel} FOR JSON AUTO;";

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
                return e.ToString();
            }
        }

        //Get Product detail based on Product id
        public string GetProduct(string productId)
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
                String sql = $"SELECT [ProductID], [Description], [Amount] FROM {_tabel} WHERE ProductID='{productId}' FOR JSON AUTO;";

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

        public int GetProductCount(string productId)
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
                String sql = $"SELECT [Amount] FROM {_tabel} WHERE ProductID='{productId}';";

                using SqlCommand command = new(sql, connection);
                connection.Open();
                SqlDataReader oReader = command.ExecuteReader();

                string res = "";
                while (oReader.Read())
                {
                    int i = 0;
                    res += oReader[i];
                }
                try { 
                    return Convert.ToInt32(res.ToString());
                } catch { return -1; }
                
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return -1;
            }
        }
        //Update Product detail based on Product id
        public string UpdateProduct(string productId, string title, int amount)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = _ip;
                builder.UserID = _user;
                builder.Password = _password;
                builder.InitialCatalog = _initialCatalog;

                using SqlConnection connection = new SqlConnection(builder.ConnectionString);
                String sql = $"UPDATE {_tabel} SET [Description]='{title}', [Amount]={amount} WHERE ProductID='{productId}';";

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