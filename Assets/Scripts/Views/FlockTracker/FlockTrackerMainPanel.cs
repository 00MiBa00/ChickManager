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

        public void SetInfo(List<FlockItemModel> models)
        {
            if (_activeObjects != null)
            {
                foreach (var activeObject in _activeObjects)
                {
                    Destroy(activeObject);
                }
                
                _activeObjects.Clear();
            }

            _activeObjects ??= new List<GameObject>();

            foreach (var model in models)
            {
                GameObject go = Instantiate(_flockTrackerItemPrefab, _container);
                FlockTrackerItemView view = go.GetComponent<FlockTrackerItemView>();
                
                go.transform.SetSiblingIndex(0);
                
                _activeObjects.Add(go);
                
                view.SetInfo(model._count, model.BreedType.ToString());
            }
        }
    }
}