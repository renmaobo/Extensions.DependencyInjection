using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.IBLL
{
    /// <summary>
    /// 日志逻辑(接口)
    /// </summary>
    public interface ILogBll
    {
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="logContext">日志内容</param>
        void Add(string logContext);
    }
}
