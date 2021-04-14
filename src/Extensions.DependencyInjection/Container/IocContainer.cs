using Extensions.DependencyInjection.Attributes;
using Extensions.DependencyInjection.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Extensions.DependencyInjection.Container
{
    /// <summary>
    /// Ioc容器
    /// </summary>
    public class IocContainer : IContainer
    {
        /// <summary>
        /// 容器
        /// </summary>
        protected Dictionary<string, ImplementationModel> Container { get; private set; } = new Dictionary<string, ImplementationModel>();

        public IContainer ChildContainer()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <typeparam name="TService">服务</typeparam>
        /// <typeparam name="TImplementation">实现</typeparam>
        /// <param name="param">构造参数</param>
        public void Register<TService, TImplementation>(object[] param = null) where TImplementation : TService
        {
            Type serviceType = typeof(TService);
            Type implementationType = typeof(TImplementation);
            if (implementationType.IsDefined(typeof(IocInjectionAttribute), true))
            {
                var attribute = (IocInjectionAttribute)(implementationType.GetCustomAttributes(typeof(IocInjectionAttribute), true)[0]);

                string key = this.GetKey(serviceType, attribute.Alias);
                if (this.Container.ContainsKey(key))
                    throw new RepeatRegisterException($"regeister {typeof(TImplementation).FullName} fail. becase exist repeat key[{key}], please check your code.");
                this.Container.Add(key, new ImplementationModel()
                {
                    ImplementationType = implementationType,
                    LifeTime = attribute.LifeTime,
                    Alias = attribute.Alias,
                    Paramters = param
                });
            }
        }

        public TImplementation Resolve<TImplementation>(string key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取键
        /// </summary>
        /// <param name="type">服务类型</param>
        /// <param name="alias">别名</param>
        /// <returns></returns>
        protected string GetKey(Type serviceType, string alias)
        {
            return $"{serviceType.FullName}-->{alias}";
        }

#if DEBUG
        /// <summary>
        /// 获取容器成员数量
        /// </summary>
        /// <returns></returns>
        public int GetContainerMembersCount()
        {
            return this.Container.Count;
        }
#endif
    }
}
