using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traffic.Business
{
    public class TrafficLight
    {
        private ILightState _state;
        private readonly int _interval;

        private TrafficLight()
        {
            _state = new GreenLight();
        }

        public TrafficLight(int lightInterval):this()
        {
                if (lightInterval < 10 || lightInterval > 60)
                {
                    throw new ArgumentOutOfRangeException(String.Format("'Interval' must be between 10 and 60 (inclusive), current value[{0}]", lightInterval));
                }
            _interval = lightInterval;
        }

        private LightColor GetColor(double elapsedSeconds)
        {
            int numberOfChanges = GetCountOfChanges(elapsedSeconds);
            _state = _state.Change(numberOfChanges);

            return _state.Color;
        }

        private int GetCountOfChanges(double elapsedSeconds)
        {
            if (elapsedSeconds < 0)
            {
                throw new ArgumentOutOfRangeException(String.Format("'elapsedSeconds' must be >= 0, current value [{0}]", elapsedSeconds));
            }
            int numberOfChanges = (int)Math.Floor(elapsedSeconds / _interval); 
            return numberOfChanges;
        }


        public double TimeTillGreen(double elapsedSeconds)
        {
            if (GetColor(elapsedSeconds) == LightColor.Green)
            {
                return 0.0;
            }
            else
            {
                return _interval - (elapsedSeconds % _interval);
            }
        }
    }
}
