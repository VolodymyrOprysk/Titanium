using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Titanium.Observer
{
    public interface ITestExecutionSubject
    {
        void Attach(ITestBehaviorObserver observer);
        void Detach(ITestBehaviorObserver observer);
        void PreTestInit(TestContext testContext, MemberInfo memberInfo);
        void PostTestInit(TestContext testContext, MemberInfo memberInfo);
        void PreTestCleanUp(TestContext testContext, MemberInfo memberInfo);
        void PostTestCleanUp(TestContext testContext, MemberInfo memberInfo);
        void TestInstanciated(MemberInfo memberInfo);
    }
}
