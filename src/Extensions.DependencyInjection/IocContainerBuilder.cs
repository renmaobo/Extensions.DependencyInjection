using Extensions.DependencyInjection.Container;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Extensions.DependencyInjection
{
    /// <summary>
    /// Ioc容器构建器
    /// </summary>
    public class IocContainerBuilder : IBuilder<IContainer>
    {
        /// <summary>
        /// 容器
        /// </summary>
        private static IContainer _container { get; set; }

        /// <summary>
        /// 单例锁
        /// </summary>
        private static object singleLock = new object();

        /// <summary>
        /// 构建容器
        /// </summary>
        /// <returns></returns>
        public IContainer Build()
        {
            if (_container == null)
                lock (singleLock)
                    if (_container == null)
                        _container = new IocContainer();

            return _container;
        }

        /// <summary>
        /// 转移服务
        /// </summary>
        /// <param name="services">微软提供的服务</param>
        public void Transfer(IServiceCollection services)
        {
            foreach (ServiceDescriptor service in services)// 转移注入微软提供的服务
            {
                if (service.ImplementationType == null)
                {

                }
                // 注入转化
                switch (service.Lifetime)
                {
                    case ServiceLifetime.Singleton:
                        this.AddSingleton(service.ServiceType, service.ImplementationType);
                        break;
                    case ServiceLifetime.Scoped:
                        this.AddScoped(service.ServiceType, service.ImplementationType);
                        break;
                    case ServiceLifetime.Transient:
                        this.AddTransient(service.ServiceType, service.ImplementationType);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
