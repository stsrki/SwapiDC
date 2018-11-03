using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SwapiDC.Tests
{
    [TestClass]
    public class TestCalculator : TestBase
    {
        private ICalculator calculator;

        [TestInitialize]
        public void Setup()
        {
            calculator = container.GetInstance<ICalculator>();
        }

        [TestMethod]
        public void Test_days()
        {
            var hours = calculator.ToHours( new Duration( TimeUnit.Day, 6 ) );
            var exptected = 144;

            Assert.AreEqual( exptected, hours );
        }

        [TestMethod]
        public void Test_years()
        {
            var hours = calculator.ToHours( new Duration( TimeUnit.Year, 3 ) );
            var exptected = 26280;

            Assert.AreEqual( exptected, hours );
        }

        [TestMethod]
        public void Test_empty()
        {
            var hours = calculator.ToHours( new Duration() );
            var exptected = 0;

            Assert.AreEqual( exptected, hours );
        }

        [TestMethod]
        [ExpectedException( typeof( ArgumentNullException ) )]
        public void Test_null()
        {
            var hours = calculator.ToHours( null );
        }
    }
}
