using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]public class PlayerData
{
  public Scene currentScene {get; set;}
  public PlayerData(Scene scene)
  {
    this.currentScene = scene;
  }
}
[System.Serializable]public class SettingData
{
  public float music {get; set;}
  public float volume {get; set;}
  public SettingData(float music, float volume)
  {
    this.music = music;
    this.volume = volume;
  }
}


[System.Serializable]public class Scene
{
  public string nameScene {get; set;}
  public int hit {get; set;}
  public int score {get; set;}

  public Scene(string name, int hit, int score)
  {
    this.nameScene = name;
    this.hit = hit;
    this.score = score;
  }
}
