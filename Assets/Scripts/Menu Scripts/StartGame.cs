using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : Item
{
    private void Start()
    {
        mClassManager = null;
    }

    public override void interact()
    {
        SceneManager.LoadScene("Kitchen", LoadSceneMode.Single);
    }

}
