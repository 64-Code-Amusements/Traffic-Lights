using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Traffic.Business;

namespace Traffic.Test
{
    [TestClass]
    public class tLightState
    {
        [TestMethod]
        public void RedLightIsRed()
        {
            ILightState light = new RedLight();
            Assert.AreEqual(LightColor.Red,light.Color);
        }

        [TestMethod]
        public void GreenLightIsGreen()
        {
            ILightState light = new GreenLight();
            Assert.AreEqual(LightColor.Green, light.Color);
        }

        [TestMethod]
        public void RedLightRemainsRed()
        {
            ILightState light = new RedLight();
            Assert.AreEqual(LightColor.Red, light.Change(0).Color);
        }

        [TestMethod]
        public void RedLightTurnsGreen()
        {
            ILightState light = new RedLight();
            Assert.AreEqual(LightColor.Green, light.Change(1).Color);
        }

        [TestMethod]
        public void RedLightTurnsRed()
        {
            ILightState light = new RedLight();
            Assert.AreEqual(LightColor.Red, light.Change(2).Color);
        }


        [TestMethod]
        public void GreenLightRemainsGreen()
        {
            ILightState light = new GreenLight();
            Assert.AreEqual(LightColor.Green, light.Change(0).Color);
        }

        [TestMethod]
        public void GreenLightTurnsRed()
        {
            ILightState light = new GreenLight();
            Assert.AreEqual(LightColor.Red, light.Change(1).Color);
        }

        [TestMethod]
        public void GreenLightTurnsGreen()
        {
            ILightState light = new GreenLight();
            Assert.AreEqual(LightColor.Green, light.Change(2).Color);
        }

        // invalid data
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void LightDoesAcceptNegatives()
        {
            ILightState light = new GreenLight();
            light.Change(-1);
        }

    }
}
