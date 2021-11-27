using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
public class LoadDataSceneEnd : MonoBehaviour
{
  [SerializeField] private Text txtHit;
  [SerializeField] private Text txtScore;
  [SerializeField] private Text txtScene;
  PlayerData data;
  private void Awake() {
    data = SaveSystem.LoadData();
    txtHit.text ="Hit: " + data.currentScene.hit.ToString();
    txtScore.text = "Score: " + data.currentScene.score.ToString();
    txtScene.text = "Level: " + data.currentScene.nameScene[5];
  }

  
  public void NextScene()
  {
    int level = data.currentScene.nameScene[5] - '0' + 1;
    if (level < 5)
      SceneManager.LoadScene("Level"+ level );
    else 
      SceneManager.LoadScene("Start");
  }

  public void ExitBtn()
  {
    SceneManager.LoadScene("Start");
  }
  public void ResetBtn()
  {
    SceneManager.LoadScene(data.currentScene.nameScene);
  }
}

