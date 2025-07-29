using System;
using System.Collections.Generic;
using Models.FlockTracker;
using UnityEngine;
using Views.General;

namespace Views.FlockTracker
{
    public class FlockTrackerMainPanel : PanelView
    {
        [SerializeField] private GameObject _flockTrackerItemPrefab;
        [SerializeField] private Transform _container;

        private List<GameObject> _activeObjects;

        public event Action<int> OnPressDeleteBtnAction;

        public void SetInfo(List<FlockItemModel> models)
        {
            if (_activeObjects != null)
            {
                foreach (var activeObject in _activeObjects)
                {
                    FlockTrackerItemView view = activeObject.GetComponent<FlockTrackerItemView>();
                    view.OnPressBtnAction -= OnPressDeleteBtn;
                    Destroy(activeObject);
                }
                
                _activeObjects.Clear();
            }

            _activeObjects ??= new List<GameObject>();

            foreach (var model in models)
            {
                GameObject go = Instantiate(_flockTrackerItemPrefab, _container);
                FlockTrackerItemView view = go.GetComponent<FlockTrackerItemView>();
                view.OnPressBtnAction += OnPressDeleteBtn;
                
                go.transform.SetSiblingIndex(0);
                
                _activeObjects.Add(go);
                
                view.SetInfo(model._count, model.BreedType.ToString());
            }
        }

        private void OnPressDeleteBtn(FlockTrackerItemView view)
        {
            int index = _activeObjects.IndexOf(view.gameObject);
            
            OnPressDeleteBtnAction?.Invoke(index);
        }
    }
}