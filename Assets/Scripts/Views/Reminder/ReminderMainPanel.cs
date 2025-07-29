using System;
using System.Collections.Generic;
using Datas.Reminder;
using UnityEngine;
using UnityEngine.UI;
using Views.General;

namespace Views.Reminder
{
    public class ReminderMainPanel : PanelView
    {
        [SerializeField] private Text _activeCountText;
        [SerializeField] private GameObject _reminderItemPrefab;
        [SerializeField] private RectTransform _container;

        private List<GameObject> _activeObjects;

        public event Action<int> OnPressDeleteItemBtnAction; 
        public event Action<int> OnToggleValueChangedAction;

        public void SetInfo(List<ReminderData> datas)
        {
            if (_activeObjects is { Count: > 0 })
            {
                foreach (var activeObject in _activeObjects)
                {
                    ReminderItemView view = activeObject.GetComponent<ReminderItemView>();
                    view.OnPressBtnAction -= OnPressDeleteBtn;
                    view.OnToggleValueChangedAction -= OnToggleValueChanged;
                    
                    Destroy(activeObject);
                }
                
                _activeObjects.Clear();
            }

            _activeObjects ??= new List<GameObject>();

            foreach (var data in datas)
            {
                GameObject go = Instantiate(_reminderItemPrefab, _container);
                _activeObjects.Add(go);
                
                go.transform.SetSiblingIndex(0);
                
                ReminderItemView view = go.GetComponent<ReminderItemView>();
                view.OnPressBtnAction += OnPressDeleteBtn;
                view.OnToggleValueChangedAction += OnToggleValueChanged;
                view.SetInfo(data._isChecked, data._name);
            }
        }

        private void OnPressDeleteBtn(ReminderItemView view)
        {
            int index = _activeObjects.IndexOf(view.gameObject);
            
            OnPressDeleteItemBtnAction?.Invoke(index);
        }

        private void OnToggleValueChanged(ReminderItemView view)
        {
            int index = _activeObjects.IndexOf(view.gameObject);
            
            OnToggleValueChangedAction?.Invoke(index);
        }
    }
}