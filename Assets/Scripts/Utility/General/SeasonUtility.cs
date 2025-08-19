using System;
using Types;

namespace Utility.General
{
    public static class SeasonUtility
    {
        public static SeasonType FromDate()
        {
            return FromMonth(DateTime.Today.Month);
        }
        
        private static SeasonType FromMonth(int m)
        {
            return m switch
            {
                12 or 1 or 2 => SeasonType.Winter,
                3 or 4 or 5  => SeasonType.Spring,
                6 or 7 or 8  => SeasonType.Summer,
                _            => SeasonType.Autumn
            };
        }
    }
}