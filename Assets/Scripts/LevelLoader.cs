using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == ("Death"))
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
