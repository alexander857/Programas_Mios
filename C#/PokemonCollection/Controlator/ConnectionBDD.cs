using System.Data;
using Npgsql;

namespace PokemonCollection
{
    public class ConnectionBDD
    {
        private static string cadenaC = "Server=127.0.0.1;" +
                                        "Port=5432;" +
                                        "User Id=postgres;" +
                                        "Password=alex00355519;" +
                                        "Database=PokemonBDD";

        public static DataTable ExecuteQuery(string query)
        {
            NpgsqlConnection conn = new NpgsqlConnection(cadenaC);
            DataSet ds = new DataSet();
            
            conn.Open();
            
            var da = new NpgsqlDataAdapter(query,conn);
            da.Fill(ds);
            
            conn.Close();

            return ds.Tables[0];
        }

        public static void ExecuteNonQuery(string act)
        {
            var conn = new NpgsqlConnection(cadenaC);
            
            conn.Open();
            
            var comm = new NpgsqlCommand(act,conn);
            comm.ExecuteNonQuery();
            
            conn.Close();
        }
    }
}