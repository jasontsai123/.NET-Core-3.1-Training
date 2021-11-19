using Microsoft.Extensions.Configuration;
using Training2020WithNorthwind.Repository.Infrastructure.Constants.Interfaces;

namespace Training2020WithNorthwind.Repository.Infrastructure.Constants
{
    public class DatabaseConstants : IDatabaseConstants
    {
        private readonly IConfiguration _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseConstants"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public DatabaseConstants(IConfiguration config)
        {
            this._config = config;
        }

        /// <summary>
        /// Gets the northwind.
        /// </summary>
        /// <value>
        /// The northwind.
        /// </value>
        public string Northwind => _config.GetConnectionString("NorthwindConnection");
    }
}