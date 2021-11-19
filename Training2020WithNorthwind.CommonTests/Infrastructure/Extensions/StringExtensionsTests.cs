using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training2020WithNorthwind.Common.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;

namespace Training2020WithNorthwind.Common.Infrastructure.Extensions.Tests
{
    [TestClass()]
    public class StringExtensionsTests
    {
        [TestMethod()]
        [Owner("TCC")]
        [TestCategory("StringExtensions")]
        [TestProperty("StringExtensions", "IsNullOrEmpty")]
        public void IsNullOrEmptyTest_傳入空白的字串_應回傳True()
        {
            // arrange
            var sut = "";

            // act
            var actual = sut.IsNullOrEmpty();

            // assert
            actual.Should().BeTrue();
        }

        [TestMethod()]
        [Owner("TCC")]
        [TestCategory("StringExtensions")]
        [TestProperty("StringExtensions", "IsNullOrEmpty")]
        public void IsNullOrEmptyTest_傳入Null的值_應回傳True()
        {
            // arrange
            string sut = null;

            // act
            var actual = sut.IsNullOrEmpty();

            // assert
            actual.Should().BeTrue();
        }

        [TestMethod()]
        [Owner("TCC")]
        [TestCategory("StringExtensions")]
        [TestProperty("StringExtensions", "IsNullOrEmpty")]
        public void IsNullOrEmptyTest_傳入StringEmpty_應回傳True()
        {
            // arrange
            var sut = string.Empty;

            // act
            var actual = sut.IsNullOrEmpty();

            // assert
            actual.Should().BeTrue();
        }

        [TestMethod()]
        [Owner("TCC")]
        [TestCategory("StringExtensions")]
        [TestProperty("StringExtensions", "IsNullOrEmpty")]
        public void IsNullOrEmptyTest_傳入隨便一個有值的字串_應回傳False()
        {
            // arrange
            string sut = ".";

            // act
            var actual = sut.IsNullOrEmpty();

            // assert
            actual.Should().BeFalse();
        }

        [TestMethod()]
        [Owner("TCC")]
        [TestCategory("StringExtensions")]
        [TestProperty("StringExtensions", "IsNullOrEmpty")]
        public void IsNullOrEmptyTest_傳入空格字串_應回傳False()
        {
            // arrange
            string sut = " ";

            // act
            var actual = sut.IsNullOrEmpty();

            // assert
            actual.Should().BeFalse();
        }

        [TestMethod()]
        [Owner("TCC")]
        [TestCategory("StringExtensions")]
        [TestProperty("StringExtensions", "IsNullOrWhiteSpace")]
        public void IsNullOrWhiteSpaceTest_傳入空格字串_應回傳True()
        {
            // arrange
            string sut = " ";

            // act
            var actual = sut.IsNullOrWhiteSpace();

            // assert
            actual.Should().BeTrue();
        }

        [TestMethod()]
        [Owner("TCC")]
        [TestCategory("StringExtensions")]
        [TestProperty("StringExtensions", "IsNullOrWhiteSpace")]
        public void IsNullOrWhiteSpaceTest_傳入Null的值_應回傳True()
        {
            // arrange
            string sut = null;

            // act
            var actual = sut.IsNullOrWhiteSpace();

            // assert
            actual.Should().BeTrue();
        }

        [TestMethod()]
        [Owner("TCC")]
        [TestCategory("StringExtensions")]
        [TestProperty("StringExtensions", "IsNullOrWhiteSpace")]
        public void IsNullOrWhiteSpaceTest_傳入隨便一個有值的字串_應回傳False()
        {
            // arrange
            string sut = ".";

            // act
            var actual = sut.IsNullOrWhiteSpace();

            // assert
            actual.Should().BeFalse();
        }

        [TestMethod()]
        [Owner("TCC")]
        [TestCategory("StringExtensions")]
        [TestProperty("StringExtensions", "IsValidEmailAddress")]
        public void IsValidEmailAddressTest_傳入錯誤的Emall格式_應回傳False()
        {
            var sut = "test@@test.com";

            var actual = sut.IsValidEmailAddress();

            actual.Should().BeFalse();
        }

        [TestMethod()]
        [Owner("TCC")]
        [TestCategory("StringExtensions")]
        [TestProperty("StringExtensions", "IsValidEmailAddress")]
        public void IsValidEmailAddressTest_傳入正確的Emall格式_應回傳True()
        {
            var sut = "test@test.com";

            var actual = sut.IsValidEmailAddress();

            actual.Should().BeTrue();
        }

        [TestMethod()]
        [Owner("TCC")]
        [TestCategory("StringExtensions")]
        [TestProperty("StringExtensions", "IsMatch")]
        public void IsMatchTest_地址有符合正則表達式_應回傳True()
        {
            var sut= "116台灣台北市文山區木新路三段312號";

            var actual = sut.IsMatch(@"(?<zipcode>(^\d{5}|^\d{3})?)(?<city>\D+[縣市])(?<district>\D+?(市區|鎮區|鎮市|[鄉鎮市區]))(?<others>.+)");

            actual.Should().BeTrue();
        }

        [TestMethod()]
        [Owner("TCC")]
        [TestCategory("StringExtensions")]
        [TestProperty("StringExtensions", "IsMatch")]
        public void IsMatchTest_地址無符合正則表達式_應回傳False()
        {
            var sut = "116台灣木新路三段312號";

            var actual = sut.IsMatch(@"(?<zipcode>(^\d{5}|^\d{3})?)(?<city>\D+[縣市])(?<district>\D+?(市區|鎮區|鎮市|[鄉鎮市區]))(?<others>.+)");

            actual.Should().BeFalse();
        }
    }
}