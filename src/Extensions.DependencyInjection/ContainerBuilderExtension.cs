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
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="builder"></param>
        public static void AddTransient<TService, TImplementation>(this IBuilder<IContainer> builder,LifeTime lifeTime = LifeTime.Transient, string alias = null, object[] param = null) where TImplementation : TService
        {
            builder.Build();

            builder.BuildObject.Register<TService, TImplementation>(lifeTime, alias, param);
        }
    }
}
