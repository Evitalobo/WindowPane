using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private bool isPaused;
    [SerializeField] private GameObject PauseMenuUI;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
            activateMenu();
        else
            deactivateMenu();
    }

    void activateMenu()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true; ;
        
    }

    void deactivateMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        PauseMenuUI.SetActive(false);

    }
}
