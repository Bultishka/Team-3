using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSettingsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject ShowingPanelSettings;

    [SerializeField]
    private GameObject ShowingPanelPlatformInfo;

    public void RestartPushButtonReleased()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (Time.timeScale == 0.0f)
            Time.timeScale = 1.0f;
    }

    public void PausePushButtonReleased()
    {
        ShowingPanelSettings.SetActive(true);
        ShowingPanelSettings.GetComponentInParent<Canvas>().sortingOrder = 1;
        Time.timeScale = 0.0f; // Stop game time
    }

    public void ContinuePushButtonReleased()
    {
        ShowingPanelSettings.SetActive(false);
        ShowingPanelSettings.GetComponentInParent<Canvas>().sortingOrder = 0;
        if (Time.timeScale == 0.0f)
            Time.timeScale = 1.0f;
    }
}
