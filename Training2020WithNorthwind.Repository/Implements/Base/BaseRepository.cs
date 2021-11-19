using Training2020WithNorthwind.Repository.Infrastructure.Helpers.Interfaces;

namespace Training2020WithNorthwind.Repository.Implements.Base
{
    /// <summary>
    /// abstract class BaseRepository
    /// </summary>
    public abstract class BaseRepository
    {
        /// <summary>
        /// DatabaseHelper
        /// </summary>
        protected IDatabaseHelper DatabaseHelper { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository" /> class.
        /// </summary>
        /// <param name="databaseHelper">The databaseHelper.</param>
        protected BaseRepository(IDatabaseHelper databaseHelper)
        {
            this.DatabaseHelper = databaseHelper;
        }

    }
}