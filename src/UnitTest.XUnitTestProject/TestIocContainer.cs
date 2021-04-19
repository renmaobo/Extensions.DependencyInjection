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
    /// 测试Ioc容器
    /// </summary>
    public class TestIocContainer
    {
        /// <summary>
        /// 单个注册测试
        /// </summary>
        [Fact]
        public void SingleRegisterTest()
        {
            IBuilder container = new IocContainerBuilder();
            container.Register<ILogBll, LogBll>();
            System.Diagnostics.Debug.WriteLine($"container count: {container.GetContainerMembersCount()}");
        }

        /// <summary>
        /// 重复注册测试
        /// </summary>
        [Fact]
        public void RepeatRegisterTest()
        {
            IBuilder container = new IocContainerBuilder();
            container.Register<ILogBll, LogBll>();
            Assert.Throws<RepeatRegisterException>(() =>
            {
                container.Register<ILogBll, LogBll>();
            });
            System.Diagnostics.Debug.WriteLine($"container count: {container.GetContainerMembersCount()}");
        }

        /// <summary>
        /// 多个实现注册测试
        /// </summary>
        [Fact]
        public void MoreImplementationRegisterTest()
        {
            IBuilder container = new IocContainerBuilder();
            container.Register<ILogBll, LogBll>(alias: "LogBll");
            container.Register<ILogBll, HttpLogBll>(alias: "HttpLogBll");
            container.Register<ILogBll, HttpsLogBll>(alias: "HttpsLogBll");
            System.Diagnostics.Debug.WriteLine($"container count: {container.GetContainerMembersCount()}");
        }

        /// <summary>
        /// 单个解析测试
        /// </summary>
        [Fact]
        public void SingleResolveTest()
        {
            IBuilder container = new IocContainerBuilder();
            container.Register<ILogBll, LogBll>();
            ILogBll logBll = container.Resolve<ILogBll>();
            logBll.Add("this is test log.");
            Assert.IsType(typeof(LogBll), logBll);
        }


        /// <summary>
        /// 多实现解析测试
        /// </summary>
        [Fact]
        public void MoreImplementationResolveTest()
        {
            IBuilder container = new IocContainerBuilder();

            container.Register<ILogBll, LogBll>(alias: "LogBll");
            ILogBll logBll = container.Resolve<ILogBll>("LogBll");
            logBll.Add("this is test log.");
            Assert.IsType(typeof(LogBll), logBll);

            container.Register<ILogBll, HttpLogBll>(alias: "HttpLogBll");
            ILogBll httpLogBll = container.Resolve<ILogBll>("HttpLogBll");
            httpLogBll.Add("this is test http log.");
            Assert.IsType(typeof(HttpLogBll), httpLogBll);

            container.Register<ILogBll, HttpsLogBll>(alias: "HttpsLogBll");
            ILogBll httpsLogBll = container.Resolve<ILogBll>("HttpsLogBll");
            httpsLogBll.Add("this is test https log.");
            Assert.IsType(typeof(HttpsLogBll), httpsLogBll);
        }
    }
}
