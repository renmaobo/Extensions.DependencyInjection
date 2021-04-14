using System;
using System.Collections.Generic;
using System.Text;

namespace Extensions.DependencyInjection.Attributes
{
    /// <summary>
    /// 容器契约特性
    /// </summary>
    /// <remarks>用于自动扫描注册容器</remarks>
    [AttributeUsage(AttributeTargets.Class)]
    public class IocContractAttribute : Attribute
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <param name="lifeTime">生存周期</param>
        /// <param name="alias">别名</param>
        public IocContractAttribute(Type serviceType, LifeTime lifeTime = LifeTime.Scoped, string alias = null)
        {
            this.ServiceType = serviceType;
            this.LifeTime = lifeTime;
            this.Alias = alias;
        }

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
