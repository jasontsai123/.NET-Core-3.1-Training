using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training2020WithNorthwind.Common.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Training2020WithNorthwind.Service.Dtos;

namespace Training2020WithNorthwind.Common.Infrastructure.Extensions.Tests
{
    [TestClass()]
    public class GenericObjectExtensionsTests
    {
        [TestMethod()]
        [Owner("TCC")]
        [TestCategory("GenericObjectExtensions")]
        [TestProperty("GenericObjectExtensions", "ToInt")]
        public void ToIntTest_傳入為正整數的物件_應傳回正確的正整數()
        {
            // arrange
            object sut = "1";
            int expected = 1;

            // act
            var actual = sut.ToInt();

            // assert
            actual.Should().Equals(expected);
        }

        [TestMethod()]
        [Owner("TCC")]
        [TestCategory("GenericObjectExtensions")]
        [TestProperty("GenericObjectExtensions", "ToInt")]
        public void ToIntTest_傳入Null值_應傳回ArgumentNullException()
        {
            // arrange
            object sut = null;

            // act
            Action actual = () => sut.ToInt();

            // assert
            actual.Should().Throw<ArgumentNullException>();
        }

        [TestMethod()]
        [Owner("TCC")]
        [TestCategory("GenericObjectExtensions")]
        [TestProperty("GenericObjectExtensions", "ToInt")]
        public void ToIntTest_傳入為非正整數的物件_應傳回預設的零()
        {
            // arrange
            object sut = "few";
            int expected = 0;

            // act
            var actual = sut.ToInt();

            // assert
            actual.Should().Be(expected);
        }

        [TestMethod()]
        [Owner("TCC")]
        [TestCategory("GenericObjectExtensions")]
        [TestProperty("GenericObjectExtensions", "ToInt")]
        public void ToIntTest_傳入為非正整數的物件_並指定預設值_應傳回傳指定的預設值()
        {
            // arrange
            object sut = "few";
            int expected = 5;

            // act
            var actual = sut.ToInt(expected);

            // assert
            actual.Should().Be(expected);
        }

        [TestMethod()]
        [Owner("TCC")]
        [TestCategory("GenericObjectExtensions")]
        [TestProperty("GenericObjectExtensions", "Deserialize")]
        public void DeserializeTest_反序列化JSON字串為CustomerDto()
        {
            // arrange
            string sut = "{\"CustomerID\":\"TCC\",\"CompanyName\":\"MS\",\"ContactName\":,\"ContactTitle\":,\"Address\":,\"City\":,\"Region\":,\"PostalCode\":,\"Country\":\"Taiwan\",\"Phone\":,\"Fax\":}";
            CustomerDto expected = new CustomerDto()
            {
                Address = null,
                City = null,
                CompanyName = "MS",
                ContactName = null,
                ContactTitle = null,
                Country = "Taiwan",
                CustomerID = "TCC",
                Fax = null,
                Phone = null,
                PostalCode = null,
                Region = null
            };

            // act
            var actual = sut.Deserialize<CustomerDto>();

            // assert
            actual.Should().Equals(expected);
            actual.CustomerID.Should().Be(expected.CustomerID);
            actual.CompanyName.Should().Be(expected.CompanyName);
            actual.Country.Should().Be(expected.Country);
        }

        [TestMethod()]
        [Owner("TCC")]
        [TestCategory("GenericObjectExtensions")]
        [TestProperty("GenericObjectExtensions", "Serialize")]
        public void SerializeTest_CustomerDto序列化()
        {
            // arrange
            CustomerDto sut = new CustomerDto()
            {
                Address = null,
                City = null,
                CompanyName = "MS",
                ContactName = null,
                ContactTitle = null,
                Country = "Taiwan",
                CustomerID = "TCC",
                Fax = null,
                Phone = null,
                PostalCode = null,
                Region = null
            };

            string expected = "{\"CustomerID\":\"TCC\",\"CompanyName\":\"MS\",\"ContactName\":,\"ContactTitle\":,\"Address\":,\"City\":,\"Region\":,\"PostalCode\":,\"Country\":\"Taiwan\",\"Phone\":,\"Fax\":}";
            
            // act
            var actual = sut.Serialize();

            // assert
            actual.Should().NotBeNull()
                .And.Equals(expected);
        }
    }
}