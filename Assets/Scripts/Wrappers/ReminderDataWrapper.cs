using System;
using System.Collections.Generic;
using Datas.Reminder;

namespace Wrappers
{
    [Serializable]
    public class ReminderDataWrapper
    {
        public List<ReminderData> _reminderDatas;

        public ReminderDataWrapper(List<ReminderData> reminderDatas)
        {
            _reminderDatas = new List<ReminderData>(reminderDatas);
        }
    }
}