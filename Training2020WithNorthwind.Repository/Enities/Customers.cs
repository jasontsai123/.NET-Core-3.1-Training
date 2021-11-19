using System.Text.Json.Serialization;

namespace Training2020WithNorthwind.Repository.Enities
{
    public class Customers
    {
        /// <summary>
        /// CustomerID
        /// </summary>
        [JsonPropertyName("CustomerID")]
        public string CustomerID { get; set; }

        /// <summary>
        /// CompanyName
        /// </summary>
        [JsonPropertyName("CompanyName")]
        public string CompanyName { get; set; }

        /// <summary>
        /// ContactName
        /// </summary>
        [JsonPropertyName("ContactName")]
        public string ContactName { get; set; }

        /// <summary>
        /// ContactTitle
        /// </summary>
        [JsonPropertyName("ContactTitle")]
        public string ContactTitle { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        [JsonPropertyName("Address")]
        public string Address { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [JsonPropertyName("City")]
        public string City { get; set; }

        /// <summary>
        /// Region
        /// </summary>
        [JsonPropertyName("Region")]
        public string Region { get; set; }

        /// <summary>
        /// PostalCode
        /// </summary>
        [JsonPropertyName("PostalCode")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        [JsonPropertyName("Country")]
        public string Country { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        [JsonPropertyName("Phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Fax
        /// </summary>
        [JsonPropertyName("Fax")]
        public string Fax { get; set; }

    }


}