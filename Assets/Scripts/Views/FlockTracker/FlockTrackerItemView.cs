using System;
using UnityEngine;
using UnityEngine.UI;

namespace Views.FlockTracker
{
    public class FlockTrackerItemView : MonoBehaviour
    {
        [SerializeField] private Text _countText;
        [SerializeField] private Text _nameText;
        [SerializeField] private Button _btn;
        
        public event Action<FlockTrackerItemView> OnPressBtnAction;

        private void OnEnable()
        {
            _btn.onClick.AddListener(OnPressBtn);
        }

        private void OnDisable()
        {
            _btn.onClick.RemoveAllListeners();
        }

        public void SetInfo(int count, string name)
        {
            _countText.text = count.ToString();
            _nameText.text = name;
        }

        private void OnPressBtn()
        {
            OnPressBtnAction?.Invoke(this);
        }
    }
}