using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traffic.Business
{
    abstract class LightState : ILightState
    {

        public abstract LightColor Color { get; }

        public ILightState Change(int numberOfChanges)
        {
            if (numberOfChanges < 0)
            {
                throw new ArgumentOutOfRangeException(String.Format("'numberOfChange' must be greater than or equal to 0. Current value[{0}]", numberOfChanges));
            }
            if (numberOfChanges % 2 == 0)
            {
                return this; 
            }
            else
            {
                return !this; 
            }
        }

       public  static ILightState operator ! (LightState light ){
           if (light.Color == LightColor.Red)
           {
               return new GreenLight();
           }
           else
           {
               return new RedLight();
           }
    }
    }
}
