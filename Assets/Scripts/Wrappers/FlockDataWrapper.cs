using System;
using System.Collections.Generic;
using Models.FlockTracker;

namespace Wrappers
{
    [Serializable]
    public class FlockDataWrapper
    {
        public List<FlockItemModel> items = new();
    }
}