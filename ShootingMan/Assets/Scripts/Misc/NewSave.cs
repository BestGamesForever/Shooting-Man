using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NewSave : MonoBehaviour
{
    //Works Only Editor id u want to work on mobile as well Just change the data path To Persistence data path.
    [System.Serializable]
    public class SaveData
    {      
        public int Shooting = ShootingManager.ShootingCounter;
    }
    public void Save()
    {
        SaveData data = new SaveData();      
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.dataPath + "/save.txt", json);
    }
    public void Load()
    {
        if (File.Exists(Application.dataPath + "/save.txt"))
        {
            string savestring = File.ReadAllText(Application.dataPath + "/save.txt");
            SaveData data = JsonUtility.FromJson<SaveData>(savestring);            
            ShootingManager.ShootingCounter = data.Shooting;
        }
    }
}
