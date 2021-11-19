using System.Data;
using System.Data.SqlClient;
using CoreProfiler;
using CoreProfiler.Data;
using Training2020WithNorthwind.Repository.Infrastructure.Constants.Interfaces;
using Training2020WithNorthwind.Repository.Infrastructure.Helpers.Interfaces;

namespace Training2020WithNorthwind.Repository.Infrastructure.Helpers
{
    public class DatabaseHelper : IDatabaseHelper
    {
        private readonly IDatabaseConstants _databaseConstants;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseHelper"/> class.
        /// </summary>
        /// <param name="databaseConstants">The database constants.</param>
        public DatabaseHelper(IDatabaseConstants databaseConstants)
        {
            this._databaseConstants = databaseConstants;
        }

        /// <summary>
        /// Gets the northwind connection.
        /// </summary>
        /// <returns></returns>
        public IDbConnection GetNorthwindConnection()
        {
            return GetConnection(_databaseConstants.Northwind);
        }

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <returns></returns>
        private IDbConnection GetConnection(string connectionString)
        {
            var connection = new ProfiledDbConnection(
                new SqlConnection(connectionString),
                () => ProfilingSession.Current == null
                    ? null
                    : new DbProfiler(ProfilingSession.Current.Profiler)
            );
            return connection;
        }
    }
}