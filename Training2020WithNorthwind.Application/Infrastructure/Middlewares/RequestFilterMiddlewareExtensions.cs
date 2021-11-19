using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;

namespace Training2020WithNorthwind.Application.Infrastructure.Middlewares
{
    /// <summary>
    /// class RequestFilterMiddlewareExtensions
    /// </summary>
    public static class RequestFilterMiddlewareExtensions
    {
        /// <summary>
        /// 預設的 IP 白名單
        /// </summary>
        private static IEnumerable<string> DefaultWhiteListIpCollection => new[]
        {
            "::1",
            "127."
        };

        /// <summary>
        /// 預設的限制路徑名稱
        /// </summary>
        private static IEnumerable<string> DefaultRestrictPathCollection => new[]
        {
            "coreprofiler",
            "swagger",
            "health"
        };

        /// <summary>
        /// Uses the request filter.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static IApplicationBuilder UseRequestFilter(this IApplicationBuilder builder)
        {
            RequestFilterMiddleware.WhiteListIpCollection = DefaultWhiteListIpCollection;
            RequestFilterMiddleware.RestrictPathCollection = DefaultRestrictPathCollection;

            return builder.UseMiddleware<RequestFilterMiddleware>();
        }

        /// <summary>
        /// Uses the Request filter.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="whiteListIpCollection">The white list ip collection.</param>
        /// <param name="restrictPathCollection">The restrict path collection.</param>
        /// <returns></returns>
        public static IApplicationBuilder UseRequestFilter(this IApplicationBuilder builder,
                                                           IEnumerable<string> whiteListIpCollection,
                                                           IEnumerable<string> restrictPathCollection)
        {
            RequestFilterMiddleware.WhiteListIpCollection = whiteListIpCollection.Any() || whiteListIpCollection != null
                ? whiteListIpCollection
                : DefaultWhiteListIpCollection;

            RequestFilterMiddleware.RestrictPathCollection = restrictPathCollection.Any() || restrictPathCollection != null
                ? restrictPathCollection
                : DefaultRestrictPathCollection;

            return builder.UseMiddleware<RequestFilterMiddleware>();
        }
    }
}