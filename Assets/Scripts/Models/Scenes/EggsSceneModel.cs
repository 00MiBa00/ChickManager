using System;
using System.Collections.Generic;
using System.IO;
using Datas.Eggs;
using UnityEngine;
using Wrappers;

namespace Models.Scenes
{
    public class EggsSceneModel
    {
        private  string SavePath => Path.Combine(Application.persistentDataPath, "eggs_data.json");
        
        public  List<EggsData> Load()
        {
            if (!File.Exists(SavePath))
            {
                Debug.Log("ℹ️ No saved eggs data found.");
                return new List<EggsData>();
            }

            string json = File.ReadAllText(SavePath);
            EggsDataWrapper wrapper = JsonUtility.FromJson<EggsDataWrapper>(json);
            
            return wrapper._datas;
        }
        
        public void AddEggs(int count)
        {
            DateTime today = DateTime.Today;

            List<EggsData> datas = new List<EggsData>(Load());
            
            EggsData todayData = datas.Find(e => e.GetDate().Date == today);

            if (todayData != null)
            {
                todayData._count += count;
            }
            else
            {
                if (datas.Count >= 5)
                {
                    datas.RemoveAt(0);
                }
                
                datas.Add(new EggsData(DateTime.Now, count));
            }

            Save(datas);
        }

        private  void Save(List<EggsData> dataList)
        {
            EggsDataWrapper wrapper = new EggsDataWrapper(dataList);
            
            string json = JsonUtility.ToJson(wrapper, true);
            File.WriteAllText(SavePath, json);
        }
    }
}