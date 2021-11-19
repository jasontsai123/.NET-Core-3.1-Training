using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Threading.Tasks;
using Training2020WithNorthwind.Repository.Implements.Interfaces;
using Training2020WithNorthwind.Service.Dtos;
using Training2020WithNorthwind.Service.Implements;
using FluentAssertions;
using Training2020WithNorthwind.ServiceTests.TestData;
using System.Collections.Generic;
using Training2020WithNorthwind.Repository.Enities;
using NSubstitute.ExceptionExtensions;

namespace Training2020WithNorthwind.ServiceTests.Implements
{
    [TestClass]
    public class CustomerServiceTests
    {
        private ICustomersRepository subCustomersRepository;
        private IMapper subMapper;

        [TestInitialize]
        public void TestInitialize()
        {
            this.subCustomersRepository = Substitute.For<ICustomersRepository>();
            this.subMapper = Substitute.For<IMapper>();
        }

        private CustomerService GetSystemUnderTest()
        {
            return new CustomerService(
                this.subCustomersRepository,
                this.subMapper);
        }

        [TestMethod()]
        [Owner("TCC")]
        [TestCategory("CustomerService")]
        [TestProperty("CustomerService", "GetAllAsync")]
        public async Task GetAllAsyncTest_取得所有資料_應取得91筆()
        {
            var data = CustomerDataProvider.GetCustomerRepositoryAllData();
            this.subCustomersRepository.GetAllAsync()
                .ReturnsForAnyArgs(data);

            this.subMapper.Map<IEnumerable<Customers>, IEnumerable<CustomerDto>>(data)
                .ReturnsForAnyArgs(CustomerDataProvider.GetCustomerServiceAllData());

            // Arrange
            var sut = this.GetSystemUnderTest();

            // Act
            var actual = await sut.GetAllAsync();

            // Assert
            actual.Should().HaveCount(91);
        }

        [TestMethod()]
        [Owner("TCC")]
        [TestCategory("CustomerService")]
        [TestProperty("CustomerService", "InsertAsync")]
        public async Task InsertAsyncTest_新增一筆資料_應回傳影響筆數1筆()
        {
            this.subCustomersRepository.InsertAsync(Arg.Any<Customers>()).ReturnsForAnyArgs(1);

            //arrange
            var sut = GetSystemUnderTest();

            //act
            CustomerDto dto = new CustomerDto() { CustomerID = "TCC", CompanyName = "YC" };
            var actual = await sut.InsertAsync(dto);

            //assert
            actual.Should().Be(1);
        }

        [TestMethod()]
        [Owner("TCC")]
        [TestCategory("CustomerService")]
        [TestProperty("CustomerService", "InsertAsync")]
        public async Task InsertAsyncTest_參數為Null引發Repository層的Exception_應回傳Exception()
        {
            this.subCustomersRepository.InsertAsync(null).ThrowsForAnyArgs<Exception>();

            // Arrange
            var sut = this.GetSystemUnderTest();
            CustomerDto dto = null;

            // Act
            Func<Task> actual = async () => await sut.InsertAsync(dto);

            // Assert
            await actual.Should().ThrowAsync<Exception>();
        }

    }
}
