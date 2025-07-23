using System;
using System.Linq;
using Types;
using UnityEngine;
using UnityEngine.UI;
using Views.General;

namespace Views.FlockTracker
{
    public class AddFlockPanel : PanelView
    {
        [SerializeField] private Dropdown _dropdown;
        [SerializeField] private InputField _inputField;
        [SerializeField] private Button _saveBtn;

        public event Action<int> OnInputCountAction;
        public event Action<int> OnSelectedBreedAction;

        private void Awake()
        {
            _saveBtn.interactable = false;
            _inputField.onValueChanged.AddListener(OnCountChanged);
            _dropdown.onValueChanged.AddListener(OnDropdownChanged);
            
            SetDropDown();
        }

        private void OnDestroy()
        {
            _inputField.onValueChanged.RemoveAllListeners();
            _dropdown.onValueChanged.RemoveAllListeners();
        }

        private void SetDropDown()
        {
            _dropdown.ClearOptions();

            var enumValues = Enum.GetValues(typeof(Types.BreedsChickensType))
                .Cast<Types.BreedsChickensType>()
                .ToList();

            var optionLabels = enumValues
                .Select((Types.BreedsChickensType b) => b.GetDescription())
                .ToList();
            
            _dropdown.AddOptions(optionLabels);
        }
        
        private void OnDropdownChanged(int index)
        {
            OnSelectedBreedAction?.Invoke(index);
        }

        private void OnCountChanged(string input)
        {
            if (int.TryParse(input, out var number))
            {
                OnInputCountAction?.Invoke(number);
            }
            else
            {
                _saveBtn.interactable = false;
            }

            _saveBtn.interactable = !string.IsNullOrWhiteSpace(input);
        }
    }
}