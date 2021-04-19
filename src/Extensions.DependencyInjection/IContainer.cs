using System;
using System.Collections.Generic;
using System.Text;

namespace Extensions.DependencyInjection
{
    /// <summary>
    /// 容器(接口)
    /// </summary>
    public interface IContainer
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <typeparam name="TService">服务</typeparam>
        /// <typeparam name="TImplementation">实现</typeparam>
        /// <param name="lifeTime">生命周期。默认为瞬时</param>
        /// <param name="alias">别名</param>
        /// <param name="param">构造参数</param>
        void Register<TService, TImplementation>(LifeTime lifeTime = LifeTime.Transient, string alias = null, object[] param = null) where TImplementation : TService;

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <param name="implementationType">实现类型</param>
        /// <param name="lifeTime">生命周期。默认为瞬时</param>
        /// <param name="alias">别名</param>
        /// <param name="param">构造参数</param>
        void Register(Type serviceType, Type implementationType, LifeTime lifeTime = LifeTime.Transient, string alias = null, object[] param = null);

        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="alias">别名</param>
        /// <returns></returns>
        TService Resolve<TService>(string alias = null) where TService : class;

        /// <summary>
        /// 子容器
        /// </summary>
        /// <returns></returns>
        IContainer ChildContainer();

#if DEBUG
        /// <summary>
        /// 获取容器成员数量
        /// </summary>
        /// <returns></returns>
        int GetContainerMembersCount();
#endif
    }
}
