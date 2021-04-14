using System;
using System.Collections.Generic;
using System.Text;

namespace Extensions.DependencyInjection.Attributes
{
    /// <summary>
    /// 常量参数特性
    /// </summary>
    /// <remarks>用于构造函数常量注册</remarks>
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class ConstantParameterAttribute : Attribute
    {
    }
}
