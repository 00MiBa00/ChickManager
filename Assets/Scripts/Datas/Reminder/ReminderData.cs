using System;

namespace Datas.Reminder
{
    [Serializable]
    public class ReminderData
    {
        public bool _isChecked;
        public string _name;
        
        public ReminderData(string name, bool flag)
        {
            this._name = name;
            this._isChecked = flag;
        }
    }
}