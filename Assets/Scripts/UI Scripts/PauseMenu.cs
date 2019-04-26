using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private bool isPaused;
    [SerializeField] private GameObject PauseMenuUI;
    private ClassManager mClassManager;

    private void Start()
    {
        mClassManager = GameObject.Find("ClassManager").GetComponent<ClassManager>();
    }

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
        mClassManager.pause();
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true; ;
        
    }

    void deactivateMenu()
    {
        mClassManager.unpause();
        Time.timeScale = 1;
        AudioListener.pause = false;
        PauseMenuUI.SetActive(false);

    }
}
