using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public GameObject[] Checkpoints;
    public GameObject onDeathScreen, player;
    public Projectile liver;
    private Vector3 offset = new Vector3(0, 2f, 0);
    
    public void LastCheckpoint()
    {
        player.transform.position = Checkpoints[PlayerPrefs.GetInt("LastCheckpoint")].transform.position+offset;
        onDeathScreen.SetActive(false);
        liver.Dead = false;
    }

    public void StartOver()
    {
        PlayerPrefs.SetInt("LastCheckpoint",0);
        PlayerPrefs.SetInt("DeathCount", 0);
        LastCheckpoint();
    }
}
