using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject playPans, playPan, skinsPan, settingsPan;
    public Button skins, levels;
    
    
    public void Play()
    {
        playPans.SetActive(true);
    }

    public void Levels()
    {
        playPan.SetActive(true);
        skinsPan.SetActive(false);
        levels.interactable = false;
        skins.interactable = true;
    }

    public void Skins()
    {
        playPan.SetActive(false);
        skinsPan.SetActive(true);
        levels.interactable = true;
        skins.interactable = false;
    }
    
    public void LevelChoose()
    {
        SceneManager.LoadScene(EventSystem.current.currentSelectedGameObject.name);
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void ClosePan()
    {
        playPans.SetActive(false);
    }

    public void CloseSettings()
    {
        settingsPan.SetActive(false);
    }

    public void Settings()
    {
        settingsPan.SetActive(true);
    }
    
    public void Exit()
    {
        Application.Quit();
    }
}
