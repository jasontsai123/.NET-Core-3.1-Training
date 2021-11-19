using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using Dapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Training2020WithNorthwind.Repository.Enities;
using Training2020WithNorthwind.Repository.Implements.Interfaces;
using Training2020WithNorthwind.Repository.Infrastructure.Helpers.Interfaces;
using Training2020WithNorthwind.RepositoryTests;
using Training2020WithNorthwind.RepositoryTests.Infrastructure;

namespace Training2020WithNorthwind.Repository.Implements.Tests
{
    [TestClass()]
    public class CustomersRepositoryTests
    {
        private IDatabaseHelper DatabaseHelper { get; set; }

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            //TableSchema
            CreateCustomersTable();
            //DataSource
            PrepareCustomersData();
        }

        [ClassCleanup]
        public static void TestClassCleanup()
        {
            using (var conn = new SqlConnection(TestHook.DbConnectionString(DatabaseName.Northwind)))
            {
                conn.Open();
                string sqlCommand = TableCommands.DropTable("Customers");
                conn.Execute(sqlCommand);
            }
        }

        [TestMethod]
        [Owner("TCC")]
        [TestCategory("CustomersRepository")]
        [TestProperty("CustomersRepository", "GetAllAsync")]
        public async Task GetAllAsyncTest_取得所有資料_應取得91筆()
        {
            //arrange
            var sut = GetSystemUnderTest();

            //act
            var actual = await sut.GetAllAsync();

            //assert
            actual.Should().HaveCount(91);
        }

        [TestMethod]
        [Owner("TCC")]
        [TestCategory("CustomersRepository")]
        [TestProperty("CustomersRepository", "InsertAsync")]
        public async Task InsertAsyncTest_新增一筆資料_應回傳影響筆數1筆()
        {
            //arrange
            var sut = GetSystemUnderTest();

            //act
            Customers entity = new Customers() { CustomerID = "TCC",CompanyName = "YC"};
            var actual = await sut.InsertAsync(entity);

            //assert
            actual.Should().Be(1);
        }

        [TestMethod()]
        [Owner("TCC")]
        [TestCategory("CustomersRepository")]
        [TestProperty("CustomersRepository", "InsertAsync")]
        public async Task InsertAsyncTest_SqlException錯誤_CompanyName不得為Null()
        {
            //arrange
            var sut = GetSystemUnderTest();

            //act
            Customers entity = new Customers() { CustomerID = "TCC" };
            Func<Task> actual = async () => await sut.InsertAsync(entity);

            //assert
            (await actual.Should().ThrowAsync<SqlException>())
                .Where(e => e.Message.StartsWith(@"Cannot insert the value NULL into column 'CompanyName'"));
        }

        [TestMethod()]
        [Owner("TCC")]
        [TestCategory("CustomersRepository")]
        [TestProperty("CustomersRepository", "InsertAsync")]
        public async Task InsertAsyncTest_SqlException錯誤_CustomerID不得為Null()
        {
            //arrange
            var sut = GetSystemUnderTest();

            //act
            Customers entity = new Customers();
            Func<Task> actual = async () => await sut.InsertAsync(entity);

            //assert
            (await actual.Should().ThrowAsync<SqlException>())
                .Where(e => e.Message.StartsWith(@"Cannot insert the value NULL into column 'CustomerID'"));
        }

        [TestMethod()]
        [Owner("TCC")]
        [TestCategory("CustomersRepository")]
        [TestProperty("CustomersRepository", "InsertAsync")]
        public async Task InsertAsyncTest_SqlException錯誤_PK不能重複()
        {
            //arrange
            var sut = GetSystemUnderTest();

            //act
            Customers entity = new Customers() { CustomerID = "ALFKI", CompanyName = "Alfreds Futterkiste" };
            Func<Task> actual = async () => await sut.InsertAsync(entity);

            //assert
            (await actual.Should().ThrowAsync<SqlException>())
                .Where(e => e.Message.StartsWith(@"Violation of PRIMARY KEY constraint 'PK_Customers'. Cannot insert duplicate key in object 'dbo.Customers'. The duplicate key value is (ALFKI)."));
        }

        [TestInitialize]
        public void TestInitialize()
        {
            this.DatabaseHelper = Substitute.For<IDatabaseHelper>();
            IDbConnection connection = new SqlConnection(TestHook.DbConnectionString(DatabaseName.Northwind));
            this.DatabaseHelper.GetNorthwindConnection().ReturnsForAnyArgs(connection);
        }

        private static void CreateCustomersTable()
        {
            using (var conn = new SqlConnection(TestHook.DbConnectionString(DatabaseName.Northwind)))
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    var filePath = PathHelper.ReplacePathCharacters(@"TestData\TableSchemas\Northwind_CustomersTable.sql");
                    var script = File.ReadAllText(filePath);
                    conn.Execute(sql: script, transaction: trans);
                    trans.Commit();
                }
            }
        }

        private static void PrepareCustomersData()
        {
            using (var conn = new SqlConnection(TestHook.DbConnectionString(DatabaseName.Northwind)))
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    var filePath = PathHelper.ReplacePathCharacters(@"TestData\DataSource\Northwind_CustomersData.sql");
                    var script = File.ReadAllText(filePath);
                    conn.Execute(sql: script, transaction: trans);
                    trans.Commit();
                }
            }
        }

        private ICustomersRepository GetSystemUnderTest()
        {
            var sut = new CustomersRepository(this.DatabaseHelper);
            return sut;
        }
    }
}