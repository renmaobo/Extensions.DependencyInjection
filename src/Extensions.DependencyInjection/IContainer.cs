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
        void Register<TService, TImplementation>() where TImplementation : TService;

        /// <summary>
        /// 解析
        /// </summary>
        /// <typeparam name="TImplementation">实现</typeparam>
        /// <param name="key">键</param>
        /// <returns></returns>
        TImplementation Resolve<TImplementation>(string key);

        /// <summary>
        /// 子容器
        /// </summary>
        /// <returns></returns>
        IContainer ChildContainer();
    }
}
