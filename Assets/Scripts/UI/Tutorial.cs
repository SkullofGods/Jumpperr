using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject firstPanel, secondPanel, movement, showAgainButton;

    public void NextHint()
    {
        firstPanel.SetActive(false);
        secondPanel.SetActive(true);
    }

    public void PreviousHint()
    {
        firstPanel.SetActive(true);
        secondPanel.SetActive(false);
    }

    public void Close()
    {
        secondPanel.SetActive(false);
        movement.SetActive(true);
        showAgainButton.SetActive(true);
    }

    public void ShowTutorial()
    {
        movement.SetActive(false);
        firstPanel.SetActive(true);
        showAgainButton.SetActive(false);
    }
}
