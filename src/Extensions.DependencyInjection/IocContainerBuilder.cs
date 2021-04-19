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
        /// 构建容器
        /// </summary>
        /// <returns></returns>
        public IContainer Build()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 转移服务
        /// </summary>
        /// <param name="services">微软提供的服务</param>
        public void Transfer(IServiceCollection services)
        {


            throw new NotImplementedException();
        }
    }
}
