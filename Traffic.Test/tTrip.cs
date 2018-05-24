using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Traffic.Business;

namespace Traffic.Test
{
    [TestClass]
    public class tTrip
    {
        // test case 0
        [TestMethod]
        public void TestCaseZero()
        {
            Trip trip = new Trip(30, new int[] { 10, 10, 10 });
            // trip.Segment = 150; // this is the default
            Assert.AreEqual(30, trip.GetTime());
        }

        // test case 1
        [TestMethod]
        public void TestCaseOne()
        {
            Trip trip = new Trip(20, new int[] { 10, 10, 10 });
            Assert.AreEqual(35, trip.GetTime());
        }

        // test case 2
        [TestMethod]
        public void TestCaseTwo()
        {
            Trip trip = new Trip(20, new int[] { 10, 20, 30 });
            Assert.AreEqual(30, trip.GetTime());
        }

        // test case 3
        [TestMethod]
        public void TestCaseThree()
        {
            Trip trip = new Trip(5, new int[] { 10, 11, 12, 13, 14, 15 });
            Assert.AreEqual(240, trip.GetTime());
        }

        // test case 4
        [TestMethod]
        public void TestCaseFour()
        {
            Trip trip = new Trip(5, new int[] { 60, 60, 60, 60, 60, 60, 60, 60, 60, 60 });
            Assert.AreEqual(630, trip.GetTime());
        }

        // test case 5
        [TestMethod]
        public void TestCaseFive()
        {
            Trip trip = new Trip(25, new int[] { 55, 29, 26, 12, 19, 39, 18, 20, 23, 28, 56, 20, 59, 48, 33, 40, 30, 60, 19 });
            Assert.AreEqual(252, trip.GetTime());
        }

    }
}
