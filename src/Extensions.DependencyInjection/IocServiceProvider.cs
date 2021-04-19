using System;
using System.Collections.Generic;
using System.Text;

namespace Extensions.DependencyInjection
{
    /// <summary>
    /// IOC服务提供者
    /// </summary>
    public class IocServiceProvider : IServiceProvider
    {
        /// <summary>
        /// 获取服务
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}
