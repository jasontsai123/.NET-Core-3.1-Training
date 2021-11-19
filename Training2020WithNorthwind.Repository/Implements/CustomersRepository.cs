using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Training2020WithNorthwind.Common.Infrastructure.Attributes;
using Training2020WithNorthwind.Repository.Enities;
using Training2020WithNorthwind.Repository.Implements.Base;
using Training2020WithNorthwind.Repository.Implements.Interfaces;
using Training2020WithNorthwind.Repository.Infrastructure.Helpers.Interfaces;

namespace Training2020WithNorthwind.Repository.Implements
{
    public class CustomersRepository : BaseRepository, ICustomersRepository
    {
        public CustomersRepository(IDatabaseHelper databaseHelper) : base(databaseHelper)
        {
        }

        /// <summary>
        /// 取得Customer所有資料表.
        /// </summary>
        /// <returns></returns>
        [CoreProfile("CustomersRepository.GetAllAsync()")]
        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            using (IDbConnection conn = this.DatabaseHelper.GetNorthwindConnection())
            {
                var sql = "SELECT * FROM Customers WITH(NOLOCK)";

                var result = await conn.QueryAsync<Customers>(sql);
                return result;
            }
        }

        /// <summary>
        /// 新增Customer資料
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>新增筆數</returns>
        [CoreProfile("CustomersRepository.InsertAsync()")]
        public async Task<int> InsertAsync(Customers entity)
        {
            using (IDbConnection conn = this.DatabaseHelper.GetNorthwindConnection())
            {
                var sql = @"
INSERT INTO [dbo].[Customers]
(
    [CustomerID],
    [CompanyName],
    [ContactName],
    [ContactTitle],
    [Address],
    [City],
    [Region],
    [PostalCode],
    [Country],
    [Phone],
    [Fax]
)
VALUES
(
    @CustomerID,
    @CompanyName,
    @ContactName,
    @ContactTitle,
    @Address,
    @City,
    @Region,
    @PostalCode,
    @Country,
    @Phone,
    @Fax
);
                ";

                var affectedRows = await conn.ExecuteAsync(sql, entity);
                return affectedRows;
            }
        }
    }
}