using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.IBLL
{
    public interface ILogBll
    {
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="logContext">日志内容</param>
        void Add(string logContext);
    }
}
