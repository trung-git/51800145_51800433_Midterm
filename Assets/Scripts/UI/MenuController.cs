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
  [SerializeField] private AudioSource backgroundAudio;
  private SettingData settingData;

  private GameObject sliderMusic;
  private GameObject sliderVolume;
  private void Awake() {
    Debug.Log("File data: \n"+Application.persistentDataPath);
    //Khi moi Awake thi load data Setting vao settingData
    if (File.Exists(Application.persistentDataPath + "/Settingdata.fun"))    
    {//Khi co du lieu settingData tu truoc thi load
      settingData = SaveSystem.LoadSetting();
    }
    else//Khong co settingData thi mac dinh sound la 75%
    {
      settingData = new SettingData(.75f,.75f);
    }
    //Cap nhap sound Background voi settingData
    backgroundAudio.volume = settingData.music;
  }
  public void PlayGame()
  {
    //Load Level1
    SceneManager.LoadScene("Level1");
    //Kiem tra neu co du lieu thi xoa
    if (File.Exists(Application.persistentDataPath + "/Playerdata.fun"))    
    {    
      // Xoa du lieu cu 
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
  }
  public void textUpdateVolume(float value)
  {
    TxtRangeVolume = GameObject.FindGameObjectWithTag("txtVolume").GetComponent<Text>();
    TxtRangeVolume.text = Mathf.RoundToInt(value * 100) + " %";
  }

  public void updateMusic(float value)
  {
    backgroundAudio.volume = value;
    settingData.music = value;
  }
  public void updateVolume(float value)
  {
    settingData.volume = value;
  }
  public void LoadDataSetting(){
    sliderMusic = GameObject.Find("SliderMusic");
    sliderMusic.GetComponent<Slider>().value = settingData.music;

    sliderVolume = GameObject.Find("SliderVolume");
    sliderVolume.GetComponent<Slider>().value = settingData.volume;
  }

  public void SaveDataSetting()
  {
    SaveSystem.SaveSetting(settingData);
  }

}
