using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace Titanium.Observer
{
    public interface ITestBehaviorObserver
    {
        void PreTestInit(TestContext testContext, MemberInfo memberInfo);
        void PostTestInit(TestContext testContext, MemberInfo memberInfo);
        void PreTestCleanUp(TestContext testContext, MemberInfo memberInfo);
        void PostTestCleanUp(TestContext testContext, MemberInfo memberInfo);
        void TestInstanciated(MemberInfo memberInfo);
    }
}