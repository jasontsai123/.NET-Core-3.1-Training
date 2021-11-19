using System;
using System.ComponentModel;
using ServiceStack.Text;

namespace Training2020WithNorthwind.Common.Infrastructure.Extensions
{
    public static class GenericObjectExtensions
    {
        /// <summary>
        /// To the int.
        /// </summary>
        /// <param name="object">The object.</param>
        /// <returns></returns>
        public static int ToInt(this object @object)
        {
            if (@object == null)
            {
                throw new ArgumentNullException("@object", "must input object");
            }
            return @object.ToInt(0);
        }

        /// <summary>
        /// To the int.
        /// </summary>
        /// <param name="object">The object.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static int ToInt(this object @object, int defaultValue = 0)
        {
            if (@object == null)
            {
                throw new ArgumentNullException("@object", "must input object");
            }
            var input = @object.ToString();
            return input.ToInt(defaultValue);
        }

        /// <summary>
        /// Converts to.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns>T.</returns>
        public static T ConvertTo<T>(this object value)
        {
            return (T)TypeDescriptor.GetConverter(typeof(T))
                                    .ConvertFrom(value);
        }

        /// <summary>
        /// Serializes the specified object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <returns>System.String.</returns>
        public static string Serialize<T>(this T obj)
        {
            string result = JsonSerializer.SerializeToString<T>(obj);
            return result;
        }

        /// <summary>
        /// Deserializes the specified value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns>T.</returns>
        public static T Deserialize<T>(this string value)
        {
            T result = JsonSerializer.DeserializeFromString<T>(value);
            return result;
        }
    }
}