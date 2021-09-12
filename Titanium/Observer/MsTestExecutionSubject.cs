using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Titanium.Observer
{
    public class MsTestExecutionSubject : ITestExecutionSubject
    {
        private readonly List<ITestBehaviorObserver> testBehaviorObservers;

        public MsTestExecutionSubject()
        {
            testBehaviorObservers = new List<ITestBehaviorObserver>();
        }

        public void Attach(ITestBehaviorObserver observer)
        {
            testBehaviorObservers.Add(observer);
        }

        public void Detach(ITestBehaviorObserver observer)
        {
            testBehaviorObservers.Remove(observer);
        }

        public void PreTestInit(TestContext testContext, MemberInfo memberInfo)
        {
            testBehaviorObservers.ForEach(x => x.PreTestInit(testContext, memberInfo));
        }

        public void PostTestInit(TestContext testContext, MemberInfo memberInfo)
        {
            testBehaviorObservers.ForEach(x => x.PostTestInit(testContext, memberInfo));
        }

        public void PreTestCleanUp(TestContext testContext, MemberInfo memberInfo)
        {
            testBehaviorObservers.ForEach(x => x.PreTestCleanUp(testContext, memberInfo));
        }

        public void PostTestCleanUp(TestContext testContext, MemberInfo memberInfo)
        {
            testBehaviorObservers.ForEach(x => x.PostTestCleanUp(testContext, memberInfo));
        }

        public void TestInstanciated(MemberInfo memberInfo)
        {
            testBehaviorObservers.ForEach(x => x.TestInstanciated(memberInfo));
        }
    }
}
