using System;
using UnityEngine;
using UnityEngine.UI;
using Views.General;

namespace Views.Reminder
{
    public class AddReminderPanel : PanelView
    {
        [SerializeField] private InputField _inputField;
        [SerializeField] private Button _saveBtn;

        public event Action<string> OnPressSaveBtnAction; 

        private void Awake()
        {
            _inputField.onValueChanged.AddListener(OnInputValueChanged);
            _saveBtn.onClick.AddListener(OnPressSaveBtn);
        }

        private void OnDestroy()
        {
            _inputField.onValueChanged.RemoveAllListeners();
            _saveBtn.onClick.RemoveAllListeners();
        }

        private void OnInputValueChanged(string input)
        {
            bool canShowSaveBtn = !string.IsNullOrWhiteSpace(input);

            _saveBtn.interactable = canShowSaveBtn;
        }

        private void OnPressSaveBtn()
        {
            OnPressSaveBtnAction?.Invoke(_inputField.text);
        }
    }
}