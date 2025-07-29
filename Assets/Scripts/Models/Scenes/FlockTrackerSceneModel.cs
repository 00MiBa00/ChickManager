using System.IO;
using System.Collections.Generic;
using UnityEngine;

using Types;
using Wrappers;
using Models.FlockTracker;

namespace Models.Scenes
{
    public class FlockTrackerSceneModel
    {
        private static string FilePath => Path.Combine(Application.persistentDataPath, "flock_data.json");

        private FlockItemModel _flockItemModel;
        private List<FlockItemModel> _flockItemModels;

        public List<FlockItemModel> FlockItemModels => _flockItemModels;

        public FlockTrackerSceneModel()
        {
            _flockItemModels = new List<FlockItemModel>(LoadFlock());
        }

        public void ResetFlock()
        {
            _flockItemModel = new FlockItemModel();
        }

        public void SetFlockCount(int value)
        {
            _flockItemModel._count = value;
        }

        public void SetFlockBreed(int index)
        {
            _flockItemModel.BreedType = (BreedsChickensType)index;
        }

        public void DeleteFlockItem(int index)
        {
            _flockItemModels.RemoveAt(index);
        }

        public void SaveFlock()
        {
            _flockItemModels.Add(_flockItemModel);
            
            SaveFlock(_flockItemModels);
        }

        private static void SaveFlock(List<FlockItemModel> flock)
        {
            var wrapper = new FlockDataWrapper { items = flock };
            string json = JsonUtility.ToJson(wrapper, true);
            File.WriteAllText(FilePath, json);
        }

        private static List<FlockItemModel> LoadFlock()
        {
            if (!File.Exists(FilePath))
            {
                return new List<FlockItemModel>();
            }

            string json = File.ReadAllText(FilePath);
            var wrapper = JsonUtility.FromJson<FlockDataWrapper>(json);
            return wrapper?.items ?? new List<FlockItemModel>();
        }
    }
}