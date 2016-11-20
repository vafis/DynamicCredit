using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCredit.DAL
{
    public class DAL : IDAL
    {
        private string _connectionString;

        public DAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Task<DataTable> ExecuteCommandAsync(string spName, string filter = "")
        {
            return Task<DataTable>.Factory.StartNew(() =>
            {
                DataTable dt = new DataTable();
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = spName;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@filter", SqlDbType.NVarChar, 100, "filter"));
                        cmd.Parameters[0].Value = filter;
                        cmd.Connection = sqlConn;
                        try
                        {
                            sqlConn.Open();
                            dt.Load(cmd.ExecuteReader());
                        }
                        catch (Exception) { };
                    }
                }
                return dt;
            });

        }
    }
}
