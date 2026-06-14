using System.Data;
using System.Reflection;

namespace todoApp.utill.SQL
{
    public class SqlRapper
    {

        private readonly string _connStr ="Server=127.0.0.1, 1477;Database=testdb;User Id=sa2;Password=dlfdltkatk1234;TrustServerCertificate=True;";
        public string ConnStr => _connStr;

        public SqlRapper() { }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            using var executor = new CustomSqlConnection.Builder()
                                              .SetConnectionString(ConnStr)
                                              .SetCommand(sql)
                                              .Build();


            return executor.Fill();
        }

        public List<T> Select<T>(string sql, int timeout = 1) where T : new()
        {
            using var executor = new CustomSqlConnection.Builder()
                                            .SetConnectionString(ConnStr)
                                            .SetCommand(sql)
                                            .SetTimeout(timeout)
                                            .Build();

            DataTable dt = executor.Fill();

            return ConvertToList<T>(dt);
        }

        public T? SelectOne<T>(string sql, int timeout = 1) where T : new()
        {
            return Select<T>(sql, timeout).FirstOrDefault();
        }

        public int Execute(string sql, bool isTran = false)
        {
            using var executor = new CustomSqlConnection.Builder()
                                              .SetConnectionString(ConnStr)
                                              .SetCommand(sql)
                                              .UseTransaction(isTran)
                                              .Build();
            try
            {
                int result = executor.ExecuteNonQuery();
                executor.Commit();

                return result;
            }
            catch
            {
                executor.Rollback();
                throw;
            }
        }

        public int Execute(string sql, int timeout, bool isTran = false)
        {
            using var executor = new CustomSqlConnection.Builder()
                                              .SetConnectionString(ConnStr)
                                              .SetCommand(sql)
                                              .SetTimeout(timeout)
                                              .UseTransaction(isTran)
                                              .Build();

            try
            {
                int result = executor.ExecuteNonQuery();
                executor.Commit();

                return result;
            }
            catch
            {
                executor.Rollback();
                throw;
            }
        }

        public int Execute(List<string> sqls, bool isTran = false)
        {
            using var executor = new CustomSqlConnection.Builder()
                                              .SetConnectionString(ConnStr)
                                              .SetCommand(sqls)
                                              .UseTransaction(isTran)
                                              .Build();
            try
            {
                int result = executor.ExecuteNonQuery();
                executor.Commit();

                return result;
            }
            catch
            {
                executor.Rollback();
                throw;
            }
        }

        public int Execute(List<string> sqls, int timeout, bool isTran = false)
        {
            using var executor = new CustomSqlConnection.Builder()
                                              .SetConnectionString(ConnStr)
                                              .SetCommand(sqls)
                                              .SetTimeout(timeout)
                                              .UseTransaction(isTran)
                                              .Build();

            try
            {
                int result = executor.ExecuteNonQuery();
                executor.Commit();

                return result;
            }
            catch
            {
                executor.Rollback();
                throw;
            }
        }

        public static List<T> ConvertToList<T>(DataTable dt) where T : new()
        {
            List<T> result = new();

            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (DataRow row in dt.Rows)
            {
                T item = new();

                foreach (PropertyInfo property in properties)
                {
                    if (!dt.Columns.Contains(property.Name))
                    {
                        continue;
                    }

                    object value = row[property.Name];

                    if (value == DBNull.Value)
                    {
                        continue;
                    }

                    Type targetType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

                    object convertedValue = Convert.ChangeType(value, targetType);

                    property.SetValue(item, convertedValue);
                }

                result.Add(item);
            }

            return result;
        }
    }
}