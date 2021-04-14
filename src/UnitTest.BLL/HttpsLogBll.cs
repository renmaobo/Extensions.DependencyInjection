using Extensions.DependencyInjection;
using Extensions.DependencyInjection.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTest.IBLL;

namespace UnitTest.BLL
{
    /// <summary>
    /// https日志逻辑
    /// </summary>
    //[IocInjection(serviceType : typeof(ILogBll), alias: "HttpsLogBll")]
    public class HttpsLogBll : ILogBll
    {
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="logContext">日志内容</param>
        public void Add(string logContext)
        {
            System.Diagnostics.Debug.WriteLine($"Https 日志：{logContext}");
        }
    }
}
