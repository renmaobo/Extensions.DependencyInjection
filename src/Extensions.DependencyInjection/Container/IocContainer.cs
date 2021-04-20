using Extensions.DependencyInjection.Attributes;
using Extensions.DependencyInjection.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Extensions.DependencyInjection.Container
{
    /// <summary>
    /// Ioc容器构建器
    /// </summary>
    public class IocContainer : IContainer
    {
        /// <summary>
        /// 容器
        /// </summary>
        protected Dictionary<string, ImplementationModel> Container { get; private set; } = new Dictionary<string, ImplementationModel>();

        /// <summary>
        /// 子容器
        /// </summary>
        /// <returns></returns>
        public IContainer ChildContainer()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <typeparam name="TService">服务</typeparam>
        /// <typeparam name="TImplementation">实现</typeparam>
        /// <param name="lifeTime">生命周期。默认为瞬时</param>
        /// <param name="alias">别名</param>
        /// <param name="implementationInstance">实现实例</param>
        public void Register<TService, TImplementation>(LifeTime lifeTime, string alias = null, object implementationInstance = null) where TImplementation : TService
        {
            this.Register(typeof(TService), typeof(TImplementation), lifeTime, alias, implementationInstance);
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <typeparam name="TService">服务</typeparam>
        /// <typeparam name="TImplementation">实现</typeparam>
        /// <param name="lifeTime">生命周期。默认为瞬时</param>
        /// <param name="alias">别名</param>
        /// <param name="param">构造参数</param>
        public void Register<TService, TImplementation>(LifeTime lifeTime = LifeTime.Transient, string alias = null, object[] param = null) where TImplementation : TService
        {
            this.Register(typeof(TService), typeof(TImplementation), lifeTime, alias, param);
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <param name="implementationType">实现类型</param>
        /// <param name="lifeTime">生命周期。默认为瞬时</param>
        /// <param name="alias">别名</param>
        /// <param name="implementationInstance">实现实例</param>
        public void Register(Type serviceType, Type implementationType, LifeTime lifeTime, string alias = null, object implementationInstance = null)
        {
            this.Register(serviceType, implementationType, lifeTime, alias, implementationInstance, null);
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <param name="implementationType">实现类型</param>
        /// <param name="lifeTime">生命周期。默认为瞬时</param>
        /// <param name="alias">别名</param>
        /// <param name="param">构造参数</param>
        public void Register(Type serviceType, Type implementationType, LifeTime lifeTime = LifeTime.Transient, string alias = null, object[] param = null)
        {
            this.Register(serviceType, implementationType, lifeTime, alias, null, param);
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <typeparam name="TService">服务</typeparam>
        /// <param name="lifeTime">生命周期。默认为瞬时</param>
        /// <param name="alias">别名</param>
        /// <param name="implementationInstance">实现实例</param>
        public void Register<TService>(LifeTime lifeTime, string alias = null, object implementationInstance = null) where TService : class
        {
            this.Register(typeof(TService), lifeTime, alias, implementationInstance);
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <typeparam name="TService">服务</typeparam>
        /// <param name="lifeTime">生命周期。默认为瞬时</param>
        /// <param name="alias">别名</param>
        /// <param name="param">构造参数</param>
        public void Register<TService>(LifeTime lifeTime = LifeTime.Transient, string alias = null, object[] param = null) where TService : class
        {
            this.Register(typeof(TService), lifeTime, alias, param);
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <param name="lifeTime">生命周期。默认为瞬时</param>
        /// <param name="alias">别名</param>
        /// <param name="implementationInstance">实现实例</param>
        public void Register(Type serviceType, LifeTime lifeTime, string alias = null, object implementationInstance = null)
        {
            this.Register(serviceType, null, lifeTime, alias, implementationInstance, null);
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <param name="lifeTime">生命周期。默认为瞬时</param>
        /// <param name="alias">别名</param>
        /// <param name="param">构造参数</param>
        public void Register(Type serviceType, LifeTime lifeTime = LifeTime.Transient, string alias = null, object[] param = null)
        {
            this.Register(serviceType, null, lifeTime, alias, null, param);
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <param name="implementationType">实现类型</param>
        /// <param name="lifeTime">生命周期。默认为瞬时</param>
        /// <param name="alias">别名</param>
        /// <param name="implementationInstance">实现实例</param>
        /// <param name="param">构造参数</param>
        private void Register(Type serviceType, Type implementationType, LifeTime lifeTime = LifeTime.Transient, string alias = null, object implementationInstance = null, object[] param = null)
        {

            string key = this.GetKey(serviceType, alias);
            if (this.Container.ContainsKey(key))
                throw new RepeatRegisterException($"regeister {(implementationType is null ? serviceType.FullName : implementationType.FullName)} fail. becase exist repeat key[{key}], please check your code.");

            this.Container.Add(key, new ImplementationModel()
            {
                LifeTime = lifeTime,
                Alias = alias,
                Paramters = param,
                ImplementationType = implementationType,
                ImplementationInstance = implementationInstance,
            });
        }

        /// <summary>
        /// 解析
        /// </summary>
        /// <typeparam name="TService">服务</typeparam>
        /// <param name="alias">别名</param>
        /// <returns></returns>
        public TService Resolve<TService>(string alias = null) where TService : class
        {
            return (TService)this.Resolve(typeof(TService), alias);
        }

        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <param name="alias">别名</param>
        /// <returns></returns>
        protected object Resolve(Type serviceType, string alias = null)
        {
            string key = this.GetKey(serviceType, alias);
            if (!this.Container.ContainsKey(key))
                throw new NullReferenceException($"not find {serviceType.FullName} implementation class");

            ImplementationModel implementationModel = this.Container[key];

            object instance = null;
            this.ConstructorInjection(ref instance, implementationModel);// 初始化，并注入
            this.PropertyInjection(ref instance, implementationModel);// 属性注入
            this.MethodInjection(ref instance, implementationModel);// 方法注入

            return instance;
        }

        /// <summary>
        /// Ioc实现特性类型
        /// </summary>
        protected static Type IocInjectionAttributeType { get; private set; } = typeof(IocInjectionAttribute);

        /// <summary>
        /// 获取别名
        /// </summary>
        /// <param name="provider">自定义特性提供者</param>
        /// <returns></returns>
        private string GetAlias(ICustomAttributeProvider provider)
        {
            if (provider.IsDefined(typeof(IocInjectionAttribute), true))
            {
                var attribute = (IocInjectionAttribute)(provider.GetCustomAttributes(typeof(IocInjectionAttribute), true)[0]);
                return attribute.Alias;
            }
            else
                return null;
        }

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="instance">实例</param>
        /// <param name="implementationModel">实现信息</param>
        public virtual void ConstructorInjection(ref object instance, ImplementationModel implementationModel)
        {
            ConstructorInfo constructor = implementationModel.ImplementationType.GetConstructors().FirstOrDefault(c => c.IsDefined(IocInjectionAttributeType, true));

            if (constructor == null)// 如果没有特性，选择参数最多的构造函数
                constructor = implementationModel.ImplementationType.GetConstructors().OrderByDescending(c => c.GetParameters().Length).First();

            List<object> paraList = new List<object>();

            object[] paraConstant = implementationModel.Paramters;
            int paramIndex = 0;
            foreach (var para in constructor.GetParameters())
            {
                if (para.IsDefined(typeof(ConstantParameterAttribute), true))
                {
                    paraList.Add(paraConstant[paramIndex]);
                    paramIndex++;
                }
                else
                {
                    Type paraType = para.ParameterType;//获取参数的类型 IUserDAL

                    string paraShortName = this.GetAlias(para);
                    object paraInstance = this.Resolve(paraType, paraShortName);
                    paraList.Add(paraInstance);
                }
            }

            instance = Activator.CreateInstance(implementationModel.ImplementationType, paraList.ToArray());
        }

        /// <summary>
        /// 属性注入
        /// </summary>
        /// <param name="instance">实例</param>
        /// <param name="implementationModel">实现信息</param>
        protected virtual void PropertyInjection(ref object instance, ImplementationModel implementationModel)
        {
            foreach (var property in implementationModel.ImplementationType.GetProperties().Where(p => p.IsDefined(IocInjectionAttributeType, true)))
            {
                Type propertyType = property.PropertyType;
                string alias = this.GetAlias(property);

                object propInstance = this.Resolve(propertyType, alias);
                property.SetValue(instance, propInstance);
            }
        }

        /// <summary>
        /// 方法注入
        /// </summary>
        /// <param name="instance">实例</param>
        /// <param name="implementationModel">实现信息</param>
        public virtual void MethodInjection(ref object instance, ImplementationModel implementationModel)
        {
            foreach (var method in implementationModel.ImplementationType.GetMethods().Where(m => m.IsDefined(IocInjectionAttributeType, true)))
            {
                List<object> paraInjectionList = new List<object>();
                foreach (var parameter in method.GetParameters())
                {
                    Type parameterType = parameter.ParameterType;
                    string paraShortName = this.GetAlias(parameter);
                    object paraInstance = this.Resolve(parameterType, paraShortName);

                    paraInjectionList.Add(paraInstance);
                }
                method.Invoke(instance, paraInjectionList.ToArray());
            }
        }

        /// <summary>
        /// 获取键
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <param name="alias">别名</param>
        /// <returns></returns>
        protected string GetKey(Type serviceType, string alias)
        {
            if (string.IsNullOrEmpty(alias))
                return serviceType.FullName;

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
