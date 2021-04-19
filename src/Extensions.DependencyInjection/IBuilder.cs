using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Extensions.DependencyInjection
{
    /// <summary>
    /// 构建器(接口)
    /// </summary>
    /// <typeparam name="TBuildObject">构建对象</typeparam>
    public interface IBuilder<TBuildObject> where TBuildObject : class
    {
        /// <summary>
        /// 构建容器
        /// </summary>
        /// <returns></returns>
        TBuildObject Build();

        /// <summary>
        /// 转移服务
        /// </summary>
        /// <param name="services">微软提供的服务</param>
        void Transfer(IServiceCollection services);
    }
}
