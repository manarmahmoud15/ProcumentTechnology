using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Library.Helpers.AdoModeule
{
    public interface IDbHandler: IDbHandlerGeneric
    {

    }

    
    public interface IDbHandlerGeneric
    {
        #region Stored

        DataSet ReturnDataset(string stored, params string[] p);
        DataSet ReturnDataSetWithParam(string Stored, SqlParameter[] p);

        DataTable ReturnTableS(string stored, SqlParameter[] p);
        DataTable ReturnTableS(string stored, List<SqlParameter> p);
        DataTable ReturnTableS(string stored, params string[] p);
        DataTable GetOutputvalues(string Stored, SqlParameter[] p, SqlParameter[] pOutput);
        bool ExecuteCommandEvent(string query);

        void ExecuteProcedure(string stored, params string[] p);
        bool ExecuteProcedure(string stored, SqlParameter[] p);
        //bool ExecuteProcedure(string Stored, SqlParameter[] p, SqlConnection cn, ransaction trn);
        DataTable GetTableUsingProcedure(string stored, params string[] p);
        string GetSingelvalue(string stored, params string[] p);
        string GetSingelvalueQuery(string query, params string[] p);
        /// <summary>
        /// the function used to get single value from stored procedure use return function to return data from stored
        /// </summary>
        /// <param name="stored"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        string GetSingelvalue_SQLReturnValue(string stored, params string[] p);

        string GetSingelvalue_SQLReturnValue(string stored, SqlParameter[] p);

        string GetSingelvalue(string stored, SqlParameter[] p);

        string GetSingelvalue(string stored, List<SqlParameter> p);

        #endregion

    }
}
