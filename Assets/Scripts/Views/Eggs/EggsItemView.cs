using UnityEngine;
using UnityEngine.UI;

namespace Views.Eggs
{
    public class EggsItemView : MonoBehaviour
    {
        [SerializeField] private Text _dateText;
        [SerializeField] private Text _countText;

        public void SetInfo(string date, int count)
        {
            _dateText.text = $"{date},";
            _countText.text =$"{ count} egg(s)";
        }
    }
}