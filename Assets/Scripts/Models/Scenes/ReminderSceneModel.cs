using System.Collections.Generic;
using System.IO;
using System.Linq;
using Datas.Reminder;
using UnityEngine;
using Wrappers;

namespace Models.Scenes
{
    public class ReminderSceneModel
    {
        private string filePath = Path.Combine(Application.persistentDataPath, "data.json");

        public List<ReminderData> ReminderDatas => LoadList();
        public int DatasCount => ReminderDatas.Count;

        public void DeleteItem(int index)
        {
            List<ReminderData> datas = new List<ReminderData>(ReminderDatas);
            
            datas.RemoveAt(index);
            
            SaveList(datas);
        }

        public void ResetStates()
        {
            List<ReminderData> datas = new List<ReminderData>(ReminderDatas);

            foreach (var data in datas)
            {
                data._isChecked = false;
            }
            
            SaveList(datas);
        }

        public void ChangeToggleState(int index)
        {
            List<ReminderData> datas = new List<ReminderData>(ReminderDatas);

            datas[index]._isChecked = !datas[index]._isChecked;
            
            SaveList(datas);
        }
        
        public int CountTrue()
        {
            return ReminderDatas.Count(item => item._isChecked);
        }

        public void AddItem(string name)
        {
            ReminderData data = new ReminderData(name, false);
            
            List<ReminderData> datas = new List<ReminderData>(ReminderDatas);
            
            datas.Add(data);     
            
            SaveList(datas);
        }

        private void SaveList(List<ReminderData> dataList)
        {
            ReminderDataWrapper wrapper = new ReminderDataWrapper(dataList);
            string json = JsonUtility.ToJson(wrapper, true);
            File.WriteAllText(filePath, json);
        }
        
        private List<ReminderData> LoadList()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                ReminderDataWrapper wrapper = JsonUtility.FromJson<ReminderDataWrapper>(json);
                return wrapper._reminderDatas;
            }
            else
            {
                List<ReminderData> dataList = new List<ReminderData>
                {
                    new ReminderData("Feeding", false),
                    new ReminderData("Cleaning", false),
                    new ReminderData("Vaccination", false)
                };
                return dataList;
            }
        }
    }
}