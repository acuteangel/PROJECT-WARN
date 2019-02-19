using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseListener : MonoBehaviour
{
    [HideInInspector] public bool isPaused = false;
    public GameObject pauseMenu;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause")) {
            if (!isPaused)
                Pause();
            else
                unPause();
        }
    }

    public void Pause()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
    }

    public void unPause()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
    }
}
