using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Extensions.DependencyInjection
{
    /// <summary>
    /// Ioc服务供应工厂
    /// </summary>
    public class IocServiceProviderFactory : IServiceProviderFactory<IBuilder<IContainer>>
    {
        /// <summary>
        /// 创建构建器
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <returns></returns>
        public IBuilder<IContainer> CreateBuilder(IServiceCollection services)
        {
            IBuilder<IContainer> builder = new IocContainerBuilder();

            builder.Transfer(services);

            return builder;
        }

        /// <summary>
        /// 创建服务供应器
        /// </summary>
        /// <param name="containerBuilder">容器构建器</param>
        /// <returns></returns>
        public IServiceProvider CreateServiceProvider(IBuilder<IContainer> containerBuilder)
        {
            throw new NotImplementedException();
        }
    }
}
