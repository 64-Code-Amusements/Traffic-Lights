using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traffic.Business
{
    public interface ILightState
    {
        LightColor Color { get; }

        ILightState Change(int numberOfChanges);
    }
}
