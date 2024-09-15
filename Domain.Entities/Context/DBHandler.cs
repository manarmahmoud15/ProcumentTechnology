using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
namespace Domain.Entities.Entity
{
    public class DBHandler
    {
        #region Sql  Connection
        // string Query = "";
        SqlCommand cmd;

        public SqlConnection cn;
        SqlDataAdapter db;
        public string ConnectionString = "";
        #endregion

        #region Conestructor

        public DBHandler()
        {
            try
            {

               cn = new SqlConnection("Data Source=10.1.223.51;Initial Catalog=OECDProjects_Test_26-5-2023;Persist Security Info=True;User ID=MOP;Password=P@ssw0rd");//(ConnectionString);
             //  cn = new SqlConnection("Data Source=.;Initial Catalog=OECDProjects;Integrated Security=True;");//(ConnectionString);

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
