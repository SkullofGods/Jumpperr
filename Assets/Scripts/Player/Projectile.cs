using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    UnityEvent _onDeath;
    UnityEvent _uraPobeda;
    
    public GameObject onDeathScreen, onWinScreen;
    
    public bool Dead = false;
    
    public DeathScreen startingPoint;

    public TextMeshProUGUI deathCounter, currentCheckpoint;
    
    private void Awake()
    {
        if (_onDeath == null)
        {
            _onDeath = new UnityEvent();
            _onDeath.AddListener(Death);
        }

        if (_uraPobeda == null)
        {
            _uraPobeda = new UnityEvent();
            _uraPobeda.AddListener(Finished);
        }
    }

    void Start()
    {
        startingPoint.LastCheckpoint();
        GetComponent<TrailRenderer>().sortingLayerName = "Foreground";
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Checkpoint") && !Dead)
        {
            PlayerPrefs.SetInt("LastCheckpoint", int.Parse(other.gameObject.name));
            currentCheckpoint.text = "Checkpoint: " + (PlayerPrefs.GetInt("LastCheckpoint")+1);
            deathCounter.text = "Deaths: " + PlayerPrefs.GetInt("DeathCount");
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            _onDeath.Invoke();
        }

        if (other.gameObject.CompareTag("Finish") && !Dead)
        {
            _uraPobeda.Invoke();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint") && !Dead)
        {
            PlayerPrefs.SetInt("LastCheckpoint", int.Parse(other.gameObject.name));
            currentCheckpoint.text = "Checkpoint: " + (PlayerPrefs.GetInt("LastCheckpoint")+1);
            deathCounter.text = "Deaths: " + PlayerPrefs.GetInt("DeathCount");
        }
    }
    
    private void Death()
    {
        onDeathScreen.SetActive(true);
        PlayerPrefs.SetInt("DeathCount", PlayerPrefs.GetInt("DeathCount")+1);
        var lvlNum = Int32.Parse(SceneManager.GetActiveScene().name
            .Substring(SceneManager.GetActiveScene().name.Length - 1));
        var nameOfPrefs = "TotalDeathsLvl" + lvlNum;
        PlayerPrefs.SetInt(nameOfPrefs, PlayerPrefs.GetInt(nameOfPrefs)+1);
        deathCounter.text = "Deaths: " + PlayerPrefs.GetInt("DeathCount");
        Dead = true;
    }
    
    private void Finished()
    {
        onWinScreen.SetActive(true);
        Dead = true;
    }
    
}
