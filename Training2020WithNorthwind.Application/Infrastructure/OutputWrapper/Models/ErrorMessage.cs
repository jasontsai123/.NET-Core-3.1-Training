using Newtonsoft.Json;

namespace Training2020WithNorthwind.Application.Infrastructure.OutputWrapper.Models
{
    /// <summary>
    /// Class ErrorMessage.
    /// </summary>
    public class ErrorMessage
    {
        /// <summary>
        /// The error code.
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// The message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The description.
        /// </summary>
        public string Description { get; set; }
    }
}