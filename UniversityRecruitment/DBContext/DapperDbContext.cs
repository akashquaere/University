using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace UniversityRecruitment.DBContext
{
    public class DapperDbContext : IDisposable
    {
        private static string _ConnectionString = null;

        public DapperDbContext()
        {
            _ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ToString();
        }

        public DbConnection GetDbConnection()
        {
            return new SqlConnection(_ConnectionString);
        }

        public string connection()
        {
            try
            {
                return _ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstriing"].ToString();
            }
            catch (Exception)
            {
                //todo error handling  mechanism
                throw;
            }
        }

        public T ExecuteGet<T>(string sp, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection con = GetDbConnection())
            {
                return con.Query<T>(sp, dynamicParameters, commandType: commandType).FirstOrDefault();
            }
        }

        public List<T> ExecuteGetAll<T>(string sp, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection con = GetDbConnection())
            {
                return con.Query<T>(sp, dynamicParameters, commandType: commandType).ToList();
            }
        }

        public T Get<T>(string sp, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection con = GetDbConnection())
            {
                return con.Query<T>(sp, dynamicParameters, commandType: commandType).FirstOrDefault();
            }
        }

        public List<T> GetAll<T>(string sp, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection con = GetDbConnection())
            {
                return con.Query<T>(sp, dynamicParameters, commandType: commandType).ToList();
            }
        }

        public T Execute<T>(string sp, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection con = GetDbConnection())
            {
                return con.Query<T>(sp, dynamicParameters, commandType: commandType).FirstOrDefault();
            }
        }

        public int ExecuteNonQuery(string commandText, params SqlParameter[] commandParameters)
        {
            int k = 0;
            try
            {
                using (var connection = new SqlConnection(_ConnectionString))
                using (var command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(commandParameters);
                    connection.Open();
                    k = command.ExecuteNonQuery();
                }
                return k;
            }
            catch
            {
                return k;
            }
        }

        public DataSet ExecuteQuery(string commandText, params SqlParameter[] parameters)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var connection = new SqlConnection(_ConnectionString))
                using (var command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(ds);
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Code");
                dt.Columns.Add("Remark");
                DataRow dr = dt.NewRow();
                dr["Code"] = "0";
                dr["Remark"] = ex.Message;
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);

            }
            return ds;
        }

        public DataSet GetSqlDataSet(string Proc, SqlParameter[] param)
        {
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Proc, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    foreach (SqlParameter p in param)
                    {
                        cmd.Parameters.Add(p);
                    }

                    connection.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    connection.Close();

                }


            }
            return ds;


        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}