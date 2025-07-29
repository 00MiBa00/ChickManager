using UnityEngine;
using UnityEngine.UI;

namespace Views.Reminder
{
    public class ReminderCounterView : MonoBehaviour
    {
        [SerializeField] private Text _text;

        public void UpdateCount(int selectedCount, int allCount)
        {
            _text.text = $"{selectedCount}/{allCount}";
        }
    }
}