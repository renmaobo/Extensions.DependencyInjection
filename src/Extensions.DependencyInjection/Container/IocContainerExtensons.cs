using System;
using System.Collections.Generic;
using System.Text;

namespace Extensions.DependencyInjection.Container
{
    /// <summary>
    /// Ioc容器扩展
    /// </summary>
    public static class IocContainerExtensons
    {
        /// <summary>
        /// 注册为瞬时
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="container"></param>
        /// <param name="alias"></param>
        /// <param name="param"></param>
        public static void AddTransient<TService, TImplementation>(this IocContainer container, string alias = null, object[] param = null) where TImplementation : TService
        {
            container.Register<TService, TImplementation>(LifeTime.Transient, alias, param);
        }

        /// <summary>
        /// 注册为瞬时
        /// </summary>
        /// <param name="container"></param>
        /// <param name="serviceType"></param>
        /// <param name="implementationType"></param>
        /// <param name="alias"></param>
        /// <param name="param"></param>
        public static void AddTransient(this IocContainer container, Type serviceType, Type implementationType, string alias = null, object[] param = null)
        {
            container.Register(serviceType, implementationType, LifeTime.Transient, alias, param);
        }

        /// <summary>
        /// 注册为作用域单例
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="container"></param>
        /// <param name="alias"></param>
        /// <param name="param"></param>
        public static void AddScoped<TService, TImplementation>(this IocContainer container, string alias = null, object[] param = null) where TImplementation : TService
        {
            container.Register<TService, TImplementation>(LifeTime.Scoped, alias, param);
        }

        /// <summary>
        /// 注册为作用域单例
        /// </summary>
        /// <param name="container"></param>
        /// <param name="serviceType"></param>
        /// <param name="implementationType"></param>
        /// <param name="alias"></param>
        /// <param name="param"></param>
        public static void AddScoped(this IocContainer container, Type serviceType, Type implementationType, string alias = null, object[] param = null)
        {
            container.Register(serviceType, implementationType, LifeTime.Scoped, alias, param);
        }

        /// <summary>
        /// 注册为单例
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="container"></param>
        /// <param name="alias"></param>
        /// <param name="param"></param>
        public static void AddSingleton<TService, TImplementation>(this IocContainer container, string alias = null, object[] param = null) where TImplementation : TService
        {
            container.Register<TService, TImplementation>(LifeTime.Singleton, alias, param);
        }

        /// <summary>
        /// 注册为单例
        /// </summary>
        /// <param name="container"></param>
        /// <param name="serviceType"></param>
        /// <param name="implementationType"></param>
        /// <param name="alias"></param>
        /// <param name="param"></param>
        public static void AddSingleton(this IocContainer container, Type serviceType, Type implementationType, string alias = null, object[] param = null)
        {
            container.Register(serviceType, implementationType, LifeTime.Singleton, alias, param);
        }
    }
}
