using UnityEngine;
using UnityEngine.UI;

namespace Views.FlockTracker
{
    public class FlockTrackerItemView : MonoBehaviour
    {
        [SerializeField] private Text _countText;
        [SerializeField] private Text _nameText;

        public void SetInfo(int count, string name)
        {
            _countText.text = count.ToString();
            _nameText.text = name;
        }
    }
}