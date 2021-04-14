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
    /// ����Ioc����
    /// </summary>
    public class TestIocContainer
    {
        /// <summary>
        /// ����ע�����
        /// </summary>
        [Fact]
        public void SingleRegisterTest()
        {
            IContainer container = new IocContainer();
            container.Register<ILogBll, LogBll>();
            System.Diagnostics.Debug.WriteLine($"container count: {container.GetContainerMembersCount()}");
        }

        /// <summary>
        /// �ظ�ע�����
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
        /// ���ʵ��ע�����
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
