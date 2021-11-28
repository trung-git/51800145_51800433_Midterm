using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerForEndScene : MonoBehaviour
{
  private void Awake() {
    SettingData data = SaveSystem.LoadSetting();
    AudioSource audio = GetComponent<AudioSource>();
    if (data != null)
    {
      audio.volume = data.volume;
    }
  }
}
