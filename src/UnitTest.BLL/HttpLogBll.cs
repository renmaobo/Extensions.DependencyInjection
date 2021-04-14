using Extensions.DependencyInjection.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTest.IBLL;

namespace UnitTest.BLL
{
    /// <summary>
    /// Http日志逻辑
    /// </summary>
    //[IocInjection(serviceType: typeof(ILogBll), alias: "HttpLogBll")]
    public class HttpLogBll : ILogBll
    {
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="logContext">日志内容</param>
        public void Add(string logContext)
        {
            System.Diagnostics.Debug.WriteLine($"Http 日志：{logContext}");
        }
    }
}
