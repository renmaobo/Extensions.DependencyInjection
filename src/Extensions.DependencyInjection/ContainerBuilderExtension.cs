using System;
using System.Collections.Generic;
using System.Text;

namespace Extensions.DependencyInjection
{
    /// <summary>
    /// Ioc容器构建器扩展
    /// </summary>
    public static class ContainerBuilderExtension
    {
        /// <summary>
        /// 添加瞬时
        /// </summary>
        /// <typeparam name="TService">服务</typeparam>
        /// <typeparam name="TImplementation">实现</typeparam>
        /// <param name="builder">构建器</param>
        /// <param name="lifeTime">生命周期。默认为瞬时</param>
        /// <param name="alias">别名</param>
        /// <param name="param">构造参数</param>
        public static void AddTransient<TService, TImplementation>(this IBuilder<IContainer> builder, LifeTime lifeTime = LifeTime.Transient, string alias = null, object[] param = null) where TImplementation : TService
        {
            IContainer container = builder.Build();

            container.Register<TService, TImplementation>(lifeTime, alias, param);
        }
    }
}
