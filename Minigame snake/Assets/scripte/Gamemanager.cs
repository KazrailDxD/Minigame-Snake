using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    [SerializeField] GameObject playerpref = null;
    [SerializeField] GameObject gameoverpanel = null;
    [SerializeField] GameObject menuoverpanel = null;
   
    bool ispaused;
    bool gameover;
    bool menu;

    // Update is called once per frame
    void Update()
    {
        if(playerpref == null && !gameover)
        {
           
            gameover = true;
            gameoverpanel.SetActive(true);            
            Time.timeScale = 0.0f;

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu = !menu;
            if (menu)
            {
                menuoverpanel.SetActive(true);
                Time.timeScale = 0.0f;
            }
            else
            {
                menuoverpanel.SetActive(false);
                Time.timeScale = 1.0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            ispaused = !ispaused;

            if (ispaused)
            {
                Time.timeScale = 0.0f;
            }
            else
            {
                Time.timeScale = 1.0f;
            }
        }
    }
}
