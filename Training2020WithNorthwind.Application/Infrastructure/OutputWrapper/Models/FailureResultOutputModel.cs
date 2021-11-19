using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Training2020WithNorthwind.Application.Infrastructure.OutputWrapper.Models
{
    /// <summary>
    /// 執行失敗的 OutputModel.
    /// </summary>
    public class FailureResultOutputModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FailureResultOutputModel"/> class.
        /// </summary>
        public FailureResultOutputModel()
        {
            this.Errors = new List<FailureInformation>();
        }

        /// <summary>
        /// The Method
        /// </summary>
        [JsonProperty(PropertyName = "method", Order = 1)]
        public string Method { get; set; }

        /// <summary>
        /// The status
        /// </summary>
        [JsonProperty(PropertyName = "status", Order = 2)]
        public string Status { get; set; }

        /// <summary>
        /// The errors
        /// </summary>
        [JsonProperty(PropertyName = "errors", Order = 3)]
        public List<FailureInformation> Errors { get; set; }
    }
}