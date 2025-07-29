using System;

namespace Datas.Eggs
{
    [Serializable]
    public class EggsData
    {
        public string _date;
        public int _count;

        public EggsData(DateTime date, int count)
        {
            _date = date.ToString("o");
            _count = count;
        }
        
        public DateTime GetDate()
        {
            return DateTime.Parse(_date);
        }
        
        public string GetRelativeDate()
        {
            DateTime date = GetDate();

            int daysAgo = (DateTime.Today - date.Date).Days;

            if (daysAgo == 0)
                return "Today";
            else if (daysAgo == 1)
                return "1 day ago";
            else
                return $"{daysAgo} days ago";
        }
    }
}