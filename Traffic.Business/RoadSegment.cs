using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traffic.Business
{
    class RoadSegment
    {
        private int _segmentLength = 150; // in meters and default value
        private readonly TrafficLight _light;
        private static int[] _acceptableSpeeds = new int[] { 5, 10, 15, 20, 25, 30 };

        public RoadSegment() { }

        public RoadSegment(int lightInterval):this()
        {
            _light = new TrafficLight(lightInterval);
        }

        // the time to travel only this segement
        internal double TimeToTravel(int speed, double elaspsedTime)
        {
            if (elaspsedTime < 0){
                throw new ArgumentOutOfRangeException(String.Format("'elapsedTime' must be greater than 0.  Current value[{0}]",  elaspsedTime));
            }
            double timeOnRoad = GetTimeOnRoad(speed);
            double timeAtLight = GetTimeAtLight(timeOnRoad + elaspsedTime);
            return timeOnRoad + timeAtLight;
        }

        internal double GetTimeAtLight(double totalTimeToLight)
        {
            if (_light != null)
            {
                return _light.TimeTillGreen(totalTimeToLight );
            }
            else
            {
                return 0.0;
            }
        }

        internal double GetTimeOnRoad(int speed)
        {
            if (!_acceptableSpeeds.Contains(speed)) {
                throw new ArgumentOutOfRangeException(String.Format("'speed' must be one of [{0}].  Current value[{1}]", String.Join(",",_acceptableSpeeds), speed));
            }
            return (double)_segmentLength / (double)speed;
        }
    }
}
