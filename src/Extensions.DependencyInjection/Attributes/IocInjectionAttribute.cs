using System;
using System.Collections.Generic;
using System.Text;

namespace Extensions.DependencyInjection.Attributes
{
    /// <summary>
    /// Ioc注入特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class IocInjectionAttribute : Attribute
    {
        /// <summary>
        /// 别名
        /// </summary>
        public string Alias { get; set; }
    }
}
