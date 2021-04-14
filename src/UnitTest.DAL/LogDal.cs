using System;
using System.Collections.Generic;
using System.Text;
using UnitTest.IDAL;

namespace UnitTest.DAL
{
    /// <summary>
    /// 日志数据层
    /// </summary>
    public class LogDal : ILogDal
    {
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="logContext">日志内容</param>
        public void Add(string logContext)
        {
            System.Diagnostics.Debug.WriteLine($"添加日志成功！日志内容为：{logContext}");
        }
    }
}
