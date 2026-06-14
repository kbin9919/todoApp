using Microsoft.Data.SqlClient;
using System.Data;

namespace todoApp.utill.SQL
{
    public class CustomSqlConnection : IDisposable
    {
        private readonly SqlConnection _conn;
        private readonly SqlCommand _cmd;
        private readonly SqlTransaction? _tran;

        private CustomSqlConnection(SqlConnection conn, SqlCommand cmd, SqlTransaction? tran = null)
        {
            _conn = conn;
            _cmd = cmd;
            _tran = tran;
        }

        public int ExecuteNonQuery()
        {
            return _cmd.ExecuteNonQuery();
        }

        public DataTable Fill()
        {
            DataTable dt = new DataTable();
            using (var da = new SqlDataAdapter(_cmd))
            {
                da.Fill(dt);
            }
            return dt;
        }

        public void Commit()
        {
            _tran?.Commit();
        }

        public void Rollback()
        {
            _tran?.Rollback();
        }

        public void Dispose()
        {
            _cmd?.Dispose();
            _tran?.Dispose();
            _conn?.Dispose();
        }

        public class Builder
        {
            private readonly SqlConnection conn = new SqlConnection();
            private readonly SqlCommand cmd = new SqlCommand();
            private SqlTransaction? tran = null;
            private bool _useTran = false;

            public Builder SetConnectionString(string connStr)
            {
                conn.ConnectionString = connStr;
                return this;
            }

            public Builder SetCommand(string sql)
            {
                cmd.Connection = conn;
                cmd.CommandText = sql;
                return this;
            }

            public Builder SetCommand(List<string> sqls)
            {
                cmd.Connection = conn;
                foreach (var sql in sqls)
                {
                    cmd.CommandText += sql;
                }
                return this;
            }

            public Builder SetTimeout(int timeout)
            {
                cmd.CommandTimeout = timeout;
                return this;
            }

            public Builder UseTransaction(bool isTran)
            {
                _useTran = isTran;
                return this;
            }

            public CustomSqlConnection Build()
            {
                conn.Open();

                if (_useTran)
                {
                    tran = conn.BeginTransaction();
                    cmd.Transaction = tran;
                }

                return new CustomSqlConnection(conn, cmd, tran);
            }
        }
    }
}