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
        public RepeatRegisterException(string message) : base(message) { }
    }
}
