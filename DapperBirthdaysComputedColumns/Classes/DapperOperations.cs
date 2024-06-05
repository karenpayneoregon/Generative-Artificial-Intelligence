using System.Data;
using Dapper;
using kp.Dapper.Handlers;
using Microsoft.Data.SqlClient;

namespace DapperBirthdaysComputedColumns.Classes;
internal class DapperOperations
{
    private readonly IDbConnection _cn;

    public DapperOperations()
    {
        /*
         * This would set the command timeout which will throw a object not set to an instance of an object.
         * I elected to not use this as GitHub Copilot will spit out a good message but not good for this
         * demonstration.
         *
         * For the curious, QueryAsync has an overload for setting timeout but the same results as
         * above as it's on the command not the connection.
         */
        //SqlMapper.Settings.CommandTimeout = 50;

        _cn = new SqlConnection(DataConnections.Instance.MainConnection);

        SqlMapper.AddTypeHandler(new SqlDateOnlyTypeHandler());
    }

    /// <summary>
    /// Read all records from BirthDaysDatabase.dbo.BirthDays
    /// </summary>
    /// <returns>
    /// List of <see cref="BirthDays"/>
    /// </returns>
    public async Task<List<BirthDays>> GetBirthdaysAsync() 
        => (await _cn.QueryAsync<BirthDays>(SqlStatements.GetBirthdays)).AsList();
}
