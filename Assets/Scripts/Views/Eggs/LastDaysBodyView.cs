using System.Collections.Generic;
using Datas.Eggs;
using UnityEngine;

namespace Views.Eggs
{
    public class LastDaysBodyView : MonoBehaviour
    {
        [SerializeField] private GameObject _eggsItemPrefab;
        [SerializeField] private RectTransform _container;

        private List<GameObject> _activeObjects;
        
        public void SetInfo(List<EggsData> datas)
        {
            if (datas == null || datas.Count == 0)
            {
                return;
            }

            if (_activeObjects is { Count: > 0 })
            {
                foreach (var activeObject in _activeObjects)
                {
                    Destroy(activeObject);
                }
                
                _activeObjects.Clear();
            }

            _activeObjects ??= new List<GameObject>();

            foreach (var data in datas)
            {
                GameObject go = Instantiate(_eggsItemPrefab, _container);
                _activeObjects.Add(go);
                
                EggsItemView view = go.GetComponent<EggsItemView>();
                view.SetInfo(data.GetRelativeDate(), data._count);
            }
        }
    }
}