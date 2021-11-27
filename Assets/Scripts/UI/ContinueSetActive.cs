using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ContinueSetActive : MonoBehaviour
{
  private PlayerData data;
    private void Awake() {
      data = SaveSystem.LoadData();
      if (data != null)
      {
        Debug.Log("Co data");
        GameObject.Find("Continue").SetActive(true);
      }
      else{
        Debug.Log("Ko data");
        GameObject.Find("Continue").SetActive(false);
      }
    }
    public void ContinueBtn()
    {
      int level = data.currentScene.nameScene[5] - '0' + 1;
      SceneManager.LoadScene("Level"+ level );
    
    }
}
