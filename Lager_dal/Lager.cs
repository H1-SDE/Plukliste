using System.Text;
using System.Data.SqlClient;

namespace Lager_dal
{
    public class Lager
    {
        private string _ip = "0.0.0.0";
        private string _password = "S3cur3P@ssW0rd!";
        private string _user = "sa";
        private string _initialCatalog = "Lager";
        private string _tabel = "Lager";
        public void AddEmply(string productId, string description, int amount)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = _ip;
                builder.UserID = _password;
                builder.Password = _user;
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

        public string GetEmply()
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = _ip;
                builder.UserID = _password;
                builder.Password = _user;
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

        //Get Produck detail based on Produck id
        public string GetEmply(int productId)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = _ip;
                builder.UserID = _password;
                builder.Password = _user;
                builder.InitialCatalog = _initialCatalog;

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    String sql = $"SELECT [ProductID], [Description], [Amount] FROM {_tabel} WHERE ProductID={productId} FOR JSON AUTO;";

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

        //Delete Produck detail based on produck id
        public string DeleteEmply(int productId)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = _ip;
                builder.UserID = _password;
                builder.Password = _user;
                builder.InitialCatalog = _initialCatalog;

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    String sql = $"DELETE FROM {_tabel} WHERE ProductID={productId};";

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

        //Update Produck detail based on Produck id
        public string UpdateEmply(int productId)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = _ip;
                builder.UserID = _password;
                builder.Password = _user;
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