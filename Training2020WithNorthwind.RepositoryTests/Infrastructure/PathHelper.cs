using System.IO;

namespace Training2020WithNorthwind.RepositoryTests.Infrastructure
{
    /// <summary>
    /// class PathHelper
    /// </summary>
    public class PathHelper
    {
        /// <summary>
        /// Replaces the path characters.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public static string ReplacePathCharacters(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return string.Empty;
            }

            if (OperatingSystem.IsLinux())
            {
                filePath = filePath.Replace(@"\", @"/");
            }

            return filePath;
        }
    }
}