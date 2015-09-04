using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevStore.Service;

namespace DevStore.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            DeveloperService devService = new DeveloperService();
            devService.page(10, 20);
        }
    }
}
