using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
public static class SaveSystem 
{
  public static void SaveData(Scene scene)
  {
    BinaryFormatter formatter = new BinaryFormatter();
    string path = Application.persistentDataPath + "/Playerdata.fun";
    FileStream stream = new FileStream(path, FileMode.Create);

    PlayerData data = new PlayerData(scene);

    formatter.Serialize(stream,data);

    stream.Close();

  }

  public static PlayerData LoadData()
  {
    string path = Application.persistentDataPath + "/Playerdata.fun";
    if (File.Exists(path))
    {
      BinaryFormatter formatter = new BinaryFormatter();
      FileStream stream = new FileStream(path, FileMode.Open);
      PlayerData data = formatter.Deserialize(stream) as PlayerData;
      return data;
    }
    else
    {
      Debug.Log("Save file path not found "+ path);
      return null;
    }
  } 

  public static void SaveSetting(SettingData setting)
  {
    BinaryFormatter formatter = new BinaryFormatter();
    string path = Application.persistentDataPath + "/Settingdata.fun";
    FileStream stream = new FileStream(path, FileMode.Create);

    SettingData data = new SettingData(setting.music,setting.volume);

    formatter.Serialize(stream,data);

    stream.Close();

  }

  public static SettingData LoadSetting()
  {
    string path = Application.persistentDataPath + "/Settingdata.fun";
    if (File.Exists(path))
    {
      BinaryFormatter formatter = new BinaryFormatter();
      FileStream stream = new FileStream(path, FileMode.Open);
      SettingData data = formatter.Deserialize(stream) as SettingData;
      return data;
    }
    else
    {
      Debug.Log("Save file path not found "+ path);
      return null;
    }
  } 
}
