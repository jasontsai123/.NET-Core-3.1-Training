using System;
using Newtonsoft.Json;

namespace Training2020WithNorthwind.Application.Infrastructure.OutputWrapper.Models
{
    /// <summary>
    /// 執行完成的 OutputModel
    /// </summary>
    /// <typeparam name="T">任意型別</typeparam>
    public class SuccessResultOutputModel<T>
    {
        /// <summary>
        /// The Method.
        /// </summary>
        [JsonProperty(PropertyName = "method", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Method { get; set; }

        /// <summary>
        /// The Status.
        /// </summary>
        [JsonProperty(PropertyName = "status", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        /// <summary>
        /// Data.
        /// </summary>
        [JsonProperty(PropertyName = "data", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public T Data { get; set; }
    }
}