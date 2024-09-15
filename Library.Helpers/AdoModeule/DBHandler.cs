using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Library.Helpers.AdoModeule
{
    public class DbHandler : DbHandlerGeneric, IDbHandler
    {
        public DbHandler(IConfiguration configuration) 
            :base (configuration, "HotelConnection")
        {
            
        }
    }
    public class DbHandlerGeneric : IDbHandlerGeneric
        {
        #region Sql  Connection
        string Query = "";
        SqlCommand cmd;

        public SqlConnection cn;
        readonly SqlDataAdapter db;
        public string ConnectionString = "";
        private readonly IConfiguration _configuration;

        #endregion

        #region Conestructor

        public DbHandlerGeneric(IConfiguration configuration , string conName)
        {
            _configuration = configuration;

            try
            {
                ConnectionString = _configuration.GetConnectionString(conName);//ConfigurationManager.ConnectionStrings["AlamiaERPConnectionString"].ConnectionString;
                cn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("", cn);
                cmd.CommandTimeout = 200;
                db = new SqlDataAdapter(cmd);
            }
            catch
            {
            }
        }


        #endregion

        #region Stored
        public DataSet ReturnDataset(string Stored, params string[] p)
        {

            cmd = new SqlCommand(Stored, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet tbl = new DataSet();
            for (int i = 0; i < p.Length; i = i + 2)
            {
                if (p[i + 1].Length < 1)
                    cmd.Parameters.Add(new SqlParameter(p[i], DBNull.Value));
                else
                    cmd.Parameters.Add(new SqlParameter(p[i], p[i + 1]));
            }

            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            try
            {

                db.SelectCommand = cmd;
                db.Fill(tbl);
                if (cn.State == ConnectionState.Open) cn.Close();
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open) cn.Close();
                throw ex;
            }
            return tbl;
        }

        public DataSet ReturnDataSetWithParam(string Stored, SqlParameter[] p)
        {
            cmd = new SqlCommand(Stored, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet tbl = new DataSet();
            if (!p.Equals(null))
            {
                for (int i = 0; i < p.Length; i++)
                {
                    cmd.Parameters.Add(p[i]);
                }
            }
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            try
            {
                db.SelectCommand = cmd;
                db.Fill(tbl);
                if (cn.State == ConnectionState.Open) cn.Close();
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open) cn.Close();
                throw ex;
            }
            return tbl;

        }

        public DataTable ReturnTableS(string Stored, SqlParameter[] p)
        {

            cmd = new SqlCommand(Stored, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable tbl = new DataTable();
            if (!p.Equals(null))
            {
                for (int i = 0; i < p.Length; i++)
                {
                    cmd.Parameters.Add(p[i]);
                }
            }
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            try
            {

                db.SelectCommand = cmd;
                db.Fill(tbl);
                if (cn.State == ConnectionState.Open) cn.Close();
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open) cn.Close();
                throw ex;
            }
           // var res = tbl.Rows.Count;
            //var res2 = tbl.Rows[0]["pp"];
                return tbl;
        }
        public DataTable ReturnTableS(string Stored, List<SqlParameter> p)
        {

            cmd = new SqlCommand(Stored, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable tbl = new DataTable();
            if (!p.Equals(null))
            {
                foreach (SqlParameter prm in p)
                {
                    cmd.Parameters.Add(prm);
                }
            }
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            try
            {

                db.SelectCommand = cmd;
                db.Fill(tbl);
                if (cn.State == ConnectionState.Open) cn.Close();
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open) cn.Close();
                throw ex;
            }
            return tbl;
        }
        public DataTable ReturnTableS(string Stored, params string[] p)
        {

            cmd = new SqlCommand(Stored, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable tbl = new DataTable();
            for (int i = 0; i < p.Length; i = i + 2)
            {
                if (p[i + 1].Length < 1)
                    cmd.Parameters.Add(new SqlParameter(p[i], DBNull.Value));
                else
                    cmd.Parameters.Add(new SqlParameter(p[i], p[i + 1]));
            }


            if (cn.State == ConnectionState.Closed)
            {
                 cn.Open();
            }
            try
            {

                db.SelectCommand = cmd;
                db.Fill(tbl);
                if (cn.State == ConnectionState.Open) cn.Close();
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open) cn.Close();
                throw ex;
            }
            return tbl;
        }

        public bool ExecuteCommandEvent(string Query)
        {
            int result = 0;

            cmd.CommandText = Query;
            cmd.CommandType = CommandType.Text;
            if (cn.State == ConnectionState.Closed) cn.Open();
            result = cmd.ExecuteNonQuery();
            if (cn.State == ConnectionState.Open) cn.Close();
            return Convert.ToBoolean(result);
        }
        public void ExecuteProcedure(string Stored, params string[] p)
        {
            try
            {
                cmd = new SqlCommand(Stored, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < p.Length; i = i + 2)
                {
                    cmd.Parameters.Add(new SqlParameter(p[i], p[i + 1]));
                }
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
        public bool ExecuteProcedure(string Stored, SqlParameter[] p)
        {
            int result;
            cmd = new SqlCommand(Stored, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 200;
            if (!p.Equals(null))
            {
                for (int i = 0; i < p.Length; i++)
                {
                    cmd.Parameters.Add(p[i]);
                }
            }
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            result = cmd.ExecuteNonQuery();
            if (cn.State == ConnectionState.Open)
                cn.Close();
            return Convert.ToBoolean(result);
        }
        public bool ExecuteProcedure(string Stored, SqlParameter[] p, SqlConnection cn, SqlTransaction trn)
        {

            int result;
            cmd = new SqlCommand(Stored, cn, trn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 200;
            if (!p.Equals(null))
            {
                for (int i = 0; i < p.Length; i++)
                {
                    cmd.Parameters.Add(p[i]);
                }
            }




            result = cmd.ExecuteNonQuery();



            return Convert.ToBoolean(result);
        }
        public DataTable GetTableUsingProcedure(string Stored, params string[] p)
        {

            db.SelectCommand.CommandText = Stored;



            cmd = new SqlCommand(Stored, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < p.Length; i = i + 2)
            {
                cmd.Parameters.Add(new SqlParameter(p[i], p[i + 1]));
            }
            DataTable tbl = new DataTable();
            db.SelectCommand = cmd;
            db.Fill(tbl);
            return tbl;


        }
        public string GetSingelvalue(string Stored, params string[] p)
        {
            try
            {
                cmd = new SqlCommand(Stored, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < p.Length; i = i + 2)
                {
                    cmd.Parameters.Add(new SqlParameter(p[i], p[i + 1]));
                }
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                object obj = cmd.ExecuteScalar();
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                if (obj != DBNull.Value && obj != null)
                    return obj.ToString();
                else
                    return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();

            }
        }
        public string GetSingelvalueQuery(string query, params string[] p)
        {
            try
            {
                cmd = new SqlCommand(query, cn);
                cmd.CommandType = CommandType.Text;
                for (int i = 0; i < p.Length; i = i + 2)
                {
                    cmd.Parameters.Add(new SqlParameter(p[i], p[i + 1]));
                }
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                object obj = cmd.ExecuteScalar();
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                if (obj != DBNull.Value && obj != null)
                    return obj.ToString();
                else
                    return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();

            }
        }


        /// <summary>
        /// the function used to get single value from stored procedure use return function to return data from stored
        /// </summary>
        /// <param name="Stored"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public string GetSingelvalue_SQLReturnValue(string Stored, params string[] p)
        {
            try
            {
                cmd = new SqlCommand(Stored, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < p.Length; i = i + 2)
                {
                    cmd.Parameters.Add(new SqlParameter(p[i], p[i + 1]));
                }
                var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                cmd.ExecuteNonQuery();
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                var result = returnParameter.Value;
                return result.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();

            }
        }

        public string GetSingelvalue_SQLReturnValue(string Stored, SqlParameter[] p)
        {
            try
            {
                cmd = new SqlCommand(Stored, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (!p.Equals(null))
                {
                    for (int i = 0; i < p.Length; i++)
                    {
                        cmd.Parameters.Add(p[i]);
                    }
                }

                //using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                //{
                //    DataSet ds = new DataSet();
                //    adp.Fill(ds); //get select list from temp table

                //    //get output param list
                //    var p2 = cmd.Parameters["@P"].Value.ToString();
                //    var pp2 = cmd.Parameters["@P2"].Value.ToString();

                //    //var p2 = cmd.Parameters["@ReturnVal"].Value.ToString();
                //    //var pp2 = cmd.Parameters["@ReturnVal2"].Value.ToString();

                //}

                var returnParameter = cmd.Parameters.Add("@P", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                cmd.ExecuteNonQuery();

                var ppp = cmd.Parameters["@P"].Value.ToString();

                var ppp2 = cmd.Parameters["@P2"].Value.ToString();

                if (cn.State == ConnectionState.Open)
                    cn.Close();
                var result = returnParameter.Value;
                return result.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();

            }
        }

        public DataTable GetOutputvalues(string Stored, SqlParameter[] p, SqlParameter[] pOutput)
        {
            try
            {
                cmd = new SqlCommand(Stored, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                 for (int i = 0; i < p.Length; i++)
                {
                    cmd.Parameters.Add(p[i]);
                }
                
               if (cn.State == ConnectionState.Closed)
                    cn.Open();
                cmd.ExecuteNonQuery();

               
                var table = new DataTable();
                foreach (var item in pOutput)
                {
                    table.Columns.Add(item.ParameterName, GetClrType(item.SqlDbType)  );
                  var val =  cmd.Parameters[item.ParameterName].Value.ToString();
                }
               
                var ppp = cmd.Parameters["@P"].Value.ToString();

                var ppp2 = cmd.Parameters["@P2"].Value.ToString();

                if (cn.State == ConnectionState.Open)
                    cn.Close();
               
                return table;
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();

            }
        }
        public static Type GetClrType(SqlDbType sqlType)
        {
            switch (sqlType)
            {
                case SqlDbType.BigInt:
                    return typeof(long?);

                case SqlDbType.Binary:
                case SqlDbType.Image:
                case SqlDbType.Timestamp:
                case SqlDbType.VarBinary:
                    return typeof(byte[]);

                case SqlDbType.Bit:
                    return typeof(bool?);

                case SqlDbType.Char:
                case SqlDbType.NChar:
                case SqlDbType.NText:
                case SqlDbType.NVarChar:
                case SqlDbType.Text:
                case SqlDbType.VarChar:
                case SqlDbType.Xml:
                    return typeof(string);

                case SqlDbType.DateTime:
                case SqlDbType.SmallDateTime:
                case SqlDbType.Date:
                case SqlDbType.Time:
                case SqlDbType.DateTime2:
                    return typeof(DateTime?);

                case SqlDbType.Decimal:
                case SqlDbType.Money:
                case SqlDbType.SmallMoney:
                    return typeof(decimal?);

                case SqlDbType.Float:
                    return typeof(double?);

                case SqlDbType.Int:
                    return typeof(int);

                case SqlDbType.Real:
                    return typeof(float?);

                case SqlDbType.UniqueIdentifier:
                    return typeof(Guid?);

                case SqlDbType.SmallInt:
                    return typeof(short?);

                case SqlDbType.TinyInt:
                    return typeof(byte?);

                case SqlDbType.Variant:
                case SqlDbType.Udt:
                    return typeof(object);

                case SqlDbType.Structured:
                    return typeof(DataTable);

                case SqlDbType.DateTimeOffset:
                    return typeof(DateTimeOffset?);

                default:
                    throw new ArgumentOutOfRangeException("sqlType");
            }
        }
        public string GetSingelvalue(string Stored, SqlParameter[] p)
        {



            cmd = new SqlCommand(Stored, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 200;
            if (!p.Equals(null))
            {
                for (int i = 0; i < p.Length; i++)
                {
                    cmd.Parameters.Add(p[i]);
                }
            }
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            object obj;
            try
            {
                obj = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            if (cn.State == ConnectionState.Open)
                cn.Close();
            if (obj != DBNull.Value && obj != null)
                return obj.ToString();
            else
                return "";
        }

        public string GetSingelvalue(string Stored, List<SqlParameter> p)
        {
            cmd = new SqlCommand(Stored, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 200;
            if (!p.Equals(null))
            {
                foreach (SqlParameter prm in p)
                {
                    cmd.Parameters.Add(prm);
                }
            }
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            object obj = cmd.ExecuteScalar();
            if (cn.State == ConnectionState.Open)
                cn.Close();
            if (obj != DBNull.Value && obj != null)
                return obj.ToString();
            else
                return "";
        }

        #endregion

    }
}
