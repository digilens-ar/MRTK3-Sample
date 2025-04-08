using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacesSessionManager : MonoBehaviour
{
    /// <summary>
    /// On pause event, exit the application
    /// Prevents rendering issues and circumvents the Snapdragon Spaces blank screen issue
    /// </summary>
    /// <param name="pause"></param>
    void OnApplicationPause(bool pause)
    {
        if (pause)
            Application.Quit();
    }

    /// <summary>
    /// Returns to previous application on double click
    /// </summary>
    /// <param name="pause"></param>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
