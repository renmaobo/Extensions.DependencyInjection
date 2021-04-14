using System;
using System.Collections.Generic;
using System.Text;

namespace Extensions.DependencyInjection.Exceptions
{
    /// <summary>
    /// 没有Ioc注册特性
    /// </summary>
    public class NotIocInjectionAttributeException : Exception
    {
        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="message"></param>
        public NotIocInjectionAttributeException(string message="Not find IocInjectionAttribute, please checke your code."):base(message)
        {

        }
    }
}
