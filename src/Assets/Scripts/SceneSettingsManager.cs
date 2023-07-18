using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSettingsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject ShowingPanel;

    public void RestartPushButtonReleased()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (Time.timeScale == 0.0f)
            Time.timeScale = 1.0f;
    }

    public void PausePushButtonReleased()
    {
        // Showing Our Panel (maybe)
        Time.timeScale = 0.0f; // Stop game time
    }

    public void ContinuePushButtonReleased()
    {
        // Hiding Out Panel (maybe)
        if (Time.timeScale == 0.0f)
            Time.timeScale = 1.0f;
    }

    void Update()
    {
        
    }
}
