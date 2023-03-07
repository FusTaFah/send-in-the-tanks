using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        Time.timeScale = PauseMenu.activeSelf ? 1.0f : 0.0f;
        PauseMenu.SetActive(!PauseMenu.activeSelf);
    }
}
