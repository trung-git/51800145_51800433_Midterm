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
  public int music {get; set;}
  public int volume {get; set;}
  public SettingData(int music, int volume)
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
