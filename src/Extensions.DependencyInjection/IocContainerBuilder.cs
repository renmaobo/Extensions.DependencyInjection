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


            throw new NotImplementedException();
        }
    }
}
