using System.Collections.Generic;
using System.IO;
using System.Text;
using Training2020WithNorthwind.Service.Dtos;
using ServiceStack.Text;
using Training2020WithNorthwind.Repository.Enities;

namespace Training2020WithNorthwind.ServiceTests.TestData
{
    public class CustomerDataProvider
    {
        public static IEnumerable<Customers> GetCustomerRepositoryAllData()
        {
            using (var reader = new StreamReader(@"TestData/GetAllCustomerResponse_TestData.json", Encoding.UTF8))
            {
                var content = reader.ReadToEnd();
                return JsonSerializer.DeserializeFromString<IEnumerable<Customers>>(content);
            }
        }

        public static IEnumerable<CustomerDto> GetCustomerServiceAllData()
        {
            using (var reader = new StreamReader(@"TestData/GetAllCustomerResponse_TestData.json", Encoding.UTF8))
            {
                var content = reader.ReadToEnd();
                return JsonSerializer.DeserializeFromString<IEnumerable<CustomerDto>>(content);
            }
        }
    }
}