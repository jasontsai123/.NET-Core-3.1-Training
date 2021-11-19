using Dora.Interception;
using Training2020WithNorthwind.Common.Infrastructure.Interception;

namespace Training2020WithNorthwind.Common.Infrastructure.Attributes
{
    public class CoreProfileAttribute : InterceptorAttribute
    {
        /// <summary>
        /// 以執行位置為監控描述
        /// </summary>
        public CoreProfileAttribute()
        {
        }

        /// <summary>
        /// 以傳入參數為監控描述
        /// </summary>
        /// <param name="stepName"></param>
        public CoreProfileAttribute(string stepName)
        {
            StepName = stepName;
        }

        public string StepName { get; set; }

        /// <summary>
        /// 方法性能監控
        /// </summary>
        /// <param name="bulBuilder"></param>
        public override void Use(IInterceptorChainBuilder builder)
        {
            builder.Use<CoreProfileInterception>(Order, StepName ?? "");
        }
    }
}