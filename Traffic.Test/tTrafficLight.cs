using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Traffic.Business;

namespace Traffic.Test
{
    [TestClass]
    public class tTrafficLight
    {
        private TrafficLight _trafficLight;

        [TestInitialize]
        public void InitTrafficLight()
        {
            this._trafficLight = new TrafficLight(10);
        }

        [TestMethod]
        public void RemainsGreenDuringFirstInterval()
        {
            Assert.AreEqual(0.0, this._trafficLight.TimeTillGreen(4.5));
        }

        [TestMethod]
        public void LightChangesToRedInSecondInterval()
        {
            Assert.AreEqual(5.5, this._trafficLight.TimeTillGreen(14.5));
        }

        [TestMethod]
        public void LightChangesToGreenInThirdInterval()
        {
            Assert.AreEqual(0.0, this._trafficLight.TimeTillGreen(24.5));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IntervalCannotBeLessThan10()
        {
            this._trafficLight = new TrafficLight(9);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IntervalCannotBeGreaterThan60()
        {
            this._trafficLight = new TrafficLight(61);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MustSpendTimeOnRoad()
        {
            this._trafficLight.TimeTillGreen(-1.0);
        }

    }
}
