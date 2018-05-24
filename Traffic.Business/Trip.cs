using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traffic.Business
{
    public class Trip
    {
        private readonly IList<RoadSegment> _segments;
        private readonly int _speed;

        public Trip(int speed, int[] lights)
        {
            _speed = speed;
            _segments = new List<RoadSegment>(lights.Count());
            foreach (int lightInterval in lights)
            {
                _segments.Add(new RoadSegment(lightInterval));
            }
            _segments.Add(new RoadSegment()); // the final piece of road without a light
        }

        public int GetTime()
        {
            double elaspsedTime = 0;
            foreach (RoadSegment segment in _segments)
            {
                elaspsedTime += segment.TimeToTravel(_speed, elaspsedTime);
            }

            return (int)Math.Floor(elaspsedTime);

        }
    }
}
