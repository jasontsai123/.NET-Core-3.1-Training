using System.Threading.Tasks;
using CoreProfiler;
using Dora.DynamicProxy;

namespace Training2020WithNorthwind.Common.Infrastructure.Interception
{
    public class CoreProfileInterception
    {
        /// <summary>
        /// 監控描述
        /// </summary>
        private string _stepName;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="stepName">監控描述</param>
        public CoreProfileInterception(string stepName)
        {
            _stepName = stepName;
        }

        /// <summary>
        /// 攔截器執行
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(InvocationContext context)
        {
            if (string.IsNullOrEmpty(_stepName))
            {
                _stepName = $"{context.Target}-{context.TargetMethod}";
            }
            using (ProfilingSession.Current.Step(_stepName))
            {
                await context.ProceedAsync();
            }
        }
    }
}