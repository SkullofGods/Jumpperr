using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public GameObject counters;
    public TextMeshProUGUI totalDeaths, thisRunDeaths;

    private int _lvlNum;
    void Start()
    {
        counters.SetActive(false);
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, PlayerPrefs.GetInt(SceneManager.GetActiveScene().name)+1);
        _lvlNum = Int32.Parse(SceneManager.GetActiveScene().name
            .Substring(SceneManager.GetActiveScene().name.Length - 1));
        var nameOfPrefs = "TotalDeathsLvl" + _lvlNum;
        
        totalDeaths.text = "Total Deaths this level: " + PlayerPrefs.GetInt(nameOfPrefs).ToString();
        thisRunDeaths.text = "Deaths this run: " + PlayerPrefs.GetInt("DeathCount").ToString();
        PlayerPrefs.SetInt("LastCheckpoint",0);
        PlayerPrefs.SetInt("DeathCount", 0);
    }

    public void StartAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void NextWorld()
    {
        var sceneName = "Level " + (_lvlNum+1).ToString();
        SceneManager.LoadScene(sceneName);
    }
    
}
