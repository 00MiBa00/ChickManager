using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace Views.General
{
    public class PanelView : MonoBehaviour
    {
        public Action<int> PressBtnAction { get; set; }

        [SerializeField]
        private List<Button> _btns;

        private void OnEnable()
        {
            for (int i = 0; i < _btns.Count; i++)
            {
                int index = i;

                _btns[i].onClick.AddListener(() => Notification(index));
            }
        }

        private void OnDisable()
        {
            for (int i = 0; i < _btns.Count; i++)
            {
                int index = i;

                _btns[i].onClick.RemoveAllListeners();
            }
        }

        public void Open()
        {
            SetActive(true);
        }

        public void Close()
        {
            SetActive(false);
        }

        private void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }

        private void Notification(int index)
        {
            PressBtnAction?.Invoke(index);
        }
    }
}