using System.Data;

namespace Training2020WithNorthwind.Repository.Infrastructure.Helpers.Interfaces
{
    public interface IDatabaseHelper
    {
        /// <summary>
        /// Gets the northwind connection.
        /// </summary>
        /// <returns></returns>
        IDbConnection GetNorthwindConnection();
    }
}