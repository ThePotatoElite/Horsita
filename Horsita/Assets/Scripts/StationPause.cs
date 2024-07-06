using System;
using UnityEngine;
using TMPro;

public class StationPause : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI stationTutorial;
    private GameObject stationUI;
    [SerializeField] SussitaManager sussitaManager;
    private bool isPaused = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Station"))
        {
            PauseGame();
        }
    }
    
    private void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0; // Pause
        stationUI.SetActive(true);
        stationTutorial.gameObject.SetActive(true);
        sussitaManager.enabled = false; // Disable the SussitaManager script to stop input
    }

    public void StartDrive() // OnClick() event to the StartDrive() in StationPause script
    {
        isPaused = false;
        Time.timeScale = 1; // Resume
        stationUI.SetActive(false);
        stationTutorial.gameObject.SetActive(false);
        sussitaManager.enabled = true; // Enable the SussitaManager script to stop input
    }
}