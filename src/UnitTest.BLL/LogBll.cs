using Extensions.DependencyInjection.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTest.IBLL;

namespace UnitTest.BLL
{
    /// <summary>
    /// 日志逻辑
    /// </summary>
    //[IocInjection(serviceType: typeof(ILogBll), alias: "LogBll")]
    public class LogBll : ILogBll
    {
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="logContext">日志内容</param>
        public void Add(string logContext)
        {
            System.Diagnostics.Debug.WriteLine($"普通 日志：{logContext}");
        }
    }
}
