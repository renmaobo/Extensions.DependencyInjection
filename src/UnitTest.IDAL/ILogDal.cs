using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.IDAL
{
    /// <summary>
    /// 日志数据层(接口)
    /// </summary>
    public interface ILogDal
    {
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="logContext">日志内容</param>
        void Add(string logContext);
    }
}
