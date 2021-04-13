using System;
using System.Collections.Generic;
using System.Text;

namespace Extensions.DependencyInjection.Attributes
{
    /// <summary>
    /// 容器注入特性
    /// </summary>
    public class IocInjectionAttribute : Attribute
    {
        /// <summary>
        /// 生存周期
        /// </summary>
        public LifeTime LifeTime { get; set; }

        /// <summary>
        /// 别名
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// 服务类型
        /// </summary>
        public Type ServiceType { get; set; }
    }
}
