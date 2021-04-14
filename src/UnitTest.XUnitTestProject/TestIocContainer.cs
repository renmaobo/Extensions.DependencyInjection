using Extensions.DependencyInjection;
using Extensions.DependencyInjection.Container;
using Extensions.DependencyInjection.Exceptions;
using System;
using UnitTest.BLL;
using UnitTest.IBLL;
using Xunit;

namespace UnitTest.XUnitTestProject
{
    /// <summary>
    /// ²âÊÔIocÈİÆ÷
    /// </summary>
    public class TestIocContainer
    {
        /// <summary>
        /// µ¥¸ö×¢²á²âÊÔ
        /// </summary>
        [Fact]
        public void SingleRegisterTest()
        {
            IContainer container = new IocContainer();
            container.Register<ILogBll, LogBll>();
            System.Diagnostics.Debug.WriteLine($"container count: {container.GetContainerMembersCount()}");
        }

        /// <summary>
        /// ÖØ¸´×¢²á²âÊÔ
        /// </summary>
        [Fact]
        public void RepeatRegisterTest()
        {
            IContainer container = new IocContainer();
            container.Register<ILogBll, LogBll>();
            Assert.Throws<RepeatRegisterException>(() =>
            {
                container.Register<ILogBll, LogBll>();
            });
            System.Diagnostics.Debug.WriteLine($"container count: {container.GetContainerMembersCount()}");
        }

        /// <summary>
        /// ¶à¸öÊµÏÖ×¢²á²âÊÔ
        /// </summary>
        [Fact]
        public void MoreImplementationRegisterTest()
        {
            IContainer container = new IocContainer();
            container.Register<ILogBll, LogBll>();
            container.Register<ILogBll, HttpLogBll>();
            container.Register<ILogBll, HttpsLogBll>();
            System.Diagnostics.Debug.WriteLine($"container count: {container.GetContainerMembersCount()}");
        }
    }
}
