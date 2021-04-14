using System;
using System.Collections.Generic;
using System.Text;

namespace Extensions.DependencyInjection.Container
{
    /// <summary>
    /// 实现实体
    /// </summary>
    public class ImplementationModel
    {
        /// <summary>
        /// 实现类型
        /// </summary>
        public Type ImplementationType { get; set; }

        /// <summary>
        /// 生命周期
        /// </summary>
        public LifeTime LifeTime { get; set; }

        /// <summary>
        /// 别名
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// 参数(构造注入时所需参数)
        /// </summary>
        public object[] Paramters { get; set; }
    }
}
