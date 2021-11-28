using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
  public static SoundManager instance {get; private set;}
  private AudioSource source;
  private AudioSource backgroundAudio;
  private SettingData settingData;
  private void Awake() {
    backgroundAudio = GameObject.Find("MusicBackground").GetComponent<AudioSource>();


    instance = this;
    source = GetComponent<AudioSource>();

    settingData = SaveSystem.LoadSetting();
    if (settingData != null)
    {
      source.volume = settingData.volume;
      backgroundAudio.volume = settingData.music;
    }

    if(instance == null)
    {
      instance = this;
      DontDestroyOnLoad(gameObject);
    }
    else if(instance != null && instance != this)
    {
      Destroy(gameObject);
    }
  }
  public void PlaySound(AudioClip sound)
  {
    source.PlayOneShot(sound);
  }
}
