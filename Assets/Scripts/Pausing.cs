using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausing : MonoBehaviour
{
    public GameObject menu;

    bool paused = false;
    public void Update()
    {
        if (!paused & Input.GetKeyDown("escape"))
        {
            Debug.Log("Paused");
            paused = true;
            Pausing();
        }
        else if (paused & Input.GetKeyDown("escape"))
        {
            Debug.Log("Paused");
            paused = false;
            Pausing();
        }

        void Pausing()
        {
            if (paused)
            {
                Time.timeScale = 0;
                menu.SetActive(true);
            }
            else if (!paused)
            {
                Time.timeScale = 1;
                menu.SetActive(false);
            }
        }
    }
}
