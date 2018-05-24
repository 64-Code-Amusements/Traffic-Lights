using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traffic.Business
{
    class GreenLight :LightState
    {
        public override LightColor Color
        {
            get { return LightColor.Green; }
        }
    }
}
