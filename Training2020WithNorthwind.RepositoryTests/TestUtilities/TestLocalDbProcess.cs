using Training2020WithNorthwind.RepositoryTests.Infrastructure;

namespace Training2020WithNorthwind.RepositoryTests.TestUtilities
{
    /// <summary>
    /// class TestLocalDbProcess
    /// </summary>
    public class TestLocalDbProcess
    {
        /// <summary>
        /// Creates the database.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="dataBaseName">Name of the data base.</param>
        public static void CreateDatabase(string connectionString, string dataBaseName)
        {
            DatabaseCommands.CreateDatabase(connectionString, dataBaseName);
        }

        /// <summary>
        /// Destroys the database.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="dataBaseName">Name of the data base.</param>
        public static void DestroyDatabase(string connectionString, string dataBaseName)
        {
            DatabaseCommands.DestroyDatabase(connectionString, dataBaseName);
        }
    }
}