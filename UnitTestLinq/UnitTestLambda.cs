using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace UnitTestLinq
{
    [TestClass]
    public class UnitTestLambda
    {
        delegate int fctInt(int i);

        [TestMethod]
        public void TestMethod_Lambda_Ptr_function()
        {
            fctInt myFctInt = value => value * value;
            int result = myFctInt(5);

            Assert.AreEqual(25, result);
        }

        [TestMethod]
        public void TestMethod_Lambda_in_standard_query()
        {
            int[] tabNum = { 20, 10, 5, 46, 45};
            int result = tabNum.Where(num => num > 18).Count();

            Assert.AreEqual(3, result);
        }
    }
}
