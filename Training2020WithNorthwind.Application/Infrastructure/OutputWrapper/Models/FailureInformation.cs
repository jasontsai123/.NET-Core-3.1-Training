using Newtonsoft.Json;

namespace Training2020WithNorthwind.Application.Infrastructure.OutputWrapper.Models
{
    /// <summary>
    /// class FailureInformation
    /// </summary>
    public class FailureInformation
    {
        /// <summary>
        /// The error code.
        /// </summary>
        [JsonProperty(PropertyName = "code", Order = 1)]
        public int ErrorCode { get; set; }

        /// <summary>
        /// The message.
        /// </summary>
        [JsonProperty(PropertyName = "message", Order = 2)]
        public string Message { get; set; }

        /// <summary>
        /// The description.
        /// </summary>
        [JsonProperty(PropertyName = "description", Order = 3)]
        public string Description { get; set; }
    }
}