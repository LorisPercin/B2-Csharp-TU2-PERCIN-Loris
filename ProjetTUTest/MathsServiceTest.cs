using NUnit.Framework;
using ProjetPourTU.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetTUTest
{
    class MathsServiceTest
    {
        MathsService mathService;

        [SetUp]
        public void Setup()
        {
            mathService = new MathsService();
        }

        [TestCase(0, 3, 0)]
        [TestCase(1, 1, 1)]
        [TestCase(42, 6, 7)]
        public void MultiplierTest(int expected, int var1, int var2)
        {
            var result = mathService.Multiplier(var1, var2);

            Assert.AreEqual(expected, result);
        }
    }
}
