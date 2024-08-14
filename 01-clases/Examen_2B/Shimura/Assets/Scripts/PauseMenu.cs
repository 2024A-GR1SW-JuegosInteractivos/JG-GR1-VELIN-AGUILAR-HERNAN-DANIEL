using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject menu;
    public int numberScene = 0;

    void Start()
    {
        menu.SetActive(false);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(Time.timeScale == 1)
            {
                menu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                menu.SetActive(false);
                Time.timeScale = 1;
            }

        }
    }
    

    public void Continue()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void toPrincipalMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(numberScene);
        Time.timeScale = 1;
    }


}
