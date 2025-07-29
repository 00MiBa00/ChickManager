using System;
using UnityEngine;
using UnityEngine.UI;

namespace Views.Reminder
{
    public class ReminderItemView : MonoBehaviour
    {
        [SerializeField] private Toggle _toggle;
        [SerializeField] private Text _name;
        [SerializeField] private Button _btn;

        public event Action<ReminderItemView> OnPressBtnAction;
        public event Action<ReminderItemView> OnToggleValueChangedAction; 

        private void OnEnable()
        {
            _btn.onClick.AddListener(OnPressBtn);
            _toggle.onValueChanged.AddListener(OnToggleValueChanged);
        }

        private void OnDisable()
        {
            _btn.onClick.RemoveAllListeners();
            _toggle.onValueChanged.RemoveAllListeners();
        }

        public void SetInfo(bool isSelected, string name)
        {
            _toggle.isOn = isSelected;
            _name.text = name;
        }

        private void OnPressBtn()
        {
            OnPressBtnAction?.Invoke(this);
        }

        private void OnToggleValueChanged(bool value)
        {
            Debug.Log("Change");
            
            OnToggleValueChangedAction?.Invoke(this);
        }
    }
}