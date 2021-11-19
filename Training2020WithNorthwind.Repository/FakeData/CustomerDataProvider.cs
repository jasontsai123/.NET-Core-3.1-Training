using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using ServiceStack.Text;
using Training2020WithNorthwind.Repository.Enities;

namespace Training2020WithNorthwind.Repository.FakeData
{
    public class CustomerDataProvider
    {
        public static IEnumerable<Customers> GetCustomerRepositoryAllData()
        {
            var list = new List<Customers>()
            {
                new Customers
                {
                    CustomerID = "ALFKI",
                    CompanyName = "Alfreds Futterkiste",
                    ContactName = "Maria Anders",
                    ContactTitle = "Sales Representative",
                    Address = "Obere Str. 57",
                    City = "Berlin",
                    PostalCode = "12209",
                    Country = "Germany",
                    Phone = "030-0074321",
                    Fax = "030-0076545"
                },
                new Customers
                {
                    CustomerID = "ANATR",
                    CompanyName = "Ana Trujillo Emparedados y helados",
                    ContactName = "Ana Trujillo",
                    ContactTitle = "Owner",
                    Address = "Avda. de la Constitucion 2222",
                    City = "Mexico D.F.",
                    PostalCode = "05021",
                    Country = "Mexico",
                    Phone = "(5) 555-4729",
                    Fax = "(5) 555-3745"
                },
                new Customers
                {
                    CustomerID = "ANTON",
                    CompanyName = "Antonio Moreno Taqueria",
                    ContactName = "Antonio Moreno",
                    ContactTitle = "Owner",
                    Address = "Mataderos  2312",
                    City = "Mexico D.F.",
                    PostalCode = "05023",
                    Country = "Mexico",
                    Phone = "(5) 555-3932"
                }
            };

            return list;
        }
    }
}