using System;
using System.Collections.Generic;
using System.Text;

namespace Extensions.DependencyInjection.Exceptions
{
    /// <summary>
    /// 重复注册异常
    /// </summary>
    public class RepeatRegisterException : Exception
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="message"></param>
        public RepeatRegisterException(string message) : base(message) { }
    }
}
