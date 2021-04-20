using System;
using System.Collections.Generic;
using System.Text;

namespace Extensions.DependencyInjection
{
    /// <summary>
    /// Ioc容器构建器扩展(基础注入)
    /// </summary>
    public static partial class ContainerBuilderExtension
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="builder">构建器</param>
        /// <param name="serviceType">服务类型</param>
        /// <param name="lifeTime">生命周期,默认瞬时</param>
        /// <param name="alias">别名</param>
        /// <param name="param">构造参数</param>
        private static void Add(this IBuilder<IContainer> builder, Type serviceType, LifeTime lifeTime = LifeTime.Transient, string alias = null, object[] param = null)
        {
            IContainer container = builder.Build();

            container.Register(serviceType, lifeTime, alias, param);
        }

        /// <summary>
        /// 添加（泛型）
        /// </summary>
        /// <param name="builder">构建器</param>
        /// <param name="lifeTime">生命周期,默认瞬时</param>
        /// <param name="alias">别名</param>
        /// <param name="param">构造参数</param>
        private static void Add<TService>(this IBuilder<IContainer> builder, LifeTime lifeTime = LifeTime.Transient, string alias = null, object[] param = null)
        => builder?.Add(typeof(TService), lifeTime, alias, param);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="builder">构建器</param>
        /// <param name="serviceType">服务类型</param>
        /// <param name="lifeTime">生命周期,默认瞬时</param>
        /// <param name="alias">别名</param>
        /// <param name="implementationInstance">实现实例</param>
        private static void Add(this IBuilder<IContainer> builder, Type serviceType, LifeTime lifeTime = LifeTime.Transient, string alias = null, object implementationInstance = null)
        {
            IContainer container = builder.Build();

            container.Register(serviceType, lifeTime, alias, implementationInstance);
        }

        /// <summary>
        /// 添加（泛型）
        /// </summary>
        /// <param name="builder">构建器</param>
        /// <param name="lifeTime">生命周期,默认瞬时</param>
        /// <param name="alias">别名</param>
        /// <param name="implementationInstance">实现实例</param>
        private static void Add<TService>(this IBuilder<IContainer> builder, LifeTime lifeTime = LifeTime.Transient, string alias = null, object implementationInstance = null)
        => builder?.Add(typeof(TService), lifeTime, alias, implementationInstance);

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

        /// <summary>
        /// 添加（泛型）
        /// </summary>
        /// <param name="builder">构建器</param>
        /// <param name="lifeTime">生命周期,默认瞬时</param>
        /// <param name="alias">别名</param>
        /// <param name="param">构造参数</param>
        private static void Add<TService, TImplementation>(this IBuilder<IContainer> builder, LifeTime lifeTime = LifeTime.Transient, string alias = null, object[] param = null)
        => builder?.Add(typeof(TService), typeof(TImplementation), lifeTime, alias, param);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="builder">构建器</param>
        /// <param name="serviceType">服务类型</param>
        /// <param name="implementationType">实现类型</param>
        /// <param name="lifeTime">生命周期,默认瞬时</param>
        /// <param name="alias">别名</param>
        /// <param name="implementationInstance">实现实例</param>
        private static void Add(this IBuilder<IContainer> builder, Type serviceType, Type implementationType, LifeTime lifeTime = LifeTime.Transient, string alias = null, object implementationInstance = null)
        {
            IContainer container = builder.Build();

            container.Register(serviceType, implementationType, lifeTime, alias, implementationInstance);
        }

        /// <summary>
        /// 添加（泛型）
        /// </summary>
        /// <param name="builder">构建器</param>
        /// <param name="lifeTime">生命周期,默认瞬时</param>
        /// <param name="alias">别名</param>
        /// <param name="implementationInstance">实现实例</param>
        private static void Add<TService, TImplementation>(this IBuilder<IContainer> builder, LifeTime lifeTime = LifeTime.Transient, string alias = null, object implementationInstance = null)
        => builder?.Add(typeof(TService), typeof(TImplementation), lifeTime, alias, implementationInstance);
    }

    /// <summary>
    /// Ioc容器构建器扩展(瞬时注入)
    /// </summary>
    public static partial class ContainerBuilderExtension
    {
        /// <summary>
        /// 添加瞬时（泛型）
        /// </summary>
        /// <typeparam name="TService">服务</typeparam>
        /// <param name="builder">构建器</param>
        /// <param name="alias">别名</param>
        /// <param name="param">构造参数</param>
        public static void AddTransient<TService>(this IBuilder<IContainer> builder, string alias = null, object[] param = null) where TService : class
        => builder?.Add<TService>(LifeTime.Transient, alias, param);

        /// <summary>
        /// 添加瞬时（泛型）
        /// </summary>
        /// <typeparam name="TService">服务</typeparam>
        /// <param name="builder">构建器</param>
        /// <param name="alias">别名</param>
        /// <param name="implementationInstance">实现实例</param>
        public static void AddTransient<TService>(this IBuilder<IContainer> builder, object implementationInstance, string alias = null) where TService : class
        => builder?.Add<TService>(LifeTime.Transient, alias, implementationInstance);

        /// <summary>
        /// 添加瞬时（泛型）
        /// </summary>
        /// <typeparam name="TService">服务</typeparam>
        /// <typeparam name="TImplementation">实现</typeparam>
        /// <param name="builder">构建器</param>
        /// <param name="alias">别名</param>
        /// <param name="param">构造参数</param>
        public static void AddTransient<TService, TImplementation>(this IBuilder<IContainer> builder, string alias = null, object[] param = null) where TImplementation : TService
        => builder?.Add<TService, TImplementation>(LifeTime.Transient, alias, param);

        /// <summary>
        /// 添加瞬时（泛型）
        /// </summary>
        /// <typeparam name="TService">服务</typeparam>
        /// <typeparam name="TImplementation">实现</typeparam>
        /// <param name="builder">构建器</param>
        /// <param name="alias">别名</param>
        /// <param name="implementationInstance">实现实例</param>
        public static void AddTransient<TService, TImplementation>(this IBuilder<IContainer> builder, object implementationInstance, string alias = null) where TImplementation : TService
        => builder?.Add<TService, TImplementation>(LifeTime.Transient, alias, implementationInstance);

        /// <summary>
        /// 添加瞬时
        /// </summary>
        /// <param name="builder">构建器</param>
        /// <param name="serviceType">服务类型</param>
        /// <param name="alias">别名</param>
        /// <param name="param">构造参数</param>
        public static void AddTransient(this IBuilder<IContainer> builder, Type serviceType, string alias = null, object[] param = null)
        => builder?.Add(serviceType, LifeTime.Transient, alias, param);

        /// <summary>
        /// 添加瞬时
        /// </summary>
        /// <param name="builder">构建器</param>
        /// <param name="serviceType">服务类型</param>
        /// <param name="alias">别名</param>
        /// <param name="implementationInstance">实现实例</param>
        public static void AddTransient(this IBuilder<IContainer> builder, Type serviceType, object implementationInstance, string alias = null)
        => builder?.Add(serviceType, LifeTime.Transient, alias, implementationInstance);

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
        /// 添加瞬时
        /// </summary>
        /// <param name="builder">构建器</param>
        /// <param name="serviceType">服务类型</param>
        /// <param name="implementationType">实现类型</param>
        /// <param name="alias">别名</param>
        /// <param name="implementationInstance">实现实例</param>
        public static void AddTransient(this IBuilder<IContainer> builder, Type serviceType, Type implementationType, object implementationInstance, string alias = null)
        => builder?.Add(serviceType, implementationType, LifeTime.Transient, alias, implementationInstance);
    }

    /// <summary>
    /// Ioc容器构建器扩展(作用域单例注入)
    /// </summary>
    public static partial class ContainerBuilderExtension
    {
        /// <summary>
        /// 添加作用域单例（泛型）
        /// </summary>
        /// <typeparam name="TService">服务</typeparam>
        /// <param name="builder">构建器</param>
        /// <param name="alias">别名</param>
        /// <param name="param">构造参数</param>
        public static void AddScoped<TService>(this IBuilder<IContainer> builder, string alias = null, object[] param = null) where TService : class
        => builder?.Add<TService>(LifeTime.Scoped, alias, param);

        /// <summary>
        /// 添加作用域单例（泛型）
        /// </summary>
        /// <typeparam name="TService">服务</typeparam>
        /// <param name="builder">构建器</param>
        /// <param name="alias">别名</param>
        /// <param name="implementationInstance">实现实例</param>
        public static void AddScoped<TService>(this IBuilder<IContainer> builder, object implementationInstance, string alias = null) where TService : class
        => builder?.Add<TService>(LifeTime.Transient, alias, implementationInstance);

        /// <summary>
        /// 添加作用域单例（泛型）
        /// </summary>
        /// <typeparam name="TService">服务</typeparam>
        /// <typeparam name="TImplementation">实现</typeparam>
        /// <param name="builder">构建器</param>
        /// <param name="alias">别名</param>
        /// <param name="param">构造参数</param>
        public static void AddScoped<TService, TImplementation>(this IBuilder<IContainer> builder, string alias = null, object[] param = null) where TImplementation : TService
        => builder?.Add<TService, TImplementation>(LifeTime.Transient, alias, param);

        /// <summary>
        /// 添加作用域单例（泛型）
        /// </summary>
        /// <typeparam name="TService">服务</typeparam>
        /// <typeparam name="TImplementation">实现</typeparam>
        /// <param name="builder">构建器</param>
        /// <param name="alias">别名</param>
        /// <param name="implementationInstance">实现实例</param>
        public static void AddScoped<TService, TImplementation>(this IBuilder<IContainer> builder, object implementationInstance, string alias = null) where TImplementation : TService
        => builder?.Add<TService, TImplementation>(LifeTime.Transient, alias, implementationInstance);

        /// <summary>
        /// 添加作用域单例
        /// </summary>
        /// <param name="builder">构建器</param>
        /// <param name="serviceType">服务类型</param>
        /// <param name="alias">别名</param>
        /// <param name="param">构造参数</param>
        public static void AddScoped(this IBuilder<IContainer> builder, Type serviceType, string alias = null, object[] param = null)
        => builder?.Add(serviceType, LifeTime.Transient, alias, param);

        /// <summary>
        /// 添加作用域单例
        /// </summary>
        /// <param name="builder">构建器</param>
        /// <param name="serviceType">服务类型</param>
        /// <param name="alias">别名</param>
        /// <param name="implementationInstance">实现实例</param>
        public static void AddScoped(this IBuilder<IContainer> builder, Type serviceType, object implementationInstance, string alias = null)
        => builder?.Add(serviceType, LifeTime.Transient, alias, implementationInstance);

        /// <summary>
        /// 添加作用域单例
        /// </summary>
        /// <param name="builder">构建器</param>
        /// <param name="serviceType">服务类型</param>
        /// <param name="implementationType">实现类型</param>
        /// <param name="alias">别名</param>
        /// <param name="param">构造参数</param>
        public static void AddScoped(this IBuilder<IContainer> builder, Type serviceType, Type implementationType, string alias = null, object[] param = null)
        => builder?.Add(serviceType, implementationType, LifeTime.Transient, alias, param);

        /// <summary>
        /// 添加作用域单例
        /// </summary>
        /// <param name="builder">构建器</param>
        /// <param name="serviceType">服务类型</param>
        /// <param name="implementationType">实现类型</param>
        /// <param name="alias">别名</param>
        /// <param name="implementationInstance">实现实例</param>
        public static void AddScoped(this IBuilder<IContainer> builder, Type serviceType, Type implementationType, object implementationInstance, string alias = null)
        => builder?.Add(serviceType, implementationType, LifeTime.Transient, alias, implementationInstance);
    }

    /// <summary>
    /// Ioc容器构建器扩展(单例注入)
    /// </summary>
    public static partial class ContainerBuilderExtension
    {
        /// <summary>
        /// 添加单例（泛型）
        /// </summary>
        /// <typeparam name="TService">服务</typeparam>
        /// <param name="builder">构建器</param>
        /// <param name="alias">别名</param>
        /// <param name="param">构造参数</param>
        public static void AddSingleton<TService>(this IBuilder<IContainer> builder, string alias = null, object[] param = null) where TService : class
        => builder?.Add<TService>(LifeTime.Singleton, alias, param);

        /// <summary>
        /// 添加单例（泛型）
        /// </summary>
        /// <typeparam name="TService">服务</typeparam>
        /// <param name="builder">构建器</param>
        /// <param name="alias">别名</param>
        /// <param name="implementationInstance">实现实例</param>
        public static void AddSingleton<TService>(this IBuilder<IContainer> builder, object implementationInstance, string alias = null) where TService : class
        => builder?.Add<TService>(LifeTime.Transient, alias, implementationInstance);

        /// <summary>
        /// 添加单例（泛型）
        /// </summary>
        /// <typeparam name="TService">服务</typeparam>
        /// <typeparam name="TImplementation">实现</typeparam>
        /// <param name="builder">构建器</param>
        /// <param name="alias">别名</param>
        /// <param name="param">构造参数</param>
        public static void AddSingleton<TService, TImplementation>(this IBuilder<IContainer> builder, string alias = null, object[] param = null) where TImplementation : TService
        => builder?.Add<TService, TImplementation>(LifeTime.Transient, alias, param);

        /// <summary>
        /// 添加单例（泛型）
        /// </summary>
        /// <typeparam name="TService">服务</typeparam>
        /// <typeparam name="TImplementation">实现</typeparam>
        /// <param name="builder">构建器</param>
        /// <param name="alias">别名</param>
        /// <param name="implementationInstance">实现实例</param>
        public static void AddSingleton<TService, TImplementation>(this IBuilder<IContainer> builder, object implementationInstance, string alias = null) where TImplementation : TService
        => builder?.Add<TService, TImplementation>(LifeTime.Transient, alias, implementationInstance);

        /// <summary>
        /// 添加单例
        /// </summary>
        /// <param name="builder">构建器</param>
        /// <param name="serviceType">服务类型</param>
        /// <param name="alias">别名</param>
        /// <param name="param">构造参数</param>
        public static void AddSingleton(this IBuilder<IContainer> builder, Type serviceType, string alias = null, object[] param = null)
        => builder?.Add(serviceType, LifeTime.Transient, alias, param);

        /// <summary>
        /// 添加单例
        /// </summary>
        /// <param name="builder">构建器</param>
        /// <param name="serviceType">服务类型</param>
        /// <param name="alias">别名</param>
        /// <param name="implementationInstance">实现实例</param>
        public static void AddSingleton(this IBuilder<IContainer> builder, Type serviceType, object implementationInstance, string alias = null)
        => builder?.Add(serviceType, LifeTime.Transient, alias, implementationInstance);

        /// <summary>
        /// 添加单例
        /// </summary>
        /// <param name="builder">构建器</param>
        /// <param name="serviceType">服务类型</param>
        /// <param name="implementationType">实现类型</param>
        /// <param name="alias">别名</param>
        /// <param name="param">构造参数</param>
        public static void AddSingleton(this IBuilder<IContainer> builder, Type serviceType, Type implementationType, string alias = null, object[] param = null)
        => builder?.Add(serviceType, implementationType, LifeTime.Transient, alias, param);

        /// <summary>
        /// 添加单例
        /// </summary>
        /// <param name="builder">构建器</param>
        /// <param name="serviceType">服务类型</param>
        /// <param name="implementationType">实现类型</param>
        /// <param name="alias">别名</param>
        /// <param name="implementationInstance">实现实例</param>
        public static void AddSingleton(this IBuilder<IContainer> builder, Type serviceType, Type implementationType, object implementationInstance, string alias = null)
        => builder?.Add(serviceType, implementationType, LifeTime.Transient, alias, implementationInstance);
    }
}
