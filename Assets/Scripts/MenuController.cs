using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    [SerializeField] private Text TxtRangeMusic = null;
    [SerializeField] private Text TxtRangeVolume = null;
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void QuitGame()
    {
        Debug.Log("Exit!!");
        Application.Quit();
    }
    private void Start()
    {
        TxtRangeMusic = GameObject.FindGameObjectWithTag("txtMusic").GetComponent<Text>();
        TxtRangeVolume = GameObject.FindGameObjectWithTag("txtVolume").GetComponent<Text>();
    }
    public void textUpdateMusic(float value)
    {
        TxtRangeMusic.text = Mathf.RoundToInt(value * 100) + " %";
    }
    public void textUpdateVolume(float value)
    {
        TxtRangeVolume.text = Mathf.RoundToInt(value * 100) + " %";
    }


}
