namespace Training2020WithNorthwind.Application.Infrastructure.Validators
{
    /// <summary>
    /// Class FluentValidation Error Message Format.
    /// </summary>
    public static class ErrorMessageFormat
    {
        /// <summary>
        /// 【{參數名稱}】參數不得為空值!
        /// </summary>
        /// <param name="parameterName">參數名稱</param>
        /// <returns></returns>
        public static string NotNull(string parameterName)
        {
            return $@"【{parameterName}】參數不得為空值!";
        }

        /// <summary>
        /// 【{參數名稱}】參數不得為空字串!
        /// </summary>
        /// <param name="parameterName">參數名稱</param>
        /// <returns>
        /// The not empty.
        /// </returns>
        public static string NotEmpty(string parameterName)
        {
            return $@"【{parameterName}】參數不得為空字串!";
        }

        /// <summary>
        /// 【{參數名稱}】參數字串最大長度不得超過{最大字串長度}!
        /// </summary>
        /// <param name="parameterName">參數名稱</param>
        /// <param name="maxLength">最大字串長度</param>
        /// <returns></returns>
        public static string NotGreaterThanMaxStringLength(string parameterName, int maxLength)
        {
            return $"【{parameterName}】參數字串最大長度不得超過{maxLength}!";
        }
    }
}