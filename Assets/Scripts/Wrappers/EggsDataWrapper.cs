using System;
using System.Collections.Generic;
using Datas.Eggs;

namespace Wrappers
{
    [Serializable]
    public class EggsDataWrapper
    {
        public List<EggsData> _datas;

        public EggsDataWrapper(List<EggsData> datas)
        {
            _datas = new List<EggsData>(datas);
        }
    }
}