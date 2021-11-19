using System.Text.Json.Serialization;

namespace Training2020WithNorthwind.Application.Controllers.Models.ViewModel
{
    /// <summary>
    /// 顧客資料
    /// </summary>
    public class CustomerViewModel
    {
        /// <summary>
        /// 顧客ID
        /// </summary>
        [JsonPropertyName("customerID")]
        public string CustomerID { get; set; }

        /// <summary>
        /// 公司名稱
        /// </summary>
        [JsonPropertyName("companyName")]
        public string CompanyName { get; set; }

        /// <summary>
        /// ContactName
        /// </summary>
        [JsonPropertyName("contactName")]
        public string ContactName { get; set; }

        /// <summary>
        /// ContactTitle
        /// </summary>
        [JsonPropertyName("contactTitle")]
        public string ContactTitle { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        [JsonPropertyName("city")]
        public string City { get; set; }

        /// <summary>
        /// 區域
        /// </summary>
        [JsonPropertyName("region")]
        public string Region { get; set; }

        /// <summary>
        /// 郵遞區號
        /// </summary>
        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }

        /// <summary>
        /// 國家
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        /// 手機
        /// </summary>
        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// 傳真
        /// </summary>
        [JsonPropertyName("fax")]
        public string Fax { get; set; }
    }
}