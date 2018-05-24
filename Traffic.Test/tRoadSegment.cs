using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Traffic.Business;

namespace Traffic.Test
{
    [TestClass]
    public class tRoadSegment
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SpeedIsConstrained()
        {
            RoadSegment segment = new RoadSegment();
            segment.GetTimeOnRoad(12);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MustHaveSpendTime()
        {
            RoadSegment segment = new RoadSegment();
            segment.TimeToTravel(10,-1.0);
        }

        [TestMethod]
        public void TimeOnRoad()
        {
            RoadSegment segment = new RoadSegment();
            Assert.AreEqual(7.5, segment.GetTimeOnRoad(20));
        }

        [TestMethod]
        public void TimeAtGreenLight()
        {
            RoadSegment segment = new RoadSegment(10);
            Assert.AreEqual(0.0, segment.GetTimeAtLight(7.5));
        }

        [TestMethod]
        public void TimeAtRedLight()
        {
            RoadSegment segment = new RoadSegment(10);
            Assert.AreEqual(7.5, segment.GetTimeAtLight(12.5));
        }

        [TestMethod]
        public void TimeOnSegmentWithGreenLight()
        {
            RoadSegment segment = new RoadSegment(10);
            Assert.AreEqual(7.5, segment.TimeToTravel(20,0.0));
        }

        [TestMethod]
        public void TimeOnSegmentWithRedLight()
        {
            RoadSegment segment = new RoadSegment(10);
            Assert.AreEqual(20, segment.TimeToTravel(10,0.0));
        }
    }
}
