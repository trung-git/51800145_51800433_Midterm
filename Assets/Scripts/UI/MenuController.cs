using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Text TxtRangeMusic = null;
    [SerializeField] private Text TxtRangeVolume = null;
    //[SerializeField] private AudioSource backgroundAudio;
    private SettingData settingData;

    //[SerializeField]private Slider slider;
    private void Awake() {
      if (File.Exists(Application.persistentDataPath + "/Settingdata.fun"))    
      { 
        settingData = SaveSystem.LoadSetting();
        
      }
      else
      {
        settingData = new SettingData(128,128);
      }
    }
    // private void Start() {
    //   backgroundAudio.priority = settingData.music;
    //   slider.value = backgroundAudio.volume;
    // }
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
        if (File.Exists(Application.persistentDataPath + "/Playerdata.fun"))    
        {    
          // If file found, delete it    
          File.Delete(Application.persistentDataPath + "/Playerdata.fun");      
        }    
    }

    public void QuitGame()
    {
        Debug.Log("Exit!!");
        Application.Quit();
    }
    
    public void textUpdateMusic(float value)
    {
      TxtRangeMusic = GameObject.FindGameObjectWithTag("txtMusic").GetComponent<Text>();
      TxtRangeMusic.text = Mathf.RoundToInt(value * 100) + " %";
      //Doc flie 

      //Gan gia tri moi 

      //Save
    }
    public void textUpdateVolume(float value)
    {
      TxtRangeVolume = GameObject.FindGameObjectWithTag("txtVolume").GetComponent<Text>();
      TxtRangeVolume.text = Mathf.RoundToInt(value * 100) + " %";
    }

    // public void updateMusic(float value)
    // {
    //   Debug.Log((int)(value * 256));
    //   backgroundAudio.volume = value;
    // }
    

}
