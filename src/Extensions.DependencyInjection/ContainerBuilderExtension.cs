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
        /// <param name="alias">别名</param>
        /// <param name="param">构造参数</param>
        public static void AddTransient<TService, TImplementation>(this IBuilder<IContainer> builder, string alias = null, object[] param = null) where TImplementation : TService
        => builder?.Add<TService, TImplementation>(LifeTime.Transient, alias, param);

        /// <summary>
        /// 添加瞬时
        /// </summary>
        /// <param name="builder">构建器</param>
        /// <param name="serviceType">服务类型</param>
        /// <param name="implementationType">实现类型</param>
        /// <param name="alias">别名</param>
        /// <param name="param">构造参数</param>
        public static void AddTransient(this IBuilder<IContainer> builder, Type serviceType, Type implementationType, string alias = null, object[] param = null)
        => builder?.Add(serviceType, implementationType, LifeTime.Transient, alias, param);

        /// <summary>
        /// 添加作用域单例
        /// </summary>
        /// <typeparam name="TService">服务</typeparam>
        /// <typeparam name="TImplementation">实现</typeparam>
        /// <param name="builder">构建器</param>
        /// <param name="alias">别名</param>
        /// <param name="param">构造参数</param>
        public static void AddScoped<TService, TImplementation>(this IBuilder<IContainer> builder, string alias = null, object[] param = null) where TImplementation : TService
        => builder?.Add<TService, TImplementation>(LifeTime.Scoped, alias, param);

        /// <summary>
        /// 添加作用域单例
        /// </summary>
        /// <param name="builder">构建器</param>
        /// <param name="serviceType">服务类型</param>
        /// <param name="implementationType">实现类型</param>
        /// <param name="alias">别名</param>
        /// <param name="param">构造参数</param>
        public static void AddScoped(this IBuilder<IContainer> builder, Type serviceType, Type implementationType, string alias = null, object[] param = null)
        => builder?.Add(serviceType, implementationType, LifeTime.Scoped, alias, param);

        /// <summary>
        /// 添加单例
        /// </summary>
        /// <typeparam name="TService">服务</typeparam>
        /// <typeparam name="TImplementation">实现</typeparam>
        /// <param name="builder">构建器</param>
        /// <param name="alias">别名</param>
        /// <param name="param">构造参数</param>
        public static void AddSingleton<TService, TImplementation>(this IBuilder<IContainer> builder, string alias = null, object[] param = null) where TImplementation : TService
        => builder?.Add<TService, TImplementation>(LifeTime.Singleton, alias, param);

        /// <summary>
        /// 添加单例
        /// </summary>
        /// <param name="builder">构建器</param>
        /// <param name="serviceType">服务类型</param>
        /// <param name="implementationType">实现类型</param>
        /// <param name="alias">别名</param>
        /// <param name="param">构造参数</param>
        public static void AddSingleton(this IBuilder<IContainer> builder, Type serviceType, Type implementationType, string alias = null, object[] param = null)
        => builder?.Add(serviceType, implementationType, LifeTime.Singleton, alias, param);

        /// <summary>
        /// 添加
        /// </summary>
        /// <typeparam name="TService">服务</typeparam>
        /// <typeparam name="TImplementation">实现</typeparam>
        /// <param name="builder">构建器</param>
        /// <param name="lifeTime">生命周期,默认瞬时</param>
        /// <param name="alias">别名</param>
        /// <param name="param">构造参数</param>
        private static void Add<TService, TImplementation>(this IBuilder<IContainer> builder, LifeTime lifeTime = LifeTime.Transient, string alias = null, object[] param = null) where TImplementation : TService
        {
            IContainer container = builder.Build();

            container.Register<TService, TImplementation>(lifeTime, alias, param);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="builder">构建器</param>
        /// <param name="serviceType">服务类型</param>
        /// <param name="implementationType">实现类型</param>
        /// <param name="lifeTime">生命周期,默认瞬时</param>
        /// <param name="alias">别名</param>
        /// <param name="param">构造参数</param>
        private static void Add(this IBuilder<IContainer> builder, Type serviceType, Type implementationType, LifeTime lifeTime = LifeTime.Transient, string alias = null, object[] param = null)
        {
            IContainer container = builder.Build();

            container.Register(serviceType, implementationType, lifeTime, alias, param);
        }
    }
}
