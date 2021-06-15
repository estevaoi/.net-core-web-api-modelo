using System;
using System.Data;
using System.Data.SqlClient;

namespace WebApiModelo.data.DataContext
{
    public class ToJobContext
    {
        public SqlConnection Connection { get; set; }

        public ToJobContext()
        {
            string t = Environment.GetEnvironmentVariable("SQLCONNSTR_CONNECTIONSTRING");
            Connection = new SqlConnection(t);
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
        }
    }
}