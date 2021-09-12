using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Titanium.Observer
{
    public class BaseTestBehaviorObserver : ITestBehaviorObserver
    {
        private ITestExecutionSubject testExecutionSubject;

        public BaseTestBehaviorObserver(ITestExecutionSubject testExecutionSubject)
        {
            this.testExecutionSubject = testExecutionSubject;
            testExecutionSubject.Attach(this);
        }

        public virtual void PostTestCleanUp(TestContext testContext, MemberInfo memberInfo)
        {
            
        }

        public virtual void PostTestInit(TestContext testContext, MemberInfo memberInfo)
        {
            
        }

        public virtual void PreTestCleanUp(TestContext testContext, MemberInfo memberInfo)
        {
            
        }

        public virtual void PreTestInit(TestContext testContext, MemberInfo memberInfo)
        {
            
        }

        public virtual void TestInstanciated(MemberInfo memberInfo)
        {

        }
    }
}
