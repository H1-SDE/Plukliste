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
        public void AddProduct(string productId, string description, int amount)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = _ip;
                builder.UserID = _user;
                builder.Password = _password;
                builder.InitialCatalog = _initialCatalog;

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    String sql = $"INSERT INTO {_tabel} ([ProductID], [Description], [Amount]) VALUES ('{productId}', '{description}', {amount});";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public string GetProduct()
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = _ip;
                builder.UserID = _user;
                builder.Password = _password;
                builder.InitialCatalog = _initialCatalog;

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    String sql = $"SELECT TOP (50) [ProductID], [Description], [Amount] FROM {_tabel} FOR JSON AUTO;";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        var jsonResult = new StringBuilder();
                        SqlDataReader oReader = command.ExecuteReader();
                        while (oReader.Read())
                        {
                            jsonResult.Append(oReader[0]);
                        }
                        return jsonResult.ToString();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return "";
            }
        }

        //Get Product detail based on Product id
        public string GetProduct(int productId)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = _ip;
                builder.UserID = _user;
                builder.Password = _password;
                builder.InitialCatalog = _initialCatalog;

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    String sql = $"SELECT [ProductID], [Description], [Amount] FROM {_tabel} WHERE ProductID='{productId}' FOR JSON AUTO;";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
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
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return "";
            }
        }

        //Update Product detail based on Product id
        public string UpdateProduct(int productId)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = _ip;
                builder.UserID = _user;
                builder.Password = _password;
                builder.InitialCatalog = _initialCatalog;

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    String sql = $"UPDATE {_tabel} WHERE ProductID={productId};";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        connection.Open();
                        command.ExecuteNonQuery();
                        return "success";
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return e.ToString();
            }
        }
    }
}