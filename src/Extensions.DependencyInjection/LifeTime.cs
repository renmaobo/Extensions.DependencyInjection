using System;
using System.Collections.Generic;
using System.Text;

namespace Extensions.DependencyInjection
{
    /// <summary>
    /// 生命周期
    /// </summary>
    public enum LifeTime:int
    {
        /// <summary>
        /// 瞬时
        /// </summary>
        Transient,
        /// <summary>
        /// 作用域单例
        /// </summary>
        Scoped,
        /// <summary>
        /// 单例
        /// </summary>
        Singleton,
    }
}
